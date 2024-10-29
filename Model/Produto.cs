using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Model
{
   public class Produto
    {
        public int id { get; set; }

        public String Nome { get; set; }

        public String Numero { get; set; }

        public int quantidade_conserto { get; set; }
    }
}
