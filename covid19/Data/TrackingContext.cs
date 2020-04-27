using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using covid19.Models;

    public class TrackingContext : DbContext
    {
        public TrackingContext (DbContextOptions<TrackingContext> options)
            : base(options)
        {
        }
    
        public DbSet<Student> Students { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<EventLog>().ToTable("EventLog");
        }
}
