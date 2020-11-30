using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Persistence
{
    public class AdultContext : DbContext
    {
        public DbSet<Adult> adults { get; set; }
        public DbSet<Family> families { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite("Data Source = Adults.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adult>().HasKey(sc => new { sc.Id });
            modelBuilder.Entity<Family>().HasKey(sc => new { sc.StreetName });
        }
    }
}
