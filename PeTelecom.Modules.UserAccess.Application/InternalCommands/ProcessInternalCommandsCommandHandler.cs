using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;

namespace PeTelecom.Modules.UserAccess.Application.InternalCommands
{
    internal class ProcessInternalCommandsCommandHandler : ICommandHandler<ProcessInternalCommandsCommand>
    {
        private readonly IInternalCommandDatabaseQueries _internalCommandDatabaseQueries;
        private readonly ICommandExecutor _commandExecutor;

        public ProcessInternalCommandsCommandHandler(IInternalCommandDatabaseQueries internalCommandDatabaseQueries, ICommandExecutor commandExecutor)
        {
            _internalCommandDatabaseQueries = internalCommandDatabaseQueries;
            _commandExecutor = commandExecutor;
        }

        public async Task<Unit> Handle(ProcessInternalCommandsCommand request, CancellationToken cancellationToken)
        {
            var internalCommands =
                await _internalCommandDatabaseQueries.GetInternalCommands();

            foreach (var internalCommand in internalCommands)
            {
                var type = typeof(ProcessInternalCommandsCommandHandler).Assembly
                    .GetType(internalCommand.Type);

                var command = JsonSerializer.Deserialize(internalCommand.Data, type) as ICommand;

                await _commandExecutor.Execute(command);
            }

            return Unit.Value;
        }
    }
}
