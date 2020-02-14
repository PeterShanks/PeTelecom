using PeTelecom.Modules.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models
{
    public class User
    {
        public Guid Id { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public bool IsActive { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Name { set; get; }
        public List<UserRole> Roles { set; get; }
        public DateTime? ConfirmedDate { set; get; }
    }
}
