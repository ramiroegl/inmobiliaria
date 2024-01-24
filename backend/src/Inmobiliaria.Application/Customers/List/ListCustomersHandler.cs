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
        IEnumerable<ListedCustomerDto> customersDto = mapper.ToListedCustomers(customers);

        return new ListedCustomersResult
        {
            Data = customersDto,
            PageSize = request.Take,
            TotalRecords = totalOfCustomers
        };
    }
}
