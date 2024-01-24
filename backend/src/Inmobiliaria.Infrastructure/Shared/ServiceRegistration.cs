using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Shared;
using Inmobiliaria.Infrastructure.Customers;
using Inmobiliaria.Infrastructure.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Inmobiliaria.Infrastructure.Shared;

public static class ServiceRegistration
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services
            .AddSingleton<IMapper, CustomMapper>();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");
        NpgsqlDataSource databaseSource = new NpgsqlDataSourceBuilder(connectionString)
            .EnableDynamicJson()
            .Build();

        return services
            .AddDbContext<Context>(options => options
                .UseNpgsql(databaseSource, builder => builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .EnableDetailedErrors())
            .AddScoped<Context>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IPropertyRepository, PropertyRepository>();
    }

    public static IServiceCollection AddTimeProvider(this IServiceCollection services)
    {
        return services
            .AddSingleton<ITimeProvider, ColombiaTimeProvider>();
    }
}
