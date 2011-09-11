@echo off
set path="C:\Program Files (x86)\protobuf-net\protobuf-net-VS9"

protogen -i:service/user_manager/user_manager.proto -o:csharp/service/user_manager/user_manager.cs
protogen -i:service/toon/toon.proto -o:csharp/service/toon/toon.cs
protogen -i:service/toon/toon_external.proto -o:csharp/service/toon/toon_external.cs
protogen -i:service/storage/storage.proto -o:csharp/service/storage/storage.cs
protogen -i:service/server_pool/server_pool.proto -o:csharp/service/server_pool/server_pool.cs
protogen -i:service/search/search.proto -o:csharp/service/search/search.cs
protogen -i:service/search/search_types.proto -o:csharp/service/search/search_types.cs
protogen -i:service/presence/presence.proto -o:csharp/service/presence/presence.cs
protogen -i:service/presence/presence_types.proto -o:csharp/service/presence/presence_types.cs
protogen -i:service/notification/notification.proto -o:csharp/service/notification/notification.cs
protogen -i:service/game_utilities/game_utilities.proto -o:csharp/service/game_utilities/game_utilities.cs
protogen -i:service/game_master/game_factory.proto -o:csharp/service/game_master/game_factory.cs
protogen -i:service/game_master/game_master.proto -o:csharp/service/game_master/game_master.cs
protogen -i:service/game_master/game_master_types.proto -o:csharp/service/game_master/game_master_types.cs
protogen -i:service/friends/friends_types.proto -o:csharp/service/friends/friends_types.cs
protogen -i:service/friends/definition/friends.proto -o:csharp/service/friends/definition/friends.cs
protogen -i:service/exchange/exchange.proto -o:csharp/service/exchange/exchange.cs
protogen -i:service/exchange/exchange_types.proto -o:csharp/service/exchange/exchange_types.cs
protogen -i:service/channel_invitation/channel_invitation_types.proto -o:csharp/service/channel_invitation/channel_invitation_types.cs
protogen -i:service/channel_invitation/definition/channel_invitation.proto -o:csharp/service/channel_invitation/definition/channel_invitation.cs
protogen -i:service/channel/channel_types.proto -o:csharp/service/channel/channel_types.cs
protogen -i:service/channel/definition/channel.proto -o:csharp/service/channel/definition/channel.cs
protogen -i:service/authentication/authentication.proto -o:csharp/service/authentication/authentication.cs
protogen -i:lib/rpc/connection.proto -o:csharp/lib/rpc/connection.cs
protogen -i:lib/rpc/rpc.proto -o:csharp/lib/rpc/rpc.cs
protogen -i:lib/protocol/attribute.proto -o:csharp/lib/protocol/attribute.cs
protogen -i:lib/protocol/content_handle.proto -o:csharp/lib/protocol/content_handle.cs
protogen -i:lib/protocol/descriptor.proto -o:csharp/lib/protocol/descriptor.cs
protogen -i:lib/protocol/entity.proto -o:csharp/lib/protocol/entity.cs
protogen -i:lib/protocol/exchange.proto -o:csharp/lib/protocol/exchange.cs
protogen -i:lib/protocol/exchange_object_provider.proto -o:csharp/lib/protocol/exchange_object_provider.cs
protogen -i:lib/protocol/invitation.proto -o:csharp/lib/protocol/invitation.cs
protogen -i:lib/protocol/resource.proto -o:csharp/lib/protocol/resource.cs
protogen -i:lib/profanity/profanity.proto -o:csharp/lib/profanity/profanity.cs
protogen -i:lib/config/process_config.proto -o:csharp/lib/config/process_config.cs
protogen -i:google/protobuf/descriptor.proto -o:csharp/google/protobuf/descriptor.cs
protogen -i:Items.proto -o:csharp/Items.cs
protogen -i:GBHandle.proto -o:csharp/GBHandle.cs
protogen -i:Quest.proto -o:csharp/Quest.cs
protogen -i:GameMessage.proto -o:csharp/GameMessage.cs
protogen -i:Hero.proto -o:csharp/Hero.cs
protogen -i:Settings.proto -o:csharp/Settings.cs
protogen -i:Stats.proto -o:csharp/Stats.cs
protogen -i:Hireling.proto -o:csharp/Hireling.cs
protogen -i:AttributeSerializer.proto -o:csharp/AttributeSerializer.cs
protogen -i:Account.proto -o:csharp/Account.cs
protogen -i:OnlineService.proto -o:csharp/OnlineService.cs
protogen -i:ItemCrafting.proto -o:csharp/ItemCrafting.cs
protogen -i:PartyMessage.proto -o:csharp/PartyMessage.cs
protogen -i:service/chat/definition/chat.proto -o:csharp/service/chat/definition/chat.cs
protogen -i:service/chat/definition/chat_types.proto -o:csharp/service/chat/definition/chat_types.cs
protogen -i:service/followers/definition/followers.proto -o:csharp/service/followers/definition/followers.cs
protogen -i:service/party/definition/party.proto -o:csharp/service/party/definition/party.cs

pause