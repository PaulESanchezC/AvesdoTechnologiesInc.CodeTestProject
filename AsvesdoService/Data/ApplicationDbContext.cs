using Microsoft.EntityFrameworkCore;
using Models.CustomerModels;
using Models.EmploymentRoleModels;
using Models.OrderItemModels;
using Models.OrderModels;
using Models.OrderStatusesModels;
using Models.PaymentModels;
using Models.ProductModels;
using Models.StaffModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<EmploymentRole> EmploymentRoles { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Tax> Tax { get; set; }
}