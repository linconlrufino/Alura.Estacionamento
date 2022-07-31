using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Ticket
    {

        public Ticket()
        {
            Id = new Guid().ToString().Substring(0, 5); ;
        }

        public string Id { get; private set; }
        public string Cupom { get; private set; }

        public void AtribuirCupom(string cupom)
        {
            Cupom = cupom;
        }
    }
}
