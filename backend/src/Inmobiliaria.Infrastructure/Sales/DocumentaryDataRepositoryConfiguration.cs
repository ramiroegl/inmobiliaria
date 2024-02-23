using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class DocumentaryDataRepositoryConfiguration : IEntityTypeConfiguration<DocumentaryData>
{
    public void Configure(EntityTypeBuilder<DocumentaryData> builder)
    {
        builder
            .ToTable(nameof(DocumentaryData));
    }
}
