using PeTelecom.BuildingBlocks.Domain;
using System;

namespace PeTelecom.Modules.UserAccess.Domain.Users
{
    public class UserId : TypedIdValueBase
    {
        public UserId(Guid value) : base(value)
        {
        }
    }
}
