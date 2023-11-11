namespace Basket.Contracts;

public record BasketCheckoutRequest(decimal TotalPrice, string UserName);