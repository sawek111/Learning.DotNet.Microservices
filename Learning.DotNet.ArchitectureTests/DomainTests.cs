using Core.Primitives;
using FluentAssertions;
using NetArchTest.Rules;

namespace Learning.DotNet.ArchitectureTests;

public class DomainTest
{
    [Fact]
    public void DomainEvents_Should_Be_Immutable()
    {
        var result = Types.InAssemblies(AssembliesList.GetDomainAssemblies())
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .BeSealed()
            .GetResult();

        result.FailingTypes.Should().HaveCountLessThan(2);
    }
}