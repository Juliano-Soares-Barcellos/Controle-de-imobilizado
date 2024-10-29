using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class EspelhoPa : Form
    {
        private DataTable tabela = new DataTable();

        public EspelhoPa()
        {
            InitializeComponent();
            Preenchimento();
            dataGridView1.CellFormatting+= MudaCorComputador;
            NumeroTotaldePaCheiaOuVazias();
            

        }

        private void Preenchimento()
        {
            tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.PasOperacao();
            dataGridView1.DataSource = tabela;
        }

        private void MudaCorComputador(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null ||
                dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() == "")

            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
             }

            else
             {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
             }
        }

        public void NumeroTotaldePaCheiaOuVazias()
        {
            int totalVazia = 0;
            int totalPaOcupada = 0;

            foreach (DataGridViewRow rown in dataGridView1.Rows)
            {
                if (rown.Cells[0].Value == null || rown.Cells[0].Value.ToString() == "")
                {
                    totalVazia += 1;
                }
                else
                {
                    totalPaOcupada += 1;
                }
            }

            lbVazio.Text = totalVazia.ToString();
            lbPaOcupada.Text = totalPaOcupada.ToString();
           
        }


    }
}


