using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Inmobiliaria.Infrastructure.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SignatureOptions:SymmetricKey"]!)),
            ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
            ValidateLifetime = true
        };
    });

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(anyOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
