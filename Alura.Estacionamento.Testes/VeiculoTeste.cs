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
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]

        public void TestarVeiculoFrearComParametro10()
        {
            var veiculo = new Veiculo();

            veiculo.Frear(10);

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestarTipoDoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Action

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda não implementado . Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            var carro = new Veiculo();

            carro.Proprietario = "Dono";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Cor = "Cinza";
            carro.Modelo = "Lancer";
            carro.Placa = "asd-9999";

            string dados = carro.ToString();

            Assert.Contains("Ficha do Veiculo:", dados);
        }
    }
}
