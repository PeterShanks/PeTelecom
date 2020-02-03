using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.BuildingBlocks.Domain
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemeberAttribute: Attribute
    {

    }
}
