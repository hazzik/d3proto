using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using bnet.protocol;
using bnet.protocol.authentication;
using bnet.protocol.connection;

namespace d3emu
{
    class Program
    {
        private static Socket m_socket;

        static void Main(string[] args)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            m_socket.Bind(new IPEndPoint(IPAddress.Loopback, 6666));

            m_socket.Listen(10);

            Accept();
        }

        static void Accept()
        {
            Console.WriteLine("Accept");

            var s = m_socket.Accept();

            var buffer = new byte[1024];

            while (true)
            {
                var len = s.Receive(buffer);

                if (len > 0)
                {
                    Console.WriteLine("Received data: length = {0}", len);

                    var newBuf = new byte[len];
                    Array.Copy(buffer, newBuf, newBuf.Length);

                    PrintHex(newBuf);

                    Handle(s, newBuf);
                }
            }
        }

        static void PrintHex(byte[] data)
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

        static void Send(Socket s, byte[] data)
        {
            Console.WriteLine("Sending data: length = {0}", data.Length);

            PrintHex(data);

            s.Send(data);
        }

        // first 6 bytes of the packet _probably_ bitstream protocol similar to wow/sc2?
        static void Handle(Socket s, byte[] buf)
        {
            if (buf[0] == 0x00 && buf[1] == 0x01)
            {
                HandleConnectRequest(s, buf);
            }
            else if (buf[1] == 0x02)
            {
                if (buf[2] == 0x01 || buf[2] == 0x02)
                {
                    HandleBindRequest(s, buf);
                }
            }
            else if (buf[1] == 0x01)
            {
                HandleLogonRequest(s, buf);
            }
            else
            {
                Console.WriteLine("Unknown crap");
                s.Disconnect(false);
                Accept();
            }
        }

        private static void HandleConnectRequest(Socket s, byte[] buf)
        {
            var newRequest = ConnectRequest.CreateBuilder();
            newRequest.MergeFrom(buf.Skip(6).ToArray());

            var request = newRequest.Build();

            Console.WriteLine(request.ToString());

            var response = ConnectResponse.CreateBuilder()
                .SetServerId(ProcessId.CreateBuilder().SetLabel(0xDEADBABE).SetEpoch(DateTime.Now.ToUnixTime()))
                .SetClientId(ProcessId.CreateBuilder().SetLabel(0xDEADBEEF).SetEpoch(DateTime.Now.ToUnixTime())).Build();

            Console.WriteLine(response.ToString());

            var header = new byte[] { 0xfe, 0x00, 0x00, 0x00, (byte)response.SerializedSize };

            Send(s, header.Append(response.ToByteArray()));
        }

        private static void HandleLogonRequest(Socket s, byte[] buf)
        {
            var newRequest = LogonRequest.CreateBuilder();
            newRequest.MergeFrom(buf.Skip(6).ToArray());

            var request = newRequest.Build();

            Console.WriteLine(request.ToString());

            var response = LogonResponse.CreateBuilder()
                .SetAccount(EntityId.CreateBuilder().SetHigh(12345).SetLow(67890))
                .SetGameAccount(EntityId.CreateBuilder().SetHigh(67890).SetLow(12345)).Build();

            Console.WriteLine(response.ToString());

            var header = new byte[] { 0x03, 0x01, 0x00, 0x00, 0x00, (byte)response.SerializedSize };

            Send(s, header.Append(response.ToByteArray()));
        }

        private static void HandleBindRequest(Socket s, byte[] buf)
        {
            var newRequest = BindRequest.CreateBuilder();
            newRequest.MergeFrom(buf.Skip(6).ToArray());

            var request = newRequest.Build();

            Console.WriteLine(request.ToString());

            var newResponse = BindResponse.CreateBuilder();
            foreach (var e in request.ExportedServiceList)
                newResponse.AddImportedServiceId(e.Id);

            var response = newResponse.Build();

            Console.WriteLine(response.ToString());

            var header = new byte[] { 0xfe, 0x00, buf[2], 0x00, (byte)response.SerializedSize };

            Send(s, header.Append(response.ToByteArray()));
        }
    }

    public static class Extenstions
    {
        public static uint ToUnixTime(this DateTime time)
        {
            return (uint)((time.ToUniversalTime().Ticks - 621355968000000000L) / 10000000L);
        }

        public static byte[] Append(this byte[] a, byte[] b)
        {
            var result = new byte[a.Length + b.Length];

            a.CopyTo(result, 0);
            b.CopyTo(result, a.Length);

            return result;
        }
    }
}
