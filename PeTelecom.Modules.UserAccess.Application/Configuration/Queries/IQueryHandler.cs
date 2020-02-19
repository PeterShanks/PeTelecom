using MediatR;
using PeTelecom.Modules.UserAccess.Application.Contracts;

namespace PeTelecom.Modules.UserAccess.Application.Configuration.Queries
{
    interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery: IQuery<TResult>
    {
    }
}
