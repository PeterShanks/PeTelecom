using MediatR;
using PeTelecome.Modules.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Application.Configuration.Queries
{
    interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery: IQuery<TResult>
    {
    }
}
