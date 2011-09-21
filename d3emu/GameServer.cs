﻿using System;
using System.Net;
using System.Net.Sockets;

namespace d3emu
{
    using System.Threading;

    class GameServer
    {
        private Socket m_socket;

        public GameServer(int port)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            m_socket.Bind(new IPEndPoint(IPAddress.Any, port));

            m_socket.Listen(10);

            BeginAccept();
        }

        private void BeginAccept()
        {
            Console.WriteLine("GS: Waiting for connections...");
            m_socket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void AcceptCallback(IAsyncResult result)
        {
            Console.WriteLine("GS: Client connected...");

            Socket client = m_socket.EndAccept(result);

            NetworkStream stream = new NetworkStream(client);

            new Thread(() => new GameClient(stream).Run()).Start();
        }
    }
}
