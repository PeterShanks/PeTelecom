using MediatR;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.BuildingBlocks.Application.Configuration.Queries;
using PeTelecom.BuildingBlocks.Infrastructure;
using PeTelecom.Modules.UserAccess.Application.Contracts;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Infrastructure
{
    public class UserAccessModule : IUserAccessModule
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMediator _mediator;
        private readonly IScopeService _scope;

        public UserAccessModule(ICommandExecutor commandExecutor, IMediator mediator, IScopeService scope)
        {
            _commandExecutor = commandExecutor;
            _mediator = mediator;
            _scope = scope;
        }

        public Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return _commandExecutor.Execute(command);
        }

        public Task ExecuteCommandAsync(ICommand command)
        {
            return _commandExecutor.Execute(command);
        }

        public Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (_scope.BeginScope())
            {
                return _mediator.Send(query);
            }
        }
    }
}
