using System.Reflection;
using Core.Application;
using Core.Primitives;
using FluentAssertions;
using NetArchTest.Rules;
using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Learning.DotNet.ArchitectureTests;

public class Application
{
    [Fact]
    public void CommandHandlers_Should_BeSealed()
    {
        var result = Types.InAssemblies(Constants.AssembliesList.GetApplicationAssemblies())
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void CommandHandlers_Should_DependsOnDomainAssembly()
    {
        var domainAssembly = typeof(UpdateOrderCommand).Assembly.FullName;
        var result = Types.InAssemblies(Constants.AssembliesList.GetApplicationAssemblies())
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveDependencyOn(domainAssembly)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}