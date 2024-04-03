using Inmobiliaria.Application.Shared;

namespace Inmobiliaria.Application.Sales.List;

public record ListedSalesResult : PaginatedResult<SaleDto>;
