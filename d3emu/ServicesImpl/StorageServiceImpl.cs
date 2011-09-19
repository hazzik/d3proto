namespace d3emu.ServicesImpl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using D3.Account;
    using D3.Hero;
    using D3.OnlineService;
    using Google.ProtocolBuffers;
    using bnet.protocol.storage;
    using bnet.protocol.toon;
    using Digest = D3.Account.Digest;

    public class StorageServiceImpl : StorageService
    {
        private static Digest AccountDigest
        {
            get
            {
                Digest.Builder builder = Digest.CreateBuilder().SetVersion(99)
                    .SetBannerConfiguration(BannerConfiguration.CreateBuilder()
                                                .SetBackgroundColorIndex(0)
                                                .SetBannerIndex(3)
                                                .SetPattern(0)
                                                .SetPatternColorIndex(0)
                                                .SetPlacementIndex(0)
                                                .SetSigilAccent(0)
                                                .SetSigilMain(0)
                                                .SetSigilColorIndex(0)
                                                .SetUseSigilVariant(false)
                                                .Build())
                    .SetFlags(0)
                    .SetLastPlayedHeroId(EntityId.CreateBuilder().SetIdHigh(0).SetIdLow(0).Build());
                return builder.Build();
            }
        }

        public override void Execute(IRpcController controller, ExecuteRequest request, Action<ExecuteResponse> done)
        {
            ExecuteResponse.Builder response;
            switch (request.QueryName)
            {
                case "QueryAccountDigest":
                    response = GetAccountDigest(request);
                    break;
                case "LoadAccountDigest":
                    response = LoadAccountDigest(request);
                    break;
                case "GetHeroDigests":
                    response = GetHeroDigest(request);
                    break;
                default:
                    response = new ExecuteResponse.Builder();
                    break;
            }
            done(response.Build());
        }

        private static ExecuteResponse.Builder GetHeroDigest(ExecuteRequest request)
        {
            var results = new List<OperationResult>();

            foreach (Operation operation in request.OperationsList)
            {
                //var toonDigest = ToonHandle.ParseFrom(operation.RowId.Hash.ToByteArray().Skip(2).ToArray());

                OperationResult.Builder operationResult = OperationResult.CreateBuilder().SetTableId(operation.TableId);
                var value = new EntityId.Builder
                                          {
                                              
                                              IdHigh = 0x300016200004433,
                                              IdLow = 2
                                          };
                operationResult.AddData(
                    Cell.CreateBuilder()
                        .SetColumnId(operation.ColumnId)
                        .SetRowId(operation.RowId)
                        .SetVersion(1)
                        .SetData(D3.Hero.Digest.CreateBuilder().SetVersion(891)
                                     .SetHeroId(value)
                                     .SetHeroName("hazzik")
                                     .SetGbidClass(0)
                                     .SetPlayerFlags(0)
                                     .SetLevel(1)
                                     .SetVisualEquipment(new VisualEquipment.Builder().Build())
                                     .SetLastPlayedAct(0)
                                     .SetHighestUnlockedAct(0)
                                     .SetLastPlayedDifficulty(0)
                                     .SetHighestUnlockedDifficulty(0)
                                     .SetLastPlayedQuest(-1)
                                     .SetLastPlayedQuestStep(-1)
                                     .SetTimePlayed(0)
                                     .Build()
                                     .ToByteString())
                        .Build()
                    );
                results.Add(operationResult.Build());
            }

            ExecuteResponse.Builder builder = ExecuteResponse.CreateBuilder();
            foreach (OperationResult result in results)
            {
                builder.AddResults(result);
            }
            return builder;
        }

        private static ExecuteResponse.Builder LoadAccountDigest(ExecuteRequest request)
        {
            ExecuteResponse.Builder builder = ExecuteResponse.CreateBuilder();
            foreach (OperationResult result in request.OperationsList.Select(operation => CreateOperationResult(operation, 1, AccountDigest.ToByteString())))
            {
                builder.AddResults(result);
            }
            return builder;
        }

        private static OperationResult CreateOperationResult(Operation operation, ulong version, ByteString data)
        {
            var operationResult = new OperationResult.Builder
                                      {
                                          TableId = operation.TableId
                                      };
            operationResult.AddData(
                new Cell.Builder
                    {
                        ColumnId = operation.ColumnId,
                        RowId = operation.RowId,
                        Version = version,
                        Data = data
                    }.Build());
            return operationResult.Build();
        }

        private ExecuteResponse.Builder GetAccountDigest(ExecuteRequest request)
        {
            ExecuteResponse.Builder builder = ExecuteResponse.CreateBuilder();
            foreach (OperationResult result in request.OperationsList.Select(operation => CreateOperationResult(operation, 1, AccountDigest.ToByteString())))
            {
                builder.AddResults(result);
            }
            return builder;
        }

        public override void OpenTable(IRpcController controller, OpenTableRequest request, Action<OpenTableResponse> done)
        {
            var response = new OpenTableResponse.Builder
                               {
                               };
            done(response.Build());
        }

        public override void OpenColumn(IRpcController controller, OpenColumnRequest request, Action<OpenColumnResponse> done)
        {
            var response = new OpenColumnResponse.Builder
                               {
                               };
            done(response.Build());
        }
    }
}
