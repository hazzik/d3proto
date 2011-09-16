namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.friends;

    public class FriendsNotifyImpl : FriendsNotify
    {
        public override void NotifyFriendAdded(IRpcController controller, FriendNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyFriendRemoved(IRpcController controller, FriendNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyReceivedInvitationAdded(IRpcController controller, InvitationAddedNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyReceivedInvitationRemoved(IRpcController controller, InvitationRemovedNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifySentInvitationRemoved(IRpcController controller, InvitationRemovedNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}