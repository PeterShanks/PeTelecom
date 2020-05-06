using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using Serilog.Core;
using Serilog.Events;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Processing
{
    internal class CommandLogEnricher : ILogEventEnricher
    {
        private readonly ICommand _command;

        public CommandLogEnricher(ICommand command)
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
