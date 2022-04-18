﻿namespace Catalog.Application.Products.GetProduct;

public class GetProductQueryResponse
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }
    public string Summary { get; private set; }
    public string Description { get; private set; }
    public string ImageFile { get; private set; }
    public decimal Price { get; private set; }
}