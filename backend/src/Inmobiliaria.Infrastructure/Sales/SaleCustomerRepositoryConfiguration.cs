using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class SaleCustomerRepositoryConfiguration : IEntityTypeConfiguration<SaleCustomer>
{
    public void Configure(EntityTypeBuilder<SaleCustomer> builder)
    {
        builder
            .ToTable(nameof(SaleCustomer));
        builder
            .ComplexProperty(customer => customer.Identity);
    }
}
