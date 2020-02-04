using PeTelecome.BuildingBlocks.Domain;
using System;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations
{
    public class UserRegistrationId : TypedIdValueBase
    {
        public UserRegistrationId(Guid value) : base(value)
        {
        }
    }
}
