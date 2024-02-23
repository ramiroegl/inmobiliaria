using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Inmobiliaria.Infrastructure.Shared;

public class Context(DbContextOptions<Context> options, ITimeProvider timeProvider) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

        var dateTimeOffsetConverter = new DateTimeOffsetConverter(timeProvider);

        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (IMutableProperty property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTimeOffset) || property.ClrType == typeof(DateTimeOffset?))
                {
                    property.SetValueConverter(dateTimeOffsetConverter);
                }
            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.AddInterceptors(new TraceEntitiesInterceptor(timeProvider));

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties(typeof(Enum))
            .HaveConversion<string>();
        configurationBuilder
            .Properties<Amount>()
            .HaveConversion<AmountConverter>();
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Property> Properties { get; set; }
    public virtual DbSet<Sale> Sales { get; set; }
    public virtual DbSet<SaleCustomer> SaleCustomers { get; set; }
    public virtual DbSet<SaleProperty> SaleProperties { get; set; }
    public virtual DbSet<FinancialData> SaleFinancialData { get; set; }
    public virtual DbSet<AppraisalData> AppraisalData { get; set; }
    public virtual DbSet<DeedData> DeedData { get; set; }
}
