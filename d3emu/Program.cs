﻿using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using bnet.protocol;
using bnet.protocol.authentication;
using bnet.protocol.connection;
//using BattleNet.Server;

namespace d3emu
{
    class Program
    {
        private static Socket m_socket;
        //private static int _previousChannel;

        static void Main(string[] args)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            m_socket.Bind(new IPEndPoint(IPAddress.Loopback, 6666));

            m_socket.Listen(10);

            Accept();
        }

        static void Accept()
        {
            //_previousChannel = 0;

            Console.WriteLine("Accept");

            var s = m_socket.Accept();

            var buffer = new byte[1024];

            while (true)
            {
                try
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
                catch
                {
                    break;
                }
            }

            Accept();
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
            //var reader = new BitReader(buf.Take(5).ToArray());

            //while (reader.ReadPos < reader.NumBits)
            //{
            //    int packetId = reader.ReadInt32(6);
            //    bool hasChannel = reader.ReadBoolean();

            //    int channelId;

            //    if (hasChannel) // If we have a channel specified
            //        channelId = _previousChannel = reader.ReadInt32(4);
            //    else
            //        channelId = _previousChannel;

            //    switch (channelId)
            //    {
            //        case 0: // App
            //            Console.WriteLine("PacketID: {0} hasChannel: {1} ChannelID: {2} App", packetId, hasChannel, channelId);
            //            // handle data
            //            if (packetId == 1)
            //            {
            //                var unk1 = reader.ReadInt32();
            //                //HandleConnectRequest(s, buf);
            //            }
            //            if (packetId == 2)
            //            {
            //                var index = reader.ReadByte();
            //                var unk1 = reader.ReadByte(); // 0
            //                var unk2 = reader.ReadByte(); // 0
            //                //HandleBindRequest(s, buf);
            //            }
            //            if (packetId == 31)
            //            {
            //                var unk1 = reader.ReadInt32();
            //                //HandleLogonRequest(s, buf);
            //            }
            //            break;
            //        case 1: // Crep
            //            Console.WriteLine("PacketID: {0} hasChannel: {1} ChannelID: {2} Crep", packetId, hasChannel, channelId);
            //            // handle data
            //            break;
            //        case 2: // Wow
            //            Console.WriteLine("PacketID: {0} hasChannel: {1} ChannelID: {2} Wow", packetId, hasChannel, channelId);
            //            // handle data
            //            break;
            //        case 3: // sc2?
            //        case 4: // d3?
            //        default:
            //            Console.WriteLine("Unknown channel: PacketID: {0} hasChannel: {1} ChannelID: {2}", packetId, hasChannel, channelId);
            //            break;
            //    }
            //}

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
                // may be EncryptRequest
                HandleEncryptRequest(s, buf);
                Console.WriteLine("Unknown crap");
            }
        }

        private static void HandleConnectRequest(Socket s, byte[] buf)
        {
            var newRequest = ConnectRequest.CreateBuilder();
            newRequest.MergeFrom(buf.Skip(6).ToArray());

            var request = newRequest.Build();

            Console.WriteLine(request.ToString()); // empty

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

            //var response = LogonResponse.CreateBuilder()
            //    .SetAccount(EntityId.CreateBuilder().SetHigh(12345).SetLow(67890))
            //    .SetGameAccount(EntityId.CreateBuilder().SetHigh(67890).SetLow(12345)).Build();

            // tell client to load authentication module (similar to wow/sc2)
            var hexModule = "03 01 00 00 02 F2 02 0A 2C 0D 53 55 00 00 15 68 74 75 61 1A 20 8F 52 90 6A 2C 85 B4 16 A5 95 70 22 51 57 0F 96 D3 52 2F 39 23 76 03 11 5F 2F 1A B2 49 62 04 3C 12 C1 02 00 C0 9E 5B DF F5 92 DD C3 8E DC 46 AE B1 57 65 68 D0 7A 94 17 D5 9C F0 70 8F 00 39 7D A2 3B 5B 23 32 8C 88 CA 5B 89 72 22 DA 43 3A 32 D2 8D 71 0C 5C EF 2A 14 46 C3 4C 10 F3 36 EC 1B 53 A8 95 ED E9 EB 82 0C C7 94 72 2E 4D F3 F4 17 33 63 46 2A 96 73 59 B5 70 19 A3 14 32 D7 6D F5 33 2A 77 90 C3 3B CD 19 65 FE 13 1E 4C F2 07 9F D8 74 9A 57 BD 22 F6 1C DF 18 1E F5 1B 15 23 25 F7 50 DD 8D AA 4D E0 9B 34 83 BE 78 C1 45 66 8D 2C B3 34 39 29 CD 88 D1 82 15 13 CE 8C D4 61 71 0C DC 5D 6B 73 E2 1C 96 F5 F5 39 3F 23 75 96 A9 70 5A C0 C7 01 3B BE 0E 71 86 FE 8B F0 F1 24 66 0A E1 89 86 38 DA B1 EA 5E D4 03 EC F8 F2 26 6D AE 2A A0 74 40 60 32 9F 9E 54 1A 39 8C 3D 6B 8E E3 75 09 CC 46 F9 D0 97 74 F1 6C 70 EF F9 D3 78 91 BD 66 6F A8 0A 39 D1 14 79 43 63 60 99 E5 11 E6 34 11 58 83 89 F6 89 E0 40 C4 2E F9 31 AC E9 7F F6 01 11 05 92 D1 3C 7F F9 20 DE EF 5A F0 37 A4 96 47 E8 92 DD 28 D0 D4 91 9F E3 4B 90 99 DD A8 6B 2D BA 1A 9B 57 FE 42 EE 19 F3 6F 38 0D A2 04 80 9F 66";

            var hexBytes = hexModule.ToByteArray().Skip(7).ToArray();

            // response.ModuleHandle.Region: US
            // response.ModuleHandle.Usage: auth
            // response.ModuleHandle.Hash: ... (SHA256 of module file)
            // response.message: ... (SRP parameters?)
            var response = ModuleLoadRequest.CreateBuilder().MergeFrom(hexBytes).Build();

            Console.WriteLine(response.ToString());

            var header = new byte[] { 0x03, 0x01, 0x00, 0x00, 0x02, 0xF2, 0x02 }; // response.SerializedSize doesn't work in this case

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

        private static void HandleEncryptRequest(Socket s, byte[] buf)
        {
            var header = new byte[] { 0xFE, 0x03, 0x03, 0x00, 0x00 }; // wrong password response?

            Send(s, header);
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

        public static byte[] ToByteArray(this string str)
        {
            str = str.Replace(" ", String.Empty);

            var res = new byte[str.Length / 2];
            for (int i = 0; i < res.Length; ++i)
            {
                string temp = String.Concat(str[i * 2], str[i * 2 + 1]);
                res[i] = Convert.ToByte(temp, 16);
            }
            return res;
        }
    }
}
