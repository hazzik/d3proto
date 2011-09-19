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

        private readonly Client client;
        private SRP srp;
        private readonly AutoResetEvent wait = new AutoResetEvent(false);

        public AuthenticationServerImpl(Client client)
        {
            this.client = client;
        }

        public override void Logon(IRpcController controller, LogonRequest request, Action<LogonResponse> done)
        {
            srp = new SRP(request.Email, "123");

            var message = srp.Response1;

            var moduleLoadRequest = ModuleLoadRequest.CreateBuilder()
                .SetModuleHandle(ContentHandle.CreateBuilder()
                    .SetRegion(Region)
                    .SetUsage(Usage)
                    .SetHash(ByteString.CopyFrom(ModuleHash)))
                .SetMessage(ByteString.CopyFrom(message))
                .Build();

            var authenticationClient = client.GetService<AuthenticationClient>();

            client.ListenerId = request.ListenerId;
            authenticationClient.ModuleLoad(controller, moduleLoadRequest,
                                            r => Console.WriteLine("{0}\r\n{1}", r.DescriptorForType.FullName, r.ToString()));

            new Thread(() =>
                           {
                               wait.WaitOne();
                               if (client.ErrorCode == 0)
                               {
                                   done(new LogonResponse.Builder
                                            {
                                                Account = new EntityId.Builder { High = 0x100000000000000, Low = 0 }.Build(),
                                                GameAccount = new EntityId.Builder { High = 0x200006200004433, Low = 0 }.Build(),
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
