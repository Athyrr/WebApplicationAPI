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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionString in Program

            //optionsBuilder.LogTo(Console.WriteLine);


            base.OnConfiguring(optionsBuilder);
        }
    }
}
