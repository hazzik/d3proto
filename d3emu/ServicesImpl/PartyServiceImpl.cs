namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol.channel;
    using bnet.protocol.party;
    using Google.ProtocolBuffers;

    public class PartyServiceImpl : PartyService
    {
        public override void CreateChannel(IRpcController controller, CreateChannelRequest request, Action<CreateChannelResponse> done)
        {
            done(new CreateChannelResponse.Builder()
                     {
                         ChannelId = request.ChannelId.ToBuilder().SetHigh(1).SetLow(1).Build(),
                         ObjectId = request.ObjectId + 1
                     }.Build());
        }

        public override void JoinChannel(IRpcController controller, JoinChannelRequest request, Action<JoinChannelResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void GetChannelInfo(IRpcController controller, GetChannelInfoRequest request, Action<GetChannelInfoResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}
