using System;

namespace PeTelecom.BuildingBlocks.Infrastructure
{
    public interface IScopeService
    {
        IDisposable BeginScope();
    }
}