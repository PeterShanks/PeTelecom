﻿using System.Threading;
using System.Threading.Tasks;

namespace PeTelecome.BuildingBlocks.Domain
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
