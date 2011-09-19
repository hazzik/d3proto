namespace d3emu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Descriptors;
    using bnet.protocol;
    using bnet.protocol.connection;

    public enum AuthError
    {
        None = 0,
        InvalidCredentials = 3,
        NoLicense = 12,
    }

    public class Client : IRpcChannel
    {
        private readonly Queue<Callback> callbacks = new Queue<Callback>();
        private readonly ICollection<IService> exportedServices = new List<IService>();
        private readonly IDictionary<uint, ExternalService> exportedServicesIds = new Dictionary<uint, ExternalService>();
        private readonly IDictionary<uint, IService> importedServices = new Dictionary<uint, IService>();
        private readonly Socket socket;

        public Client(Socket socket)
        {
            this.socket = socket;
            LoadExportedService(0, 0);
            LoadImportedService(0);
        }

        public ulong ListenerId { get; set; }
        
        public AuthError ErrorCode { get; set; }

        public void CallMethod(MethodDescriptor method, IRpcController controller, IMessage request, IMessage responsePrototype, Action<IMessage> done)
        {
            string name = method.Service.FullName;
            uint hash = GetServiceHash(name);
            ExternalService externalService = exportedServicesIds[hash];

            var requestId = externalService.GetNextRequestId();
            callbacks.Enqueue(new Callback { Action = done, Builder = responsePrototype.WeakToBuilder(), RequestId = requestId });

            ServerPacket data = new ServerPacket(externalService.Id, (int) GetMethodId(method), requestId, ListenerId).WriteMessage(request);
            Send(data);
        }

        //are we need to store external service?
        public T GetService<T>() where T : IService
        {
            return exportedServices
                .Where(service => typeof (T).IsAssignableFrom(service.GetType()))
                .Select(x => (T) x)
                .Single();
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    if (!socket.IsConnected())
                        break;

                    if (socket.Available > 0)
                    {
                        var buffer = new byte[socket.Available];

                        int len = socket.Receive(buffer);

                        if (len > 0)
                        {
                            Console.WriteLine("Received data: length = {0}", len);

                            var newBuf = new byte[len];
                            Array.Copy(buffer, newBuf, newBuf.Length);

                            newBuf.PrintHex();

                            CodedInputStream stream = CodedInputStream.CreateInstance(newBuf);

                            while (!stream.IsAtEnd)
                            {
                                Handle(stream);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Disconnected!");
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void Handle(CodedInputStream stream)
        {
            var packet = new ClientPacket(stream);

            if (packet.Service == Program.PrevService)
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
                        ServerPacket data = new ServerPacket(Program.PrevService, (int) ErrorCode, packet.RequestId, 0).WriteMessage(response);
                        Send(data);
                        if (ErrorCode != AuthError.None)
                        {
                            DisconnectNotification dcNotify = DisconnectNotification.CreateBuilder().SetErrorCode((uint) ErrorCode).Build();
                            GetService<ConnectionService>().ForceDisconnect(null, dcNotify, r => { });
                        }
                    };

            IMessage requestProto = service.GetRequestPrototype(method);

            try
            {
                IMessage message = packet.ReadMessage(requestProto.WeakToBuilder());
                // Logging
                Console.WriteLine(requestProto.GetType());
                Console.WriteLine("Text View:");
                Console.WriteLine(message.ToString());

                service.CallMethod(method, null, message, done);
            }
            catch (UninitializedMessageException exc)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception in message: {0}", requestProto.DescriptorForType.FullName);
                Console.WriteLine(exc.Message);
                Console.ResetColor();
            }
        }

        public void LoadExportedService(uint hash, uint id)
        {
            exportedServices.Add(ClientServices.ServicesDict[hash](this)); // WTF?
            exportedServicesIds[hash] = new ExternalService
                                            {
                                                Hash = hash,
                                                Id = (byte) id,
                                            };
        }

        public uint LoadImportedService(uint hash)
        {
            var i = (uint) importedServices.Count;
            importedServices[i] = Services.ServicesDict[hash](this);
            return i;
        }

        private void Send(ServerPacket packet)
        {
            byte[] data = packet.Data;
            IMessage msg = packet.Message;

            // Logging
            Console.WriteLine("Sending data: length = {0}", data.Length);
            Console.WriteLine(msg.DescriptorForType.FullName);

            Console.WriteLine("HEX View:");
            data.PrintHex();

            Console.WriteLine("Text View:");
            Console.WriteLine(msg.ToString());

            socket.Send(data);
        }

        private static uint GetMethodId(MethodDescriptor method)
        {
            return (uint) method.Options[Rpc.MethodId.Descriptor];
        }

        /// <summary>
        /// FNV hash implementation
        /// </summary>
        /// <param name="name">Service name</param>
        /// <returns>Service hash</returns>
        private static uint GetServiceHash(string name)
        {
            if (name == "bnet.protocol.connection.ConnectionService")
                return 0;
            return Encoding.ASCII.GetBytes(name)
                .Aggregate(0x811C9DC5, (current, t) => 0x1000193*(t ^ current));
        }

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