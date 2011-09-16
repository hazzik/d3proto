namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.channel;

    public class ChannelSubscriberImpl : ChannelSubscriber
    {
        public override void NotifyAdd(IRpcController controller, AddNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyJoin(IRpcController controller, JoinNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyRemove(IRpcController controller, RemoveNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyLeave(IRpcController controller, LeaveNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifySendMessage(IRpcController controller, SendMessageNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyUpdateChannelState(IRpcController controller, UpdateChannelStateNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyUpdateMemberState(IRpcController controller, UpdateMemberStateNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}