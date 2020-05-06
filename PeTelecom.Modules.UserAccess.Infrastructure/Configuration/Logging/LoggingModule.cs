using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using Serilog;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Logging
{
    internal class LoggingModule : IModule
    {
        private readonly ILogger _logger;

        public LoggingModule(ILogger logger)
        {
            _logger = logger;
        }
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.Register(() => _logger, Lifetime.Singleton);
        }
    }
}
