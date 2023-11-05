using Core.Primitives;

namespace Ordering.Contracts;

public sealed record OrderResponse(Guid OrderId, string UserName, decimal TotalPrice, string Status) : IResponse;