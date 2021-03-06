﻿using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.Modules.UserAccess.Domain.Users.UserRegistration.Events
{
    public class UserCreatedDomainEvent: DomainEventBase
    {
        public UserId Id { get;  }
        public UserCreatedDomainEvent(UserId id)
        {
            Id = id;
        }
    }
}
