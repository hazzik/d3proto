namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol.server_pool;

    public class ServerPoolServiceImpl : ServerPoolService
    {
        public override void GetPoolState(IRpcController controller, PoolStateRequest request, Action<PoolStateResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}