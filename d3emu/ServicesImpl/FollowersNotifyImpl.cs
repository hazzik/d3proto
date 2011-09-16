namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.followers;

    public class FollowersNotifyImpl : FollowersNotify
    {
        public override void NotifyFollowerRemoved(IRpcController controller, FollowerNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}