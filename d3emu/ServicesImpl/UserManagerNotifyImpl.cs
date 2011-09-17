namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.user_manager;
    using Google.ProtocolBuffers;

    public class UserManagerNotifyImpl : UserManagerNotify
    {
        public override void NotifyPlayerBlocked(IRpcController controller, BlockedPlayerNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyPlayerBlockRemoved(IRpcController controller, BlockedPlayerNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}
