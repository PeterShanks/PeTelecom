using MediatR;
using PeTelecom.BuildingBlocks.Application;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Application.Contracts;
using Serilog;
using Serilog.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Processing
{
    internal class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ILogger _logger;
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly ICommandHandler<TCommand> _decorated;

        public LoggingCommandHandlerDecorator(ILogger logger,
            IExecutionContextAccessor executionContextAccessor,
            ICommandHandler<TCommand> decorated)
        {
            _logger = logger;
            _executionContextAccessor = executionContextAccessor;
            _decorated = decorated;
        }
        public async Task<Unit> Handle(TCommand command, CancellationToken cancellationToken)
        {
            if (command is IRecurringCommand)
            {
                await _decorated.Handle(command, cancellationToken);
            }

            using (LogContext.Push(
                new RequestLogEnricher(_executionContextAccessor),
                new CommandLogEnricher(command)
                ))
            {
                try
                {
                    _logger.Information("Executing command {Command}", command.GetType().Name);

                    var result = await _decorated.Handle(command, cancellationToken);

                    _logger.Information("Command {Command} processed successful", command.GetType().Name);

                    return result;
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Command {Command} processing failed", command.GetType().Name);
                    throw;
                }
            }
        }
    }
}
