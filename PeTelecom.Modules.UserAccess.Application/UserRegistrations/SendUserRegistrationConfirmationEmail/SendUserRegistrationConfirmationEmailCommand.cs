using PeTelecom.Modules.UserAccess.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using PeTelecom.Modules.UserAccess.Domain.Users;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    internal class SendUserRegistrationConfirmationEmailCommand : InternalCommandBase
    {
        public SendUserRegistrationConfirmationEmailCommand(UserId userId, string email)
        {
            UserId = userId;
            Email = email;
        }

        public UserId UserId { get; }
        public string Email { get; }
    }
}
