namespace d3emu
{
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Descriptors;

    public class Client
    {
        private readonly IDictionary<uint, IService> loadedServices = new Dictionary<uint, IService>();
        private readonly Socket socket;

        public Client(Socket socket)
        {
            this.socket = socket;
            LoadService(0, 0);
        }

        public Socket Socket
        {
            get { return socket; }
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

            IService service = loadedServices[packet.Service];
            Console.WriteLine(service.GetType());
            MethodDescriptor method = service.DescriptorForType.Methods[packet.Method - 1];
            Console.WriteLine(method.Name);
            if(method.Name == "ModuleLoad") // WTF!?
            {
                service = loadedServices[0];
                method = service.DescriptorForType.Methods[5];
            }
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

        public void LoadService(uint hash, uint key)
        {
            loadedServices[key] = Services.ServicesDict[hash](this);
        }

        public  void Send(byte[] data)
        {
            Console.WriteLine("Sending data: length = {0}", data.Length);

            Program.PrintHex(data);

            socket.Send(data);
        }
    }
}