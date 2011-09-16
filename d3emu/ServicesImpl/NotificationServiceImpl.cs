namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.notification;

    public class NotificationServiceImpl : NotificationService
    {
        public override void SendNotification(IRpcController controller, Notification request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void RegisterClient(IRpcController controller, RegisterClientRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void UnregisterClient(IRpcController controller, UnregisterClientRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void FindClient(IRpcController controller, FindClientRequest request, Action<FindClientResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}