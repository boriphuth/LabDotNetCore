using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using LeakHand.Model;

namespace LeakHand.Context
{
    public class MySqlDbContext : DbContext , IDbContext
    {

        public DbSet<Item> Items { get; set; }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 

            builder.Entity<Item>().HasKey(m => m.Id);
 
            // shadow properties
            builder.Entity<Item>().Property<DateTime>("UpdatedTimestamp");
            
            base.OnModelCreating(builder);
        }
 
 
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
 
            updateUpdatedProperty<Item>();
 
            return base.SaveChanges();
        }
 
        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
 
            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}