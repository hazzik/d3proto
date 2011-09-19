namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.presence;
    using Google.ProtocolBuffers;

    public class PresenceServiceImpl : PresenceService
    {
        private readonly Client client;

        public PresenceServiceImpl(Client client)
        {
            this.client = client;
        }

        public override void Subscribe(IRpcController controller, SubscribeRequest request, Action<NoData> done)
        {
            done(new NoData.Builder().Build());
        }

        public override void Unsubscribe(IRpcController controller, UnsubscribeRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void Update(IRpcController controller, UpdateRequest request, Action<NoData> done)
        {
            done(new NoData.Builder().Build());
        }

        public override void Query(IRpcController controller, QueryRequest request, Action<QueryResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
