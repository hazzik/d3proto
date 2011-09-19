namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.channel;
    using bnet.protocol.party;
    using Google.ProtocolBuffers;

    public class PartyServiceImpl : PartyService
    {
        private readonly Client client;

        public PartyServiceImpl(Client client)
        {
            this.client = client;
        }

        public override void CreateChannel(IRpcController controller, CreateChannelRequest request, Action<CreateChannelResponse> done)
        {
            done(new CreateChannelResponse.Builder
                     {
                         ChannelId = request.ChannelId.ToBuilder().SetHigh(0x604ac77c9aa0d7d).SetLow(0x9be5ecbd0000279f).Build(),
                         ObjectId = 67093
                     }.Build());

            client.ListenerId = request.ObjectId;

            var notification = new AddNotification.Builder
                                   {
                                       Self = new Member.Builder
                                                  {
                                                      Identity = new Identity.Builder
                                                                     {
                                                                         AccountId = new EntityId.Builder
                                                                                         {
                                                                                             High = HighId.Account,
                                                                                             Low = 0
                                                                                         }.Build(),
                                                                         GameAccountId = new EntityId.Builder
                                                                                             {
                                                                                                 High = HighId.GameAccount,
                                                                                                 Low = 5200929,
                                                                                             }.Build(),
                                                                         ToonId = new EntityId.Builder
                                                                                      {
                                                                                          High = HighId.Toon,
                                                                                          Low = 2,
                                                                                      }.Build()
                                                                     }.Build(),
                                                      State = new MemberState.Builder
                                                                  {
                                                                      Privileges = 64511,
                                                                  }.AddRole(2).Build(),

                                                  }.Build(),

                                       ChannelState = new ChannelState.Builder
                                                          {
                                                              MaxMembers = 8,
                                                              MinMembers = 1,
                                                              MaxInvitations = 12,
                                                              PrivacyLevel = ChannelState.Types.PrivacyLevel.PRIVACY_LEVEL_OPEN_INVITATION
                                                          }.Build()
                                   }.AddMember(new Member.Builder
                                   {
                                       Identity = new Identity.Builder
                                       {
                                           ToonId = new EntityId.Builder
                                           {
                                               High = HighId.Toon,
                                               Low = 2,
                                           }.Build()
                                       }.Build(),
                                       State = new MemberState.Builder
                                       {
                                           Privileges = 64511,
                                       }.AddRole(2).Build(),
                                   }.Build());

            ChannelSubscriber.CreateStub(client).NotifyAdd(controller, notification.Build(), r => { });
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
