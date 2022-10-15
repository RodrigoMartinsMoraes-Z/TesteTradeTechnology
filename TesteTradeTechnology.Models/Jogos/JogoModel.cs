using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Models.Campeonatos;
using TesteTradeTechnology.Models.Placares;

namespace TesteTradeTechnology.Models.Jogos
{
    public class JogoModel
    {
        public int Id { get; set; }
        public int IdPlacar { get; set; }
        public int IdVencedor { get => ObterVencedor(); }

        public virtual PlacarModel Placar { get; set; }

        private int ObterVencedor()
        {
            if (Placar.PontosTimeA > Placar.PontosTimeB)
                return Placar.IdTimeA;
            else
                return Placar.IdTimeB;
        }
    }
}
