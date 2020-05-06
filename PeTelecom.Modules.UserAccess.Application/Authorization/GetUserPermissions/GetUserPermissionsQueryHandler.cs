using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PeTelecom.BuildingBlocks.Application.Configuration.Queries;
using PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate;

namespace PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions
{
    public class GetUserPermissionsQueryHandler : IQueryHandler<GetUserPermissionQuery, List<UserPermissionDto>>
    {
        private readonly IUserDatabaseQueries _databaseQueries;

        public GetUserPermissionsQueryHandler(IUserDatabaseQueries databaseQueries)
        {
            _databaseQueries = databaseQueries;
        }

        public async Task<List<UserPermissionDto>> Handle(GetUserPermissionQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserPermissionDto> userPermissions = await _databaseQueries.GetUserPermissionsAsync(request.Id);

            return userPermissions.ToList();
        }
    }
}
