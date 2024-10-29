using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computadoresMapeadosEconsertado.model
{
    public class computadorModel
    {
        public int id_computador { get; set; }

        [Required(ErrorMessage = "Patrimonio Obrigatória")]
        public int patrimonio { get; set; }

        public string marca { get; set; }
        public string NomeDaMaquina { get; set; }

        public string programa { get; set; }

        public string sistemasOperacionais { get; set; }

        public paModel fk_compComputador_Pa { get; set; }

        public string tag_servico{ get; set; }

        public string empresa { get; set; }

        public string processador { get; set; }

        public Double valor { get; set; }

        public DateTime DataCompra { get; set; }

        public string Conservacao { get; set; }
        public string Tipo_Memoria { get; set; }

        public computadorModel()
        {
            fk_compComputador_Pa = new paModel();
        }
    }
}
