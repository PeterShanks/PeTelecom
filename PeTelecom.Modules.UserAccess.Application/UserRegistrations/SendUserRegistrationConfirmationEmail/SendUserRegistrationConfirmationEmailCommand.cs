using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    internal class SendUserRegistrationConfirmationEmailCommand : InternalCommandBase
    {
        public SendUserRegistrationConfirmationEmailCommand(UserRegistrationId userRegistrationId, string email)
        {
            UserRegistrationId = userRegistrationId;
            Email = email;
        }

        public UserRegistrationId UserRegistrationId { get; }
        public string Email { get; }
    }
}
