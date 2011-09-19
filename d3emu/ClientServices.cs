namespace d3emu
{
    using System;
    using System.Collections.Generic;
    using bnet.protocol.authentication;
    using bnet.protocol.channel;
    using bnet.protocol.channel_invitation;
    using bnet.protocol.connection;
    using bnet.protocol.exchange;
    using bnet.protocol.followers;
    using bnet.protocol.friends;
    using bnet.protocol.game_master;
    using bnet.protocol.notification;
    using bnet.protocol.user_manager;
    using Google.ProtocolBuffers;

    public static class ClientServices
    {
        public static readonly Dictionary<uint, Func<Client, IService>> ServicesDict
            = new Dictionary<uint, Func<Client, IService>>
                  {
                      {0x00000000, c => ConnectionService.CreateStub(c)},
                      {0x71240e35, c => AuthenticationClient.CreateStub(c)},
                      {0xbf8c8094, c => ChannelSubscriber.CreateStub(c)},
                      {0xe1cb2ea8, c => NotificationListener.CreateStub(c)},
                      {0xf084fc20, c => ChannelInvitationNotify.CreateStub(c)},
                      {0x905cdf9f, c => FollowersNotify.CreateStub(c)},
                      {0xbc872c22, c => UserManagerNotify.CreateStub(c)},
                      {0x6f259a13, c => FriendsNotify.CreateStub(c)},
                      {0xc6f9ccc5, c => GameFactorySubscriber.CreateStub(c)},
                      {0x166fe4a1, c => ExchangeNotify.CreateStub(c)},
                  };
    }
}
