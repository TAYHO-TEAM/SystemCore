using Microsoft.EntityFrameworkCore;

namespace IntegrationEventLog.EF
{
    public class IntegrationEventLogContext : DbContext
    {
        private const string IntegrationEventTableName = "IntegrationEventLogs";

        public IntegrationEventLogContext(DbContextOptions<IntegrationEventLogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntegrationEventLogEntry>(e =>
            {
                e.ToTable(IntegrationEventTableName);
                e.HasKey(integrationEventLogEntry => integrationEventLogEntry.EventId);
                e.Property(integrationEventLogEntry => integrationEventLogEntry.EventId).IsRequired();
                e.Property(integrationEventLogEntry => integrationEventLogEntry.Content).IsRequired();
                e.Property(integrationEventLogEntry => integrationEventLogEntry.CreationDate).IsRequired();
                e.Property(integrationEventLogEntry => integrationEventLogEntry.State).IsRequired();
                e.Property(integrationEventLogEntry => integrationEventLogEntry.EventTypeName).IsRequired();
                e.Property(integrationEventLogEntry => integrationEventLogEntry.TransactionId).IsRequired();
            });
        }

        public DbSet<IntegrationEventLogEntry> IntegrationEventLogs { get; set; }
    }
}