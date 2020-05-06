using System.ComponentModel.DataAnnotations;
using PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser;

namespace PeTelecom.API.Modules.UserAccess
{
    public class RegisterNewUserRequest
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public RegisterNewUserCommand ToCommand() =>
            new RegisterNewUserCommand(Login, Password, Email, FirstName, LastName);
    }
}