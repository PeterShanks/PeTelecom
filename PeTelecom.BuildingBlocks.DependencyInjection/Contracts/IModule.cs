namespace PeTelecom.BuildingBlocks.DependencyInjection.Contracts
{
    public interface IModule
    {
        void Initialize(IModuleRegistrar registrar);
    }
}
