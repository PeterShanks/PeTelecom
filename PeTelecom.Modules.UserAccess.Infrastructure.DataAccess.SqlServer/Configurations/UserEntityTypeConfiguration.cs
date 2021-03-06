﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeTelecom.Modules.UserAccess.Domain.Users;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Configurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Login).HasColumnName("Login");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.RegisterDate).HasColumnName("RegisterDate");
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.ConfirmedDate).HasColumnName("ConfirmedDate");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");

            builder.OwnsMany<UserRole>("_roles", roleBuilder =>
            {
                roleBuilder.ToTable("UserRole", "User");
                roleBuilder.WithOwner().HasForeignKey("UserId");
                roleBuilder.Property(x => x.Role).HasColumnName("RoleCode");
                roleBuilder.Property<UserId>("UserId");
                roleBuilder.HasKey("UserId", "RoleCode");
            });
        }
    }
}
