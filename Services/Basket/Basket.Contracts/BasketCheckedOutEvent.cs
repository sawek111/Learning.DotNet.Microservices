using Core.Messages;

namespace Basket.Contracts;

public sealed record BasketCheckedOutEvent : IntegrationBaseEvent
{
    public string UserName { get; private set; }
    public decimal TotalPrice { get; private set; }
}