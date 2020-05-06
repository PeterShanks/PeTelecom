using System;
using Quartz.Logging;
using Serilog;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs
{
    internal class SerilogLogProvider : ILogProvider
    {
        private readonly ILogger _logger;

        public SerilogLogProvider(ILogger logger)
        {
            _logger = logger;
        }
        public Logger GetLogger(string name)
        {
            return (level, func, exception, parameters) =>
            {
                if (func == null)
                {
                    return true;
                }

                switch (level)
                {
                    case LogLevel.Debug:
                    case LogLevel.Trace:
                        _logger.Debug(exception, func(), parameters);
                        break;
                    case LogLevel.Info:
                        _logger.Information(exception, func(), parameters);
                        break;
                    case LogLevel.Warn:
                        _logger.Warning(exception, func(), parameters);
                        break;
                    case LogLevel.Error:
                        _logger.Error(exception, func(), parameters);
                        break;
                    case LogLevel.Fatal:
                        _logger.Fatal(exception, func(), parameters);
                        break;
                    default:
                        throw new ArgumentException("Unsupported LogLevel", nameof(level));
                }

                return true;
            };
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenMappedContext(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
