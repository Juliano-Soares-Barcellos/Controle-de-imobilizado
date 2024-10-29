using computadoresMapeadosEconsertado.consultas;
using computadoresMapeadosEconsertado.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computadoresMapeadosEconsertado.Dao
{
   public class delete
    {
        public static void DeletePaTemporaria(string temp)
        {
            Query query = new Query();
            var parametros = new
            {
                id_tempConserto = temp,
                
            };
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.DeletePaTemp, parametros);
            }
        }
    }
}
