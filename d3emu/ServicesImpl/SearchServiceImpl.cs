namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.search;

    public class SearchServiceImpl : SearchService
    {
        public override void FindMatches(IRpcController controller, FindMatchesRequest request, Action<FindMatchesResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void SetObject(IRpcController controller, SetObjectRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void RemoveObjects(IRpcController controller, RemoveObjectsRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}