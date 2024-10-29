using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    internal class AindaNaoConsertoDao
    {
        private SelectFiltro s = new SelectFiltro();

        public void GravarCsv(List<object[]> dados)
        {
            try
            {
                string nomeArquivo = "InsersaoDbPlanilha.csv";
                string caminhoPastaAreaDeTrabalho = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string caminhoArquivo = Path.Combine(caminhoPastaAreaDeTrabalho, nomeArquivo); // Caminho completo do arquivo CSV

                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true, Encoding.UTF8))
                {

                    List<String> columnTitles = new List<String>
                    {
                     "NOME DO MATERIAL ","NUMERO", "QUANTIDADE DE CONSERTO","DATAS DE CONSERTO","DIAS DE GARANTIA ", "GARANTIA", "DATA ATUAL"
                    };
                    writer.WriteLine(String.Join(";", columnTitles));

                    foreach (Object[] rowData in dados)
                    {
                        List<String> row = new List<String>(); // Inicialize a lista row

                        for (int i = 1; i < rowData.Length; i++)
                        {
                            // Adicione os dados à lista de colunas, exceto as datas
                            if (i != rowData.Length) // Ignora a penúltima coluna (última data antes da atual)
                            {
                                row.Add(rowData[i].ToString());
                            }
                        }


                        string dataString = rowData[rowData.Length - 1].ToString();
                        string[] datas = dataString.Split(',');
                        int elemento = datas.Length;

                        DateTime dataAtual = DateTime.Now;

                        DateTime dataConserto = DateTime.MinValue;

                        if (elemento >= 2)
                        {
                            DateTime.TryParse(datas[elemento - 1].Trim(), out dataConserto);
                            String dia = s.CalcularDias(dataConserto);
                            String garantia = s.CalcularGarantia(dataConserto);
                            row.Add(dia);
                            row.Add(garantia);
                        }
                        else
                        {
                            DateTime.TryParse(datas[elemento - 1].Trim(), out dataConserto);
                            String dia = s.CalcularDias(dataConserto);
                            String garantia = s.CalcularGarantia(dataConserto);
                            row.Add(dia);
                            row.Add(garantia);
                        }

                        row.Add(dataAtual.ToString("yyyy-MM-dd"));
                        
                        writer.WriteLine(String.Join(";", row));
                    }

                    MessageBox.Show("Dados salvos no arquivo CSV");
                    writer.Flush();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Desculpe, não foi possível gravar esses dados: " + ex.Message);
            }



        }
    }
}



