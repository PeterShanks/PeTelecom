using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Application.Outbox;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Jobs.Quartz
{
    internal class ProcessOutboxJob : Job<ProcessOutboxCommand>
    {
        public ProcessOutboxJob(ICommandExecutor commandExecutor) : base(commandExecutor)
        {
        }
    }
}
