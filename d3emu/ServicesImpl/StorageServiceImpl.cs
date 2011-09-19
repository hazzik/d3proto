namespace d3emu.ServicesImpl
{
    using System;
    using System.Linq;
    using D3.Account;
    using D3.OnlineService;
    using Google.ProtocolBuffers;
    using bnet.protocol.storage;

    public class StorageServiceImpl : StorageService
    {
        private static Digest Digest
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
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(request);
            Console.ForegroundColor = foregroundColor;
            ExecuteResponse.Builder response;
            switch (request.QueryName)
            {
                case "QueryAccountDigest":
                    response = GetAccountDigest(request);
                    break;
                case "LoadAccountDigest":
                    response = LoadAccountDigest(request);
                    break;
                default:
                    response = new ExecuteResponse.Builder();
                    break;
            }
            done(response.Build());
        }

        private ExecuteResponse.Builder LoadAccountDigest(ExecuteRequest request)
        {
            ExecuteResponse.Builder builder = ExecuteResponse.CreateBuilder();
            foreach (OperationResult result in request.OperationsList.Select(operation => CreateOperationResult(operation, 1, Digest.ToByteString())))
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
            foreach (OperationResult result in request.OperationsList.Select(operation => CreateOperationResult(operation, 1, Digest.ToByteString())))
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