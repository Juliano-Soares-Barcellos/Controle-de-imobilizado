using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computadoresMapeadosEconsertado.model
{
    public class computador_conserto
    {
        public int id_conserto { get; set; }

        public DateTime data_entrada { get; set; }

        public string Descricao_problema { get; set; }

        public computadorModel fkComputador { get; set; }

        public string descricao_problema_resolvido { get; set; }

        public DateTime data_conserto_finalizado { get; set; }

        public computador_conserto()

        {
            fkComputador = new computadorModel();
        }
    }
}
