using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Models.Jogos;

namespace TesteTradeTechnology.Models.Campeonatos
{
    public class CampeonatoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual List<JogoModel> Jogos { get; set; }

        public CampeonatoModel()
        {
            Jogos = new();
            Nome = "";
        }
    }
}
