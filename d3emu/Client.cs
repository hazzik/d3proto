namespace d3emu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using bnet.protocol.connection;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Descriptors;

    public enum AuthError
    {
        None = 0,
        InvalidCredentials = 3,
        NoLicense = 12,
    }

    public class Client : IRpcChannel
    {
        private readonly IDictionary<uint, IService> exportedServices = new Dictionary<uint, IService>();
        private readonly IDictionary<uint, IService> importedServices = new Dictionary<uint, IService>();
        private readonly Socket socket;

        public ulong ListenerId { get; set; }

        public T GetService<T>() where T : IService
        {
            return exportedServices
                .Where(service => typeof(T).IsAssignableFrom(service.Value.GetType()))
                .Select(x => (T)x.Value)
                .Single();
        }

        public Client(Socket socket)
        {
            this.socket = socket;
            LoadExportedService(0, 0);
            LoadImportedService(0);
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

                            var stream = CodedInputStream.CreateInstance(newBuf);

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
                var callback = callbacks.Dequeue();
                callback.Action(packet.ReadMessage(callback.Builder));
                return;
            }

            IService service = importedServices[packet.Service];

            MethodDescriptor method = service.DescriptorForType.Methods.Single(m => GetMethodId(m) == packet.Method);

            Action<IMessage> done =
                response =>
                {
                    var data = new ServerPacket(Program.PrevService, (int)ErrorCode, packet.RequestId, 0).WriteMessage(response);
                    Send(data);
                    if (ErrorCode != AuthError.None)
                    {
                        var dcNotify = DisconnectNotification.CreateBuilder().SetErrorCode((uint)ErrorCode).Build();
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
            exportedServices[id] = ClientServices.ServicesDict[hash](this);
            exportedServicesIds[hash] = (byte)id;
        }

        private readonly IDictionary<uint, byte> exportedServicesIds = new Dictionary<uint, byte>();

        public uint LoadImportedService(uint hash)
        {
            var i = (uint)importedServices.Count;
            importedServices[i] = Services.ServicesDict[hash](this);
            return i;
        }

        private void Send(ServerPacket packet)
        {
            var data = packet.Data;
            var msg = packet.Message;

            // Logging
            Console.WriteLine("Sending data: length = {0}", data.Length);
            Console.WriteLine(msg.DescriptorForType.FullName);

            Console.WriteLine("HEX View:");
            data.PrintHex();

            Console.WriteLine("Text View:");
            Console.WriteLine(msg.ToString());

            socket.Send(data);
        }

        private readonly Queue<Callback> callbacks = new Queue<Callback>();

        // need better solution for request counter...
        private short reqCounter = 0;

        public void CallMethod(MethodDescriptor method, IRpcController controller, IMessage request, IMessage responsePrototype, Action<IMessage> done)
        {
            var name = method.Service.FullName;
            var hash = GetServiceHash(name);
            var sId = exportedServicesIds[hash];
            callbacks.Enqueue(new Callback { Action = done, Builder = responsePrototype.WeakToBuilder() });

            //TODO: make sure that callback executes for right request_id
            var data = new ServerPacket(sId, GetMethodId(method), reqCounter, ListenerId).WriteMessage(request);
            reqCounter++;
            Send(data);
        }

        private static int GetMethodId(MethodDescriptor method)
        {
            return (int)(uint)method.Options[bnet.protocol.Rpc.MethodId.Descriptor];
        }

        public AuthError ErrorCode { get; set; }

        private class Callback
        {
            public Action<IMessage> Action { get; set; }

            public IBuilder Builder { get; set; }
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
                .Aggregate(0x811C9DC5, (current, t) => 0x1000193 * (t ^ current));
        }
    }
}
