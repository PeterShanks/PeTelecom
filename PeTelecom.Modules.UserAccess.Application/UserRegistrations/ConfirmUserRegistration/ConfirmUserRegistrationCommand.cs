using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration
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
