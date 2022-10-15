using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Domain.Jogos;

namespace TesteTradeTechnology.Domain.Campeonatos
{
    public class Campeonato
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual List<Jogo> Jogos { get; set; }

        public Campeonato()
        {
            Jogos = new();
            Nome = "";
        }
    }
}
