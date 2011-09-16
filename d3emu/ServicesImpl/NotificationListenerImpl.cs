namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.notification;

    public class NotificationListenerImpl : NotificationListener
    {
        public override void OnNotificationReceived(IRpcController controller, Notification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}