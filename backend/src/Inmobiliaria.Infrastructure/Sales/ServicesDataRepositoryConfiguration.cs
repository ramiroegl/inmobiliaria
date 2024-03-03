using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class ServicesDataRepositoryConfiguration : IEntityTypeConfiguration<ServicesData>
{
    public void Configure(EntityTypeBuilder<ServicesData> builder)
    {
        builder
            .ToTable(nameof(ServicesData));
    }
}

