namespace d3emu.ServicesImpl
{
    using System;
    using System.Linq;
    using System.Text;
    using bnet.protocol;
    using bnet.protocol.authentication;
    using Google.ProtocolBuffers;

    public class AuthenticationServerImpl : AuthenticationServer
    {
        private readonly Client client;

        public AuthenticationServerImpl(Client client)
        {
            this.client = client;
        }

        public override void Logon(IRpcController controller, LogonRequest request, Action<LogonResponse> done)
        {
            Console.WriteLine(request.ToString());

            //// this should not be here
            //var response = LogonResponse.CreateBuilder()
            //    .SetAccount(EntityId.CreateBuilder().SetHigh(12345).SetLow(67890))
            //    .SetGameAccount(EntityId.CreateBuilder().SetHigh(67890).SetLow(12345)).Build();

            // tell client to load authentication module (similar to wow/sc2)
            var hexModule = "03 01 00 00 02 F2 02 0A 2C 0D 53 55 00 00 15 68 74 75 61 1A 20 8F 52 90 6A 2C 85 B4 16 A5 95 70 22 51 57 0F 96 D3 52 2F 39 23 76 03 11 5F 2F 1A B2 49 62 04 3C 12 C1 02 00 C0 9E 5B DF F5 92 DD C3 8E DC 46 AE B1 57 65 68 D0 7A 94 17 D5 9C F0 70 8F 00 39 7D A2 3B 5B 23 32 8C 88 CA 5B 89 72 22 DA 43 3A 32 D2 8D 71 0C 5C EF 2A 14 46 C3 4C 10 F3 36 EC 1B 53 A8 95 ED E9 EB 82 0C C7 94 72 2E 4D F3 F4 17 33 63 46 2A 96 73 59 B5 70 19 A3 14 32 D7 6D F5 33 2A 77 90 C3 3B CD 19 65 FE 13 1E 4C F2 07 9F D8 74 9A 57 BD 22 F6 1C DF 18 1E F5 1B 15 23 25 F7 50 DD 8D AA 4D E0 9B 34 83 BE 78 C1 45 66 8D 2C B3 34 39 29 CD 88 D1 82 15 13 CE 8C D4 61 71 0C DC 5D 6B 73 E2 1C 96 F5 F5 39 3F 23 75 96 A9 70 5A C0 C7 01 3B BE 0E 71 86 FE 8B F0 F1 24 66 0A E1 89 86 38 DA B1 EA 5E D4 03 EC F8 F2 26 6D AE 2A A0 74 40 60 32 9F 9E 54 1A 39 8C 3D 6B 8E E3 75 09 CC 46 F9 D0 97 74 F1 6C 70 EF F9 D3 78 91 BD 66 6F A8 0A 39 D1 14 79 43 63 60 99 E5 11 E6 34 11 58 83 89 F6 89 E0 40 C4 2E F9 31 AC E9 7F F6 01 11 05 92 D1 3C 7F F9 20 DE EF 5A F0 37 A4 96 47 E8 92 DD 28 D0 D4 91 9F E3 4B 90 99 DD A8 6B 2D BA 1A 9B 57 FE 42 EE 19 F3 6F 38 0D A2 04 80 9F 66";

            var hexBytes = hexModule.ToByteArray().Skip(7).ToArray();

            // response.ModuleHandle.Region: US
            // response.ModuleHandle.Usage: auth
            // response.ModuleHandle.Hash: 8f52906a2c85b416a595702251570f96d3522f39237603115f2f1ab24962043c (SHA256 of auth module file)
            // response.Message: ... (SRP parameters)
            // response.Message structure:
            //     byte command;
            //     if (command == 0 || command == 1)
            //     {
            //         if (command == 0)
            //         {
            //             byte accountSalt[32];
            //         }
            //         byte passwordSalt[32];
            //         byte serverChallenge[128];
            //         byte secondaryChallenge[128];
            //     }
            //     else if (command == 2)
            //     {
            //         // empty?
            //     }
            //     else if (command == 3)
            //     {
            //         byte M2[32];
            //         byte data2[128]; // for veryfing secondaryChallenge
            //     }
            var response = ModuleLoadRequest.CreateBuilder().MergeFrom(hexBytes).Build();

            Console.WriteLine("Region: {0}", Encoding.ASCII.GetString(BitConverter.GetBytes(response.ModuleHandle.Region).Reverse().ToArray()));
            Console.WriteLine("Usage: {0}", Encoding.ASCII.GetString(BitConverter.GetBytes(response.ModuleHandle.Usage).Reverse().ToArray()));
            Console.WriteLine("Hash: {0:X8}", response.ModuleHandle.Hash.ToByteArray().ToHexString());
            Console.WriteLine("Message: {0:X8}", response.Message.ToByteArray().ToHexString());

            byte sId = 0;
            foreach (var service in client.exportedServices)
            {
                if (service.Value.GetType() == typeof(AuthenticationClientImpl))
                {
                    sId = (byte)service.Key;
                    //client.importedServices[254] = service.Value;
                }
            }
            var data = new ServerPacket(sId, 1, 0, request.ListenerId).WriteMessage(response);

            client.Send(data);

            //            done(new LogonResponse.Builder
            //                     {
            //                         //Account = 
            //                     }.Build());
        }

        public override void ModuleMessage(IRpcController controller, ModuleMessageRequest request, Action<NoData> done)
        {
            done(new NoData.Builder().Build());
            //            var data = new ServerPacket(PrevService, 3, 3, 0).WriteMessage(NO_RESPONSE.CreateBuilder().Build());
            //
            //            Send(s, data);
        }
    }
}
