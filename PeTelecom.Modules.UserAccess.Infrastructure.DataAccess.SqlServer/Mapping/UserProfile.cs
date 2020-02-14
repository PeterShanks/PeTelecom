using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using DomainUser = PeTelecom.Modules.UserAccess.Domain.Users.User;
using DBUser = PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models.User;

using DomainUserRegistration = PeTelecom.Modules.UserAccess.Domain.UserRegistrations.UserRegistration;
using DBUserRegistration = PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models.UserRegistration;

using OutboxMessage = PeTelecom.BuildingBlocks.Infrastructure.Outbox.OutboxMessage;
using DBOutboxMessage = PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models.OutboxMessage;
using System.Linq;
using PeTelecom.Modules.UserAccess.Domain.Users;
using PeTelecom.Modules.UserAccess.Domain.UserRegistrations;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Mapping
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<DomainUser, DBUser>();
            CreateMap<DBUser, DomainUser>().ConvertUsing(ConstructDomainUserFromDBUser);

            CreateMap<DomainUserRegistration, DBUserRegistration>();
            CreateMap<DBUserRegistration, DomainUserRegistration>().ConvertUsing(ConstructDomainUserRegistrationFromDBUserRegistration);

            CreateMap<OutboxMessage, DBOutboxMessage>();
            CreateMap<DBOutboxMessage, OutboxMessage>().ConvertUsing(ConstructOutboxMessageFromDBOutboxMessage);

        }

        private DomainUser ConstructDomainUserFromDBUser(DBUser dBUser, DomainUser domainUser)
        {
            return DomainUser.Load(
                new Domain.Users.UserId(dBUser.Id),
                dBUser.Login,
                dBUser.Password,
                dBUser.Email,
                dBUser.IsActive,
                dBUser.FirstName,
                dBUser.LastName,
                dBUser.Name,
                dBUser.Roles
                );
        }

        private DomainUserRegistration ConstructDomainUserRegistrationFromDBUserRegistration(DBUserRegistration dBUserRegistration, DomainUserRegistration domainUserRegistration)
        {
            return DomainUserRegistration.Load(
                new UserRegistrationId(dBUserRegistration.Id),
                dBUserRegistration.Login,
                dBUserRegistration.Password,
                dBUserRegistration.Email,
                dBUserRegistration.FirstName,
                dBUserRegistration.LastName,
                dBUserRegistration.Name,
                dBUserRegistration.RegisterDate,
                dBUserRegistration.Status,
                dBUserRegistration.ConfirmedDate
                );
        }

        private OutboxMessage ConstructOutboxMessageFromDBOutboxMessage(DBOutboxMessage dBOutboxMessage, OutboxMessage outboxMessage)
        {
            return new OutboxMessage(dBOutboxMessage.Id, dBOutboxMessage.OccurredOn, dBOutboxMessage.Type, dBOutboxMessage.Data, dBOutboxMessage.ProcessedDate);
        }
    }

}
