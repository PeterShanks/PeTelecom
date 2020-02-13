using PeTelecome.Modules.UserAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models
{
    public class UserRegistration
    {
        public Guid Id { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Name { set; get; }
        public DateTime RegisterDate { set; get; }
        public UserRegistrationStatus Status { get; set; }
        public DateTime? ConfirmedDate { get; set; }
    }
}
