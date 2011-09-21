namespace d3emu.ServicesImpl
{
    using System;
    using System.Linq;
    using System.Threading;
    using bnet.protocol;
    using bnet.protocol.authentication;
    using Google.ProtocolBuffers;

    public class AuthenticationServerImpl : AuthenticationServer
    {
        const uint Region = 0x00005553; // US
        const uint Usage = 0x61757468; // auth
        readonly byte[] ModuleHash = "8F52906A2C85B416A595702251570F96D3522F39237603115F2F1AB24962043C".ToByteArray(); // Password.dll

        private readonly BnetClient client;
        private SRP srp;
        private readonly AutoResetEvent wait = new AutoResetEvent(false);

        public AuthenticationServerImpl(BnetClient client)
        {
            this.client = client;
        }

        public override void Logon(IRpcController controller, LogonRequest request, Action<LogonResponse> done)
        {
            srp = new SRP(request.Email, "123");

            var message = srp.LogonChallenge;

            var moduleLoadRequest = ModuleLoadRequest.CreateBuilder()
                .SetModuleHandle(ContentHandle.CreateBuilder()
                    .SetRegion(Region)
                    .SetUsage(Usage)
                    .SetHash(ByteString.CopyFrom(ModuleHash)))
                .SetMessage(ByteString.CopyFrom(message))
                .Build();

            client.ListenerId = request.ListenerId;

            AuthenticationClient.CreateStub(client).ModuleLoad(controller, moduleLoadRequest, ClientServiceCallback);

            new Thread(() =>
                           {
                               wait.WaitOne();
                               if (client.ErrorCode == AuthError.None)
                               {
                                   done(new LogonResponse.Builder
                                            {
                                                Account = new EntityId.Builder { High = HighId.Account, Low = 0 }.Build(),
                                                GameAccount = new EntityId.Builder { High = HighId.GameAccount, Low = 0 }.Build(),
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
            var moduleId = request.ModuleId;

            var message = request.Message.ToByteArray();
            var command = message[0];

            done(new NoData.Builder().Build());

            if (moduleId == 0 && command == 2)
            {
                byte[] A = message.Skip(1).Take(128).ToArray();
                byte[] M1 = message.Skip(1 + 128).Take(32).ToArray();
                byte[] seed = message.Skip(1 + 32 + 128).Take(128).ToArray();

                if (srp.Verify(A, M1, seed))
                {
                    var moduleMessagedRequest = new ModuleMessageRequest.Builder
                    {
                        ModuleId = moduleId,
                        Message = ByteString.CopyFrom(srp.LogonProof)
                    }.Build();

                    AuthenticationClient.CreateStub(client).ModuleMessage(controller, moduleMessagedRequest, ClientServiceCallback);
                }
                else
                {
                    client.ListenerId = 0;
                    client.ErrorCode = AuthError.InvalidCredentials;
                }

                wait.Set();
            }
        }

        // just for logging purposes
        private static void ClientServiceCallback(IMessage msg)
        {
            Console.WriteLine("{0}", msg.DescriptorForType.FullName);
            Console.WriteLine("{0}", msg.ToString());
        }
    }
}
