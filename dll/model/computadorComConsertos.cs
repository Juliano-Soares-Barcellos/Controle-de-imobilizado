using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computadoresMapeadosEconsertado.model
{
    public class computadorComConsertos
    {
        public computadorModel Computador { get; set; }
        public List<computador_conserto> Conserto { get; set; }
    }
}