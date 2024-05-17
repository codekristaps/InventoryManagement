using InventoryManagement.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name)
                  .IsRequired()
                  .HasMaxLength(100);
            entity.Property(c => c.Description)
                  .HasMaxLength(500);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Name)
                  .IsRequired()
                  .HasMaxLength(100);
            entity.Property(i => i.Description)
                  .HasMaxLength(500);
            entity.Property(i => i.Quantity)
                  .IsRequired();
            entity.Property(i => i.Price)
                  .IsRequired()
                  .HasPrecision(18, 2);
            entity.HasOne(i => i.Category)
                  .WithMany(c => c.Inventories)
                  .HasForeignKey(i => i.CategoryId)
                  .IsRequired();
        });
    }
}
