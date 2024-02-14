using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class SaleDocumentaryDataRepositoryConfiguration : IEntityTypeConfiguration<SaleDocumentaryData>
{
    public void Configure(EntityTypeBuilder<SaleDocumentaryData> builder)
    {
        builder
            .ToTable(nameof(SaleDocumentaryData));
    }
}
