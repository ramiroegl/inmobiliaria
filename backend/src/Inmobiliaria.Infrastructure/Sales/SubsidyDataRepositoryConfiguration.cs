using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class SubsidyDataRepositoryConfiguration : IEntityTypeConfiguration<SubsidyData>
{
    public void Configure(EntityTypeBuilder<SubsidyData> builder)
    {
        builder
            .ToTable(nameof(SubsidyData));
    }
}

