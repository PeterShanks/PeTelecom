using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.BuildingBlocks.Domain
{
    public interface IBusinessRule
    {
        string Message { get; }
        bool IsBroken();
    }
}
