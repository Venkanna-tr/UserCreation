using Microsoft.EntityFrameworkCore;
using System;

namespace MessWala.Data
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }

        //public SampleDbContext(DbContextOptionsBuilder options) : base(options.Options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(new Restaurant() { Name = "Ads", RestaurantId = 1 });
        }

        //public static void SeedData(SampleDbContext context)
        //{
        //    context.Database.Migrate();
        //}

        //entities
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
