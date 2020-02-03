using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PeTelecome.BuildingBlocks.Domain
{
    public class TypedIdValueBase : IEquatable<TypedIdValueBase>
    {
        public Guid Value { get; }

        public TypedIdValueBase(Guid value)
        {
            if (value == Guid.Empty)
                throw new InvalidOperationException("Id value cannot be empty!");

            Value = value;
        }

        // The following comments are essential for Value types only
        // The receiver will not be boxed but the object obj will be boxed
        public override bool Equals(object obj)
        {
            // If i call obj == null that would make it recursive and blow a stack overflow exception
            if (ReferenceEquals(null, obj))
                return false;

            return obj is TypedIdValueBase other && Equals(other);
        }

        // The list class uses internally the overload of the Equal method  
        // only when the object implements IEquatable
        public bool Equals([AllowNull] TypedIdValueBase other)
        {
            return Value == other?.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator == (TypedIdValueBase obj1, TypedIdValueBase obj2)
        {
            if (obj1 != null)
                return obj1.Equals(obj2);

            return ReferenceEquals(obj1, obj2);
        }

        public static bool operator != (TypedIdValueBase obj1, TypedIdValueBase obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
