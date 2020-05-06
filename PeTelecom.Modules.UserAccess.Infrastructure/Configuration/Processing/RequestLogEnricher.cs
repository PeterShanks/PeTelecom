using PeTelecom.BuildingBlocks.Application;
using Serilog.Core;
using Serilog.Events;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Processing
{
    internal class RequestLogEnricher : ILogEventEnricher
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public RequestLogEnricher(IExecutionContextAccessor executionContextAccessor)
        {
            _executionContextAccessor = executionContextAccessor;
        }
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (_executionContextAccessor.IsAvailable)
                logEvent.AddOrUpdateProperty(
                    new LogEventProperty(
                        nameof(IExecutionContextAccessor.CorrelationId),
                        new ScalarValue(_executionContextAccessor.CorrelationId)
                        ));
        }
    }
}
