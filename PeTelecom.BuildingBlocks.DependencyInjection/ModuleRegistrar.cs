using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Reflection;
using PeTelecom.BuildingBlocks.DependencyInjection.Helpers;

namespace PeTelecom.BuildingBlocks.DependencyInjection
{
    public class ModuleRegistrar : IModuleRegistrar
    {
        private readonly Container _container;

        public ModuleRegistrar(Container container)
        {
            _container = container;
        }
        public IModuleRegistrar Register<TFrom, TTo>(Lifetime lifetime) where TFrom : class where TTo : class, TFrom
        {
            _container.Register<TFrom, TTo>(lifetime.ToLifeStyle());

            return this;
        }

        public IModuleRegistrar Register<T>(Func<T> instanceCreator, Lifetime lifetime) where T: class
        {
            _container.Register(instanceCreator, lifetime.ToLifeStyle());

            return this;
        }

        public IModuleRegistrar Register(Type openGenericServiceType, Assembly assembly, Lifetime lifetime)
        {
            _container.Register(openGenericServiceType, assembly, lifetime.ToLifeStyle());

            return this;
        }

        public IModuleRegistrar Register<T>(Lifetime lifetime)
            where T : class
        {
            _container.Register<T>(Lifestyle.Scoped);
            return this;
        }

        public IModuleRegistrar Register(IEnumerable<Registry> registries, Lifetime lifetime)
        {
            var lifestyle = lifetime.ToLifeStyle();
            foreach (var registry in registries)
            {
                _container.Register(registry.Service, registry.Implementation, lifestyle);
            }

            return this;
        }
    }
}
