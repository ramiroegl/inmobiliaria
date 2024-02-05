using Ardalis.Specification.EntityFrameworkCore;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Infrastructure.Shared;

namespace Inmobiliaria.Infrastructure.Sales;

public class SaleRepository(Context dbContext) : RepositoryBase<Sale>(dbContext), ISaleRepository;
