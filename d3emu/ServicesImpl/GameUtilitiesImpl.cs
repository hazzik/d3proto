namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.game_utilities;
    using bnet.protocol.server_pool;
    using Google.ProtocolBuffers;

    public class GameUtilitiesImpl : GameUtilities
    {
        public override void ProcessClientRequest(IRpcController controller, ClientRequest request, Action<ClientResponse> done)
        {
            var response = new ClientResponse.Builder
                              {
                                   
                              };
            done(response.Build());
        }

        public override void CreateToon(IRpcController controller, CreateToonRequest request, Action<CreateToonResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void DeleteToon(IRpcController controller, DeleteToonRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void TransferToon(IRpcController controller, TransferToonRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void SelectToon(IRpcController controller, SelectToonRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void PresenceChannelCreated(IRpcController controller, PresenceChannelCreatedRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void GetPlayerVariables(IRpcController controller, PlayerVariablesRequest request, Action<VariablesResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void GetGameVariables(IRpcController controller, GameVariablesRequest request, Action<VariablesResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void GetLoad(IRpcController controller, GetLoadRequest request, Action<ServerState> done)
        {
            throw new NotImplementedException();
        }
    }
}
