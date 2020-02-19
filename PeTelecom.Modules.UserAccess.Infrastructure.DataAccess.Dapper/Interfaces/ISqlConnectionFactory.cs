using System.Data;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.Dapper.Interfaces
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
