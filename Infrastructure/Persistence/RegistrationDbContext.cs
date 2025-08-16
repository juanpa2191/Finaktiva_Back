using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infrastructure.Persistence
{
    public class RegistrationDbContext : DbContext
    {
        public DbSet<EventLog> EventLogs { get; set; }
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EventLog>()
                .ToTable("EventLogs")
                .HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
