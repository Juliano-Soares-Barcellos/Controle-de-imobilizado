using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computadoresMapeadosEconsertado.model
{
    public class paModel
    {
        public int id_pa { get; set; }
        public int pa { get; set; }
        public grupos_pa Fk_gurupoModel { get; set; }
        public int talk_id { get; set; }

        public paModel()
        {
            Fk_gurupoModel = new grupos_pa();
        }
    }
}