using MediatR;
using PeTelecom.Modules.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.Modules.UserAccess.Application.Configuration.Queries
{
    interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery: IQuery<TResult>
    {
    }
}
