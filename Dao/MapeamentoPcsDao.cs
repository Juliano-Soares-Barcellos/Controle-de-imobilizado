using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    public class MapeamentoPcsDao
    {
        public void PreencherCombo(string setores, string empresa, ComboBox Cmap, List<string> Maximidia)
        {

            if (Maximidia.Count > 0)
            {
                Cmap.Items.Clear();

                foreach (var item in Maximidia)
                {
                    Cmap.Items.Add(item.ToString());
                }
            }

        }

        

        public DataTable QuantiSistemas(DataTable data)
        {
            int linhas = 0;
            DataTable dinamico = new DataTable();
            
            dinamico.Columns.Add("Sistemas", typeof(string));
            dinamico.Columns.Add("Quantidade", typeof(int));

            foreach (DataRow item in data.Rows)
            {
                string sistema = item["sistemas Operacionais"].ToString().Trim();

                if (!string.IsNullOrEmpty(sistema))
                {
                    DataRow[] existingRows = dinamico.Select($"Sistemas = '{sistema}'");
                    if (existingRows.Length > 0)
                    {
                        existingRows[0]["Quantidade"] = Convert.ToInt32(existingRows[0]["Quantidade"]) + 1;
                    }
                    else
                    {

                        DataRow newRow = dinamico.NewRow();
                        newRow["Sistemas"] = sistema;
                        newRow["Quantidade"] = 1;
                        dinamico.Rows.Add(newRow);

                    }
                    linhas +=1;
                    
                }

                if (data.Rows.Count == linhas)
                {
                    DataRow newRow = dinamico.NewRow();
                    newRow["Sistemas"] = "Total :";
                    newRow["Quantidade"] = linhas;
                    dinamico.Rows.Add(newRow);
                }
            }

            return dinamico;
        }


    }
}