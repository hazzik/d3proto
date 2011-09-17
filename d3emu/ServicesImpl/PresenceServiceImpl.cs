namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.presence;
    using Google.ProtocolBuffers;

    public class PresenceServiceImpl : PresenceService
    {
        public override void Subscribe(IRpcController controller, SubscribeRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void Unsubscribe(IRpcController controller, UnsubscribeRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void Update(IRpcController controller, UpdateRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void Query(IRpcController controller, QueryRequest request, Action<QueryResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
