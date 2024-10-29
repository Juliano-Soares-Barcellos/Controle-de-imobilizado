using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    public class ListarConsertoTelaCadastramento
    {
        private DataTable retornaTudoConserto;
        public  DataGridView Tabela;
        private MaskedTextBox textBox1;
        private ComboBox comboBox;
        private CheckBox checkBox3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;

        public ListarConsertoTelaCadastramento(DataGridView tabela, MaskedTextBox textBox1, ComboBox comboBox, CheckBox checkBox3, CheckBox checkBox1, CheckBox checkBox2)
        {
            this.Tabela = tabela;
            this.textBox1 = textBox1;
            this.comboBox = comboBox;
            this.checkBox3 = checkBox3;
            this.checkBox1 = checkBox1;
            this.checkBox2 = checkBox2;
        }

        public void carregarTabela()
        {
            retornaTudoConserto = computadoresMapeadosEconsertado.Dao.montarTabelasDao.TabelaConserto();
            Tabela.DataSource = retornaTudoConserto;
            Tabela.RowPrePaint += new DataGridViewRowPrePaintEventHandler(MudaCor);
        }

        private void MudaCor(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                Tabela.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                Tabela.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(221,221,221);
            }
            this.Tabela.GridColor = Color.BlueViolet;
        }
        public void Apagar()
        {
            if (retornaTudoConserto.Rows.Count > 0) retornaTudoConserto.Reset();

            if (retornaTudoConserto.Rows.Count > 0) retornaTudoConserto.Reset();

        }

        public void procurarPatrimonio()
        {
            Apagar();
            retornaTudoConserto = computadoresMapeadosEconsertado.Dao.montarTabelasDao.retornaPcTabelaPatrimonio(textBox1.Text);
            object pc = retornaTudoConserto.Rows.Count > 0 ? retornaTudoConserto.Rows[0][0].ToString() : "";
            if (pc.ToString() == "")
            {
                MessageBox.Show("Computador não encontrado !");
            }
            else
            {
                Tabela.DataSource = retornaTudoConserto;
                Tabela.RowPrePaint += new DataGridViewRowPrePaintEventHandler(MudaCor);
            }
        }
        public void ProcurarPeloSistema(String sistemaOp)
        {
            this.Apagar();
            retornaTudoConserto = computadoresMapeadosEconsertado.Dao.montarTabelasDao.MontarTabela(sistemaOp);
            Tabela.DataSource = retornaTudoConserto;
            Tabela.RowPrePaint += new DataGridViewRowPrePaintEventHandler(MudaCor);
        }

        public void check()
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                GravadorCsv s = new GravadorCsv();
                if (retornaTudoConserto.Columns.Count == 0)
                {
                    MessageBox.Show("Impossivel gravar a tabela zerada");
                }
                else
                {
                    s.GravarCSV(retornaTudoConserto);
                }
            }
        }

        public void check2()
        {
            this.Apagar();
            TabelaDao t = new TabelaDao();
            retornaTudoConserto = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Ssd();

            Tabela.DataSource = retornaTudoConserto;
            Tabela.RowPrePaint += new DataGridViewRowPrePaintEventHandler(MudaCor);
            checkBox2.Checked = false;
        }

        public void check3()
        {
            this.Apagar();
            carregarTabela();
            Tabela.RowPrePaint += new DataGridViewRowPrePaintEventHandler(MudaCor);
            checkBox3.Checked = false;
        }
       
    }
}
