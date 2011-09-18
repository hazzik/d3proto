namespace d3emu
{
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using bnet.protocol.authentication;
    using ServicesImpl;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Descriptors;

    public class Client
        : IRpcChannel
    {
        public readonly IDictionary<uint, IService> exportedServices = new Dictionary<uint, IService>();
        public readonly IDictionary<uint, IService> importedServices = new Dictionary<uint, IService>();
        private readonly Socket socket;

        public byte GetServiceIdFor<T>() where T : IService
        {
            foreach (var service in exportedServices)
                if (service.Value.GetType() == typeof (T))
                    return (byte) service.Key;

            return 0xFF;
        }

        public Client(Socket socket)
        {
            this.socket = socket;
            LoadImportedService(0);
        }

        public void Run()
        {
            while (true)
            {
                try
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
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void Handle(CodedInputStream stream)
        {
            var packet = new ClientPacket(stream);

            if (packet.Service == Program.PrevService)
            {
                var callback = callbacks.Dequeue();
                callback.Action(packet.ReadMessage(callback.ResponceProto.WeakToBuilder()));
                return;
            }

            IService service = importedServices[packet.Service];

            // hack
            if (packet.Method == 0)
            {
                if (importedServices[packet.Service].GetType() == typeof (AuthenticationClientImpl))
                {
                    var modResp = packet.ReadMessage(ModuleLoadResponse.CreateBuilder());
                    Console.WriteLine(modResp.ToString());
                }
                return;
            }

            MethodDescriptor method = service.DescriptorForType.Methods[packet.Method - 1];

            Action<IMessage> done =
                response =>
                    {
                        byte[] data = new ServerPacket(Program.PrevService, 0, packet.RequestId, 0).WriteMessage(response);

                        Send(data);
                    };

            IMessage requestProto = service.GetRequestPrototype(method);

            Console.WriteLine(requestProto.GetType());

            IMessage message = packet.ReadMessage(requestProto.WeakToBuilder());

            service.CallMethod(method, null, message, done);
        }

        public void LoadExportedService(uint hash, uint key)
        {
            exportedServices[key] = Services.ServicesDict[hash](this);
        }

        public uint LoadImportedService(uint hash)
        {
            var i = (uint) importedServices.Count;
            importedServices[i] = Services.ServicesDict[hash](this);
            return i;
        }

        private void Send(byte[] data)
        {
            Console.WriteLine("Sending data: length = {0}", data.Length);

            data.PrintHex();

            socket.Send(data);
        }

        private readonly Queue<Callback> callbacks = new Queue<Callback>();

        private class Callback
        {
            public Action<IMessage> Action { get; set; }
            public IMessage ResponceProto { get; set; }
        }

        public void CallMethod(MethodDescriptor method, IRpcController controller, IMessage request, IMessage responsePrototype, Action<IMessage> done)
        {
            var sId = GetServiceIdFor<AuthenticationClient.Stub>();

            var data = new ServerPacket(sId, 1, 0, 0).WriteMessage(responsePrototype);
            callbacks.Enqueue(new Callback {Action = done, ResponceProto = responsePrototype});
            Send(data);
        }
    }
}
