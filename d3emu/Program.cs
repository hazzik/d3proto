using System;
using System.Net;
using System.Net.Sockets;

namespace d3emu
{
    using System.Threading;

    static class Program
    {
        private static Socket m_socket;

        public const byte PrevService = 0xFE;

        static void Main(string[] args)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            m_socket.Bind(new IPEndPoint(IPAddress.Any, 6666));

            m_socket.Listen(10);

            while (true)
            {
                Console.WriteLine("Waiting for connections...");
                var client = m_socket.Accept();
                new Thread(() => new Client(client).Run()).Start();
            }
        }
    }
}
