using SystemCalculadora;
using Xunit;

namespace CalculadoraSystem
{
    public class CalculadoraTest
    {
        [Fact]
        public void Add_Enviarstringvacio_RetornaCero()
        {
            //arrange
            var calculadora = new Calculadora();
            //act
            int result = calculadora.Add("");
            //assert
            Assert.Equal(0, result);
        }


        [Theory]
        [InlineData("3,4", 7)]
        [InlineData("5|99", 104)]
        [InlineData("5;6", 11)]
        [InlineData("25,45", 70)]
        public void Add_EnviaDosNumeros_RetornaLaSuma(string values, int expected)
        {
            //arrange
            var calculadora = new Calculadora();
            //act
            int result = calculadora.Add(values);
            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("25|15|45", 85)]
        [InlineData("10;12;33", 55)]
        [InlineData("25,10,50,15,30,28", 158)]
        [InlineData("22;53,48|65,80", 268)]
        public void Add_EnviaMuchosNumeros_RetornaLaSuma(string values, int expected)
        {
            //arrange
            var calculadora = new Calculadora();
            //act
            int result = calculadora.Add(values);
            //assert
            Assert.Equal(expected,result);
        }

        [Theory]
        [InlineData("2,-5")]
        [InlineData("5;-20")]
        [InlineData("12|-30")]
        public void Add_EnviaNumerosNegativos_RetornaExcepcion(string values)
        {
            //arrange
            var calculadora = new Calculadora();
            //assert
            Assert.Throws<Exception>(() => calculadora.Add(values));
        }

        [Theory]
        [InlineData("5*6*10")]
        [InlineData("15/20/35")]
        [InlineData("22-35-43")]
        [InlineData("14_11_16")]
        public void Add_EnviaDelimitadoresInvalidos_RetornaExcepcion(string values)
        {
            //arrange
            var calculadora = new Calculadora();
            //assert
            Assert.Throws<Exception>(() => calculadora.Add(values));
        }

        [Theory]
        [InlineData("5|x")]
        [InlineData("15;20;z")]
        [InlineData("34,25,14,s")]
        public void Add_EnviaCaracteresInvalidos_RetornaExcepcion(string values)
        {
            //arrange
            var calculadora = new Calculadora();
            //assert
            Assert.Throws<Exception>(() => calculadora.Add(values));
        }

        [Theory]
        [InlineData("1200,10,950,45,500,15", 70)]
        [InlineData("350|10|500|20|600|20", 50)]
        [InlineData("700;15;600;25;200;45", 85)]
        public void Add_EnviaNumerosMayorACien_RetornaSumaNumerosPorDebajoDeCien(string values, int expected)
        {
            //arrange
            var calculadora = new Calculadora();
            //act
            int result = calculadora.Add(values);
            //assert
            Assert.Equal(expected, result);
        }

    }
}