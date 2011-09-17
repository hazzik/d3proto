namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.followers;
    using Google.ProtocolBuffers;

    public class FollowersNotifyImpl : FollowersNotify
    {
        public override void NotifyFollowerRemoved(IRpcController controller, FollowerNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}
