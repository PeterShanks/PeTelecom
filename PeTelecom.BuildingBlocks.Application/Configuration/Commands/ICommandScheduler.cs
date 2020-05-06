using System.Threading.Tasks;

namespace PeTelecom.BuildingBlocks.Application.Configuration.Commands
{
    public interface ICommandScheduler
    {
        Task EnqueueAsync(ICommand command);

        Task EnqueueAsync<TResult>(ICommand<TResult> command);
    }
}
