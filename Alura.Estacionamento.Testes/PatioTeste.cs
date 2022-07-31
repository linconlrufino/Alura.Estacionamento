using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;

        public PatioTeste()
        {
            veiculo = new Veiculo();
            estacionamento = new Patio();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "Dono";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData(TipoVeiculo.Automovel, "André Teste", "QQR-1191", "Preto", "Lancer")]
        [InlineData(TipoVeiculo.Automovel, "José Teste", "QQM-1192", "Cinza", "Astra")]
        [InlineData(TipoVeiculo.Automovel, "Maria Teste", "QQT-1193", "Branco", "Santana")]
        [InlineData(TipoVeiculo.Automovel, "Pedro Teste", "QQQ-1194", "Vermelho", "Kwid")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(TipoVeiculo tipo,
                                                        string proprietario,
                                                        string placa,
                                                        string cor,
                                                        string modelo)
        {
            //Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = tipo;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData(TipoVeiculo.Automovel, "Pedro Teste", "QQQ-1194", "Vermelho", "Kwid")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(TipoVeiculo tipo,
                                          string proprietario,
                                          string placa,
                                          string cor,
                                          string modelo)
        {
            //Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = tipo;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.Placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosDoVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "Dono";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Dono";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Cinza";
            veiculoAlterado.Modelo = "Fusca";
            veiculoAlterado.Placa = "asd-9999";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(veiculoAlterado.Cor, alterado.Cor);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
