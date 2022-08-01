using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using System;

namespace Alura.Estacionamento.Modelos
{
    public class Veiculo
    {
        public Veiculo()
        {

        }

        public Veiculo(string proprietario,
                       string placa,
                       string cor,
                       string modelo,
                       TipoVeiculo tipo = TipoVeiculo.Automovel)
        {
            ValidarProprietario(proprietario);
            Proprietario = proprietario;
            ValidarPlaca(placa);
            Placa = placa;
            Cor = cor;
            Modelo = modelo;
            Tipo = tipo;
        }

        //Campos    
        public TipoVeiculo Tipo { get; private set; }
        public string Placa { get; private set; }
        public string Proprietario { get; private set; }
        public Ticket Ticket { get; private set; }
        public string Cor { get; private set; }
        public double Largura { get; private set; }
        public double VelocidadeAtual { get; private set; }
        public string Modelo { get; private set; }
        public DateTime HoraEntrada { get; private set; }
        public DateTime HoraSaida { get; private set; }

        public void DefinirHoraDeSaida(DateTime hora)
        {
            HoraSaida = hora;
        }

        public void RegistrarHoraDeEntrada(DateTime hora)
        {
            HoraEntrada = hora;
        }

        public void AtribuirTicket(Ticket ticket)
        {
            Ticket = ticket;
        }

        public void Acelerar(int tempoSeg)
        {
            VelocidadeAtual += (tempoSeg * 10);
        }

        public void Frear(int tempoSeg)
        {
            VelocidadeAtual -= (tempoSeg * 15);
        }

        public void AlterarDados(Veiculo veiculoAlterado)
        {
            Proprietario = veiculoAlterado.Proprietario;
            Modelo = veiculoAlterado.Modelo;
            Largura = veiculoAlterado.Largura;
            Cor = veiculoAlterado.Cor;
        }

        public void ValidarPlaca(string placa)
        {
            // Checa se o valor possui pelo menos 8 caracteres
            if (placa.Length != 8)
            {
                throw new FormatException(" A placa deve possuir 8 caracteres");
            }
            for (int i = 0; i < 3; i++)
            {
                //checa se os 3 primeiros caracteres são numeros
                if (char.IsDigit(placa[i]))
                {
                    throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                }
            }
            //checa o Hifem
            if (placa[3] != '-')
            {
                throw new FormatException("O 4° caractere deve ser um hífen");
            }
            //checa se os 3 primeiros caracteres são numeros
            for (int i = 4; i < 8; i++)
            {
                if (!char.IsDigit(placa[i]))
                {
                    throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                }
            }
        }

        public void ValidarProprietario(string proprietario)
        {
            if (proprietario.Length < 3)
                throw new FormatException(" Nome de proprietário inválido");
        }

        public override string ToString()
        {
            return $"Ficha do veiculo:\n " +
                   $"Tipo de veículo: {Tipo.ToString()}\n " +
                   $"Proprietário: {Proprietario}\n " +
                   $"Modelo: {Modelo}\n " +
                   $"Cor: {Cor}\n " +
                   $"Placa: {Placa}\n";
        }
    }
}
