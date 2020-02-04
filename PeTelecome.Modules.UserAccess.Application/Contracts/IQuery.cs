using MediatR;
using System;

namespace PeTelecome.Modules.UserAccess.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}
