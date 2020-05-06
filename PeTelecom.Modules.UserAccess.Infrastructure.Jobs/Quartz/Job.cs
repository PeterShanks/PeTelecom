using System.Threading.Tasks;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using Quartz;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs.Quartz
{
    [DisallowConcurrentExecution]
    internal class Job<TCommand> : IJob
        where TCommand : ICommand, new()
    {
        private readonly ICommandExecutor _commandExecutor;

        public Job(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await _commandExecutor.Execute(new TCommand());
        }
    }
}
