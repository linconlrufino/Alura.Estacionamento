using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        //Arrange
        //Act    
        //Assert

        private Veiculo veiculo;

        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper saidaConsoleTeste)
        {
            SaidaConsoleTeste = saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado");
            veiculo = new Veiculo();
        }

        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]

        public void TestarVeiculoFrearComParametro10()
        {
            veiculo.Frear(10);

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestarTipoDoVeiculo()
        {
            //Arrange
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

            veiculo.Proprietario = "Dono";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Cinza";
            veiculo.Modelo = "Lancer";
            veiculo.Placa = "asd-9999";

            string dados = veiculo.ToString();

            Assert.Contains("Ficha do Veiculo:", dados);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Construtor invocado");
        }
    }
}
