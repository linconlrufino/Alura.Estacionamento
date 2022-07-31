using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;

namespace Alura.Estacionamento.Modelos
{
    public class Patio
    {
        public Patio()
        {
            Faturado = 0;
            veiculos = new List<Veiculo>();
        }

        private List<Veiculo> veiculos;
        public IReadOnlyCollection<Veiculo> Veiculos
        {
            get { return veiculos.ToArray(); }
        }
        public double Faturado { get; private set; }
        public Operador Operador { get; private set; }

        public void AdicionarVeiculoAoPatio(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }
        public void RemoveVeiculoDoPatio(Veiculo veiculo)
        {
            veiculos.Remove(veiculo);
        }

        public void DefinirOperador(Operador operador)
        {
            Operador = operador;
        }

        public double TotalFaturado()
        {
            return Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", TotalFaturado());
            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            GerarTicket(veiculo);
            AdicionarVeiculoAoPatio(veiculo);
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Veiculo procurado = null;
            string informacao = string.Empty;

            foreach (Veiculo v in veiculos)
            {
                if (v.Placa == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorASerCobrado = 0;

                    if (v.Tipo == TipoVeiculo.Automovel)
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;

                    if (v.Tipo == TipoVeiculo.Motocicleta)
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;

                    informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                             "Hora de saída: {1: HH:mm:ss}\n " +
                                             "Permanência: {2: HH:mm:ss} \n " +
                                             "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    procurado = v;

                    Faturado = Faturado + valorASerCobrado;

                    break;
                }

            }

            if (procurado != null)
                RemoveVeiculoDoPatio(procurado);
            else
                return "Não encontrado veículo com a placa informada.";

            return informacao;
        }

        public Veiculo PesquisaVeiculo(string idTicket)
        {
            var carroLocalizado = veiculos.Find(x => x.Ticket.Id == idTicket);

            return carroLocalizado;
        }

        public Veiculo AlterarDadosVeiculo(Veiculo veiculoAlterado)
        {
            var veiculotemporario = veiculos.Find(x => x.Placa == veiculoAlterado.Placa);

            veiculotemporario.AlterarDados(veiculoAlterado);

            return veiculotemporario;
        }

        public Ticket GerarTicket(Veiculo veiculo)
        {
            var ticket = new Ticket();

            ticket.AtribuirCupom($"### Ticket Estacionamento Alura ###\n " +
                            $">>> Identificador: {ticket.Id}\n " +
                            $">>> Data/Hora de entrada: {DateTime.Now}\n " +
                            $">>> Placa Veículo: {veiculo.Placa}\n " +
                            $">>> Operador Patio: {Operador.Nome}");

            veiculo.AtribuirTicket(ticket);

            return ticket;
        }
    }
}
