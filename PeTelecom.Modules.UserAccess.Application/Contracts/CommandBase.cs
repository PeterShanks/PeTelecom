using PeTelecom.Modules.UserAccess.Application.Contracts;
using System;

namespace PeTelecom.Modules.UserAccess.Application.Configuration.Commands
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
