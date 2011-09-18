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
        const uint Region = 0x00005553; // US
        const uint Usage = 0x61757468; // auth
        readonly byte[] ModuleHash = "8F52906A2C85B416A595702251570F96D3522F39237603115F2F1AB24962043C".ToByteArray(); // Password.dll

        private readonly Client client;

        public AuthenticationServerImpl(Client client)
        {
            this.client = client;
        }

        public override void Logon(IRpcController controller, LogonRequest request, Action<LogonResponse> done)
        {
            Console.WriteLine(request.ToString());

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
            //var response = ModuleLoadRequest.CreateBuilder().MergeFrom(hexBytes).Build();

            var message = new byte[0]
                .Concat(new byte[] { 0 }) // command = 0
                .Concat("28 E5 1C 5E 79 1C DD 57 6C 2F F1 53 22 19 C3 30 1E 63 F3 4E 98 62 E9 74 4E B6 E2 B7 83 BF 9D C9".ToByteArray()) // accountSalt
                .Concat("A7 90 43 D3 49 47 29 8F A9 4E 3E 85 26 38 B7 5A 6D D0 1B 8C 91 88 83 59 E0 73 FE 28 68 43 E9 44".ToByteArray()) // passwordSalt
                .Concat("9D E7 22 9B 02 03 36 E9 9E D5 10 B9 4E F3 69 0C 5C 32 AB 71 24 9E D8 5E 14 F0 97 D4 EF 44 FC 62 63 F1 57 E7 25 CD 86 1B 3B 82 26 6A 58 56 C4 FB 71 60 84 15 27 19 01 E1 58 15 2B 09 C8 A1 5F BA CA 4B A3 63 A4 C5 CB 46 B9 86 E8 62 7B 0D B4 92 8A 2C 60 9D FD 2D 99 CC BC FC 81 EB 40 32 03 D6 4F B8 12 C5 6D 56 19 B5 8B A3 F8 72 67 82 2A 3B 91 B8 1F 48 07 AE E4 EF 34 F4 2E C1 F7 01 6D 5B".ToByteArray()) // serverChallenge
                .Concat("BF 7A 5F F0 3E 6F B6 7E 7C 4E 9A EE E4 16 4B 7A C7 3A F8 AE A8 B9 21 5D 13 D8 D9 67 93 58 20 A3 B4 08 19 4C F0 DF DB 9E 06 85 87 4C 9F BC BB C7 DD 39 0A 0A 1F F1 8F 3E 5B F4 85 EF 22 6B 19 52 9A D3 18 25 DE 17 7C C8 21 53 AF 81 69 12 45 C6 04 BE 22 F4 01 B3 08 02 FE E1 BD 79 56 FA A8 78 D8 06 90 8D 22 73 EE DD 12 9E 27 47 76 07 79 5C 81 29 04 2C 97 3C A4 70 D9 9E F4 97 85 F3 B9 56".ToByteArray()) // secondaryChallenge
                .ToArray();

            var moduleLoadRequest = ModuleLoadRequest.CreateBuilder()
                .SetModuleHandle(ContentHandle.CreateBuilder()
                    .SetRegion(Region)
                    .SetUsage(Usage)
                    .SetHash(ByteString.CopyFrom(ModuleHash)))
                .SetMessage(ByteString.CopyFrom(message))
                .Build();

            Console.WriteLine("Region: {0}", Encoding.ASCII.GetString(BitConverter.GetBytes(moduleLoadRequest.ModuleHandle.Region).Reverse().ToArray()));
            Console.WriteLine("Usage: {0}", Encoding.ASCII.GetString(BitConverter.GetBytes(moduleLoadRequest.ModuleHandle.Usage).Reverse().ToArray()));
            Console.WriteLine("Hash: {0}", moduleLoadRequest.ModuleHandle.Hash.ToByteArray().ToHexString());
            Console.WriteLine("Message: {0}", moduleLoadRequest.Message.ToByteArray().ToHexString());

            var authenticationClient = (AuthenticationClient)(Services.ServicesDict[Services.AuthenticationClient](client));

            authenticationClient.ModuleLoad(controller, moduleLoadRequest, r =>
                                                                               {

                                                                               });

            //done(new LogonResponse.Builder
            //         {
            //             //Account = 
            //         }.Build());
        }

        public override void ModuleMessage(IRpcController controller, ModuleMessageRequest request, Action<NoData> done)
        {
            Console.WriteLine(request.ToString());

            var moduleId = request.ModuleId;
            var message = request.Message.ToByteArray();

            var command = message[0]; // comamnd 2 with data wtf

            byte[] passwordSalt = message.Skip(1).Take(32).ToArray();
            byte[] serverChallenge = message.Skip(1 + 32).Take(128).ToArray();
            byte[] secondaryChallenge = message.Skip(1 + 32 + 128).Take(128).ToArray();

            done(new NoData.Builder().Build());
            //            var data = new ServerPacket(PrevService, 3, 3, 0).WriteMessage(NO_RESPONSE.CreateBuilder().Build());
            //
            //            Send(s, data);
        }
    }
}
