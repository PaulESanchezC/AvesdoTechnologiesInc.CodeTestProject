using Microsoft.EntityFrameworkCore;
using Models.OrderModels;
using Models.PaymentModels;

namespace Data.ModelBuilderConfigurations;

public static class OnOrderDeleteExtensionMethod
{
    public static void AddOnOrderDeleteBehavior(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasMany(fk => fk.OrderItems)
            .WithOne(k => k.Order).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>().HasMany(fk => fk.Payments)
            .WithOne(k => k.Order).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Payment>().HasOne(fk => fk.Customer).WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Payment>().HasOne(fk => fk.Store).WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}