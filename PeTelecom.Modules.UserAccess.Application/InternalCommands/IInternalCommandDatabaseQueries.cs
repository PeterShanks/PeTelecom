using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.InternalCommands
{
    public interface IInternalCommandDatabaseQueries
    {
        Task<IEnumerable<InternalCommandDto>> GetInternalCommands();
    }
}