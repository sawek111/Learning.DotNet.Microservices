using Core.Messages;
using Ordering.Application;
using Ordering.Domain;
using Ordering.Domain.Email;
using Ordering.Domain.Orders;
using Ordering.Infrastructure;
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


// TODO - Add automapper when OrderRepository done
// builder.Services.AddMapster(typeof(OrderRepository).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
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