using Core.Messages;
using Ordering.Application;
using Ordering.Domain;
using Ordering.Domain.Email;
using Ordering.Domain.Orders;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Mapping;
using Ordering.Infrastructure.Peristence;
using Ordering.WebApi.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddMessagingInfrastructure(builder.Configuration, typeof(BasketCheckedOutEventConsumer).Assembly);
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(OrderProfile));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();