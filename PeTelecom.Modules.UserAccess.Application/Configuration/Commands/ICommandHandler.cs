using MediatR;
using PeTelecom.Modules.UserAccess.Application.Contracts;

namespace PeTelecom.Modules.UserAccess.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> : 
        IRequestHandler<TCommand, TResult> where TCommand: ICommand<TResult>
    {

    }
}
