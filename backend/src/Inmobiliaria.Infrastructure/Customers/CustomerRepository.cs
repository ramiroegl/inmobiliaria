using Ardalis.Specification.EntityFrameworkCore;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Customers;

public class CustomerRepository(Context context) : RepositoryBase<Customer>(context), ICustomerRepository;

public class CustomerRepositoryConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsOne(customer => customer.Salary);
        builder.OwnsOne(customer => customer.Identity);
    }
}
