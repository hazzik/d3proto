namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.exchange;
    using bnet.protocol.exchange_object_provider;
    using Google.ProtocolBuffers;

    public class ExchangeServiceImpl : ExchangeService
    {
        public override void CreateOrderBook(IRpcController controller, CreateOrderBookRequest request, Action<CreateOrderBookResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void PlaceOfferOnOrderBook(IRpcController controller, PlaceOfferOnOrderBookRequest request, Action<PlaceOfferOnOrderBookResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void PlaceOfferCreateOrderBookIfNeeded(IRpcController controller, PlaceOfferCreateOrderBookIfNeededRequest request, Action<PlaceOfferCreateOrderBookIfNeededResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void PlaceBidOnOrderBook(IRpcController controller, PlaceBidOnOrderBookRequest request, Action<PlaceBidOnOrderBookResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void PlaceBidCreateOrderBookIfNeeded(IRpcController controller, PlaceBidCreateOrderBookIfNeededRequest request, Action<PlaceBidCreateOrderBookIfNeededResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void QueryOffersByOrderBook(IRpcController controller, QueryOffersByOrderBookRequest request, Action<QueryOffersByOrderBookResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void QueryBidsByOrderBook(IRpcController controller, QueryBidsByOrderBookRequest request, Action<QueryBidsByOrderBookResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void QueryOffersByAccountForItem(IRpcController controller, QueryOffersByAccountForItemRequest request, Action<QueryOffersByAccountForItemResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void QueryBidsByAccountForItem(IRpcController controller, QueryBidsByAccountForItemRequest request, Action<QueryBidsByAccountForItemResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void QueryOrderBooksSummary(IRpcController controller, QueryOrderBooksSummaryRequest request, Action<QueryOrderBooksSummaryResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void QuerySettlementsByOrderBook(IRpcController controller, QuerySettlementsByOrderBookRequest request, Action<QuerySettlementsByOrderBookResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void ReportAuthorize(IRpcController controller, ReportAuthorizeRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void ReportSettle(IRpcController controller, ReportSettleRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void ReportCancel(IRpcController controller, ReportCancelRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void SubscribeOrderBookStatusChange(IRpcController controller, SubscribeOrderBookStatusChangeRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void UnsubscribeOrderBookStatusChange(IRpcController controller, UnsubscribeOrderBookStatusChangeRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void SubscribeOrderStatusChange(IRpcController controller, SubscribeOrderStatusChangeRequest request, Action<NoData> done)
        {
            done(new NoData());
        }

        public override void UnsubscribeOrderStatusChange(IRpcController controller, UnsubscribeOrderStatusChangeRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void GetPaymentMethods(IRpcController controller, GetPaymentMethodsRequest request, Action<GetPaymentMethodsResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void ClaimBidItem(IRpcController controller, ClaimRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void ClaimBidMoney(IRpcController controller, ClaimRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void ClaimOfferItem(IRpcController controller, ClaimRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void ClaimOfferMoney(IRpcController controller, ClaimRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void CancelBid(IRpcController controller, CancelRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void CancelOffer(IRpcController controller, CancelRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void GetConfiguration(IRpcController controller, GetConfigurationRequest request, Action<GetConfigurationResponse> done)
        {
            done(new GetConfigurationResponse.Builder().Build());
        }

        public override void GetBidFeeEstimation(IRpcController controller, GetBidFeeEstimationRequest request, Action<GetFeeEstimationResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void GetOfferFeeEstimation(IRpcController controller, GetOfferFeeEstimationRequest request, Action<GetFeeEstimationResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
