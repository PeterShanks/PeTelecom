using System;
using System.Collections.Generic;
using System.Text;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using PeTelecom.BuildingBlocks.Infrastructure;
using PeTelecom.Modules.UserAccess.Application.Contracts;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.Register<ICommandExecutor, CommandExecutor>(Lifetime.Scoped);
            registrar.Register<IScopeService, UserAccessCompositionRoot>(Lifetime.Scoped);
            registrar.Register<IUserAccessModule, UserAccessModule>(Lifetime.Scoped);
        }
    }
}
