using System;
using System.Reflection;

namespace PeTelecom.BuildingBlocks.DependencyInjection.Contracts
{
    public class Registry
    {
        public Type Service { get; set; }
        public Type Implementation { get; set; }
    }
}