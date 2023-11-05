using System.Reflection;
using Ordering.Domain.Orders;

namespace Learning.DotNet.ArchitectureTests;

public static class AssembliesList
{
    public static IEnumerable<Assembly> GetDomainAssemblies()
    {
        yield return typeof(Order).Assembly;
    }
}