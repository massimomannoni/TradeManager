using Coravel.Pro.EntityFramework;
using Microsoft.EntityFrameworkCore;
using TradeManager.Domain.Models.Events;
using TradeManager.Domain.Models.EventsLog;

namespace TradeManager.Scheduler.Infrastructure.Database
{
    public class UpsLightJobContext : DbContext, ICoravelProDbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventLog> EventsLog { get; set; }
        public DbSet<CoravelJobHistory> Coravel_JobHistory { get; set; }
        public DbSet<CoravelScheduledJob> Coravel_ScheduledJobs { get; set; }
        public DbSet<CoravelScheduledJobHistory> Coravel_ScheduledJobHistory { get; set; }

        protected UpsLightJobContext() { }

        public UpsLightJobContext (DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UpsLightJobContext).Assembly);
        }
    }
}
