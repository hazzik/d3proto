namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.attribute;
    using bnet.protocol.game_master;
    using Attribute = bnet.protocol.attribute.Attribute;

    public class GameMasterImpl : GameMaster
    {
        public override void JoinGame(IRpcController controller, JoinGameRequest request, Action<JoinGameResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void ListFactories(IRpcController controller, ListFactoriesRequest request, Action<ListFactoriesResponse> done)
        {
            GameFactoryDescription.Builder description = GameFactoryDescription.CreateBuilder().SetId(14249086168335147635);

            var atributes = new[]
                                {
                                    Attribute.CreateBuilder().SetName("min_players").SetValue(Variant.CreateBuilder().SetIntValue(2)).Build(),
                                    Attribute.CreateBuilder().SetName("max_players").SetValue(Variant.CreateBuilder().SetIntValue(4)).Build(),
                                    Attribute.CreateBuilder().SetName("num_teams").SetValue(Variant.CreateBuilder().SetIntValue(1)).Build(),
                                    Attribute.CreateBuilder().SetName("version").SetValue(Variant.CreateBuilder().SetStringValue("0.3.0")).Build()
                                };

            description.AddRangeAttribute(atributes);
            description.AddStatsBucket(GameStatsBucket.CreateBuilder()
                                           .SetBucketMin(0)
                                           .SetBucketMax(4294967296F)
                                           .SetWaitMilliseconds(1354)
                                           .SetGamesPerHour(0)
                                           .SetActiveGames(1)
                                           .SetActivePlayers(1)
                                           .SetFormingGames(0)
                                           .SetWaitingPlayers(0).Build());

            ListFactoriesResponse response = ListFactoriesResponse.CreateBuilder().AddDescription(description).SetTotalResults(1).Build();
            done(response);
        }

        public override void FindGame(IRpcController controller, FindGameRequest request, Action<FindGameResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void CancelFindGame(IRpcController controller, CancelFindGameRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void GameEnded(IRpcController controller, GameEndedNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void PlayerLeft(IRpcController controller, PlayerLeftNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void RegisterServer(IRpcController controller, RegisterServerRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void UnregisterServer(IRpcController controller, UnregisterServerRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void RegisterUtilities(IRpcController controller, RegisterUtilitiesRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void UnregisterUtilities(IRpcController controller, UnregisterUtilitiesRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void Subscribe(IRpcController controller, SubscribeRequest request, Action<SubscribeResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void Unsubscribe(IRpcController controller, UnsubscribeRequest request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }

        public override void ChangeGame(IRpcController controller, ChangeGameRequest request, Action<NoData> done)
        {
            throw new NotImplementedException();
        }

        public override void GetFactoryInfo(IRpcController controller, GetFactoryInfoRequest request, Action<GetFactoryInfoResponse> done)
        {
            throw new NotImplementedException();
        }

        public override void GetGameStats(IRpcController controller, GetGameStatsRequest request, Action<GetGameStatsResponse> done)
        {
            throw new NotImplementedException();
        }
    }
}