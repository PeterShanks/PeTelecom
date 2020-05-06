using System.Threading.Tasks;
using MediatR;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.BuildingBlocks.Infrastructure;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Processing
{
    internal class CommandExecutor : ICommandExecutor
    {
        private readonly IMediator _mediator;
        private readonly IScopeService _scope;

        public CommandExecutor(IMediator mediator, IScopeService scope)
        {
            _mediator = mediator;
            _scope = scope;
        }

        public async Task Execute(ICommand command)
        {
            using (_scope.BeginScope())
            {
                await _mediator.Send(command);
            }
        }

        public async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (_scope.BeginScope())
            {
                return await _mediator.Send(command);
            }
        }
    }
}
