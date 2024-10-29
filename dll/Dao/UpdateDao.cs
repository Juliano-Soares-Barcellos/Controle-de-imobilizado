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
    public class UpdateDao
    {

        public static void AtualizarComputador(String idComputador, string novoSistema)
        {
            Query query = new Query();
            var parametros = new
            {
                sistema = novoSistema,
                IdComputador = idComputador
            };
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.queryAtualizacaoSistemaOpPc, parametros);
            }
        }


        public static void ConsertoFinalizadoComputador(string descricao, string idConserto)
        {
            Query query = new Query();
            var parametros = new
            {
                descricao = descricao,
                dataFinalizado = DateTime.Now,
                idConserto = idConserto
            };
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.consertoFinalizado, parametros);
            }
        }

        public static void updateProgramasPc(string programa, string id_computador)
        {
            Query query = new Query();
            var parametros = new
            {
                programa = programa,
                id_computador = id_computador,
            };
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.UpdateNosPrograma, parametros);
            }
        }

        public static void updatePaTi(string id_computador)
        {
            Query query = new Query();
            var parametros = new
            {
                id_computador = id_computador,
            };
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.mudarParaTi, parametros);
            }
        }

        public static void retornarPaOrigem(string id_computador,string fk_pa)
        {
            Query query = new Query();
            var parametros = new
            {
                id_computador = id_computador,
                fk_pa=fk_pa,
            };
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.retornarPaDeOrigem, parametros);
            }
        }

        public static void Condenar(string id_computador)
        {
            Query query = new Query();
            var parametros = new
            {
                id_computador = id_computador,
              
            };
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.Condenar, parametros);
            }
        }

        public static void InseririModelo(string id_computador, string marca)
        {
            Query query = new Query();
            var parametros = new
            {
                id_computador = id_computador,
                marca = marca,
            };
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                conexao.Execute(query.atualizaModeloDoPc, parametros);
            }
        }
    }
}
