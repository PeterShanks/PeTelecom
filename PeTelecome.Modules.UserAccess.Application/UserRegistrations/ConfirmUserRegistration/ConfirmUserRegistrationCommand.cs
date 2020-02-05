using PeTelecome.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecome.Modules.UserAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    public class ConfirmUserRegistrationCommand: CommandBase
    {
        public UserRegistrationId UserRegistrationId { get; }

        public ConfirmUserRegistrationCommand(UserRegistrationId userRegistrationId)
        {
            UserRegistrationId = userRegistrationId;
        }
    }
}
