using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computadoresMapeadosEconsertado.model
{
    public class temp_conserto
    {
       public int id_tempConserto { get; set; }

        public int fk_computador { get; set; }

        public int fk_pa { get; set; }


    }
}
