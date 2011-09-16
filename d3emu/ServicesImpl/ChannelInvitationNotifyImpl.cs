namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.channel_invitation;

    public class ChannelInvitationNotifyImpl : ChannelInvitationNotify
    {
        public override void NotifyReceivedInvitationAdded(IRpcController controller, InvitationAddedNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyReceivedInvitationRemoved(IRpcController controller, InvitationRemovedNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyReceivedSuggestionAdded(IRpcController controller, SuggestionAddedNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void HasRoomForInvitation(IRpcController controller, HasRoomForInvitationRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }
    }
}