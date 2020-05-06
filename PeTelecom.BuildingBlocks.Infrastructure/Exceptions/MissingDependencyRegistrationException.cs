using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecom.BuildingBlocks.Infrastructure.Exceptions
{
    public class MissingDependencyRegistrationException : Exception
    {
        public MissingDependencyRegistrationException(string message): base(message)
        {
            
        }

        public MissingDependencyRegistrationException(string message, Exception exception) 
            : base(message, exception)
        {

        }
    }
}
