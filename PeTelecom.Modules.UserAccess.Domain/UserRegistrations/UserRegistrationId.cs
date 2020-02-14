using PeTelecom.BuildingBlocks.Domain;
using System;

namespace PeTelecom.Modules.UserAccess.Domain.UserRegistrations
{
    public class UserRegistrationId : TypedIdValueBase
    {
        public UserRegistrationId(Guid value) : base(value)
        {
        }
    }
}
