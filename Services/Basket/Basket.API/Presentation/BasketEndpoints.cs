using AutoMapper;
using Basket.Contracts;
using Basket.Core.Domain.Basket;
using Basket.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Presentation;

public static class BasketEndpoints
{
    private const string MainRoute = "api/baskets";
    
    // TODO auth and results
    public static void AddBasketEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(MainRoute);
        
        group.MapPost("{userName}", UpsertBasket);
        group.MapGet("{userName}", GetBasket);
        group.MapDelete("{userName}", DeleteBasket);
    }

    public static async Task<IResult> UpsertBasket(string userName, [FromBody] BasketRequest basketRequest, IBasketRepository repository, IMapper mapper)
    {
        var basket = mapper.Map<ShoppingCart>((userName, basketRequest));
        return Results.Ok(await repository.UpdateBasket(basket));
    }
    
    public async static Task<IResult> GetBasket(string userName, IBasketRepository repository, IMapper mapper)
    {
        // TODO auth
        var basket = await repository.GetBasket(userName);
        var response = mapper.Map<BasketResponse>(basket);
        return Results.Ok(response);
    }
    
    private async static Task<IResult> DeleteBasket(string userName, IBasketRepository repository)
    {

        var result = await repository.DeleteBasket(userName);
        return result ? Results.Ok() : Results.Problem();
    }
}