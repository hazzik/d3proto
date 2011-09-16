using System.Collections.Generic;
using bnet.protocol.authentication;
using bnet.protocol.channel;
using bnet.protocol.channel_invitation;
using bnet.protocol.chat;
using bnet.protocol.connection;
using bnet.protocol.exchange;
using bnet.protocol.followers;
using bnet.protocol.friends;
using bnet.protocol.game_master;
using bnet.protocol.game_utilities;
using bnet.protocol.notification;
using bnet.protocol.party;
using bnet.protocol.presence;
using bnet.protocol.search;
using bnet.protocol.storage;
using bnet.protocol.toon.external;
using bnet.protocol.user_manager;
using Google.ProtocolBuffers.Descriptors;

namespace d3emu
{
    public class Services
    {
        public static Dictionary<uint, ServiceDescriptor> ServicesDict = new Dictionary<uint, ServiceDescriptor>
        {
            { 0x00000000, ConnectionService.Descriptor },
            { 0x71240e35, AuthenticationClient.Descriptor },
            { 0x0decfc01, AuthenticationServer.Descriptor },
            { 0xb732db32, Channel.Descriptor },
            { 0x060ca08d, ChannelOwner.Descriptor },
            { 0xbf8c8094, ChannelSubscriber.Descriptor },
            { 0x83040608, ChannelInvitationService.Descriptor },
            { 0xf084fc20, ChannelInvitationNotify.Descriptor },
            { 0x00d89ca9, ChatService.Descriptor },
            { 0xd750148b, ExchangeService.Descriptor },
            { 0x166fe4a1, ExchangeNotify.Descriptor },
            { 0xe5a11099, FollowersService.Descriptor },
            { 0x905cdf9f, FollowersNotify.Descriptor },
            { 0xa3ddb1bd, FriendsService.Descriptor },
            { 0x6f259a13, FriendsNotify.Descriptor },
            { 0x810cb195, GameMaster.Descriptor },
            // GameMasterSubscriber ???
            { 0xc6f9ccc5, GameFactorySubscriber.Descriptor },
            { 0x3fc1274d, GameUtilities.Descriptor },
            { 0x0cbe3c43, NotificationService.Descriptor },
            { 0xe1cb2ea8, NotificationListener.Descriptor },
            { 0xf4e7fa35, PartyService.Descriptor },
            { 0xfa0796ff, PresenceService.Descriptor },
            { 0x0a24a291, SearchService.Descriptor },
            // ServerPoolService ???
            { 0xda6e4bb9, StorageService.Descriptor },
            { 0x4124c31b, ToonServiceExternal.Descriptor },
            { 0x3e19268a, UserManagerService.Descriptor },
            { 0xbc872c22, UserManagerNotify.Descriptor },
        };
    }
}
