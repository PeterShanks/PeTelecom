using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.BuildingBlocks.DependencyInjection.Contracts
{
    public enum Lifetime
    {
        Transient,
        Scoped,
        Singleton
    }
}
