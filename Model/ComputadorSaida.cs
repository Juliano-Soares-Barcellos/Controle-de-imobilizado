using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Model
{
    public class ComputadorSaida
    {
        public int Id { get; set; }

        public String DescricaoSaida { get; set; }

        public DateTime DataSaida { get; set; }

        public Computador Computador_id { get; set; }


        public int computadorEntrada_id { get; set; }

        public ComputadorSaida()
        {
            this.Computador_id = new Computador();
        }
        
    }
}
