namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol.channel;
    using Google.ProtocolBuffers;

    public class ChannelOwnerImpl : ChannelOwner
    {
        public override void GetChannelId(IRpcController controller, GetChannelIdRequest request, Action<GetChannelIdResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void CreateChannel(IRpcController controller, CreateChannelRequest request, Action<CreateChannelResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void JoinChannel(IRpcController controller, JoinChannelRequest request, Action<JoinChannelResponse> done)
        {
            done(new JoinChannelResponse.Builder().Build());
        }

        public override void FindChannel(IRpcController controller, FindChannelRequest request, Action<FindChannelResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void GetChannelInfo(IRpcController controller, GetChannelInfoRequest request, Action<GetChannelInfoResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
