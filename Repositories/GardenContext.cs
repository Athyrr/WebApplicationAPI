using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GardenContext : DbContext
    {
        public GardenContext(DbContextOptions<GardenContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Field> Fields { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionString in Program

            //optionsBuilder.LogTo(Console.WriteLine);


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>()
                .HasMany(f => f.Flowers)
                .WithOne(fl => fl.Field)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
