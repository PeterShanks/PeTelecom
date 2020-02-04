using PeTelecome.BuildingBlocks.Domain;
using System;

namespace PeTelecome.Modules.UserAccess.Domain.Users
{
    public class UserId : TypedIdValueBase
    {
        public UserId(Guid value) : base(value)
        {
        }
    }
}
