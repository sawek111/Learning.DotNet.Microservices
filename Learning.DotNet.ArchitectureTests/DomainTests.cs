using System.Reflection;
using Core.Primitives;
using FluentAssertions;
using NetArchTest.Rules;

namespace Learning.DotNet.ArchitectureTests;

public class DomainTest
{
    [Fact]
    public void DomainEvents_Should_BeSealed()
    {
        var result = Types.InAssemblies(Constants.AssembliesList.GetDomainAssemblies())
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .BeSealed()
            .GetResult();

        result.FailingTypes.Should().HaveCountLessThan(2);
    }

    [Fact]
    public void DomainEvents_Should_HaveDomainEventPostfix()
    {
        var result = Types.InAssemblies(Constants.AssembliesList.GetDomainAssemblies())
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .HaveNameEndingWith("DomainEvent")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// To keep ir for ORMs or serializers, it shouldn't be public!
    /// </summary>
    [Fact]
    public void Entities_Should_ShouldHavePrivateParameterLessConstructor()
    {
        var entityTypes = Types.InAssemblies(Constants.AssembliesList.GetDomainAssemblies())
            .That()
            .Inherit(typeof(Entity))
            .GetTypes();
        var failingTypes = new List<Type>();

        foreach (var entityType in entityTypes)
        {
            var constructors = entityType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            if (Array.Exists(constructors, c => c.IsPrivate && c.GetParameters().Length == 0))
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }
}