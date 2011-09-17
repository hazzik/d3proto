namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.exchange;
    using Google.ProtocolBuffers;

    public class ExchangeNotifyImpl : ExchangeNotify
    {
        public override void NotifyOrderBookStatusChange(IRpcController controller, OrderBookNotificationRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyOfferStatusChange(IRpcController controller, OfferNotificationRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void NotifyBidStatusChange(IRpcController controller, BidNotificationRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}
