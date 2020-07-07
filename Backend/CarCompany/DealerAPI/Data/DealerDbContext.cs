using DealerAPI.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Data
{
    public class DealerDbContext : IdentityDbContext
    {

        public DbSet<DealerEntity> Dealers { get; set; }
        public DbSet<CarEntity> Cars { get; set; }

        public DealerDbContext(DbContextOptions<DealerDbContext> options)
            :base (options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DealerEntity>().ToTable("Dealers");
            modelBuilder.Entity<DealerEntity>().HasMany(d => d.Cars).WithOne(c => c.Dealer);
            modelBuilder.Entity<DealerEntity>().Property(d => d.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CarEntity>().ToTable("Cars");
            modelBuilder.Entity<CarEntity>().HasOne(c => c.Dealer).WithMany(d => d.Cars);
            modelBuilder.Entity<CarEntity>().Property(c => c.Id).ValueGeneratedOnAdd();
        }
    }
}
