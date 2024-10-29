using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Dao;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Querys;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class AindaNaoConserto : Form
    {
        private List<Object[]> Dados;
        private DataTable tabelaPivotada;
        private Form1 f;
        public AindaNaoConserto(Form1 f)
        {
            this.f = f;
            InitializeComponent();
            Dados = new List<Object[]>();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            AindaNaoConsertoDao aindaNaoConsertoDa = new AindaNaoConsertoDao();
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Digite o Material.");
            }
            else if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha o nome do material.");
            }
            else
            {
                ProcurarCodigo procurarCodigo = new ProcurarCodigo();

                string message = "Deseja prosseguir? Digite 's' para sim ou 'n' para não:";
                string caption = "Confirmação";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                Conserto conserto = new Conserto();
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    NumeroDao numeroDao = new NumeroDao();
                    //    InseriDataNaoConserto InseriDataNaoConsert = new InseriDataNaoConserto();
                    string numero = textBox1.Text;
                    string NomeMaterial = comboBox.SelectedItem.ToString();
                    List<Object[]> novosDados = procurarCodigo.carregarTabela(numero);
                    Dados.AddRange(novosDados);

                    if (novosDados.Count > 0)
                    {

                        CarregarDadosNaTabela();
                        MessageBox.Show("Produto encontrado no Banco !");
                    }
                    else
                    {
                        Produto produto = new Produto();
                        produto.id = 0;
                        produto.Nome = NomeMaterial;
                        produto.Numero = numero;
                        produto.quantidade_conserto = 0;

                        Object[] Produtos = new object[] { produto.id, produto.Nome, produto.Numero, produto.quantidade_conserto, "00" };
                        Dados.Add(Produtos);
                        CarregarDadosNaTabela();
                        MessageBox.Show("Produto não encontrado no nosso Banco de dados !");

                    }
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("nenhum produto foi consertado !!! ");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
                ArquivoTxtDao arquivo = new ArquivoTxtDao();
                int headset = 0;
                int carrapato = 0;
                int discador = 0;

                foreach (DataGridViewRow row in Tabela.Rows)
                {
                    if (row.Cells[3].Value != null)
                    {
                        String garantia = row.Cells[3].Value.ToString();

                        if (garantia == "Com Garantia")
                        {
                            String material = row.Cells[0].Value.ToString();
                            switch (material)
                            {
                                case "HEADSET":
                                    headset++;
                                    break;

                                case "DISCADOR":
                                    discador++;
                                    break;

                                case "CARRAPATOS":
                                    carrapato++;
                                    break;
                            }
                        }
                    }
                }

                arquivo.GeararArquivoTxt(LabelHeadset.Text, LabelDiscador.Text, LabelCarrapato.Text, headset, discador, carrapato);

                
            }
        }

        private void CarregarDadosNaTabela()
        {

            SelectTabela selectTabela = new SelectTabela();
            tabelaPivotada = selectTabela.PivotData(Dados);
            Tabela.DataSource = tabelaPivotada;
            LabelsMostrar(Dados);


        }
        public void LabelsMostrar(List<Object[]> Dados)
        {
            SelectTabela SelectTabel = new SelectTabela();

            List<int> Produtos = SelectTabel.HEADSETDISCADORConserto(Dados);
            int Headset = Produtos[0];
            int Discador = Produtos[1];
            int Carrapatos = Produtos[2];
            LabelHeadset.Visible = true;
            LabelDiscador.Visible = true;
            LabelCarrapato.Visible = true;
            labelD.Visible = true;
            LabelCarra.Visible = true;
            labelh.Visible = true;

            LabelHeadset.Text = Headset.ToString();
            LabelDiscador.Text = Discador.ToString();
            LabelCarrapato.Text = Carrapatos.ToString();

        }

        private void Tabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se uma linha foi selecionada
            {
                DataGridViewRow selectedRow = Tabela.Rows[e.RowIndex]; // Obtém a linha selecionada

                string coluna1 = selectedRow.Cells[1].Value.ToString();

                DialogResult result = MessageBox.Show("Deseja excluir os dados da linha selecionada?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (object[] rowData in Dados.ToList())
                    {
                        if (rowData.Contains(coluna1))
                        {
                            Dados.Remove(rowData);
                            Tabela.Rows.Remove(selectedRow);

                            MessageBox.Show("Dados excluídos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break; // Interrompe o loop após a exclusão
                        }
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                AindaNaoConsertoDao aindaNaoConsertoDa = new AindaNaoConsertoDao();
                aindaNaoConsertoDa.GravarCsv(Dados);
            }
        }


        private void AindaNaoConserto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (f.IsDisposed == false)
            {
                f.Close();
            }
            else
            {
                f.Close();
            }
        }

     
    }
}
