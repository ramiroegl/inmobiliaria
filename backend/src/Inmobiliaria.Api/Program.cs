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

const string anyOrigin = "any_origin";

var assembly = Assembly.Load("Inmobiliaria.Application");

builder.Services
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly))
    .AddMappers()
    .AddRepositories(builder.Configuration)
    .AddTimeProvider()
    .AddSecurity(builder.Configuration);

builder.Services
    .AddCors(options =>
    {
        options.AddPolicy(anyOrigin, policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(anyOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
