using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.BuildingBlocks.DependencyInjection.Contracts
{
    public interface IModuleRegistrar
    {
        void RegisterType<TFrom, TTo>(Lifetime lifetime)
            where TFrom : class
            where TTo : class, TFrom;
    }
}
