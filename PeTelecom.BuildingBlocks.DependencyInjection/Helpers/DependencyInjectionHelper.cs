using System;
using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using SimpleInjector;

namespace PeTelecom.BuildingBlocks.DependencyInjection.Helpers
{
    internal static class DependencyInjectionHelper
    {
        public static Lifestyle ToLifeStyle(this Lifetime lifetime)
        {
            return lifetime switch
            {
                Lifetime.Scoped => Lifestyle.Scoped,
                Lifetime.Singleton => Lifestyle.Singleton,
                Lifetime.Transient => Lifestyle.Transient,
                _ => throw new ArgumentException("Unsupported lifetime scope", nameof(Lifetime)),
            };
        }
    }
}
