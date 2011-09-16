namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol.storage;

    public class StorageServiceImpl : StorageService
    {
        public override void Execute(IRpcController controller, ExecuteRequest request, Action<ExecuteResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void OpenTable(IRpcController controller, OpenTableRequest request, Action<OpenTableResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void OpenColumn(IRpcController controller, OpenColumnRequest request, Action<OpenColumnResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}