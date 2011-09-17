namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.channel_invitation;
    using bnet.protocol.invitation;
    using Google.ProtocolBuffers;
    using SendInvitationRequest = bnet.protocol.invitation.SendInvitationRequest;

    public class ChannelInvitationServiceImpl : ChannelInvitationService
    {
        public override void Subscribe(IRpcController controller, SubscribeRequest request, Action<SubscribeResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void Unsubscribe(IRpcController controller, UnsubscribeRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void SendInvitation(IRpcController controller, SendInvitationRequest request, Action<SendInvitationResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void AcceptInvitation(IRpcController controller, AcceptInvitationRequest request, Action<AcceptInvitationResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void DeclineInvitation(IRpcController controller, GenericRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void RevokeInvitation(IRpcController controller, RevokeInvitationRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void SuggestInvitation(IRpcController controller, SuggestInvitationRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }
    }
}
