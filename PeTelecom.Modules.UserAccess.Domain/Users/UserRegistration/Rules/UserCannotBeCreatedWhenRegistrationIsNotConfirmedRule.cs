﻿using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.Modules.UserAccess.Domain.Users.UserRegistration.Rules
{
    class UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule : IBusinessRule
    {
        private readonly UserRegistrationStatus _actualRegistrationStatus;

        internal UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule(UserRegistrationStatus actualRegistrationStatus)
        {
            _actualRegistrationStatus = actualRegistrationStatus;
        }
        public string Message => "User cannot be created when registration is not confirmed";

        public bool IsBroken()
        {
            return _actualRegistrationStatus != UserRegistrationStatus.Confirmed;
        }
    }
}
