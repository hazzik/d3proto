namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol.server_pool;
    using Google.ProtocolBuffers;

    public class ServerPoolServiceImpl : ServerPoolService
    {
        public override void GetPoolState(IRpcController controller, PoolStateRequest request, Action<PoolStateResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
