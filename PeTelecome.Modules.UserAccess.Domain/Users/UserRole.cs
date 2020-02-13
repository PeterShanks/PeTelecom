using PeTelecome.BuildingBlocks.Domain;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PeTelecome.Modules.UserAccess.Domain.Users
{
    //public class UserRole: ValueObject
    //{
    //    public static UserRole Client => new UserRole(nameof(Client));
    //    public string Value { get; }
    //    public UserRole(string value)
    //    {
    //        Value = value;
    //    }
    //}

    public class UserRole : IEquatable<UserRole>
    {
        public static UserRole Client => new UserRole(Role.Client);
        public Role Role { get; }
        public UserRole(Role role)
        {
            Role = role;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is UserRole))
                return false;

            return Role == ((UserRole)obj).Role;
        }

        public bool Equals([AllowNull] UserRole other)
        {
            return Role == other?.Role;
        }

        public override int GetHashCode()
        {
            return Role.GetHashCode();
        }

        public static bool operator == (UserRole ur1, UserRole ur2)
        {
            return ur1.Equals(ur2);
        }

        public static bool operator != (UserRole ur1, UserRole ur2)
        {
            return !(ur1 == ur2);
        }
    }
}
