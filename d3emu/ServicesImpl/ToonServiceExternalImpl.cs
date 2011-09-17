namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol.toon.external;
    using Google.ProtocolBuffers;

    public class ToonServiceExternalImpl : ToonServiceExternal
    {
        public override void ToonList(IRpcController controller, ToonListRequest request, Action<ToonListResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void SelectToon(IRpcController controller, SelectToonRequest request, Action<SelectToonResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void CreateToon(IRpcController controller, CreateToonRequest request, Action<CreateToonResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void DeleteToon(IRpcController controller, DeleteToonRequest request, Action<DeleteToonResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
