using ProjetoDeControleDeMateriaisMandadoParaConserto.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class ProcurarCodigoT : Form
    {
        public ProcurarCodigoT()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Equals(""))
            {
                MessageBox.Show("Por favor digite o numero");
            }
            else
            {

                NumeroDao numeroDao = new NumeroDao();
                InsersaoDbPlanilha t = new InsersaoDbPlanilha();
                string numero = textBox1.Text;
                Object[] encontrar = numeroDao.EncontrarNumero(numero);

                if (encontrar.Length > 0)
                {
                    MessageBox.Show("Produto encontrado com sucesso!!!");
                    CarregarDadosNaTabela(numero);
                    TextDeletar.Text = textBox1.Text;

                }
                else
                {
                    CarregarDadosNaTabela(numero);
                    MessageBox.Show("Produto nao encontrado");
                }
                textBox1.Text = "";

            }
        }

        private void CarregarDadosNaTabela(String numero)
        {
            SelectTabela selectTabela = new SelectTabela();
            ProcurarCodigo ProcurarCodigo = new ProcurarCodigo();
            // Carrega os dados do banco de dados e cria a tabela pivotada
            List<Object[]> dados = ProcurarCodigo.carregarTabela(numero);
            DataTable tabelaPivotada = selectTabela.PivotData(dados);

            // Exibe a tabela pivotada no DataGridView
            Tabela.DataSource = tabelaPivotada;
        }

        public event EventHandler ProdutoExcluido;

        private void button2_Click(object sender, EventArgs e)
        {
            if (TextDeletar.Text == "")
            {
                MessageBox.Show("Por favor digite o numero que deseja deletar");
            }
            else
            {
                DeleteDao d = new DeleteDao();
                d.deletarProduto(TextDeletar.Text);

                // Dispara o evento ProdutoExcluido
                ProdutoExcluido?.Invoke(this, EventArgs.Empty);

                CarregarDadosNaTabela(TextDeletar.Text);
            }
        }

       
    }
}
