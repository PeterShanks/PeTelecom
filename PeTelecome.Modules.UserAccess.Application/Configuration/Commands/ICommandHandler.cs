using MediatR;
using PeTelecome.Modules.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> : 
        IRequestHandler<TCommand, TResult> where TCommand: ICommand<TResult>
    {

    }
}
