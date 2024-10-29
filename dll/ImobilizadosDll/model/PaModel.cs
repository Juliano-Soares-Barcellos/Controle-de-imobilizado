using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadosDll.model
{
    public class PaModel
    {
        public int Id_pa { get; set; }


        public int Pa { get; set; }

        public Grupos_paModel Fk_gurupoModel { get; set; }

        public int Talk_id { get; set; }

        public PaModel()
        {
            Fk_gurupoModel = new Grupos_paModel();
        }
    }
}
