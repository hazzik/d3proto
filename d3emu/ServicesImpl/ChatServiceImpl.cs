namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol.channel;
    using bnet.protocol.chat;
    using Google.ProtocolBuffers;

    public class ChatServiceImpl : ChatService
    {
        public override void FindChannel(IRpcController controller, FindChannelRequest request, Action<FindChannelResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void CreateChannel(IRpcController controller, CreateChannelRequest request, Action<CreateChannelResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void JoinChannel(IRpcController controller, JoinChannelRequest request, Action<JoinChannelResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
