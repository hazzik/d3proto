using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace d3emu
{
    class GameServer
    {
        private bool first = true;
        private Socket m_gameSocket;
        private NetworkStream m_gameStream;
        private byte[] m_buffer = new byte[2048];

        public GameServer()
        {
            m_gameSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            m_gameSocket.Bind(new IPEndPoint(IPAddress.Any, 6665));

            m_gameSocket.Listen(10);

            BeginAccept();
        }

        private void BeginAccept()
        {
            Console.WriteLine("GS: Waiting for connections...");
            m_gameSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void BeginRead()
        {
            m_gameStream.BeginRead(m_buffer, 0, m_buffer.Length, new AsyncCallback(ReadCallback), null);
        }

        private void ReadCallback(IAsyncResult result)
        {
            int received = 0;

            try
            {
                received = m_gameStream.EndRead(result);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return;
            }

            if (received > 0)
            {
                byte[] data = new byte[received];
                Array.Copy(m_buffer, data, received);

                Console.WriteLine("GS: Received packet, len = {0}", received);
                data.PrintHex();

                if (first) // send hardcoded packets after first client packet
                {
                    first = false;
                    new HardcodedGsPackets(m_gameStream);
                }

                using (BinaryReader br = new BinaryReader(new MemoryStream(data)))
                {
                    var size = br.ReadInt32Reversed(); // includes size of this field as well

                    var opcode = br.ReadUInt16(); // ?

                    Console.WriteLine("GS: Opcode {0:X4}, size {1}", opcode, size);

                    //if (opcode == 0x783C) // movement
                    //{
                    //    // can't seems figure this out yet

                    //    var x1 = br.ReadByte();
                    //    var y1 = br.ReadByte();
                    //    var z1 = br.ReadByte();

                    //    var x2 = br.ReadSingle();
                    //    var y2 = br.ReadSingle();
                    //    var z2 = br.ReadSingle();

                    //    var x3 = br.ReadByte();
                    //    var y3 = br.ReadByte();
                    //    var z3 = br.ReadByte();

                    //    var x4 = br.ReadSingle();
                    //    var y4 = br.ReadSingle();

                    //    Console.WriteLine("Move: {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4);
                    //}
                }

                BeginRead();
            }
            else
            {
                Console.WriteLine("GS: Disconnected!");
            }
        }

        private void AcceptCallback(IAsyncResult result)
        {
            Socket client = m_gameSocket.EndAccept(result);

            m_gameStream = new NetworkStream(client);

            Console.WriteLine("GS: Client connected...");

            BeginRead();
        }
    }
}
