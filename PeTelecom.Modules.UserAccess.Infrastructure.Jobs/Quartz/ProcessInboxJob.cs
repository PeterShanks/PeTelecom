using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Application.Inbox;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs.Quartz
{
    internal class ProcessInboxJob : Job<ProcessInboxCommand>
    {
        public ProcessInboxJob(ICommandExecutor commandExecutor) : base(commandExecutor)
        {
        }
    }
}
