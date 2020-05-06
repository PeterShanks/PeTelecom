using System;
using MediatR;

namespace PeTelecom.BuildingBlocks.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}
