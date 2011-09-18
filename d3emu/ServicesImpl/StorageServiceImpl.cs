namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol.storage;
    using Google.ProtocolBuffers;

    public class StorageServiceImpl : StorageService
    {
        public override void Execute(IRpcController controller, ExecuteRequest request, Action<ExecuteResponse> done)
        {
            var response = new ExecuteResponse.Builder
            {

            };
            done(response.Build());
        }

        public override void OpenTable(IRpcController controller, OpenTableRequest request, Action<OpenTableResponse> done)
        {
            var response = new OpenTableResponse.Builder
                               {
                                   
                               };
            done(response.Build());
        }

        public override void OpenColumn(IRpcController controller, OpenColumnRequest request, Action<OpenColumnResponse> done)
        {
            var response = new OpenColumnResponse.Builder
            {
                
            };
            done(response.Build());
        }
    }
}
