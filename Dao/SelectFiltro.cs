using MySql.Data.MySqlClient;
using ProjetoDeControleDeMateriaisMandadoParaConserto.BancoConexao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    internal class SelectFiltro
    {
        private MySqlConnection con = null;

        public List<Object[]> carregarTabela(int Mes, int Ano, string sql)
        {
            List<Object[]> resultados = new List<Object[]>();

            try
            {
                con = new Banco().Conexao();
                con.Open();
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@Mes", Mes);
                comando.Parameters.AddWithValue("@Ano", Ano);
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
                pivotTable.Columns.Add("Nome", typeof(string));
                pivotTable.Columns.Add("Numero", typeof(string));
                pivotTable.Columns.Add("quantidade_conserto", typeof(int));
                pivotTable.Columns.Add("Data Conserto", typeof(DateTime));
                pivotTable.Columns.Add("Garantia", typeof(string));
                pivotTable.Columns.Add("Dias de Garantia", typeof(string));

                // Pivotar os dados e preencher as colunas de datas de conserto
                foreach (Object[] row in dados)
                {
                    int id = (int)row[0];
                    string nome = (string)row[1];
                    string numero = row[2].ToString();
                    int quantidadeConserto = (int)row[3];
                    DateTime Data = (DateTime)row[5];

                    DataRow newRow = pivotTable.NewRow();
                    newRow["Nome"] = nome;
                    newRow["Numero"] = numero;
                    newRow["quantidade_conserto"] = quantidadeConserto;
                    newRow["Data Conserto"] = Data.ToString("dd/MM/yyyy");


                    DateTime ultimaDataConserto = Data;
                    newRow["Garantia"] = CalcularGarantia(ultimaDataConserto);
                    newRow["Dias de Garantia"] = CalcularDias(ultimaDataConserto);
                    pivotTable.Rows.Add(newRow);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return pivotTable;
        }

        public int CalcularMesConserto(List<Object[]> dados)
        {
            int totalConserto = 0;

            foreach (Object[] row in dados)
            {
                totalConserto++;
            }

            return totalConserto;

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


        public int CalcularQuantidadeGarantia(List<Object[]> dados)
        {
            int totalComGarantia = 0;

            foreach (object[] row in dados)
            {
                DateTime dataConserto = (DateTime)row[5];
                if (dataConserto != DateTime.MinValue)
                {
                    TimeSpan diferenca = DateTime.Now.Date - dataConserto.Date;
                    if (diferenca.Days <= 90)
                    {
                        totalComGarantia++;
                    }
                }
            }

            return totalComGarantia;
        }

        public string CalcularGarantia(DateTime ultimaDataConserto)
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
                return "Sem Garantia";
            }
        }
        public string CalcularDias(DateTime Data)
        {
            if (Data != DateTime.MinValue)
            {
                TimeSpan diferenca = DateTime.Now.Date.Subtract(Data);
                TimeSpan duracao = new TimeSpan(90, 0, 0, 0);
                TimeSpan res = duracao.Subtract(diferenca);

                if (res.Days <= 90 && res.Days >= 1)
                {
                    return   res.Days.ToString() ;
                }
                else if (res.Days <= 0 && res.Days >= -15)
                {
                    return  res.Days.ToString();
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }

        }


        public List<Object[]> BuscaPreenchimentoGrafico(String Data1, String Data2, string sql)
        {
            List<Object[]> resultados = new List<Object[]>();

            try
            {
                con = new Banco().Conexao();
                con.Open();

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@data1", Data1);
                comando.Parameters.AddWithValue("@data2", Data2);
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
    }
}
