using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeTelecome.Modules.UserAccess.Domain.Users;
using System;
using User = PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models.User;

namespace PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Configurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Login).HasColumnName("Login");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.ConfirmedDate).HasColumnName("ConfirmedDate");


            builder.OwnsMany<UserRole>(x => x.Roles, roleBuilder =>
            {
                roleBuilder.WithOwner().HasForeignKey("UserId");
                roleBuilder.ToTable("UserRole", "User");
                roleBuilder.Property(x => x.Role).HasColumnName("RoleCode");
                roleBuilder.Property<Guid>("UserId").HasColumnName("UserId");
                roleBuilder.HasKey("UserId", "Role");
            });

            builder.HasQueryFilter(x => x.ConfirmedDate != null);
        }
    }
}
