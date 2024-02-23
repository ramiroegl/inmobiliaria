using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class DeedDataRepositoryConfiguration : IEntityTypeConfiguration<DeedData>
{
    public void Configure(EntityTypeBuilder<DeedData> builder)
    {
        builder
            .ToTable(nameof(DeedData));
    }
}
