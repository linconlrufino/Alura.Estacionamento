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
        private Operador operador;


        public PatioTeste()
        {
            veiculo = new Veiculo("Abias", "asd-9999", "Verde", "Lancer", TipoVeiculo.Automovel);
            estacionamento = new Patio();
            operador = new Operador("Operador 1");
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            estacionamento.DefinirOperador(operador);
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
            estacionamento.DefinirOperador(operador);

            var veiculo = new Veiculo(proprietario, placa, cor, modelo, tipo);

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData(TipoVeiculo.Automovel, "Pedro Teste", "QQQ-1194", "Vermelho", "Kwid")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(TipoVeiculo tipo,
                                          string proprietario,
                                          string placa,
                                          string cor,
                                          string modelo)
        {
            //Arrange
            estacionamento.DefinirOperador(operador);

            var veiculo = new Veiculo(proprietario, placa, cor, modelo, tipo);

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.Ticket.Id);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket.Cupom);
        }

        [Fact]
        public void AlterarDadosDoVeiculo()
        {
            //Arrange

            estacionamento.DefinirOperador(operador);

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo("Abias", "asd-9999", "Amarelo", "Corolla", TipoVeiculo.Automovel);

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(veiculoAlterado.Cor, alterado.Cor);
        }

        public void Dispose()
        {

        }
    }
}
