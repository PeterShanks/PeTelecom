using PeTelecom.Modules.UserAccess.Application.Contracts;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.Configuration.Commands
{
    public interface ICommandScheduler
    {
        Task EnqueueAsync(ICommand command);
        Task EnqueueAsync<TCommand, TResult>(ICommand<TResult> command);
    }
}
