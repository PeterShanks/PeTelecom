﻿using PeTelecom.BuildingBlocks.Application.Configuration.Commands;
using PeTelecom.Modules.UserAccess.Domain.Users;

namespace PeTelecom.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    public class ConfirmUserRegistrationCommand: CommandBase
    {
        public UserId UserId { get; }

        public ConfirmUserRegistrationCommand(UserId userId)
        {
            UserId = userId;
        }
    }
}
