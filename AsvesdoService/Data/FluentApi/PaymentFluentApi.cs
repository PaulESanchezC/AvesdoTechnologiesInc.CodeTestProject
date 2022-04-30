using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.PaymentModels;

namespace Data.FluentApi;

public class PaymentFluentApi : IEntityTypeConfiguration<PaymentBase>
{
    public void Configure(EntityTypeBuilder<PaymentBase> model)
    {
        model.HasOne(fk => fk.Order).WithMany(fk => fk.Payments).OnDelete(DeleteBehavior.NoAction);
    }
}