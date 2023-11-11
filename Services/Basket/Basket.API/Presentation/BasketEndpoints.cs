using AutoMapper;
using Basket.Contracts;
using Basket.Core.Domain.Basket;
using Basket.Infrastructure;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Presentation;

public static class BasketEndpoints
{
    private const string MainRoute = "api/Baskets";
    
    // TODO auth and results
    public static void AddBasketEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(MainRoute);
        
        group.MapPost("{userName}", UpsertBasket);
        group.MapPost("Checkout", CheckoutBasket);
        group.MapGet("{userName}", GetBasket);
        group.MapDelete("{userName}", DeleteBasket);
    }

    private static async Task<IResult> UpsertBasket(string userName, [FromBody] BasketRequest basketRequest, IBasketRepository repository, IMapper mapper)
    {
        var basket = mapper.Map<ShoppingCart>((userName, basketRequest));
        return Results.Ok(await repository.UpdateBasketAsync(basket));
    }
    
    private static async Task<IResult> GetBasket(string userName, IBasketRepository repository, IMapper mapper)
    {
        var basket = await repository.GetBasketAsync(userName);
        var response = mapper.Map<BasketResponse>(basket);
        return Results.Ok(response);
    }
    
    private static async Task<IResult> DeleteBasket(string userName, IBasketRepository repository)
    {
        var result = await repository.DeleteBasketAsync(userName);
        return result ? Results.Ok() : Results.Problem();
    }

    // TODO commandhander for this
    private static async Task<IResult> CheckoutBasket(BasketCheckoutRequest request, IMapper mapper, IBasketRepository repository, IBus bus)
    {
        var basket = await repository.GetBasketAsync(request.UserName);
        if (basket is null || basket.TotalPrice != request.TotalPrice)
        {
            return Results.Problem();
        }

        var message = mapper.Map<BasketCheckedOutEvent>(basket);
        await bus.Publish(message);

        var isDeleted = await repository.DeleteBasketAsync(request.UserName);
        return Results.Ok(isDeleted);
    }
}