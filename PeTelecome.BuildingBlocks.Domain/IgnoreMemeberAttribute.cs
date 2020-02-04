using System;

namespace PeTelecome.BuildingBlocks.Domain
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemeberAttribute: Attribute
    {

    }
}
