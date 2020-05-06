using MediatR;

namespace PeTelecom.BuildingBlocks.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery: IQuery<TResult>
    {
    }
}
