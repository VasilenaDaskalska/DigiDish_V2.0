using DigiDish.Entities.AuditTriailEntities;
using Microsoft.EntityFrameworkCore;

namespace DigiDish.Entities.Context
{
    public class DigiDishDbContext : DbContext
    {
        public DigiDishDbContext(DbContextOptions<DigiDishDbContext> options)
       : base(options)
        {
        }

        public DigiDishDbContext(string connectionString)
            : base(new DbContextOptionsBuilder<DigiDishDbContext>().UseSqlServer(connectionString).Options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        //Logs
        public DbSet<UserLog> UserLogs { get; set; }

        public DbSet<MeasureLog> MeasureLogs { get; set; }

        public DbSet<ProductLog> ProductLogs { get; set; }

        public DbSet<RecipeLog> RecipeLogs { get; set; }

        public DbSet<ShoppingListlog> ShoppingListlogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fix for AuditLog
            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.LastUserModified)
                .WithMany()
                .HasForeignKey(a => a.LastUserModifiedID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.UserCreator)
                .WithMany()
                .HasForeignKey(a => a.UserCreatorID)
                .OnDelete(DeleteBehavior.Restrict);

            // Fix for UserLog
            modelBuilder.Entity<UserLog>()
                .HasOne(u => u.LastUserModified)
                .WithMany()
                .HasForeignKey(u => u.LastUserModifiedID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserLog>()
                .HasOne(u => u.UserCreator)
                .WithMany()
                .HasForeignKey(u => u.UserCreatorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserLog>()
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductLog>()
                .HasOne(pl => pl.Product)
                .WithMany()
                .HasForeignKey(pl => pl.ProductID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
