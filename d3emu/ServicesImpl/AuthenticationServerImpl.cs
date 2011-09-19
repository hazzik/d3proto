namespace d3emu.ServicesImpl
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using bnet.protocol;
    using bnet.protocol.authentication;
    using Google.ProtocolBuffers;
    using bnet.protocol.connection;

    public class AuthenticationServerImpl : AuthenticationServer
    {
        const uint Region = 0x00005553; // US
        const uint Usage = 0x61757468; // auth
        readonly byte[] ModuleHash = "8F52906A2C85B416A595702251570F96D3522F39237603115F2F1AB24962043C".ToByteArray(); // Password.dll

        private readonly Client client;
        private SRP srp;
        private readonly AutoResetEvent wait = new AutoResetEvent(false); 

        public AuthenticationServerImpl(Client client)
        {
            this.client = client;
        }

        public override void Logon(IRpcController controller, LogonRequest request, Action<LogonResponse> done)
        {
            Console.WriteLine(request.ToString());

            // response.Message structure:
            //     byte command;
            //     if (command == 0 || command == 1) // from server
            //     {
            //         if (command == 0)
            //             byte accountSalt[32]; // static value per account
            //         byte passwordSalt[32]; // static value per account
            //         byte serverChallenge[128]; // changes every login
            //         byte secondaryChallenge[128]; // changes every login
            //     }
            //     else if (command == 2) // from server
            //     {
            //         // empty
            //     }
            //     else if (command == 3) // from server
            //     {
            //         byte M2[32];
            //         byte data2[128]; // for veryfing secondaryChallenge
            //     }

            srp = new SRP(request.Email, "123");

            var message = srp.Response1;

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

            var authenticationClient = client.GetService<AuthenticationClient>();

            client.ListenerId = request.ListenerId;
            authenticationClient.ModuleLoad(controller, moduleLoadRequest,
                                            r => Console.WriteLine("{0}\r\n{1}", r.GetType().Name, r.ToString()));

            new Thread(() =>
                           {
                               wait.WaitOne();
                               if (client.ErrorCode == 0)
                               {
                                   done(new LogonResponse.Builder
                                            {
                                                Account = new EntityId.Builder {High = 0x100000000000000, Low = 0}.Build(),
                                                GameAccount = new EntityId.Builder {High = 0x200006200004433, Low = 0}.Build(),
                                            }.Build());
                               }
                               else
                               {
                                   done(new LogonResponse());
                               }
                           }).Start();

        }

        public override void ModuleMessage(IRpcController controller, ModuleMessageRequest request, Action<NoData> done)
        {
            Console.WriteLine(request.ToString());

            var moduleId = request.ModuleId;
            
            var message = request.Message.ToByteArray();
            var command = message[0];

            done(new NoData.Builder().Build());

            if (moduleId == 0 && command == 2)
            {
                byte[] A = message.Skip(1).Take(128).ToArray();
                byte[] M1 = message.Skip(1 + 128).Take(32).ToArray();
                byte[] seed = message.Skip(1 + 32 + 128).Take(128).ToArray();

                if (srp.Verify(A, M1, seed) == false)
                {
                    client.ListenerId = 0;
                    client.ErrorCode = 3;
                }

                wait.Set();
            }

        }
    }
}
