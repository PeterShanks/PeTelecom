using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTelecom.API.Exceptions
{
    public class UserContextException : Exception
    {
        public UserContextException(string message) : base(message)
        {
            
        }
    }
}
