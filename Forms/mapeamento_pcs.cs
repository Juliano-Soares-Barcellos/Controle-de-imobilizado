using ProjetoDeControleDeMateriaisMandadoParaConserto.Dao;
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
    public partial class mapeamento_pcs : Form
    {
        DataTable tabela = new DataTable();
        public mapeamento_pcs()
        {
            InitializeComponent();
            carregaTabela();
            dataGridView.RowPrePaint += new DataGridViewRowPrePaintEventHandler(MudaCor);
        }

        private List<String> Maximidia = new List<string> { "operacao maximidia", "supervisao", "placar", "coordenacao", "administrativo", "treinamento", "treinamento 2", "condenada", "todos" };
        private List<String> ClubeMaxi = new List<string> { "operacao clube", "condenada", "supervisao clube", "Ti", "todos" };

        string filtro = "";
        string empresa = "";
        MapeamentoPcsDao map = new MapeamentoPcsDao();

        private void BotaoFiltrar_Click(object sender, EventArgs e)
        {
            empresa = Cempresa.SelectedItem==null? Cempresa.Text: Cempresa.SelectedItem.ToString();

            filtro = Cfiltro.SelectedItem==null?Cfiltro.Text :Cfiltro.SelectedItem.ToString();

            if (!filtro.Equals("") && !empresa.Equals(""))
            {
                EnterTab.Visible = true;

                if (filtro.Equals("setores"))
                {
                    map.PreencherCombo(filtro, empresa, CombSetores, Maximidia);
                    CombSetores.Visible = true;
                    Lsetor.Text = "Selecione o setor ";
                    Lsetor.Visible = true;
                    MaskBox.Visible = false;
                }
                else
                {
                    Lsetor.Text = "Digite o(a) " + filtro + " :";
                    CombSetores.Visible = false;
                    Lsetor.Visible = true;
                    MaskBox.Visible = true;
                }
                panel4.Visible = true;
            }
            else
            {
                MessageBox.Show("Por favor ambas as opcoes tem que estar selecionada !");
            }
        }

        private void EnterTab_Click(object sender, EventArgs e)
        {
            String comboboxSetores = CombSetores.SelectedItem == null ? CombSetores.Text : CombSetores.SelectedItem.ToString();
            if (comboboxSetores != "" || !MaskBox.Text.Equals(""))
            {
                if (CombSetores.Visible)
                {
                    if (empresa.Equals("Clube Maxivida") && comboboxSetores.Equals("todos"))
                    {
                        tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(empresa, comboboxSetores, "todosclube");
                        quantidadeSistemas.DataSource = map.QuantiSistemas(tabela);
                    }
                    else
                    {
                        if (Cfiltro.SelectedItem.Equals("setores") )
                        {
                            if(comboboxSetores.Equals("todos") && empresa.Equals("Maximidia") )
                            {
                                tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(empresa, comboboxSetores, comboboxSetores);
                            }
                            else
                            {
                                 tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(empresa, comboboxSetores, "grupos");
                            }
                            quantidadeSistemas.DataSource = map.QuantiSistemas(tabela);
                        }
                        else
                        {
                            tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(empresa, comboboxSetores, Cfiltro.SelectedItem.ToString());
                            quantidadeSistemas.DataSource = map.QuantiSistemas(tabela);
                        }
                    }
                }
                else
                {
                    tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio(empresa, MaskBox.Text, filtro);
                    quantidadeSistemas.DataSource = map.QuantiSistemas(tabela);
                }
            }
            else
            {
                MessageBox.Show("Precisa preencher");
            }
            dataGridView.DataSource = tabela;
            quantidadeSistemas.DataSource = map.QuantiSistemas(tabela); ;
            panel4.Visible = false;
            MaskBox.Text="";
            CombSetores.SelectedItem=null;

        }


        private void MudaCor(object sender, DataGridViewRowPrePaintEventArgs e)
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

        public void carregaTabela()
        {
            tabela = computadoresMapeadosEconsertado.Dao.montarTabelasDao.Patrimonio("", "", "");
            quantidadeSistemas.DataSource= map.QuantiSistemas(tabela);
            //List<int> sistemas = map.quantiSistemas(tabela);

            //foreach (DataTable item in tabela.Rows)
            //{
            //    item["sistemas operacionais"].
            //}

            //w7.Text = sistemas[0].ToString();
            //w8.Text = sistemas[1].ToString();
            //w10.Text = sistemas[2].ToString();
            //w11.Text = sistemas[3].ToString();
            dataGridView.DataSource = tabela;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quantidadeSistemas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
