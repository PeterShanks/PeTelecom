using PeTelecome.Modules.UserAccess.Application.Configuration.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.Authorization.GetUserPermissions
{
    public class GetUserPermissionsQueryHandler : IQueryHandler<GetUserPermissionQuery, List<UserPermissionDto>>
    {
        private readonly IGetUserPermissionDatabaseQuery _getUserPermissionDatabaseQuery;

        public GetUserPermissionsQueryHandler(IGetUserPermissionDatabaseQuery getUserPermissionDatabaseQuery)
        {
            _getUserPermissionDatabaseQuery = getUserPermissionDatabaseQuery;
        }

        public async Task<List<UserPermissionDto>> Handle(GetUserPermissionQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserPermissionDto> userPermissions = await _getUserPermissionDatabaseQuery.GetUserPermissionsAsync(request.Id);

            return userPermissions.ToList();
        }
    }
}
