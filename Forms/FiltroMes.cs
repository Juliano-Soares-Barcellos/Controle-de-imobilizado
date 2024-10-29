using ProjetoDeControleDeMateriaisMandadoParaConserto.Dao;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class FiltroMes : Form
    {
        private List<Object[]> Dados;
        private List<String> Meses = new List<String>
        {
            "Janeiro", "Fevereiro", "Março", "Abril",
            "Maio", "Junho", "Julho", "Agosto",
            "Setembro", "Outubro", "Novembro", "Dezembro"
        };

        private DataTable tabelaPivotada;
        public FiltroMes()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(761, 150);
            this.MinimumSize = new System.Drawing.Size(761, 150);
        }

        private void testbtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            button2.Visible = true;
            BtnGrafico.Visible = false;

            this.panel3.Size = new System.Drawing.Size(756, 116);
            this.panel1.Size = new System.Drawing.Size(756, 626);
            this.Size = new System.Drawing.Size(770, 776);
            this.MaximumSize = new System.Drawing.Size(770, 776);
            this.MinimumSize = new System.Drawing.Size(770, 776);

            button2.Left = 300;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            button2.Visible = false;
            BtnGrafico.Visible = true;

            this.panel3.Size = new System.Drawing.Size(510, 116);
            this.panel2.Size = new System.Drawing.Size(510, 661);
            this.Size = new System.Drawing.Size(529, 814);
            this.MaximumSize = new System.Drawing.Size(529, 814);
            this.MinimumSize = new System.Drawing.Size(529, 814);
            BtnGrafico.Left = 180;


        }
   
        public object Obtermes(object MesesObjeto)
        {
           
            if (MesesObjeto != null && int.TryParse(MesesObjeto.ToString(), out int ValorConvertido))
            {
               
               String Mes=Meses[ValorConvertido-1];
                return Mes;
            }
            else
            {

                int NumeroMes = Meses.IndexOf(MesesObjeto.ToString());
                return NumeroMes+1;
            }
        }

        private void Carregar_Click(object sender, EventArgs e)
        {
            object obterMeses = null;
            obterMeses = (String)ComboMes1.SelectedItem;
            int MesNumero1 = (int)Obtermes(obterMeses);
            obterMeses = (String)ComboMes2.SelectedItem;
            int MesNumero2 = (int)Obtermes(obterMeses);
            String AnoString = TextAno.Text;
            String AnoString2 = Ano2.Text;


            if (MesNumero1 == 0 || MesNumero2 == 0 || cbxGrafico.SelectedIndex <= -1 || AnoString.Equals("") || AnoString2.Equals(""))
            {
                MessageBox.Show("Por favor preencha todos os campos");

            }
            else
            {
                String GraficoSelecionado = (String)cbxGrafico.SelectedItem;
                int ano = Convert.ToInt32(AnoString);
                int ano2 = Convert.ToInt32(AnoString2);
                if (ano <= 2022 || ano > DateTime.Now.Year || ano2 <= 2022 || ano2 > DateTime.Now.Year)
                {
                    MessageBox.Show("Por favor preencha um ano válido");

                }
                else
                {
                    List<String> mesesArray = new List<string>();
                    mesesArray.Clear();
                    SelectFiltro selectFiltro = new SelectFiltro();
                    string data1 = $"{ano}-{MesNumero1:D2}-01";
                    string data2 = $"{ano2}-{MesNumero2:D2}-31";
                    Query query = new Query();
                    String sql = query.FiltroGrafico;
                    Dados = selectFiltro.BuscaPreenchimentoGrafico(data1, data2, sql);
                    graficoBox.Series.Clear();
                    graficoBox.Titles.Clear();
                    graficoBox.Legends.Clear();

                    for (int i = 0; i < Dados.Count; i++)
                    {
                        DateTime Datas = (DateTime)Dados[i][1];
                        object data = Convert.ToInt32(Datas.Month);
                        String Mes = (String)Obtermes(data);
                        String MesVal = $"{Dados[i][0]}-{Mes}";


                        if (cbxGrafico.Text.Equals("Column"))
                        {


                            if (graficoBox.Series.Count <= 0)
                            {
                                graficoBox.Series.Add(cbxGrafico.Text);
                            }
                            
                            Boolean acharMeses= !mesesArray.Contains(Mes)?true:false;
                            graficoBox.Legends.Add(acharMeses ? $"{Mes}" : $"{Mes + 2}");
                            mesesArray.Add(Mes);


                            Series series = new Series(MesVal);
                            series.Points.Add(Double.Parse(Dados[i][0].ToString()));
                            series.LegendText = Mes;
                            series.IsValueShownAsLabel = true;
                            series.LabelFormat = "#,0";
                            Legend legend = graficoBox.Legends[0];
                            legend.Alignment = StringAlignment.Center;
                            legend.Docking = Docking.Top;
                            ChartArea chartArea = graficoBox.ChartAreas[0];
                            chartArea.AxisX.MajorGrid.Enabled = true;
                            chartArea.AxisY.MajorGrid.Enabled = true;
                            graficoBox.Series.Add(series);
                        }
                        else
                        {
                            String ItemCombo = cbxGrafico.SelectedItem.ToString();
                            if (graficoBox.Series.Count <= 0)
                            {
                                graficoBox.Series.Add(cbxGrafico.Text);
                            }

                            Boolean acharMeses = !mesesArray.Contains(Mes) ? true : false;
                            graficoBox.Legends.Add(acharMeses ? $"{Mes}" : $"{Mes + 2}");
                            mesesArray.Add(Mes);

                            String QuantidadeJuntos = $"{Mes}";

                            graficoBox.Series[0].IsValueShownAsLabel = true;
                            graficoBox.Series[0].LabelFormat = "#,0";

                            Legend Generico = graficoBox.Legends[0];
                            Generico.Alignment = StringAlignment.Center;
                            Generico.Docking = Docking.Top;
                            graficoBox.Series[0].Points.AddXY(QuantidadeJuntos, Dados[i][0]);
                            if (Enum.TryParse(ItemCombo, out SeriesChartType chartType))
                            {
                                graficoBox.Series[0].ChartType = chartType;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int AnoNao = comboBox1.SelectedIndex;
            int MesNao = comboBox2.SelectedIndex;
            if (AnoNao < 0 || MesNao < 0)
            {
                MessageBox.Show("Por favor selecione os dois ComboBox: ");
            }
            else
            {
                Object obterMeses = null;
                obterMeses = (String)comboBox2.SelectedItem;

                int mesEscolhido = (int)Obtermes(obterMeses);

                String anoSelecionado = (String)comboBox1.SelectedItem;
                int ano = Int32.Parse(anoSelecionado);


                SelectFiltro selectFiltro = new SelectFiltro();
                string sql = "SELECT * FROM Produto as p inner join Conserto as _computadorSaida on p.id=_computadorSaida.Produto_id WHERE MONTH(DATE(_computadorSaida.Data)) = @Mes AND YEAR(DATE(_computadorSaida.Data)) = @Ano;";
                Dados = selectFiltro.carregarTabela(mesEscolhido, ano, sql);
                if (Dados.Count == 0)
                {
                    Tabela.DataSource = null;
                    label11.Text = "";
                    label8.Text = "";
                    label10.Text = "";
                    MessageBox.Show("Nenhum item encontrado");
                }
                else
                {
                    tabelaPivotada = selectFiltro.PivotData(Dados);
                    SelectTabela SelectTabel = new SelectTabela();
                    // Calcula o total de consertos e produtos com garantia
                    int MesConserto = selectFiltro.CalcularMesConserto(Dados);
                    int totalConserto = selectFiltro.CalcularTotalConserto(Dados);
                    int totalProdutosComGarantia = selectFiltro.CalcularQuantidadeGarantia(Dados);
                    List<int> Produtos = SelectTabel.HEADSETDISCADORConserto(Dados);
                    int Headset = Produtos[0];
                    int Discador = Produtos[1];
                    int Carrapatos = Produtos[2];
                 
                    Tabela.DataSource = tabelaPivotada;
                    MessageBox.Show("Total de Consertos neste mês: " + MesConserto + "\n" + "\n" +
                                    "Total de Headset: " + Headset + "\n" + "\n" +
                                    "total de Discadores : " + Discador + "\n" + "\n" +
                                    "Total de Carrapatos :  " + Carrapatos + "\n" + "\n" +
                                    "                   Informações do mês !!!");

                    label4.Visible = true;
                    label11.Visible = true;
                    label8.Visible = true;
                    label10.Visible = true;
                    label13.Visible = true;
                    label12.Visible = true;
                    label9.Visible = true;
                    label4.Visible = true;
                    label11.Text = totalProdutosComGarantia.ToString();
                    label8.Text = totalConserto.ToString();
                    label10.Text = MesConserto.ToString();
                }
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

       
    }
}







