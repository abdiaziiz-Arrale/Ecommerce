using Microsoft.EntityFrameworkCore;

using Models;

namespace Data;

public class ECommerceDbContext : DbContext
{
      public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
      {
      }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                      .HasIndex(u => u.Email)
                      .IsUnique();
      }

      public DbSet<User> Users { get; set; }

      public DbSet<Bussiness> bussinesses { get; set; }

      public DbSet<Product> products { get; set; }
      public DbSet<Ticket> tickets { get; set; }
}
