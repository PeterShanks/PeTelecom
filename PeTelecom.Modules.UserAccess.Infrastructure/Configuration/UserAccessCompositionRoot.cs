using System;
using System.Threading;
using PeTelecom.BuildingBlocks.Infrastructure;


namespace PeTelecom.Modules.UserAccess.Infrastructure.Configuration
{
    internal class UserAccessCompositionRoot : CompositionRootBase, IServiceProvider
    {
        private static readonly Lazy<UserAccessCompositionRoot> LazySingleton = 
            new Lazy<UserAccessCompositionRoot>(() => new UserAccessCompositionRoot());

        public static UserAccessCompositionRoot CompositionRoot => LazySingleton.Value;

        public CancellationToken ServicesCancellationToken { get; }

        private UserAccessCompositionRoot()
        {
            var cts = new CancellationTokenSource();
            ServicesCancellationToken = cts.Token;
        }

        public object GetService(Type type)
        {
            return Container.GetInstance(type);
        }
    }
}
