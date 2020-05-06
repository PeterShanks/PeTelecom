using System.Threading.Tasks;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.BuildingBlocks.Application.Configuration.Queries;

namespace PeTelecom.Modules.UserAccess.Application.Contracts
{
    public interface IUserAccessModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
