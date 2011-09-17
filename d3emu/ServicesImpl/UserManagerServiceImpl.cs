namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol.user_manager;
    using Google.ProtocolBuffers;

    public class UserManagerServiceImpl : UserManagerService
    {
        public override void SubscribeToUserManager(IRpcController controller, SubscribeToUserManagerRequest request, Action<SubscribeToUserManagerResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void ReportPlayer(IRpcController controller, ReportPlayerRequest request, Action<ReportPlayerResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void BlockPlayer(IRpcController controller, BlockPlayerRequest request, Action<BlockPlayerResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void RemovePlayerBlock(IRpcController controller, RemovePlayerBlockRequest request, Action<RemovePlayerBlockResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void AddRecentPlayers(IRpcController controller, AddRecentPlayersRequest request, Action<AddRecentPlayersResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void RemoveRecentPlayers(IRpcController controller, RemoveRecentPlayersRequest request, Action<RemoveRecentPlayersResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
