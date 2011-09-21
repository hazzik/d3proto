using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace d3emu
{
    class BnetServer
    {
        private Socket m_socket;
        private List<BnetClient> Clients = new List<BnetClient>();

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

            Socket clientSocket = m_socket.EndAccept(result);

            BnetClient client = new BnetClient(clientSocket);

            Clients.Add(client);

            new Thread(() => client.Run()).Start();

            BeginAccept();
        }

        public void Shutdown()
        {
            foreach (var client in Clients)
            {
                client.Disconnect();
            }
        }
    }
}
