using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class FinancialDataRepositoryConfiguration : IEntityTypeConfiguration<FinancialData>
{
    public void Configure(EntityTypeBuilder<FinancialData> builder)
    {
        builder
            .ToTable(nameof(FinancialData));
    }
}
