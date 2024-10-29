using ProjetoDeControleDeMateriaisMandadoParaConserto.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class Imobilizados : Form
    {
        private DataTable tabela = new DataTable();
        private DataTable tabelaimob = new DataTable();
        MapeamentoPcsDao map = new MapeamentoPcsDao();
        private List<String> Maximidia = new List<string> { "administrativo", "condenada", "coordenacao", "coordenacao", "operacao maximidia", "placar", "procurar", "supervisao", "todos", "Ti", "treinamento 2","todos" };
        private List<String> ClubeMaxi = new List<string> { "administrativo", "condenada", "Diretoria", "operacao clube", "todos", "procurar", "supervisao clube","Ti" };
        public Imobilizados()
        {
            InitializeComponent();
            carregaTabelaPC();
            carregaImobilizados();
            dataGridView.RowPrePaint += new DataGridViewRowPrePaintEventHandler(MudaCorComputador);
            dataGridViewImob.RowPrePaint += new DataGridViewRowPrePaintEventHandler(MudaCorImob);
        }
       
        private void BtnPatrimonio_Click(object sender, EventArgs e)
        {
            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor Escolha a empresa");
            }
            else if (string.IsNullOrEmpty(textPatrimonioPc.Text.ToString()))
            {
                MessageBox.Show("Por Favor digite o Patrimonio");

            }
            else
            {
                tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(ComboEmpresa.SelectedItem.ToString(), textPatrimonioPc.Text.ToString(), "patrimonio");
                quantidadeDeSistemas.DataSource = map.QuantiSistemas(tabela);
                dataGridView.DataSource = tabela;
                ComboEmpresa.SelectedIndex = -1;
                setarLabel(tabela.Rows.Count, LabelString, LabelTotalComputador);
            }

        }


        private void carregaTabelaPC()
        {
            tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio("", "", "");
            quantidadeDeSistemas.DataSource = map.QuantiSistemas(tabela);
            dataGridView.DataSource = tabela;
            dataGridView.DefaultCellStyle.Font = new Font("Arial", 8);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            quantidadeDeSistemas.DefaultCellStyle.Font = new Font("Arial", 8);
            quantidadeDeSistemas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            setarLabel(tabela.Rows.Count, LabelString, LabelTotalComputador);
        }

        private void carregaImobilizados()
        {
            tabelaimob =ImobilizadosDll.TabelasDao.Tabelas.TabelaInicial();
            dataGridViewImob.DataSource=tabelaimob;
            dataGridViewImob.DefaultCellStyle.Font = new Font("Arial", 8);
            dataGridViewImob.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dataGridViewImob.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void MudaCorComputador(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            if (e.RowIndex % 2 == 0)
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }

            this.dataGridView.GridColor = Color.BlueViolet;
        }

        private void MudaCorImob(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            if (e.RowIndex % 2 == 0)
            {
                dataGridViewImob.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                dataGridViewImob.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }

            this.dataGridView.GridColor = Color.BlueViolet;
        }

        private void BtnPa_Click(object sender, EventArgs e)
        {
            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor Escolha a empresa");
            }
            else if (string.IsNullOrEmpty(textPa.Text.ToString()))
            {
                MessageBox.Show("Por Favor digite a Pa");

            }
            else
            {
                tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(ComboEmpresa.SelectedItem.ToString(), textPa.Text.ToString(), "pa");
                quantidadeDeSistemas.DataSource = map.QuantiSistemas(tabela);
                dataGridView.DataSource = tabela;
                ComboEmpresa.SelectedIndex = -1;
                setarLabel(tabela.Rows.Count, LabelString, LabelTotalComputador);

            }
        }

        private void BtnTag_Click(object sender, EventArgs e)
        {
            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor Escolha a empresa");
            }
            else if (string.IsNullOrEmpty(textTag.Text.ToString()))
            {
                MessageBox.Show("Por Favor digite a Server Tag");

            }
            else
            {
                tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(ComboEmpresa.SelectedItem.ToString(), textTag.Text.ToString().ToUpper(), "tag_servico");
                quantidadeDeSistemas.DataSource = map.QuantiSistemas(tabela);
                dataGridView.DataSource = tabela;
                ComboEmpresa.SelectedIndex = -1;
                setarLabel(tabela.Rows.Count, LabelString, LabelTotalComputador);
            }
        }

        private void BtnSetor_Click(object sender, EventArgs e)
        {

            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor Escolha a empresa");
            }
            else if (comboSetor.SelectedIndex < 0 )
            {
                MessageBox.Show("Por Favor escolha o setor");

            }
            else
            {
                string comboboxSetor = comboSetor == null ? "" : comboSetor.SelectedItem.ToString();
                string empresa = ComboEmpresa == null ? "" : ComboEmpresa.SelectedItem.ToString();
                if (empresa.Equals("Clube Maxivida") && comboboxSetor.Equals("todos"))
                {
                    tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(empresa, comboboxSetor, "todosclube");
                    quantidadeDeSistemas.DataSource = map.QuantiSistemas(tabela);
                    setarLabel(tabela.Rows.Count, LabelString, LabelTotalComputador);

                }
                else
                {
                    if (comboboxSetor.Equals("todos") && empresa.Equals("Maximidia"))
                    {
                        tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(empresa, comboboxSetor, comboboxSetor);
                    }
                    else
                    {
                        tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(empresa, comboboxSetor, "grupos");
                    }
                }
                setarLabel(tabela.Rows.Count, LabelString, LabelTotalComputador);
                dataGridView.DataSource = tabela;
                quantidadeDeSistemas.DataSource = map.QuantiSistemas(tabela);
            }
        }

        //private void ComboEmpresa_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    string empresa= ComboEmpresa==null?"":ComboEmpresa.SelectedItem.ToString();
        //    map.PreencherCombo("setores", empresa, comboSetor, Maximidia, ClubeMaxi);
        //}

        private void ComboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> combo = new List<string>();

            string empresa = ComboEmpresa.SelectedIndex < 0? ComboEmpresa.SelectedText : ComboEmpresa.SelectedItem.ToString();
            // map.PreencherCombo("setores", empresa, comboSetor, Maximidia, ClubeMaxi);
            comboSetor1.SelectedIndex = -1;
            
            comboSetor1.Items.Clear();
            map.PreencherCombo("setores", empresa, comboSetor, ImobilizadosDll.TabelasDao.Tabelas.RetornaComboBoxPc(empresa));
            combo = ImobilizadosDll.TabelasDao.Tabelas.RetornaComboBox(empresa);
            foreach (var item in combo)
            {
                comboSetor1.Items.Add(item.ToString());
            }
            comboSetor1.Items.Add("Todos");
        }


        private void setarLabel(int row,  Label label1, Label label2)
        {
            if (row == 0)
            {
                label1.Visible = false;
                label2.Visible = false;
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                label2.Text = row.ToString();
            }
        }

        private void btnImob_Click(object sender, EventArgs e)
        {
            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a Empresa");
            }
            else if (textImobPatrimonio.Text.Equals(""))
            {
                MessageBox.Show("Por favor Digitar o patrimonio");
            }
            else
            {
                string empresa = ComboEmpresa.SelectedIndex < 0 ? ComboEmpresa.SelectedText : ComboEmpresa.SelectedItem.ToString();
                tabelaimob = ImobilizadosDll.TabelasDao.Tabelas.gruposImobGruposPc(empresa, "patrimonio", textImobPatrimonio.Text);
                dataGridViewImob.DataSource = tabelaimob;
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a Empresa");
            }

            else if(textItem.Text.Equals(""))
            {
                
                 MessageBox.Show("Por favor Digitar o nome do item");
            }
            else
            {
                string empresa = ComboEmpresa.SelectedIndex < 0 ? ComboEmpresa.SelectedText : ComboEmpresa.SelectedItem.ToString();
                tabelaimob = ImobilizadosDll.TabelasDao.Tabelas.gruposImobGruposPc(empresa, "item", textItem.Text);
                dataGridViewImob.DataSource = tabelaimob;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string empresa = ComboEmpresa.SelectedIndex < 0 ? ComboEmpresa.SelectedText : ComboEmpresa.SelectedItem.ToString();
            string Combogrupos = comboSetor1.SelectedIndex < 0  ? comboSetor1.SelectedText : comboSetor1.SelectedItem.ToString();

            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a empresa");
            }
            else if (comboSetor1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione algum Setor ");
            }
            else if(comboSetor1.SelectedItem.Equals("Todos"))
            {
                tabelaimob = ImobilizadosDll.TabelasDao.Tabelas.gruposImobGruposPc(empresa, "todos", Combogrupos);
                dataGridViewImob.DataSource = tabelaimob;
            }
            else
            {

                tabelaimob = ImobilizadosDll.TabelasDao.Tabelas.gruposImobGruposPc(empresa, "grupos", Combogrupos);
                dataGridViewImob.DataSource = tabelaimob;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                GravadorCsv s = new GravadorCsv();
                if (tabela.Columns.Count == 0)
                {
                    MessageBox.Show("Impossivel gravar a tabela zerada");
                }
                else
                {
                    s.GravarCSV(tabela);
                }
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
                GravadorCsv s = new GravadorCsv();
                if (tabelaimob.Columns.Count == 0)
                {
                    MessageBox.Show("Impossivel gravar a tabela zerada");
                }
                else
                {
                    s.GravarCSV(tabelaimob);
                }
            }
        }

        private void trocarComputadorDePaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrocaPcPa trocaPc = new TrocaPcPa();
            trocaPc.Show();
        }

        private void espelhoOperaçãoMaximidiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspelhoPa espelho = new EspelhoPa();
            espelho.Show();
        }

        private void Imobilizados_Load(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Checked = false;
                 carregaTabelaPC();
            }
        }

        private void Digi_Click(object sender, EventArgs e)
        {

        }

        private void BtnMemoria_Click(object sender, EventArgs e)
        {
            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor Escolha a empresa");
            }
            else if (string.IsNullOrEmpty(TextoMemoria.Text.ToString()))
            {
                MessageBox.Show("Por Favor digite a Server Tag");

            }
            else
            {
                string texto = "%" + TextoMemoria.Text.ToString() + "%";
                tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(ComboEmpresa.SelectedItem.ToString(), texto.ToUpper(), "memoria");
                quantidadeDeSistemas.DataSource = map.QuantiSistemas(tabela);
                dataGridView.DataSource = tabela;
                ComboEmpresa.SelectedIndex = -1;
                
                setarLabel(tabela.Rows.Count, LabelString, LabelTotalComputador);
            }



        }

        private void BtnProcessador_Click(object sender, EventArgs e)
        {
            if (ComboEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor Escolha a empresa");
            }
            else if (string.IsNullOrEmpty(TextoProcessador.Text.ToString()))
            {
                MessageBox.Show("Por Favor digite o processador");

            }
            else
            {
                string Text = "%" + TextoProcessador.Text.ToString() + "%";
                tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(ComboEmpresa.SelectedItem.ToString(), Text.ToUpper(), "processador");
                quantidadeDeSistemas.DataSource = map.QuantiSistemas(tabela);
                dataGridView.DataSource = tabela;
                ComboEmpresa.SelectedIndex = -1;
                setarLabel(tabela.Rows.Count, LabelString, LabelTotalComputador);
            }

        }
    }
}


