using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadosDll.model
{
    public class ComputadorModel
    {
        public int Id_computador { get; set; }

        public int Patrimonio { get; set; }

        public string Marca { get; set; }

        public string Nota_fiscal{ get; set; }

        public string Fornecedor{ get; set; }

        public string conservacao { get; set; }

        public string Programa { get; set; }

        public string SistemasOperacionais { get; set; }

        public PaModel Fk_compComputador_Pa { get; set; }

        public string Tag_servico { get; set; }

        public string Empresa { get; set; }

        public Double Valor { get; set; }

        public DateTime DataCompra { get; set; }

        public string Conservacao { get; set; }

        public ComputadorModel()
        {
            Fk_compComputador_Pa = new PaModel();
        }
    }
}
