using MySql.Data.MySqlClient;
using ProjetoDeControleDeMateriaisMandadoParaConserto.BancoConexao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    internal class SelectTabela
    {
        public MySqlConnection con = null;
        int TotalConserto = 1;

        public List<Object[]> carregarTabela()
        {
            List<Object[]> resultados = new List<Object[]>();

            try
            {
                con = new Banco().Conexao();
                con.Open();
                string sql = "SELECT p.id, p.Nome, p.Numero, p.quantidade_conserto, GROUP_CONCAT(_computadorSaida.Data SEPARATOR ', ') AS Datas FROM Produto AS p INNER JOIN Conserto AS _computadorSaida ON p.id = _computadorSaida.Produto_id GROUP BY p.id, p.Nome, p.Numero, p.quantidade_conserto ORDER BY p.id, _computadorSaida.Data ASC";
                MySqlCommand comando = new MySqlCommand(sql, con);

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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultados;
        }
        public DataTable PivotData(List<Object[]> dados)
        {
            DataTable pivotTable = new DataTable();
            try
            {
                // Adiciona as colunas iniciais (id, Nome, Numero e quantidade_conserto)
                pivotTable.Columns.Add("Nome", typeof(string));
                pivotTable.Columns.Add("Numero", typeof(string));
                pivotTable.Columns.Add("quantidade_conserto", typeof(int));
                pivotTable.Columns.Add("Garantia", typeof(string));
                pivotTable.Columns.Add("Dias de Garantia", typeof(string));

                // Cria um dicionário para armazenar as datas de conserto de cada produto
                Dictionary<int, List<DateTime>> datasPorProduto = new Dictionary<int, List<DateTime>>();

                // Percorre os dados para agrupar as datas de conserto de cada produto
                foreach (Object[] row in dados)
                {
                    int id = (int)row[0];
                    string datas = row[4].ToString();
                    string[] datasArray = datas.Split(',');

                    List<DateTime> datasConserto = new List<DateTime>();
                    foreach (string data in datasArray)
                    {
                        DateTime dataConserto;
                        if (DateTime.TryParse(data.Trim(), out dataConserto))
                        {
                            datasConserto.Add(dataConserto);
                        }
                    }

                    // Adiciona as datas de conserto do produto ao dicionário
                    datasPorProduto[id] = datasConserto;
                }

                // Encontra o maior número de datas de conserto entre os produtos
                int maxDatasPorProduto = datasPorProduto.Values.Max(d => d.Count);

                // Adiciona as colunas de datas de conserto para cada produto
                for (int i = 1; i <= maxDatasPorProduto; i++)
                {
                    DataColumn dataColumn = new DataColumn($"DataConserto{i}", typeof(DateTime));
                    dataColumn.DateTimeMode = DataSetDateTime.Unspecified;

                    pivotTable.Columns.Add(dataColumn);
                }

                // Pivotar os dados e preencher as colunas de datas de conserto
                foreach (Object[] row in dados)
                {
                    int id = (int)row[0];
                    string nome = (string)row[1];
                    string numero = row[2].ToString();
                    int quantidadeConserto = (int)row[3];
                    TotalConserto += quantidadeConserto;

                    DataRow newRow = pivotTable.NewRow();
                    newRow["Nome"] = nome;
                    newRow["Numero"] = numero;
                    newRow["quantidade_conserto"] = quantidadeConserto;

                    // Preenche as colunas de datas de conserto
                    List<DateTime> datasConserto = datasPorProduto[id];
                    datasConserto.Sort(); // Ordena as datas em ordem crescente

                    for (int i = 0; i < datasConserto.Count; i++)
                    {
                        newRow[$"DataConserto{i + 1}"] = datasConserto[i].ToString("dd/MM/yyyy"); // Formatando a data no formato desejado
                    }

                    DateTime ultimaDataConserto = datasConserto.Count > 0 ? datasConserto.Last() : DateTime.MinValue;
                    if (quantidadeConserto != 0)
                    {
                        newRow["Garantia"] = CalcularGarantia(ultimaDataConserto);
                        newRow["Dias de Garantia"] = CalcularDias(ultimaDataConserto);
                        pivotTable.Rows.Add(newRow);
                    }
                    else
                    {
                        newRow["Garantia"] = "Sem Garantia";
                        newRow["Dias de Garantia"] = "sem garantia";
                        pivotTable.Rows.Add(newRow);

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return pivotTable;
        }


        public int CalcularTotalConserto(List<Object[]> dados)
        {
            int totalConserto = 0;

            foreach (Object[] row in dados)
            {
                int quantidadeConserto = (int)row[3];
                totalConserto += quantidadeConserto;
            }

            return totalConserto;
        }
        public int ProdutoConserto(List<Object[]> dados)
        {
            int Produtos = 0;

            foreach (object [] item in dados)
            {
                Produtos++;
            }
            
            return Produtos;
        }


        public List<int> HEADSETDISCADORConserto(List<Object[]> dados)
        {
            List<int> resultados = new List<int>();
            int HEADSET = 0;
            int DISCADOR = 0;
            int CARRAPATOS = 0;

            foreach (Object[] row in dados)
            {
                String NomeProduto = (String)row[1];

                if (NomeProduto.StartsWith("HEADSET",StringComparison.OrdinalIgnoreCase))
                {
                    HEADSET++;
                }

                else if (NomeProduto.StartsWith("DISCADOR",StringComparison.OrdinalIgnoreCase))
                {
                    DISCADOR++;

                }
                else
                {
                    CARRAPATOS++;
                }
            }
            resultados.Add(HEADSET);
            resultados.Add(DISCADOR);
            resultados.Add(CARRAPATOS);

            return resultados;
        }



        private string CalcularGarantia(DateTime ultimaDataConserto)
        {
            if (ultimaDataConserto != DateTime.MinValue)
            {
                TimeSpan diferenca = DateTime.Now.Date - ultimaDataConserto.Date;
                if (diferenca.Days <= 90)
                {
                    return "Com Garantia";
                }
                else
                {
                    return "Sem Garantia";
                }
            }
            else
            {
                return "";
            }
        }
        private string CalcularDias(DateTime Dias)
        {
            if (Dias != DateTime.MinValue)
            {
                TimeSpan diferenca = DateTime.Now.Date.Subtract(Dias);
                TimeSpan duracao = new TimeSpan(90, 0, 0, 0);
                TimeSpan res = duracao.Subtract(diferenca);

                if (res.Days <= 90 && res.Days >= 1)
                {
                    return "tem: " + res.Days + " dias de garantia";
                }
                else if (res.Days <= 0 && res.Days >= -15)
                {
                    return "Excedeu: " + res.Days + " dias de garantia";
                }
                else
                {
                    return "sem garantia";
                }
            }
            else
            {
                return "";
            }

        }
    }
}
