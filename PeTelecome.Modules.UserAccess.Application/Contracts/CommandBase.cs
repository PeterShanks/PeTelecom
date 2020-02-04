using System;

namespace PeTelecome.Modules.UserAccess.Application.Contracts
{
    public class CommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }

        protected CommandBase() : this(Guid.NewGuid())
        {
        }

        private CommandBase(Guid guid)
        {
            Id = guid;
        }
    }

    public class CommandBase : ICommand
    {
        public Guid Id { get; }

        protected CommandBase() : this(Guid.NewGuid())
        {
        }
        private CommandBase(Guid guid)
        {
            Id = guid;
        }
    }
}
