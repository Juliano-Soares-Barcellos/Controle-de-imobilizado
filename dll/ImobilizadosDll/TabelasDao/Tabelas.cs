using ImobilizadosDll.Consulta;
using ImobilizadosDll.Dao;
using ImobilizadosDll.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadosDll.TabelasDao
{
    public static class Tabelas
    {
        public static DataTable TabelaInicial()
        {
            Select consulta = new Select();

            DataTable tabela = new DataTable();

            List<ComputadorModel> computador = new List<ComputadorModel>();

            List<ImobilizadosModel> imobilizados = new List<ImobilizadosModel>();

            computador = consulta.TodosDadosDoComputador("select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id order by patrimonio;");

            imobilizados = consulta.TodosDadosDosImobilizados();

            MontaColunasElinhas montaTabela = new MontaColunasElinhas();

            tabela = montaTabela.MinhasColunas();

            foreach (var item in computador)
            {
                tabela.Rows.Add(montaTabela.MinhasLinhasPC(item, tabela));
            }

            foreach (var item in imobilizados)
            {
                tabela.Rows.Add(montaTabela.MinhasLinhasImobilizado(item, tabela));
            }

            return tabela;
        }

        public static DataTable gruposImobGruposPc(string empresa, string coluna, string filtro)
        {
            List<ComputadorModel> pc = new List<ComputadorModel>();
            List<ImobilizadosModel> imob = new List<ImobilizadosModel>();
            Select select = new Select();
            MontaColunasElinhas linha = new MontaColunasElinhas();
            DataTable tabela = new DataTable();

            string consultaDb = "";
            string empresaNum = empresa == "Maximidia" ? "1" : "2";

            if (coluna.Equals("item")) filtro = "%" + filtro + "%";

            if (coluna.Equals("todos"))
            {
                consultaDb = linha.VerificaGruposImob(coluna, "imob");

                imob = select.RetornaTodosImob(empresaNum, consultaDb);

                consultaDb = linha.VerificaGruposImob(coluna, "pc");

                pc = select.RetornaImobFiltroEmpresaPc(empresa,consultaDb);

            }
            else
            {
                consultaDb = linha.VerificaGruposImob(coluna, "imob");

                imob = select.RetornaGruposImob(empresaNum, filtro, consultaDb);

                consultaDb = linha.VerificaGruposImob(coluna, "pc");

                pc = select.RetornaGruposPc(empresa, filtro, consultaDb);
            }

            tabela = linha.MinhasColunas();

            foreach (var item in pc)
            {
                tabela.Rows.Add(linha.MinhasLinhasPC(item, tabela));
            }

            foreach (var item in imob)
            {
                tabela.Rows.Add(linha.MinhasLinhasImobilizado(item, tabela));
            }
            return tabela;
        }


        public static List<string> RetornaComboBox(string empresa)
        {
            string valor = empresa == "Maximidia" ? "1" : "2";
            Select select = new Select();
            MontaColunasElinhas linha = new MontaColunasElinhas();
            List<String> PreenchaComboBox = new List<String>();
            List<Grupos_paModel> gp = new List<Grupos_paModel>();
            gp = select.RetornaSetor(valor);

            foreach (var item in gp)
            {
                PreenchaComboBox.Add(item.Grupos.ToLower());
            }
            return PreenchaComboBox;
        }

        public static List<object> trocaPa(string empresa,string patrimonio,string pa,string setor)
        {
            try
            {
                Query query = new Query();
                MontaColunasElinhas linha = new MontaColunasElinhas();
                Select select = new Select();
                List<object> RetornoPcs = null;
                ComputadorModel retornaDadosDoPcAtual = linha.PegarDadosDoPcAntesDaTroca(patrimonio, empresa);
                ComputadorModel retornaDadosDaPaRequerida = new ComputadorModel();
                int paRequerida = 0;
                int id_pa = 0;
                List<PaModel> PA = select.RetornaPaEscolhida(empresa, pa, query.acharPa, setor);
                foreach (var item in PA)
                {
                    retornaDadosDaPaRequerida = select.RetornaPcParaTroca(empresa, item.Id_pa.ToString());

                    if (retornaDadosDaPaRequerida != null)
                    {
                        paRequerida = item.Pa;
                        id_pa = item.Id_pa;
                        break;
                    }
                }

                if (retornaDadosDaPaRequerida != null)
                {
                    RetornoPcs = new List<object> {
                    retornaDadosDoPcAtual.Patrimonio,
                    retornaDadosDoPcAtual.Fk_compComputador_Pa.Pa,
                    retornaDadosDoPcAtual.Fk_compComputador_Pa.Id_pa,
                    retornaDadosDaPaRequerida.Patrimonio,
                    paRequerida,
                    id_pa};
                }
                else
                {
            
                    RetornoPcs = new List<object> { retornaDadosDoPcAtual.Patrimonio, pa, PA[0].Id_pa.ToString() };
                }
                return RetornoPcs;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public static List<string> RetornaComboBoxPc(string empresa)
        {
            Query query = new Query();
            Select select = new Select();
            MontaColunasElinhas linha = new MontaColunasElinhas();
            List<String> PreenchaComboBox = new List<String>();
            List<ComputadorModel> gp = new List<ComputadorModel>();
            gp = select.RetornaImobFiltroEmpresaPc(empresa, query.setorPc);

            foreach (var item in gp)
            {
                PreenchaComboBox.Add(item.Fk_compComputador_Pa.Fk_gurupoModel.Grupos.ToLower());
            }
            PreenchaComboBox.Add("todos");
            return PreenchaComboBox;
        }

        public static List<String> RetornaComboBoxPC(string empresa)
        {
            List<String> RetornoCombo = new List<String>();
            List<ComputadorModel> computador = new List<ComputadorModel>();
            Select select = new Select();
            computador = select.RetornaSetorPc(empresa);
            foreach (var item in computador)
            {
                RetornoCombo.Add(item.Fk_compComputador_Pa.Fk_gurupoModel.Grupos.ToString().ToLower().Trim());
            }
            return RetornoCombo;



            
        }
    }
}
