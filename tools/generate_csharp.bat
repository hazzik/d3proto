@echo off

protogen --proto_path=./ Account.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ AttributeSerializer.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ GameMessage.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ GBHandle.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ Hero.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ Hireling.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ ItemCrafting.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ Items.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ OnlineService.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ PartyMessage.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ Quest.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ Settings.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ Stats.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ google/protobuf/descriptor.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/config/process_config.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/profanity/profanity.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/protocol/attribute.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/protocol/content_handle.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/protocol/descriptor.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/protocol/entity.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/protocol/exchange.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/protocol/exchange_object_provider.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/protocol/invitation.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/protocol/resource.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/rpc/connection.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ lib/rpc/rpc.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/authentication/authentication.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/chat/definition/chat.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/chat/definition/chat_types.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/followers/definition/followers.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/party/definition/party.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/channel/definition/channel.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/channel/channel_types.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/channel_invitation/definition/channel_invitation.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/channel_invitation/channel_invitation_types.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/exchange/exchange.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/exchange/exchange_types.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/friends/definition/friends.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/friends/friends_types.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/game_master/game_factory.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/game_master/game_master.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/game_master/game_master_types.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/game_utilities/game_utilities.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/notification/notification.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/presence/presence.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/presence/presence_types.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/search/search.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/search/search_types.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/server_pool/server_pool.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/storage/storage.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/toon/toon.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/toon/toon_external.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp
protogen --proto_path=./ service/user_manager/user_manager.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp

pause