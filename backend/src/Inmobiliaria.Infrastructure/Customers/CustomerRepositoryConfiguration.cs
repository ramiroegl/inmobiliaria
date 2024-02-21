using Inmobiliaria.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Customers;

public class CustomerRepositoryConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .ToTable(nameof(Customer));
        builder
            .ComplexProperty(customer => customer.Identity);
        builder
            .HasMany(property => property.Sales)
            .WithOne(saleCustomer => saleCustomer.Customer)
            .HasForeignKey(saleCustomer => saleCustomer.CustomerId);
    }
}
