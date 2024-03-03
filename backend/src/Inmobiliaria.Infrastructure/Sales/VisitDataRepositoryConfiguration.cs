using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class VisitDataRepositoryConfiguration : IEntityTypeConfiguration<VisitData>
{
    public void Configure(EntityTypeBuilder<VisitData> builder)
    {
        builder
            .ToTable(nameof(VisitData));
    }
}

