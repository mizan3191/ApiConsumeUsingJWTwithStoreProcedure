using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts
{
    public class TshirtDbContext : DbContext
    {

        public TshirtDbContext(DbContextOptions<TshirtDbContext> dbContext)
            : base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TShirt>()
                .HasMany(x => x.Color)
                .WithOne(y => y.Shirt);

            modelBuilder.Entity<TShirt>()
                .HasMany(x => x.Size)
                .WithOne(y => y.Shirt);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TShirt> Tshirts { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}