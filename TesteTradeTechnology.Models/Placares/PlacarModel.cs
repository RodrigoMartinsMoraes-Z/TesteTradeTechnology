using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Models.Times;

namespace TesteTradeTechnology.Models.Placares
{
    public class PlacarModel
    {
        public int Id { get; set; }
        public int IdTimeA { get; set; }
        public int IdTimeB { get; set; }
        public int PontosTimeA { get; set; }
        public int PontosTimeB { get; set; }

        public virtual TimeModel TimeA { get; set; }
        public virtual TimeModel TimeB { get; set; }
    }
}
