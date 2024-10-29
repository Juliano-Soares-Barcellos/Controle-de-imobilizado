using Dapper;
using ImobilizadosDll.Consulta;
using ImobilizadosDll.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadosDll.Dao
{
   public  class UpdateDao
    {
        public static void TrocaPa(string patrimonio,string FK_estrangeira ,string empresa)
        {
            Query query = new Query();
            var parametros = new
            {
                empresa = empresa,
                estrangeira = FK_estrangeira,
                patrimonio = patrimonio,
            };
            using (var conexao = new Banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.trocarPa, parametros);
            }
        }
    }
}
