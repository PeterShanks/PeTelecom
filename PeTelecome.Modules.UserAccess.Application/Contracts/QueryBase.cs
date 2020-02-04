using System;

namespace PeTelecome.Modules.UserAccess.Application.Contracts
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
