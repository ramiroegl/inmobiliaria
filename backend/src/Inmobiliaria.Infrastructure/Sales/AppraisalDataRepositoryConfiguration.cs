using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class AppraisalDataRepositoryConfiguration : IEntityTypeConfiguration<AppraisalData>
{
    public void Configure(EntityTypeBuilder<AppraisalData> builder)
    {
        builder
            .ToTable(nameof(AppraisalData));
    }
}
