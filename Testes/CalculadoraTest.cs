using CalculadoraApplication.Models;

namespace Testes;


public class CalculadoraTest
{
    public Calculadora construirClasse()
    {
        Calculadora calculadora = new Calculadora("07/05/2024");

        return calculadora;

    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    public void TesteSomar(int valor1, int valor2, int resultado)
    {
        // Arrange
        Calculadora calculadora = construirClasse();

        // Act
        int resultadoCalculadora = calculadora.somar(valor1, valor2);

        // Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(4, 5, 20)]
    public void TesteMultiplicar(int valor1, int valor2, int resultado)
    {

        // Arrange
        Calculadora calculadora = construirClasse();

        // Act
        int resultadoCalculadora = calculadora.multiplicar(valor1, valor2);

        // Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(5, 5, 1)]
    public void TesteDividir(int valor1, int valor2, int resultado)
    {

        // Arrange
        Calculadora calculadora = construirClasse();

        // Act
        int resultadoCalculadora = calculadora.dividir(valor1, valor2);

        // Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(6, 2, 4)]
    [InlineData(5, 5, 0)]
    public void TesteSubtrair(int valor1, int valor2, int resultado)
    {

        // Arrange
        Calculadora calculadora = construirClasse();

        // Act
        int resultadoCalculadora = calculadora.subtrair(valor1, valor2);

        // Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        // Arrange
        Calculadora calculadora = construirClasse();

        // Assert
        Assert.Throws<DivideByZeroException>(
            () => calculadora.dividir(3,0)
        );
    }

    [Fact]
    public void TestarHistorico()
    {
        // Arrange
        Calculadora calculadora = construirClasse();

        // Act
        calculadora.somar(1, 2);
        calculadora.somar(2, 8);
        calculadora.somar(3, 7);
        calculadora.somar(4, 1);

        var lista = calculadora.historico();
        // Assert
        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }


}