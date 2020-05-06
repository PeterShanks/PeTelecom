using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PeTelecom.BuildingBlocks.Domain
{
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        public abstract IEnumerable<object> GetComponents();
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var valueObject = (ValueObject<T>)obj;

            return CompareEqualityComponents(valueObject);
        }

        public bool CompareEqualityComponents(ValueObject<T> valueObject)
        {
            using var thisValues = GetComponents().GetEnumerator();
            using var otherValues = valueObject.GetComponents().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public bool Equals([AllowNull] T other)
        {
            return CompareEqualityComponents(other);
        }
    }
    #region ValueObject Old Implementation
    //public abstract class ValueObject : IEquatable<ValueObject>
    //{
    //    private List<PropertyInfo> _properties;
    //    private List<FieldInfo> _fields;

    //    public override bool Equals(object obj)
    //    {
    //        if (obj == null || GetType() != obj.GetType())
    //            return false;

    //        return GetProperties().All(p => ArePropertiesEqual(obj, p)) &&
    //            GetFields().All(f => AreFieldsEqual(obj, f));
    //    }

    //    private IEnumerable<PropertyInfo> GetProperties()
    //    {
    //        if (_properties != null)
    //            return _properties;

    //        _properties = GetType()
    //            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
    //            .Where(p => p.GetCustomAttribute<IgnoreMemberAttribute>() == null)
    //            .ToList();

    //        return _properties;
    //    }

    //    private IEnumerable<FieldInfo> GetFields()
    //    {
    //        if (_fields != null)
    //            return _fields;

    //        _fields = GetType()
    //            .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
    //            .Where(p => p.GetCustomAttribute<IgnoreMemberAttribute>() == null)
    //            .ToList();

    //        return _fields;
    //    }

    //    private bool ArePropertiesEqual(object obj, PropertyInfo propertyInfo)
    //    {
    //        return propertyInfo.GetValue(this) == propertyInfo.GetValue(obj);
    //    }

    //    private bool AreFieldsEqual(object obj, FieldInfo fieldInfo)
    //    {
    //        return fieldInfo.GetValue(this) == fieldInfo.GetValue(obj);
    //    }

    //    public bool Equals([AllowNull] ValueObject other)
    //    {
    //        return Equals(other);
    //    }

    //    public static bool operator ==(ValueObject obj1, ValueObject obj2)
    //    {
    //        if (obj1 != null)
    //            return obj1.Equals(obj2);

    //        return ReferenceEquals(obj1, obj2);
    //    }

    //    public static bool operator !=(ValueObject obj1, ValueObject obj2)
    //    {
    //        return !(obj1 == obj2);
    //    }

    //    public override int GetHashCode()
    //    {
    //        unchecked
    //        {
    //            int hash = 17;
    //            foreach (var prop in GetProperties())
    //            {
    //                var value = prop.GetValue(this);
    //                hash = HashValue(hash, value);
    //            }

    //            foreach (var field in GetFields())
    //            {
    //                var value = field.GetValue(this);
    //                hash = HashValue(hash, value);
    //            }

    //            return hash;
    //        }
    //    }

    //    private int HashValue(int seed, object value)
    //    {
    //        var currentHash = value?.GetHashCode() ?? 0;
    //        return seed * 23 + currentHash;
    //    }

    //    protected static void CheckRule(IBusinessRule businessRule)
    //    {
    //        if (businessRule.IsBroken())
    //            throw new BusinessRuleValidationException(businessRule);
    //    }
    //} 
    #endregion
}
