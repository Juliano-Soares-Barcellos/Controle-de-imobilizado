using Dapper;
using ImobilizadosDll.Consulta;
using ImobilizadosDll.Data;
using ImobilizadosDll.model;
using ImobilizadosDll.TabelasDao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadosDll.Dao
{
    public class Select
    {
        public Query query = new Query();
        public List<ComputadorModel> TodosDadosDoComputador(string sql)
        {
            try
            {
                using (var conexao = new Banco().conexao())
                {
                    conexao.Open();
                    var resultados = conexao.Query<ComputadorModel, PaModel, Grupos_paModel, ComputadorModel>(
                        sql,
                        (computador, pa, grupo) =>
                        {
                            computador.Fk_compComputador_Pa = pa;
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

        public List<ImobilizadosModel> TodosDadosDosImobilizados()
        {
            using (var conexao = new Banco().conexao())
            {
                var resultados = conexao.Query<ImobilizadosModel, Grupos_paModel, classificacao_contabilModel, EmpresaModel, ImobilizadosModel>(
                    @"select * from imobilizados left join grupos_pa on grupos_pa.id_grupo=imobilizados.fk_grupos  left join classificacao_contabil on classificacao_contabil.Id_classificacao_contabil = imobilizados.fk_contabil inner join empresas on empresas.id_empresas= imobilizados.Fk_Empresa ;",
                    (imobilizado, grupo, classificacao_contabil, empresa) =>
                    {
                        imobilizado.grupo = grupo;
                        imobilizado.contabil = classificacao_contabil;
                        imobilizado.empresa = empresa;

                        return imobilizado;
                    },
                    splitOn: "id_Imobilizado, id_grupo, Id_classificacao_contabil, id_empresas"
                );

                return resultados.ToList();
            }
        }
        public List<ImobilizadosModel> RetornaGruposImob(string Empresa, string resfiltro, string query)
        {
       
                using (var conexao = new Banco().conexao())
                {
                    conexao.Open();
                    var resultados = conexao.Query<ImobilizadosModel, Grupos_paModel, classificacao_contabilModel, EmpresaModel, ImobilizadosModel>
                   (
                        query,
                        (imobilizado, grupo, classificacao_contabil, empresa) =>
                        {
                            imobilizado.grupo = grupo;
                            imobilizado.contabil = classificacao_contabil;
                            imobilizado.empresa = empresa;

                            return imobilizado;
                        },
                        new { empresa = Empresa, resfiltro = resfiltro },
                         splitOn: "id_Imobilizado, id_grupo, Id_classificacao_contabil, id_empresas"
                    );
                    return resultados.ToList();
                }
        }

        public List<ComputadorModel> RetornaGruposPc(string Empresa, string Resfiltro, string query)
        {
            using (var conexao = new Banco().conexao())
            {
                conexao.Open();
                var resultados = conexao.Query<ComputadorModel, PaModel, Grupos_paModel, ComputadorModel>
               (
                    query,
                    (computador, pa, grupo) =>
                    {
                        computador.Fk_compComputador_Pa = pa;
                        pa.Fk_gurupoModel = grupo;
                        return computador;
                    },
                    new { empresa = Empresa, resfiltro = Resfiltro },
                    splitOn: "id_pa,id_grupo"
                );
                return resultados.ToList();
            }
        }

        public List<Grupos_paModel> RetornaSetor(string empresa)
        {
            Query query = new Query();
            using (var conexao = new Banco().conexao())
            {
                conexao.Open();

                var resultados = conexao.Query<Grupos_paModel>(query.setor,new { empresa });
               
                return resultados.ToList();
            }
        }

        public List<ImobilizadosModel> RetornaTodosImob(string Empresa, string query)
        {
            using (var conexao = new Banco().conexao())
            {
                conexao.Open();
                var resultados = conexao.Query<ImobilizadosModel, Grupos_paModel, classificacao_contabilModel, EmpresaModel, ImobilizadosModel>
               (
                    query,
                    (imobilizado, grupo, classificacao_contabil, empresa) =>
                    {
                        imobilizado.grupo = grupo;
                        imobilizado.contabil = classificacao_contabil;
                        imobilizado.empresa = empresa;

                        return imobilizado;
                    },
                    new { empresa = Empresa},
                     splitOn: "id_Imobilizado, id_grupo, Id_classificacao_contabil, id_empresas"
                );
                return resultados.ToList();
            }
        }
        public List<ComputadorModel> RetornaImobFiltroEmpresaPc(string Empresa, string query)
        {
            using (var conexao = new Banco().conexao())
            {
                conexao.Open();
                var resultados = conexao.Query<ComputadorModel, PaModel, Grupos_paModel, ComputadorModel>
               (
                    query,
                    (computador, pa, grupo) =>
                    {
                        computador.Fk_compComputador_Pa = pa;
                        pa.Fk_gurupoModel = grupo;
                        return computador;
                    },
                    new { empresa = Empresa },
                    splitOn: "id_pa,id_grupo"
                );
                return resultados.ToList();
            }
        }
        public List<PaModel> RetornaPaEscolhida(string Empresa, string pas, string query, string grupos)
        {
            using (var conexao = new Banco().conexao())
            {
                conexao.Open();
                var resultado = conexao.Query<PaModel, Grupos_paModel, PaModel>
                (
                    query,
                    (pa, grupo) =>
                    {
                        pa.Fk_gurupoModel = grupo;
                        return pa;
                    },
                    new { empresa = Empresa, pas = pas, grupos = grupos },
                    splitOn: "id_pa,id_grupo"
                );
                return resultado.ToList();
            }
        }

        public ComputadorModel RetornaPcParaTroca(string empresa, string pa)
        {
            Query query = new Query();
            using (var conexao = new Banco().conexao())
            {
                conexao.Open();

                var resultados = conexao.QueryFirstOrDefault<ComputadorModel>(query.RetornaPcFiltro, new { empresa ,pa});

                return resultados;
            }
        }

        public List<ComputadorModel> RetornaSetorPc(string empresa)
        {
            Query query = new Query();
            using (var conexao = new Banco().conexao())
            {
                conexao.Open();

                var resultados = conexao.Query<ComputadorModel>(query.setorPc, new { empresa });

                return resultados.ToList();
            }
        }
    }
}



