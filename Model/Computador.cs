using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Model
{
    public class Computador
    {

        public int Id{ get; set; }

        public String Nome{ get; set; }

        public String Descricao { get; set; }

        public String Marca { get; set; }

        public String Sistema { get; set; }

        public DateTime DataEntrada { get; set; }

        public String Programas { get; set; }


        public Computador(int id,String Nome,String Marca,String Sistema,String prog)
        {
            this.Id = id;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Marca = Marca;
            this.Sistema = Sistema;
            this.Programas = prog;
        }

        public Computador()
        {

        }
    }
}
