using ImobilizadosDll.Consulta;
using ImobilizadosDll.Dao;
using ImobilizadosDll.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadosDll.TabelasDao
{
    public class MontaColunasElinhas
    {
        CultureInfo cultura = new CultureInfo("pt-BR");
       

        public DataTable MinhasColunas()
        {
            DataTable data = new DataTable();
            data.Columns.Add("patrimonio", typeof(string));
            data.Columns.Add("item", typeof(string));
            data.Columns.Add("Estado da Conservação", typeof(string));
            data.Columns.Add("data da compra", typeof(string));
            data.Columns.Add("Nota fiscal", typeof(string));
            data.Columns.Add("Fornecedor", typeof(string));
            data.Columns.Add("valor", typeof(string));
            data.Columns.Add("vida util", typeof(string));
            data.Columns.Add("depreciacao", typeof(string));
            data.Columns.Add("local", typeof(string));
            data.Columns.Add("Classificacao", typeof(string));
            data.Columns.Add("empresa", typeof(string));

            return data;
        }

        public DataRow MinhasLinhasPC(ComputadorModel computador, DataTable tabela)
        {
            DataRow row = null;

            if (computador != null)
            {
                row = tabela.NewRow();

                row["patrimonio"] = computador.Patrimonio;
                row["item"] = "Computador " + computador.Tag_servico;
                row["Estado da Conservação"] = computador.Conservacao;
                row["data da compra"] = dataNormal(computador.DataCompra);
                row["Nota fiscal"] = computador.Nota_fiscal;
                row["Fornecedor"] = computador.Fornecedor;
                row["valor"] = valorFormatadoEmDinheiro(computador.Valor);
                row["vida util"] = "5";
                row["depreciacao"] = 20;
                row["local"] = computador.Fk_compComputador_Pa.Fk_gurupoModel.Grupos;
                row["Classificacao"] = "1011 - EQUIPAMENTOS DE INFORMÁTICA";
                row["empresa"] = computador.Empresa;

            }
            return row;
        }
        public DataRow MinhasLinhasImobilizado(ImobilizadosModel imob, DataTable tabela)
        {
            DataRow row = null;

            if (imob != null)
            {
                row = tabela.NewRow();

                row["patrimonio"] = imob.Patrimonio;
                row["item"] = imob.Item;
                row["Estado da Conservação"] = imob.Estado_de_Conservacao;
                row["data da compra"] = dataNormal(imob.Data_Compra);
                row["Nota fiscal"] = imob.Nota_Fiscal;
                row["Fornecedor"] = imob.Fornecedor;
                row["valor"] = valorFormatadoEmDinheiro(imob.Valor);
                row["vida util"] = "5";
                row["depreciacao"] = imob.Depreciacao;


                if (imob.grupo == null)
                {
                    row["local"] = "";

                }
                else
                {
                    row["local"] = imob.grupo.Grupos;

                }
                row["Classificacao"] = imob.contabil.Classificacao;
                row["empresa"] = imob.empresa.Empresa;
            }
            return row;
        }


        public string valorFormatadoEmDinheiro(double valor)
        {
            return valor.ToString("C", cultura);
        }

        public string dataNormal(DateTime data)
        {
            data = Convert.ToDateTime(data);
            string DataFormatada = data.ToString("dd/MM/yyyy");
            return DataFormatada;
        }

        public string VerificaGruposImob(string grupos, string imob)
        {
            Query query = new Query();
            switch (grupos)
            {
                case "grupos":
                    return imob == "imob" ? query.GrupoImobilizados : query.GruposImobilizadoPC;

                case "patrimonio":
                    return imob == "imob" ? query.retornaPatrimonioImob : query.retornaPatrimonioPc;

                case "item":
                    return imob == "imob" ? query.retornaProcuraItem : query.procuraTagPc;

                case "todos":
                    return imob == "imob" ? query.retornaProcuraTodosImobEmpresa : query.retornaProcuraPcEmpresa;

            }
            return "";
        }
        public ComputadorModel PegarDadosDoPcAntesDaTroca(string patrimonio, string empresa)
        {
           
            try
            {
                Query query = new Query();
                List<ComputadorModel> pc = new List<ComputadorModel>();
                Select select = new Select();
                pc = select.RetornaGruposPc(empresa, patrimonio, query.retornaPatrimonioPc);

                return pc[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }
    }
}
