using ProjetoDeControleDeMateriaisMandadoParaConserto.Dao;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Model;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class TelaCadastramentoFones : Form
    {
        private Form1 fecha;
        private DataTable tabelaPivotada;
        private List<Object[]> dados;


        public TelaCadastramentoFones(Form1 f)
        {
            this.fecha = f;
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress;
            CarregarDadosNaTabela();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Digite o Material.");
            }
            else if (comboBox.SelectedIndex == -1 && comboBox.Text.Equals(""))
            {
                MessageBox.Show("Escolha o nome do material.");
            }
            else
            {
                string message = "Deseja prosseguir? Digite 's' para sim ou 'n' para não:";
                string caption = "Confirmação";
               
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, caption, buttons);


                if (result == DialogResult.Yes)
                {
                    NumeroDao numeroDao = new NumeroDao();
                    InsersaoDbPlanilha t = new InsersaoDbPlanilha();
                    string numero = textBox1.Text;
                    string NomeMaterial="";

                    if (comboBox.SelectedIndex == -1)
                    {
                        NomeMaterial = comboBox.Text.ToUpper();
                    }
                    else
                    {
                        NomeMaterial = comboBox.SelectedItem.ToString();
                    }

                    Object[] encontrar = numeroDao.EncontrarNumero(numero);
                    Query query = new Query();
                    if (encontrar.Length > 0)
                    {
                        String sql = (encontrar[3].Equals(0)) ? query.UpdateConsertoIgualZero : query.UpdateConsertoMaisUm;
                        numeroDao.Update(numero, sql);
                        int idProduto = Convert.ToInt32(encontrar[0]);
                        String sqlInsertConserto = query.SqlInsertConserto;
                        numeroDao.NovaData(idProduto, sqlInsertConserto);

                    }
                    else
                    {
                        message = "é para conserto ? Digite 's' para sim ou 'n' para não:";
                        caption = "Confirmação";
                        buttons = MessageBoxButtons.YesNo;

                        result = MessageBox.Show(message, caption, buttons);

                        Produto produto = new Produto()
                        {
                            Nome = NomeMaterial,
                            Numero = numero
                        };
                        Conserto conserto = null;

                        if (result == DialogResult.Yes)
                        {
                            conserto = new Conserto() { Data = DateTime.Now };
                        }

                        t.inserirProduto(produto, conserto);
                        String mensagem = (result.Equals(DialogResult.Yes)) ? "Produto consertado com Sucesso !!! " : "Produto Cadastrado com Sucesso !!! ";
                        MessageBox.Show(mensagem);


                    }
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("nenhum produto foi consertado !!! ");
                }
                CarregarDadosNaTabela();
            }
        }

        public void CarregarDadosNaTabela()
        {
            SelectTabela selectTabela = new SelectTabela();
            dados = selectTabela.carregarTabela();
            tabelaPivotada = selectTabela.PivotData(dados);
            Tabela.DataSource = tabelaPivotada;


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é um dígito numérico ou a tecla de backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Cancela o evento de pressionar a tecla
                e.Handled = true;
            }
        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                GravadorCsv g = new GravadorCsv();
                g.GravarCSV(tabelaPivotada);

            }
        }



        public void gravar()
        {
            AindaNaoConsertoDao aindaNaoConsertoDa = new AindaNaoConsertoDao();

            foreach (DataRow row in tabelaPivotada.Rows)
            {
                object[] rowData = row.ItemArray;
                dados.Add(rowData);
            }

            aindaNaoConsertoDa.GravarCsv(dados);
        }



        private void inserirArquivoCsvToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ArrastarArquivoCsv arrastarArquivoCsv = new ArrastarArquivoCsv();
            arrastarArquivoCsv.DadosEnviados += ArrastarArquivoCsv_DadosEnviados;
            arrastarArquivoCsv.ShowDialog(); // Altere aqui para usar ShowDialog()
        }

        private void qToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectTabela selectTabela = new SelectTabela();
            int HEADSET = 0;
            int CARRAPATO = 0;
            int DISCADOR = 0;
            int TotalConserto = selectTabela.CalcularTotalConserto(dados);
            int TotConserto = selectTabela.ProdutoConserto(dados);
            List<int> Consertado = selectTabela.HEADSETDISCADORConserto(dados);
            HEADSET = Consertado[0];
            DISCADOR = Consertado[1];
            CARRAPATO = Consertado[2];



            MessageBox.Show("Total de Consertos: " + TotalConserto + " \n \n quantidade de Produtos consertados : " + TotConserto +
                " \n \n quantidade de HEADSET : " + HEADSET + " \n \n quantidade de DISCADOR : " + DISCADOR + " \n \n quantidade de CARRAPATO : " + CARRAPATO);
        }

        private void filtrarPeloMêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltroMes filtro = new FiltroMes();
            filtro.Show();
        }

        private void ProcurarProdutoExcluido(object sender, EventArgs e)
        {
            CarregarDadosNaTabela();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcurarCodigoT p = new ProcurarCodigoT();
            // Inscreva-se no evento ProdutoExcluido
            p.ProdutoExcluido += ProcurarProdutoExcluido;
            p.Show();
        }

        private void ArrastarArquivoCsv_DadosEnviados(object sender, EventArgs e)
        {
            // Atualize a tabela na tela inicial quando os dados do arquivo forem enviados
            CarregarDadosNaTabela();
        }

        private void d_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            AindaNaoConserto a = new AindaNaoConserto(f);
            a.Show();
        }


        private void TelaInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fecha.IsDisposed == false)
            {
                fecha.Close();
            }
            else
            {
                fecha.Close();
            }
        }

        private void Checkbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
            {
                checkBox1.Checked = true;
            }
        }


    }
}

