using System;
using System.Net;
using System.Net.Sockets;

namespace d3emu
{
    using System.Threading;

    class BnetServer
    {
        private Socket m_socket;

        public BnetServer(int port)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            m_socket.Bind(new IPEndPoint(IPAddress.Any, port));

            m_socket.Listen(10);

            BeginAccept();
        }

        private void BeginAccept()
        {
            Console.WriteLine("BN: Waiting for connections...");
            m_socket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void AcceptCallback(IAsyncResult result)
        {
            Console.WriteLine("BN: Client connected...");

            Socket client = m_socket.EndAccept(result);

            NetworkStream stream = new NetworkStream(client);

            new Thread(() => new BnetClient(stream).Run()).Start();
        }
    }
}
