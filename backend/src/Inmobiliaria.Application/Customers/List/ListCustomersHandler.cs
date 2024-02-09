using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Customers.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Customers.List;

public class ListCustomersHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<ListCustomersQuery, ListedCustomersResult>
{
    public async Task<ListedCustomersResult> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
    {
        var specification = new SearchCustomersSpec(request.Search, request.Skip, request.Take);
        List<Customer> customers = await customerRepository.ListAsync(specification, cancellationToken);
        var totalOfCustomers = await customerRepository.CountAsync(specification, cancellationToken);

        return new ListedCustomersResult
        {
            Data = mapper.ToListedCustomers(customers),
            PageSize = request.Take,
            TotalRecords = totalOfCustomers
        };
    }
}
