using System;

namespace PeTelecom.BuildingBlocks.Application.Configuration.Queries
{
    public class QueryBase<TResult> : IQuery<TResult>
    {
        public Guid Id { get; }

        protected QueryBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
