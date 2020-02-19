using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeTelecom.BuildingBlocks.Infrastructure.Outbox;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Configurations
{
    internal class OutboxMessageEntityTypeConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("OutboxMessage", "User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.OccurredOn).HasColumnName("OccurredOn");
            builder.Property(x => x.Type).HasColumnName("Type");
            builder.Property(x => x.Data).HasColumnName("Data");
            builder.Property(x => x.ProcessedDate).HasColumnName("ProcessedDate");
        }
    }
}
