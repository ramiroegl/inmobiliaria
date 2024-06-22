using Ardalis.Specification;

namespace Inmobiliaria.Domain.Customers.Specifications;

public class GetCustomerWithSalesSpec : Specification<Customer>
{
    public GetCustomerWithSalesSpec(Guid id)
    {
        Query
            .Where(customer => customer.Id == id && customer.Sales != null && customer.Sales.Count > 0);
    }
}
