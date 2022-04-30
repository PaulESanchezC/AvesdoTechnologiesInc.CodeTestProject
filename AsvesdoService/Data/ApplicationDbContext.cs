using Data.FluentApi;
using Microsoft.EntityFrameworkCore;
using Models.CustomerModels;
using Models.EmploymentRoleModels;
using Models.OrderItemModels;
using Models.OrderModels;
using Models.OrderStatusModels;
using Models.OrderTypeModels;
using Models.PaymentModels;
using Models.PreferredPronounsModels;
using Models.ProductModels;
using Models.StaffModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<CustomerBase> Customers { get; set; }
    public DbSet<EmploymentRoleBase> EmploymentRoles { get; set; }
    public DbSet<OrderItemBase> OrderItems { get; set; }
    public DbSet<OrderBase> Orders { get; set; }
    public DbSet<OrderStatusBase> OrderStatuses { get; set; }
    public DbSet<OrderTypeBase> OrderTypes { get; set; }
    public DbSet<PaymentBase> Payments { get; set; }
    public DbSet<PreferredPronounBase> PreferredPronouns { get; set; }
    public DbSet<ProductBase> Products { get; set; }
    public DbSet<StaffBase> Staff { get; set; }
    public DbSet<StoreBase> Stores { get; set; }
    public DbSet<TaxBase> Tax { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PaymentFluentApi());
    }
}