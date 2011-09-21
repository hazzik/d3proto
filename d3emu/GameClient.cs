using System;
using System.Net.Sockets;
using Google.ProtocolBuffers;

namespace d3emu
{
    class GameClient
    {
        private bool first = true;
        private readonly Socket socket;
        private readonly NetworkStream stream;

        public GameClient(Socket socket)
        {
            this.socket = socket;
            this.stream = new NetworkStream(socket);
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
                Console.WriteLine("GS: Disconnected!");
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
            if (first)
            {
                first = false;
                new HardcodedGsPackets(this.stream);
            }

            var size = stream.ReadInt32Reversed(); // includes size of size

            var payLoad = stream.ReadRawBytes(size - 4);
            payLoad.PrintHex();

            var opcode = payLoad[0]; // assume that opcode is 1 byte for now

            Console.WriteLine("GS: Opcode {0:X2}, payload size {1}", opcode, size - 4);
        }
        #endregion
    }
}
