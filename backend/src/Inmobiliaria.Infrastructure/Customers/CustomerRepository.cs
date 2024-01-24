using Ardalis.Specification.EntityFrameworkCore;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Infrastructure.Shared;

namespace Inmobiliaria.Infrastructure.Customers;

public class CustomerRepository(Context context) : RepositoryBase<Customer>(context), ICustomerRepository;
