using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Shared;
using Inmobiliaria.Domain.Users;
using Inmobiliaria.Infrastructure.Customers;
using Inmobiliaria.Infrastructure.Properties;
using Inmobiliaria.Infrastructure.Sales;
using Inmobiliaria.Infrastructure.Users;
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
            )
            .AddScoped<Context>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IPropertyRepository, PropertyRepository>()
            .AddScoped<ISaleRepository, SaleRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }

    public static IServiceCollection AddTimeProvider(this IServiceCollection services)
    {
        return services
            .AddSingleton<ITimeProvider, ColombiaTimeProvider>();
    }

    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddSingleton<IHasher, Hasher>()
            .AddSingleton<TokenService>()
            .Configure<SignatureOptions>(configuration.GetRequiredSection(nameof(SignatureOptions)));
    }
}
