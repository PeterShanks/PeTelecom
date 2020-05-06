using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTelecom.API.Exceptions
{
    public class CorrelationException : Exception
    {
        public CorrelationException(string message) : base(message)
        {
            
        }
    }
}
