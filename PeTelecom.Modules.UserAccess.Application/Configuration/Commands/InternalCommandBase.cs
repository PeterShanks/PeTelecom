using PeTelecom.Modules.UserAccess.Application.Contracts;
using System;

namespace PeTelecom.Modules.UserAccess.Application.Configuration.Commands
{
    public class InternalCommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }

        protected InternalCommandBase() : this(Guid.NewGuid())
        {
        }

        private InternalCommandBase(Guid guid)
        {
            Id = guid;
        }
    }

    public class InternalCommandBase : ICommand
    {
        public Guid Id { get; }

        protected InternalCommandBase() : this(Guid.NewGuid())
        {
        }
        private InternalCommandBase(Guid guid)
        {
            Id = guid;
        }
    }
}
