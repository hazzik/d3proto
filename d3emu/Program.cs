using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using bnet.protocol.exchange;

namespace d3emu
{
    class Program
    {
        private static Socket m_socket;

        public const byte PrevService = 0xFE;

        /// <summary>
        /// FNV hash implementation
        /// </summary>
        /// <param name="name">Service name</param>
        /// <returns>Service hash</returns>
        public static uint GetServiceHash(string name)
        {
            return Encoding.ASCII.GetBytes(name)
                .Aggregate(0x811C9DC5, (current, t) => 0x1000193*(t ^ current));
        }

        static void Main(string[] args)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            m_socket.Bind(new IPEndPoint(IPAddress.Any, 6666));

            m_socket.Listen(10);

            while (true)
            {  
                Console.WriteLine("Accept");
                new Client(m_socket.Accept()).Run();
            }
        }

        public static void PrintHex(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 0 && (i % 16) == 0)
                    Console.WriteLine();

                Console.Write("{0:X2} ", data[i]);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
