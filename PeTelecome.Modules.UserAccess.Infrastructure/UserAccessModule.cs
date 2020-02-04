using PeTelecome.Modules.UserAccess.Application.Contracts;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Infrastructure
{
    public class UserAccessModule : IUserAccessModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            throw new System.NotImplementedException();
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            throw new System.NotImplementedException();
        }
    }
}
