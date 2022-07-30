using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        //Arrange
        //Act
        //Assert

        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestarVeiculoAcelerar()
        {
            var veiculo = new Veiculo();

            veiculo.Frear(10);

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestarTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Action

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }
}