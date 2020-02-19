using System;
using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using SimpleInjector;

namespace PeTelecom.BuildingBlocks.DependencyInjection
{
    internal class ModuleRegistrar : IModuleRegistrar
    {
        private readonly Container _container;

        public ModuleRegistrar(Container container)
        {
            _container = container;
        }

        public void RegisterType<TFrom, TTo>(Lifetime lifetime) where TFrom : class where TTo : class, TFrom
        {
            Lifestyle lifestyle = lifetime switch
            {
                Lifetime.Scoped => Lifestyle.Scoped,
                Lifetime.Singleton => Lifestyle.Singleton,
                Lifetime.Transient => Lifestyle.Transient,
                _ => throw new ArgumentException("Unsupported lifetime scope", nameof(Lifetime)),
            };
            _container.Register<TFrom, TTo>(lifestyle);
        }
    }
}
