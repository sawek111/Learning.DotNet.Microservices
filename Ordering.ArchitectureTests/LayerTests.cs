using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;

namespace Learning.DotNet.ArchitectureTests;

public class LayerTests
{
    [Fact]
    public void Domain_Should_NotHaveDependencyOnOtherProjects()
    {
        var result = Types.InAssemblies(Constants.AssembliesList.GetDomainAssemblies())
            .Should()
            .NotHaveDependencyOnAny(
                Constants.Application,
                Constants.Infrastructure,
                Constants.Presentation,
                Constants.WebApi)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Application_Should_NotHaveDependencyOnHigherLevels()
    {
        var result = Types.InAssemblies(Constants.AssembliesList.GetApplicationAssemblies())
            .Should()
            .NotHaveDependencyOnAny(
                Constants.Infrastructure,
                Constants.Presentation,
                Constants.WebApi)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void NoneLayer_Should_HaveDependencyOnWebApiLayer()
    {
        var assemblies = Constants.AssembliesList.GetApplicationAssemblies()
            .Concat(Constants.AssembliesList.GetDomainAssemblies())
            .Concat(Constants.AssembliesList.GetInfrastructureAssemblies());
        
            
        var result = Types.InAssemblies(assemblies)
            .Should()
            .NotHaveDependencyOn(
                Constants.WebApi)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}