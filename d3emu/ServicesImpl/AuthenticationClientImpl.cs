namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.authentication;
    using Google.ProtocolBuffers;

    public class AuthenticationClientImpl : AuthenticationClient
    {
        public override void ModuleLoad(IRpcController controller, ModuleLoadRequest request, Action<ModuleLoadResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void ModuleMessage(IRpcController controller, ModuleMessageRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }
    }
}
