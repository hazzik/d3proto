namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol.followers;
    using Google.ProtocolBuffers;

    public class FollowersServiceImpl : FollowersService
    {
        public override void SubscribeToFollowers(IRpcController controller, SubscribeToFollowersRequest request, Action<SubscribeToFollowersResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void StartFollowing(IRpcController controller, StartFollowingRequest request, Action<StartFollowingResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void StopFollowing(IRpcController controller, StopFollowingRequest request, Action<StopFollowingResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void UpdateFollowerState(IRpcController controller, UpdateFollowerStateRequest request, Action<UpdateFollowerStateResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
