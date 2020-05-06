using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Application.Contracts;

namespace PeTelecom.Modules.UserAccess.Application.Outbox
{
    public class ProcessOutboxCommand : CommandBase, IRecurringCommand
    {
    }
}
