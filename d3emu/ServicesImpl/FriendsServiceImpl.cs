namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.friends;
    using bnet.protocol.invitation;
    using Google.ProtocolBuffers;
    using SendInvitationRequest = bnet.protocol.invitation.SendInvitationRequest;

    public class FriendsServiceImpl : FriendsService
    {
        public override void SubscribeToFriends(IRpcController controller, SubscribeToFriendsRequest request, Action<SubscribeToFriendsResponse> done)
        {
            done(new SubscribeToFriendsResponse.Builder
                     {

                     }.Build());
        }

        public override void SendInvitation(IRpcController controller, SendInvitationRequest request, Action<SendInvitationResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void AcceptInvitation(IRpcController controller, GenericRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void RevokeInvitation(IRpcController controller, GenericRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void DeclineInvitation(IRpcController controller, GenericRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void IgnoreInvitation(IRpcController controller, GenericRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void RemoveFriend(IRpcController controller, GenericFriendRequest request, Action<GenericFriendResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void ViewFriends(IRpcController controller, ViewFriendsRequest request, Action<ViewFriendsResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void UpdateFriendState(IRpcController controller, UpdateFriendStateRequest request, Action<UpdateFriendStateResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void UnsubscribeToFriends(IRpcController controller, UnsubscribeToFriendsRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }
    }
}
