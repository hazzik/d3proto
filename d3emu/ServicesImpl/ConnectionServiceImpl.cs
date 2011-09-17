namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.connection;

    class ConnectionServiceImpl : ConnectionService
    {
        private readonly Client client;

        public ConnectionServiceImpl(Client client)
        {
            this.client = client;
        }

        public override void Connect(IRpcController controller, ConnectRequest request, Action<ConnectResponse> done)
        {
            Console.WriteLine(request.ToString()); // empty

            var response = ConnectResponse.CreateBuilder()
                .SetServerId(ProcessId.CreateBuilder().SetLabel(0xDEADBABE).SetEpoch(DateTime.Now.ToUnixTime()))
                .SetClientId(ProcessId.CreateBuilder().SetLabel(0xDEADBEEF).SetEpoch(DateTime.Now.ToUnixTime())).Build();

            Console.WriteLine(response.ToString());

            done(response);
        }

        public override void Bind(IRpcController controller, BindRequest request, Action<BindResponse> done)
        {
            Console.WriteLine(request.ToString());

            var newResponse = BindResponse.CreateBuilder();

            foreach (var hash in request.ImportedServiceHashList)
            {
                newResponse.AddImportedServiceId(client.LoadImportedService(hash));
            }
            foreach (var s in request.ExportedServiceList)
            {
                client.LoadExportedService(s.Hash, s.Id);
            }

            var response = newResponse.Build();

            Console.WriteLine(response.ToString());

            done(response);
        }

        public override void Echo(IRpcController controller, EchoRequest request, Action<EchoResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void ForceDisconnect(IRpcController controller, DisconnectNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void Null(IRpcController controller, NullRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void Encrypt(IRpcController controller, EncryptRequest request, Action<NoData> done)
        {
            var data = new ServerPacket(Program.PrevService, 3, 3, 0).WriteMessage(NO_RESPONSE.CreateBuilder().Build());

            client.Send(data);
        }

        public override void RequestDisconnect(IRpcController controller, DisconnectRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}
