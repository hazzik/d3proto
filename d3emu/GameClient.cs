using System;
using System.Net.Sockets;
using Google.ProtocolBuffers;

namespace d3emu
{
    class GameClient
    {
        private bool first = true;
        private readonly NetworkStream stream;

        public GameClient(NetworkStream stream)
        {
            this.stream = stream;
        }

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

        private void Handle(CodedInputStream stream)
        {
            if (first)
            {
                first = false;
                new HardcodedGsPackets(this.stream);
            }

            var size = (int)stream.ReadInt32Reversed(); // includes size of size

            var payLoad = stream.ReadRawBytes(size - 4);
            payLoad.PrintHex();

            var opcode = payLoad[0]; // assume that opcode is 1 byte for now

            Console.WriteLine("GS: Opcode {0:X2}, size {1}", opcode, size);
        }
    }
}
