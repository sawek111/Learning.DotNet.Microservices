using Bogus;
using Shopping.Response;

namespace Shopping;

public static class TestEndpoints
{
    private const string MainRoute = "api/tests";

    public static void AddTestEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(MainRoute);
        
        group.MapGet(string.Empty, GetRandom);
        group.MapGet("{count}", GetMany);
    }

    private static async Task<IResult> GetRandom()
    {
        await Task.Delay(20);
        return Results.Ok(GetTest());
    }

    private static async Task<IResult> GetMany(int count)
    {
        await Task.Delay(20);
        return Results.Ok(GetTest(count));
    }

    private static IEnumerable<TestResponse> GetTest(int count = 1)
    {
        var testFactory = new Faker<TestResponse>()
            .RuleFor(o => o.Age, f => f.Random.Int(1, 99))
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Address, f => f.Address.FullAddress());
        
        return testFactory.Generate(count);
    }
}