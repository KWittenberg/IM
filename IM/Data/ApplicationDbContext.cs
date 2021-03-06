namespace IM.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is IEntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                    break;
                case EntityState.Modified:
                    ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                    break;
                default:
                    break;
            }
        }
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is IEntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                    break;
                case EntityState.Modified:
                    ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                    break;
                default:
                    break;
            }
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }


    // Add ApplicationUser
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    
    // Add Address
    public DbSet<Address> Address { get; set; }

    // Add Product
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }

    // Add ShoppingChart
    public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
    public DbSet<ShoppingCart> ShoppingCart { get; set; }

    // Add Order
    public DbSet<Order> Order { get; set; }
}