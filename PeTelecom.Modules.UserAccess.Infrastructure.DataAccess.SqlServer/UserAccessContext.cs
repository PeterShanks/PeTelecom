using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeTelecom.BuildingBlocks.Infrastructure.InternalCommands;
using PeTelecom.BuildingBlocks.Infrastructure.Outbox;
using PeTelecom.Modules.UserAccess.Domain.Users;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer
{
    public class UserAccessContext: DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public DbSet<User> Users { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }

        public UserAccessContext(DbContextOptions options, ILoggerFactory loggerFactory): base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserAccessContext).Assembly);
        }
    }
}
