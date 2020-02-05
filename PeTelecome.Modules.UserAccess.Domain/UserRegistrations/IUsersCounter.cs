using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Domain.UserRegistrations
{
    public interface IUsersCounter
    {
        int CountUsersWithLogin(string login);
    }
}
