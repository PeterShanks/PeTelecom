using PeTelecom.BuildingBlocks.Application;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Processing
{
    internal class LoggingCommandHandlerWithResultDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        private readonly ILogger _logger;
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly ICommandHandler<TCommand, TResult> _decorated;
        public LoggingCommandHandlerWithResultDecorator(ILogger logger,
            IExecutionContextAccessor executionContextAccessor,
            ICommandHandler<TCommand, TResult> decorated)
        {
            _logger = logger;
            _executionContextAccessor = executionContextAccessor;
            _decorated = decorated;
        }
        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
        {
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

        private class CommandLogEnricher : ILogEventEnricher
        {
            private readonly ICommand<TResult> _command;

            public CommandLogEnricher(ICommand<TResult> command)
            {
                _command = command;
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                logEvent.AddOrUpdateProperty(new LogEventProperty(
                    "Context",
                    new ScalarValue($"Command: {_command.Id}")
                ));
            }
        }
    }
}
