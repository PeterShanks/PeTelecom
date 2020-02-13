using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeTelecome.BuildingBlocks.Infrastructure.InternalCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Configurations
{
    public class InternalCommandEntityTypeConfiguration : IEntityTypeConfiguration<InternalCommand>
    {
        public void Configure(EntityTypeBuilder<InternalCommand> builder)
        {
            builder.ToTable("OutboxMessage", "User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.OccurredOn).HasColumnName("OccurredOn");
            builder.Property(x => x.Type).HasColumnName("Type");
            builder.Property(x => x.Data).HasColumnName("Data");
            builder.Property(x => x.ProcessedDate).HasColumnName("ProcessedDate");
        }
    }
}
