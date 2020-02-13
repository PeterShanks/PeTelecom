using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Configurations
{
    internal class UserRegistrationEntityTypeConfiguration : IEntityTypeConfiguration<UserRegistration>
    {
        public void Configure(EntityTypeBuilder<UserRegistration> builder)
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
        }
    }
}
