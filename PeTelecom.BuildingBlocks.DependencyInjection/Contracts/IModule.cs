using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.BuildingBlocks.DependencyInjection.Contracts
{
    public interface IModule
    {
        void Initialize(IModuleRegistrar registrar);
    }
}
