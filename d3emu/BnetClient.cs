namespace d3emu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using bnet.protocol;
    using bnet.protocol.connection;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Descriptors;

    public enum AuthError
    {
        None = 0,
        InvalidCredentials = 3,
        NoToonSelected = 11,
        NoGameAccount = 12,
    }

    public class BnetClient : IRpcChannel
    {
        public const byte PrevService = 0xFE;

        private readonly Queue<Callback> callbacks = new Queue<Callback>();
        private readonly IDictionary<uint, ExternalService> exportedServicesIds = new Dictionary<uint, ExternalService>();
        private readonly IDictionary<uint, IService> importedServices = new Dictionary<uint, IService>();

        private readonly Socket socket;
        private readonly NetworkStream stream;

        public BnetClient(Socket socket)
        {
            this.socket = socket;
            this.stream = new NetworkStream(socket);

            LoadExportedService(0, 0);
            LoadImportedService(0);
        }

        public ulong ListenerId { get; set; }

        public AuthError ErrorCode { get; set; }

        public void CallMethod(MethodDescriptor method, IRpcController controller, IMessage request, IMessage responsePrototype, Action<IMessage> done)
        {
            uint hash = method.Service.GetHash();
            ExternalService externalService = exportedServicesIds[hash];

            var requestId = externalService.GetNextRequestId();
            callbacks.Enqueue(new Callback { Action = done, Builder = responsePrototype.WeakToBuilder(), RequestId = requestId });

            ServerPacket data = new ServerPacket(externalService.Id, (int)GetMethodId(method), requestId, ListenerId).WriteMessage(request);
            Send(data);
        }

        public void LoadExportedService(uint hash, uint id)
        {
            exportedServicesIds[hash] = new ExternalService
                                            {
                                                Hash = hash,
                                                Id = (byte)id,
                                            };
        }

        public uint LoadImportedService(uint hash)
        {
            var i = (uint)importedServices.Count;
            importedServices[i] = Services.ServicesDict[hash](this);
            return i;
        }

        private static uint GetMethodId(MethodDescriptor method)
        {
            return (uint)method.Options[Rpc.MethodId.Descriptor];
        }

        #region Network
        public void Run()
        {
            try
            {
                CodedInputStream stream = CodedInputStream.CreateInstance(this.stream);

                while (!stream.IsAtEnd)
                {
                    Handle(stream);
                }
                Console.WriteLine("BN: Disconnected!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Disconnect()
        {
            socket.Disconnect(false);
        }

        private void Handle(CodedInputStream stream)
        {
            var packet = new ClientPacket(stream);

            if (packet.Service == PrevService)
            {
                //packet.Method should be 0, if there is no errors
                Callback callback = callbacks.Dequeue();
                if (callback.RequestId != packet.RequestId)
                    throw new InvalidOperationException("Callback does not match!");
                callback.Action(packet.ReadMessage(callback.Builder));
                return;
            }

            IService service = importedServices[packet.Service];

            MethodDescriptor method = service.DescriptorForType.Methods.Single(m => GetMethodId(m) == packet.Method);

            Action<IMessage> done =
                response =>
                {
                    ServerPacket data = new ServerPacket(PrevService, (int)ErrorCode, packet.RequestId, 0).WriteMessage(response);
                    Send(data);
                    if (ErrorCode != AuthError.None)
                    {
                        DisconnectNotification dcNotify = DisconnectNotification.CreateBuilder().SetErrorCode((uint)ErrorCode).Build();
                        ConnectionService.CreateStub(this).ForceDisconnect(null, dcNotify, r => { });
                        Disconnect();
                    }
                };

            IMessage requestProto = service.GetRequestPrototype(method);

            IMessage message = packet.ReadMessage(requestProto.WeakToBuilder());

            // Logging
            Console.WriteLine(requestProto.GetType());
            Console.WriteLine("Text View:");
            Console.WriteLine(message.ToString());

            service.CallMethod(method, null, message, done);
        }

        private void Send(ServerPacket packet)
        {
            byte[] data = packet.Data;
            IMessage msg = packet.Message;

            // Logging
            Console.WriteLine("BN: Sending data: length = {0}", data.Length);
            Console.WriteLine(msg.DescriptorForType.FullName);

            Console.WriteLine("HEX View:");
            data.PrintHex();

            Console.WriteLine("Text View:");
            Console.WriteLine(msg.ToString());

            this.stream.Write(data, 0, data.Length);
        }
        #endregion

        private class Callback
        {
            public Action<IMessage> Action { get; set; }

            public IBuilder Builder { get; set; }

            public short RequestId { get; set; }
        }

        private class ExternalService
        {
            private short requestCounter;
            public byte Id { get; set; }
            public uint Hash { get; set; }

            public short GetNextRequestId()
            {
                return requestCounter++;
            }
        }
    }
}
