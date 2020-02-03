using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PeTelecome.BuildingBlocks.Domain
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        private List<PropertyInfo> _properties;
        private List<FieldInfo> _fields;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (_properties != null)
                return _properties;

            _properties = GetType()
                .GetProperties(BindingFlags.Instance & BindingFlags.Public)
                .Where(p => p.GetCustomAttribute<IgnoreMemeberAttribute>() == null)
                .ToList();

            return _properties;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            if (_fields != null)
                return _fields;

            _fields = GetType()
                .GetFields()
        }

        public bool Equals([AllowNull] ValueObject other)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(ValueObject obj1, ValueObject obj2)
        {
            if (obj1 != null)
                return obj1.Equals(obj2);

            return ReferenceEquals(obj1, obj2);
        }

        public static bool operator !=(ValueObject obj1, ValueObject obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
