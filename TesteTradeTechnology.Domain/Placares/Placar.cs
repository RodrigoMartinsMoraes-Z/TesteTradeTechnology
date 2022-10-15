using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Domain.Times;

namespace TesteTradeTechnology.Domain.Placares
{
    public class Placar
    {
        public int Id { get; set; }
        public int IdTimeA { get; set; }
        public int IdTimeB { get; set; }
        public int PontosTimeA { get; set; }
        public int PontosTimeB { get; set; }

        public virtual Time TimeA { get; set; }
        public virtual Time TimeB { get; set; }
    }
}
