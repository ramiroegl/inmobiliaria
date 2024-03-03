using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class DeedCostsDataRepositoryConfiguration : IEntityTypeConfiguration<DeedCostsData>
{
    public void Configure(EntityTypeBuilder<DeedCostsData> builder)
    {
        builder
            .ToTable(nameof(DeedCostsData));
    }
}
