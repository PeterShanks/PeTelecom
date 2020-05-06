using System;

namespace PeTelecom.BuildingBlocks.Domain
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute: Attribute
    {

    }
}
