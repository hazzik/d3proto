using System.Collections.Generic;

namespace d3emu
{
    using System;
    using Google.ProtocolBuffers;
    using ServicesImpl;

    public partial class Services
    {
        public static Dictionary<uint, System.Func<Client, IService>> ServicesDict
            = new Dictionary<uint, Func<Client, IService>>
                  {
                      {0x00000000, c => new ConnectionServiceImpl(c)},
                      {0x71240e35, c => new AuthenticationClientImpl()},
                      {0x0decfc01, c => new AuthenticationServerImpl(c)},
                      {0xb732db32, c => new ChannelImpl()},
                      {0x060ca08d, c => new ChannelOwnerImpl()},
                      {0xbf8c8094, c => new ChannelSubscriberImpl()},
                      {0x83040608, c => new ChannelInvitationServiceImpl()},
                      {0xf084fc20, c => new ChannelInvitationNotifyImpl()},
                      {0x00d89ca9, c => new ChatServiceImpl()},
                      {0xd750148b, c => new ExchangeServiceImpl()},
                      {0x166fe4a1, c => new ExchangeNotifyImpl()},
                      {0xe5a11099, c => new FollowersServiceImpl()},
                      {0x905cdf9f, c => new FollowersNotifyImpl()},
                      {0xa3ddb1bd, c => new FriendsServiceImpl()},
                      {0x6f259a13, c => new FriendsNotifyImpl()},
                      {0x810cb195, c => new GameMasterImpl()},
                      {0x5772ab33, c => new GameMasterSubscriberImpl()},
                      {0xc6f9ccc5, c => new GameFactorySubscriberImpl()},
                      {0x3fc1274d, c => new GameUtilitiesImpl()},
                      {0x0cbe3c43, c => new NotificationServiceImpl()},
                      {0xe1cb2ea8, c => new NotificationListenerImpl()},
                      {0xf4e7fa35, c => new PartyServiceImpl()},
                      {0xfa0796ff, c => new PresenceServiceImpl()},
                      {0x0a24a291, c => new SearchServiceImpl()},
                      {0x67960c70, c => new ServerPoolServiceImpl()},
                      {0xda6e4bb9, c => new StorageServiceImpl()},
                      {0x4124c31b, c => new ToonServiceExternalImpl()},
                      {0x3e19268a, c => new UserManagerServiceImpl()},
                      {0xbc872c22, c => new UserManagerNotifyImpl()}
                  };

