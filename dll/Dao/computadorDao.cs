using computadoresMapeadosEconsertado.consultas;
using computadoresMapeadosEconsertado.Data;
using computadoresMapeadosEconsertado.model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace computadoresMapeadosEconsertado.Dao
{
    public class computadorDao
    {
        public static Query query = new Query();

        public static computadorModel AcharPc(string patrimonio)
        {
            try
            {
                using (var conexao = new banco().conexao())
                {
                    conexao.Open();
                    query = new Query();
                    var resultados = conexao.Query<computadorModel, paModel, grupos_pa, computadorModel>(
                    query.buscaMapPc,
                    (computador, pa, grupo) =>
                    {
                        computador.fk_compComputador_Pa = pa;
                        pa.Fk_gurupoModel = grupo;
                        return computador;
                    }, new { patrimonio },
                    splitOn: "id_pa,id_grupo"
                );
                    return resultados.FirstOrDefault();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
            return null;

        }

        public static List<computadorModel> BuscaMapPc()
        {
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                query = new Query();
                var resultados = conexao.Query<computadorModel, paModel, grupos_pa, computadorModel>(
                    query.buscaMapPc,
                    (computador, pa, grupo) =>
                    {
                        computador.fk_compComputador_Pa = pa;
                        pa.Fk_gurupoModel = grupo;
                        return computador;
                    },
                    splitOn: "id_pa,id_grupo"
                );

                return resultados.AsList();
            }
        }


        public List<Object[]> ssd()
        {
           MySqlConnection con = null;
            Query sql;
            con = new banco().conexao();
            con.Open();

            List<Object[]> resultados = new List<Object[]>();

            try
            {
                sql = new Query();
                MySqlCommand comando = new MySqlCommand(sql.filtrossd, con);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Object[] row = new Object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }

                    resultados.Add(row);
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultados;
        }
    
    public List<computadorComConsertos> BuscaComputadorConsertado()
        {
            using (var conexao = new banco().conexao())
            {
                var resultados = conexao.Query<computadorModel, paModel, grupos_pa, computador_conserto, Tuple<computadorModel, computador_conserto>>(
                     query.computadores_consertados,
                     (computador, pa, grupo, computadorConserto) =>
                     {
                         computador.fk_compComputador_Pa = pa;
                         pa.Fk_gurupoModel = grupo;
                         computadorConserto.fkComputador = computador;

                         return Tuple.Create(computador, computadorConserto);
                     },
                     splitOn: "id_computador,id_pa,id_grupo,id_conserto"
                 );

                var computadoresComConsertos = new List<computadorComConsertos>();
                foreach (var resultado in resultados)
                {
                    var computador = resultado.Item1;
                    var conserto = resultado.Item2;

                    var computadorExistente = computadoresComConsertos.FirstOrDefault(c => c.Computador.id_computador == computador.id_computador);
                    if (computadorExistente != null)
                    {
                        computadorExistente.Conserto.Add(conserto);
                    }
                    else
                    {
                        computadoresComConsertos.Add(new computadorComConsertos
                        {
                            Computador = computador,
                            Conserto = new List<computador_conserto> { conserto }
                        });
                    }
                }

                return computadoresComConsertos;
            }
        }
        public List<computadorModel> BuscaPAs()
        {
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                query = new Query();
                var resultados = conexao.Query<computadorModel, paModel, grupos_pa, computadorModel>(
                    query.LocalizacaoPa,
                    (computador, pa, grupo) =>
                    {
                        computador.fk_compComputador_Pa = pa;
                        pa.Fk_gurupoModel = grupo;
                        return computador;
                    },
                    splitOn: "id_computador,id_pa,id_grupo"
                );

                return resultados.AsList();
            }
        }
        public List<computadorComConsertos> BuscaPatrimonio(string patrimonio)
        {


            using (var conexao = new banco().conexao())
            {
                var resultados = conexao.Query<computadorModel, computador_conserto, paModel, grupos_pa, computadorComConsertos>(
                     query.acharPcDetalhado,
                     (computador, computadorConserto, pa, grupo) =>
                     {
                         computador.fk_compComputador_Pa = pa;
                         pa.Fk_gurupoModel = grupo;

                         if (computadorConserto != null)
                         {
                             computadorConserto.fkComputador = computador;
                         }

                         return new computadorComConsertos
                         {
                             Computador = computador,
                             Conserto = computadorConserto != null ? new List<computador_conserto> { computadorConserto } : null
                         };
                     },
                     new { patrimonio },
                     splitOn: "id_computador,id_conserto,id_pa,id_grupo"
                 );

                return resultados.ToList();
            }
        }

        public List<computadorComConsertos> BuscaPeloSistema(string sistemasOperacionais)
        {
            
            using (var conexao = new banco().conexao())
            {
                var resultados = conexao.Query<computadorModel, paModel, grupos_pa, computador_conserto, computadorComConsertos>(
                    query.acharPcsPeloSistema,
                    (computador, pa, grupo, computadorConserto) =>
                    {
                        computador.fk_compComputador_Pa = pa;
                        pa.Fk_gurupoModel = grupo;
                        computadorConserto.fkComputador = computador;

                        return new computadorComConsertos
                        {
                            Computador = computador,
                            Conserto = new List<computador_conserto> { computadorConserto }
                        };
                    },
                    new { sistemasOperacionais },
                    splitOn: "id_computador,id_pa,id_grupo,id_conserto"
                );

                return resultados.ToList();
            }
        }


        public object[] GetValoresPropriedades(object obj)
        {
            var tipoObjeto = obj.GetType();
            var propriedades = tipoObjeto.GetProperties();
            var valores = new List<object>();

            foreach (var propriedade in propriedades)
            {
                valores.Add(propriedade.GetValue(obj));
            }

            return valores.ToArray();
        }

        public List<temp_conserto> ObterDadosTemp(string idComputador)
        {
            using (var conexao = new banco().conexao())
            {
                conexao.Open();
                var dados = conexao.Query<temp_conserto>(query.selectTabelaTemp, new { id_computador = idComputador });
                return dados.ToList();
            }
        }



        public List<computadorModel> FiltroMapPc(string Empresa, string resfiltro, string query)
        {
            try
            {
                using (var conexao = new banco().conexao())
                {
                    conexao.Open();
                    var resultados = conexao.Query<computadorModel, paModel, grupos_pa, computadorModel>
                   (
                        query,
                        (computador, pa, grupo) =>
                        {
                            computador.fk_compComputador_Pa = pa;
                            pa.Fk_gurupoModel = grupo;
                            return computador;
                        },
                        new { empresa = Empresa, Resfiltro = resfiltro },
                        splitOn: "id_pa,id_grupo"
                    );
                    return resultados.ToList();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public List<computadorModel> FiltroMapInitFiltroMapInit(string query)
        {
            try
            {
                using (var conexao = new banco().conexao())
                {
                    conexao.Open();
                    var resultados = conexao.Query<computadorModel, paModel, grupos_pa, computadorModel>(
                        query,
                        (computador, pa, grupo) =>
                        {
                            computador.fk_compComputador_Pa = pa;
                            pa.Fk_gurupoModel = grupo;
                            return computador;
                        },
                        splitOn: "id_pa,id_grupo"
                    );
                    return resultados.ToList();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        //public List<computadorModel> FiltroMapInitFiltroMapInit(string query)
        //{
        //    try
        //    {
        //        using (var conexao = new banco().conexao())
        //        {
        //            conexao.Open();
        //            var resultados = conexao.Query<computadorModel, paModel, grupos_pa, computadorModel>(
        //                query,
        //                (computador_teste, pa_teste, grupo_teste) =>
        //                {
        //                    computador_teste.fk_compComputador_Pa = pa_teste;
        //                    pa_teste.Fk_gurupoModel = grupo_teste;
        //                    return computador_teste;
        //                },
        //                splitOn: "id_pa,id_grupo"
        //            );
        //            return resultados.ToList();
        //        }
        //    }
        //    catch (MySqlException e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //    return null;
        //}
        public string condicao(string query)
        {
            Query q = new Query();

            switch (query)
            {
                case "grupos":
                    return q.gruposFiltroCompMapeamento;

                case "pa":
                    return q.paFiltroCompMapeamento;

                case "TALK_id":
                    return q.TalkfiltroCompMapeamento;

                case "patrimonio":
                    return q.PatrifiltroCompMapeamento;

                case "todos":
                    return q.TodfiltroCompMapeamento;

                case "todosclube":
                    return q.TodClub;

                case "tag_servico":
                    return q.TagFiltroCompMapeamento;

                case "memoria":
                    return q.memoria;

                case "processador":
                    return q.processador;
                default:
                    return null;
            }

        }

        public Double depreciacao(DateTime dataCompra, Double valor)
        {
            double depreciacao = 0.20;
            double valorRespostaDepreciacao = 0.0;
            if (dataCompra != null)
            {
                int diferenca =  DateTime.Now.Year - dataCompra.Year;

                if (diferenca <= 5 )
                {
                    for (int i = 0; i < diferenca; i++)
                    {
                        valorRespostaDepreciacao += valor* depreciacao;
                    }
                    return valor-valorRespostaDepreciacao;

                }
            }
            return 0;
        }
     }

}





