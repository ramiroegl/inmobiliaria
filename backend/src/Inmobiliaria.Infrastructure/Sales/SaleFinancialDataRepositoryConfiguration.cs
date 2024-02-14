using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class SaleFinancialDataRepositoryConfiguration : IEntityTypeConfiguration<SaleFinancialData>
{
    public void Configure(EntityTypeBuilder<SaleFinancialData> builder)
    {
        builder
            .ToTable(nameof(SaleFinancialData));
    }
}
