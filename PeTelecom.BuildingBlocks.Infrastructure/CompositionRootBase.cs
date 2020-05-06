using System;
using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeTelecom.BuildingBlocks.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace PeTelecom.BuildingBlocks.Infrastructure
{
    public abstract class CompositionRootBase: IScopeService
    {
        protected readonly Container Container;
        protected readonly IModuleRegistrar ModuleRegistrar;
        protected readonly List<IModule> Modules;

        protected CompositionRootBase()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            ModuleRegistrar = new ModuleRegistrar(Container);
            Modules = new List<IModule>();
        }

        public virtual void AddModule(IModule module)
        {
            Modules.Add(module);
        }

        public virtual void BuildContainer()
        {
            foreach (var module in Modules)
            {
                module.Initialize(ModuleRegistrar);
            }

            Container.Verify(VerificationOption.VerifyAndDiagnose);
        }

        public virtual IDisposable BeginScope()
        {
            return AsyncScopedLifestyle.BeginScope(Container);
        }
    }
}
