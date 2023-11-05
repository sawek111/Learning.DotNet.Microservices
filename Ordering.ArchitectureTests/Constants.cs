using System.Reflection;
using Ordering.Application.Orders.Commands.DeleteOrder;
using Ordering.Domain.Orders;

namespace Learning.DotNet.ArchitectureTests;

public static class Constants
{
    public const string Domain = "Domain";
    public const string Application = "Application";
    public const string Infrastructure = "Infrastructure";
    public const string Presentation = "Presentation";
    public const string WebApi = "WebApi";

    public static class AssembliesList
    {
        public static IEnumerable<Assembly> GetAllAssemblies =>
            GetDomainAssemblies()
                .Concat(GetApplicationAssemblies());


        public static IEnumerable<Assembly> GetDomainAssemblies()
        {
            yield return typeof(Order).Assembly;
        }
        
        public static IEnumerable<Assembly> GetInfrastructureAssemblies()
        {
            yield return typeof(DeleteOrderCommandHandler).Assembly;
        }

        public static IEnumerable<Assembly> GetApplicationAssemblies()
        {
            yield return typeof(DeleteOrderCommandHandler).Assembly;
        }
    }
}