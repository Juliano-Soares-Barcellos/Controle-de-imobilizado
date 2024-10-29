using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    internal class ArquivoTxtDao
    {
        public void GeararArquivoTxt(String headset, String Discador, String Carrapato, int quantidadeHeadset, int quantidadeDiscador, int quantidadeCarrapatos)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivo TXT|*.txt";
                saveFileDialog.Title = "Salvar Arquivo txt";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = saveFileDialog.FileName;
                    // Cria e escreve o conteúdo no arquivo
                    using (StreamWriter writer = new StreamWriter(caminhoArquivo, false, Encoding.UTF8))
                    {
                        List<String> texto = new List<String>();
                        texto.Add($"Quantidade de Headset: {headset}, headset na garantia: {quantidadeHeadset}");
                        texto.Add($"Quantidade de Discador: {Discador}, Discador na garantia: {quantidadeDiscador}");
                        texto.Add($"Quantidade de Carrapato: {Carrapato}, Carrapato na garantia: {quantidadeCarrapatos}");

                        foreach (String item in texto)
                        {
                            writer.WriteLine(item);
                        }
                    }
                    MessageBox.Show("Arquivo criado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
        }

    }
}


