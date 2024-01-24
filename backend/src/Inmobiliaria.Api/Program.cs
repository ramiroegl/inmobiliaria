using System.Reflection;
using System.Text.Json.Serialization;
using Inmobiliaria.Infrastructure.Shared;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string AnyOrigin = "any_origin";

var assembly = Assembly.Load("Inmobiliaria.Application");

builder.Services
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly))
    .AddMappers()
    .AddRepositories(builder.Configuration)
    .AddTimeProvider();

builder.Services
    .AddCors(options =>
    {
        options.AddPolicy(AnyOrigin, policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(AnyOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
