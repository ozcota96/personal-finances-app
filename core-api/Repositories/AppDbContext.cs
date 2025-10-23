using core_api.Models;
using Microsoft.EntityFrameworkCore;

namespace core_api.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Account>()
                .Property(a => a.CreatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Account>()
                .Property(a => a.UpdatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Movement>()
                .Property(m => m.CreatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Movement>()
                .Property(m => m.Date)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Movement>()
                .Property(m => m.UpdatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Movement>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Movements)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Movement>()
                .HasOne(m => m.Subcategory)
                .WithMany(s => s.Movements)
                .HasForeignKey(m => m.SubcategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Category>()
                .Property(c => c.UpdatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Subcategory>()
                .Property(s => s.CreatedAt)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Subcategory>()
                .Property(s => s.UpdatedAt)
                .HasColumnType("timestamp with time zone");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
    }
}