        public static readonly IDictionary<string, IDictionary<int, string>> Methods =
            new Dictionary<string, IDictionary<int, string>>
				{
					{
						"ConnectionService",
						new Dictionary<int, string>
							{
								{1, "Connect"},
								{2, "Bind"},
								{3, "Echo"},
								{4, "ForceDisconnect"},
								{5, "Null"},
								{6, "Encrypt"},
								{7, "RequestDisconnect"},
							}
						},
					{
						"AuthenticationClient",
						new Dictionary<int, string>
							{
								{1, "ModuleLoad"},
								{2, "ModuleMessage"},
							}
						},
					{
						"AuthenticationServer",
						new Dictionary<int, string>
							{
								{1, "Logon"},
								{2, "ModuleMessage"},
							}
						},
					{
						"Channel",
						new Dictionary<int, string>
							{
								{1, "AddMember"},
								{2, "RemoveMember"},
								{3, "SendMessage"},
								{4, "UpdateChannelState"},
								{5, "UpdateMemberState"},
								{6, "Dissolve"},
								{7, "SetRoles"},
							}
						},
					{
						"ChannelOwner",
						new Dictionary<int, string>
							{
								{1, "GetChannelId"},
								{2, "CreateChannel"},
								{3, "JoinChannel"},
								{4, "FindChannel"},
								{5, "GetChannelInfo"},
							}
						},
					{
						"ChannelSubscriber",
						new Dictionary<int, string>
							{
								{1, "NotifyAdd"},
								{2, "NotifyJoin"},
								{3, "NotifyRemove"},
								{4, "NotifyLeave"},
								{5, "NotifySendMessage"},
								{6, "NotifyUpdateChannelState"},
								{7, "NotifyUpdateMemberState"},
							}
						},
					{
						"ChannelInvitationService",
						new Dictionary<int, string>
							{
								{1, "Subscribe"},
								{2, "Unsubscribe"},
								{3, "SendInvitation"},
								{4, "AcceptInvitation"},
								{5, "DeclineInvitation"},
								{6, "RevokeInvitation"},
								{7, "SuggestInvitation"},
							}
						},
					{
						"ChannelInvitationNotify",
						new Dictionary<int, string>
							{
								{1, "NotifyReceivedInvitationAdded"},
								{2, "NotifyReceivedInvitationRemoved"},
								{3, "NotifyReceivedSuggestionAdded"},
								{4, "HasRoomForInvitation"},
							}
						},
					{
						"ChatService",
						new Dictionary<int, string>
							{
								{1, "FindChannel"},
								{2, "CreateChannel"},
								{3, "JoinChannel"},
							}
						},
					{
						"ExchangeService",
						new Dictionary<int, string>
							{
								{1, "CreateOrderBook"},
								{2, "PlaceOfferOnOrderBook"},
								{3, "PlaceOfferCreateOrderBookIfNeeded"},
								{4, "PlaceBidOnOrderBook"},
								{5, "PlaceBidCreateOrderBookIfNeeded"},
								{6, "QueryOffersByOrderBook"},
								{7, "QueryBidsByOrderBook"},
								{8, "QueryOffersByAccountForItem"},
								{9, "QueryBidsByAccountForItem"},
								{11, "QueryOrderBooksSummary"},
								{12, "QuerySettlementsByOrderBook"},
								{13, "ReportAuthorize"},
								{14, "ReportSettle"},
								{15, "ReportCancel"},
								{16, "SubscribeOrderBookStatusChange"},
								{17, "UnsubscribeOrderBookStatusChange"},
								{18, "SubscribeOrderStatusChange"},
								{19, "UnsubscribeOrderStatusChange"},
								{20, "GetPaymentMethods"},
								{21, "ClaimBidItem"},
								{22, "ClaimBidMoney"},
								{23, "ClaimOfferItem"},
								{24, "ClaimOfferMoney"},
								{25, "CancelBid"},
								{26, "CancelOffer"},
								{27, "GetConfiguration"},
								{28, "GetBidFeeEstimation"},
								{29, "GetOfferFeeEstimation"},
							}
						},
					{
						"ExchangeNotify",
						new Dictionary<int, string>
							{
								{1, "NotifyOrderBookStatusChange"},
								{2, "NotifyOfferStatusChange"},
								{3, "NotifyBidStatusChange"},
							}
						},
					{
						"FollowersService",
						new Dictionary<int, string>
							{
								{1, "SubscribeToFollowers"},
								{2, "StartFollowing"},
								{3, "StopFollowing"},
								{8, "UpdateFollowerState"},
							}
						},
					{
						"FollowersNotify",
						new Dictionary<int, string>
							{
								{1, "NotifyFollowerRemoved"},
							}
						},
					{
						"FriendsService",
						new Dictionary<int, string>
							{
								{1, "SubscribeToFriends"},
								{2, "SendInvitation"},
								{3, "AcceptInvitation"},
								{4, "RevokeInvitation"},
								{5, "DeclineInvitation"},
								{6, "IgnoreInvitation"},
								{7, "RemoveFriend"},
								{8, "ViewFriends"},
								{9, "UpdateFriendState"},
								{12, "UnsubscribeToFriends"},
							}
						},
					{
						"FriendsNotify",
						new Dictionary<int, string>
							{
								{1, "NotifyFriendAdded"},
								{2, "NotifyFriendRemoved"},
								{3, "NotifyReceivedInvitationAdded"},
								{4, "NotifyReceivedInvitationRemoved"},
								{5, "NotifySentInvitationRemoved"},
							}
						},
					{
						"GameMaster",
						new Dictionary<int, string>
							{
								{1, "JoinGame"},
								{2, "ListFactories"},
								{3, "FindGame"},
								{4, "CancelFindGame"},
								{5, "GameEnded"},
								{6, "PlayerLeft"},
								{7, "RegisterServer"},
								{8, "UnregisterServer"},
								{9, "RegisterUtilities"},
								{10, "UnregisterUtilities"},
								{11, "Subscribe"},
								{12, "Unsubscribe"},
								{13, "ChangeGame"},
								{14, "GetFactoryInfo"},
								{15, "GetGameStats"},
							}
						},
					{
						"GameMasterSubscriber",
						new Dictionary<int, string>
							{
								{1, "NotifyFactoryUpdate"},
							}
						},
					{
						"GameFactorySubscriber",
						new Dictionary<int, string>
							{
								{1, "NotifyGameFound"},
							}
						},
					{
						"GameUtilities",
						new Dictionary<int, string>
							{
								{1, "ProcessClientRequest"},
								{2, "CreateToon"},
								{3, "DeleteToon"},
								{4, "TransferToon"},
								{5, "SelectToon"},
								{6, "PresenceChannelCreated"},
								{7, "GetPlayerVariables"},
								{8, "GetGameVariables"},
								{9, "GetLoad"},
							}
						},
					{
						"NotificationService",
						new Dictionary<int, string>
							{
								{1, "SendNotification"},
								{2, "RegisterClient"},
								{3, "UnregisterClient"},
								{4, "FindClient"},
							}
						},
					{
						"NotificationListener",
						new Dictionary<int, string>
							{
								{1, "OnNotificationReceived"},
							}
						},
					{
						"PartyService",
						new Dictionary<int, string>
							{
								{1, "CreateChannel"},
								{2, "JoinChannel"},
								{3, "GetChannelInfo"},
							}
						},
					{
						"PresenceService",
						new Dictionary<int, string>
							{
								{1, "Subscribe"},
								{2, "Unsubscribe"},
								{3, "Update"},
								{4, "Query"},
							}
						},
					{
						"SearchService",
						new Dictionary<int, string>
							{
								{1, "FindMatches"},
								{2, "SetObject"},
								{3, "RemoveObjects"},
							}
						},
					{
						"ServerPoolService",
						new Dictionary<int, string>
							{
								{1, "GetPoolState"},
							}
						},
					{
						"StorageService",
						new Dictionary<int, string>
							{
								{1, "Execute"},
								{2, "OpenTable"},
								{3, "OpenColumn"},
							}
						},
					{
						"ToonServiceExternal",
						new Dictionary<int, string>
							{
								{1, "ToonList"},
								{2, "SelectToon"},
								{3, "CreateToon"},
								{4, "DeleteToon"},
							}
						},
					{
						"UserManagerService",
						new Dictionary<int, string>
							{
								{1, "SubscribeToUserManager"},
								{2, "ReportPlayer"},
								{3, "BlockPlayer"},
								{4, "RemovePlayerBlock"},
								{5, "AddRecentPlayers"},
								{6, "RemoveRecentPlayers"},
							}
						},
					{
						"UserManagerNotify",
						new Dictionary<int, string>
							{
								{1, "NotifyPlayerBlocked"},
								{2, "NotifyPlayerBlockRemoved"},
							}
						},
				};
    }
}
