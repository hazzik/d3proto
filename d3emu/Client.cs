namespace d3emu
{
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Descriptors;

    public class Client
    {
        public readonly IDictionary<uint, IService> exportedServices = new Dictionary<uint, IService>();
        public readonly IDictionary<uint, IService> importedServices = new Dictionary<uint, IService>();
        private readonly Socket socket;

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

                            Program.PrintHex(newBuf);
                            Handle(newBuf);
                        }
                        else
                        {
                            Console.WriteLine("Disconnected!");
                            break;
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void Handle(byte[] newBuf)
        {
            var packet = new ClientPacket(newBuf);

            IService service = importedServices[packet.Service];
            importedServices[254] = service;

            if (packet.Method == 0)
            {
                Console.WriteLine("NoData?");
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
            var i = (uint)(importedServices.Count);
            importedServices[i] = Services.ServicesDict[hash](this);
            return i;
        }

        public  void Send(byte[] data)
        {
            Console.WriteLine("Sending data: length = {0}", data.Length);

            Program.PrintHex(data);

            socket.Send(data);
        }
    }
}