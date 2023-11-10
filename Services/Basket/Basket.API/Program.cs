using Basket.API.Presentation;
using Basket.Infrastructure;
using Core.Messages;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    conf =>
    {
        conf.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket", Version = "v1" });
    });

builder.Services.AddAutoMapper(typeof(BasketProfile));
builder.Services.AddOptions<RedisSettings>()
    .BindConfiguration(RedisSettings.SectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddMessagingInfrastructure(builder.Configuration);
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<RedisSettings>>().Value);
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddStackExchangeRedisCache(
    options =>
    {
        var redisSettings = builder.Configuration.GetSection(RedisSettings.SectionName).Get<RedisSettings>();
        options.Configuration = redisSettings!.ConnectionString;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapGet("settings/redis", (RedisSettings settings) => Results.Ok(settings));

app.AddBasketEndpoints();

app.Run();