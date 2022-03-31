using FluentAssertions;
using Kalkulator.Implementasjon;

namespace Kalkulator.Tests;

public class KalkulatorTest
{
    private readonly EnkelKalkulator kalkulator = new();

    [Theory]
    [InlineData(1,1,2)]
    public void TestAddering(int a, int b, int fasit)
    {
        var resultat = kalkulator.Adder(a, b);
        resultat.Should().Be(fasit);
    }

    [Theory]
    [InlineData(1, 1, 0)]
    public void TestSubtraksjon(int a, int b, int fasit)
    {
        var resultat = kalkulator.Subtraher(a, b);
        resultat.Should().Be(fasit);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    public void TestMultiplikasjon(int a, int b, int fasit)
    {
        var resultat = kalkulator.Multipliser(a, b);
        resultat.Should().Be(fasit);
    }

    [Theory]
    [InlineData(1, 1, 1, 0)]
    public void TestDivisjon(int a, int b, int fasitSvar, int fasitRest)
    {
        var (svar, rest) = kalkulator.Divider(a, b);
        svar.Should().Be(fasitSvar);
        rest.Should().Be(fasitRest);
    }

    [Fact]
    public void TestDivisjonMedNull()
    {
        var svar = () => kalkulator.Divider(1, 0);
        svar.Should().Throw<DivideByZeroException>();
    }
}