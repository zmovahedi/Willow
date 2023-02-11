using Willow.Core.Contracts.ApplicationService.Common;
using Willow.Core.Contracts.ApplicationService.Queries;
using Willow.Utilities;

namespace Willow.Core.ApplicationService.Queries
{
    public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
    {
        protected readonly WillowService _willowService;
        protected readonly QueryResult<TData> result = new();

        protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
        {
            result._data = data;
            result.Status = status;
            return Task.FromResult(result);
        }

        protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)
        {
            result._data = data;
            result.Status = status;
            return result;
        }

        protected virtual Task<QueryResult<TData>> ResultAsync(TData data)
        {
            var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
            return ResultAsync(data, status);
        }

        protected virtual QueryResult<TData> Result(TData data)
        {
            var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
            return Result(data, status);
        }

        public QueryHandler(WillowService willowService)
        {
            _willowService = willowService;
        }

        protected void AddMessage(string message)
        {
            result.AddMessage(_willowService.Translator[message]);
        }

        protected void AddMessage(string message, params string[] arguments)
        {
            result.AddMessage(_willowService.Translator[message, arguments]);
        }

        public abstract Task<QueryResult<TData>> Handle(TQuery query);
    }
}
