using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Sales;

namespace Inmobiliaria.Application.Sales.List;

public record ListedSalesResult : PaginatedResult<Sale>;
