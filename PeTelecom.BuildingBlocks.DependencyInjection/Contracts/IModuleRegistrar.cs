using System;
using System.Collections.Generic;
using System.Reflection;

namespace PeTelecom.BuildingBlocks.DependencyInjection.Contracts
{
    public interface IModuleRegistrar
    {
        IModuleRegistrar Register<TFrom, TTo>(Lifetime lifetime)
            where TFrom : class
            where TTo : class, TFrom;


        IModuleRegistrar Register<T>(Func<T> instanceCreator, Lifetime lifetime) 
            where T : class;

        IModuleRegistrar Register(Type openGenericServiceType, Assembly assembly, Lifetime lifetime);

        IModuleRegistrar Register<T>(Lifetime lifetime)
            where T : class;

        IModuleRegistrar Register(IEnumerable<Registry> registries, Lifetime lifetime);
    }
}
