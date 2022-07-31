using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {
        private string matricula;
        private string nome;

        public string Matricula { get { return matricula; } set { matricula = value; } }
        public string Nome { get { return nome; } set { nome = value; } }

        public Operador(string nome)
        {
            Nome = nome;
            matricula = new Guid().ToString().Substring(0, 8);
        }

        public override string ToString()
        {
            return $"Operador: {Nome} \n" +
                   $"Matricuka: {Matricula}";
        }
    }
}
