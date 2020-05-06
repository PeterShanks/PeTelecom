using System.Threading.Tasks;

namespace PeTelecom.BuildingBlocks.Application.Configuration.Commands
{
    public interface ICommandExecutor
    {
        Task Execute(ICommand command);
        Task<TResult> Execute<TResult>(ICommand<TResult> command);
    }
}