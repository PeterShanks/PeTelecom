using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Application.InternalCommands;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs.Quartz
{
    internal class ProcessInternalCommandsJob : Job<ProcessInternalCommandsCommand>
    {
        public ProcessInternalCommandsJob(ICommandExecutor commandExecutor) : base(commandExecutor)
        {
        }
    }
}
