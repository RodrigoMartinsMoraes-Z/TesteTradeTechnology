using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Domain.Campeonatos;
using TesteTradeTechnology.Domain.Placares;

namespace TesteTradeTechnology.Domain.Jogos
{
    public class Jogo
    {
        public int Id { get; set; }
        public int IdPlacar { get; set; }
        public int IdCampeonato { get; set; }

        public virtual Placar Placar { get; set; }
        public virtual Campeonato Campeonato { get; set; }
    }
}
