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
    public partial class TrocaPcPa : Form
    {
        public TrocaPcPa()
        {
            InitializeComponent();
            this.Location = new Point(20,30);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textPatrimonio.Text.Equals("") || textPa.Text.Equals("") || comboEmpresa.SelectedIndex < 0 || comboSetor.SelectedIndex < 0)
            {
                MessageBox.Show("Precisa Preencher todos os Campos !!!");
            }
            else
            {
                //pronto
                string patrimonio = textPatrimonio.Text.ToString().Trim();
                string empresa = comboEmpresa.SelectedIndex < 0 ? comboEmpresa.SelectedText : comboEmpresa.SelectedItem.ToString();
                string setor = comboSetor.SelectedIndex < 0 ? comboSetor.SelectedText : comboSetor.SelectedItem.ToString();
                string pa = textPa.Text;
                string message = "";

                List<object> AntesTroca = ImobilizadosDll.TabelasDao.Tabelas.trocaPa(empresa,patrimonio,pa,setor);
                int verificaSeTemAlguemNaPa = AntesTroca.Count() - 2;

                string caption = "Confirmação";
                //MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                if (verificaSeTemAlguemNaPa < 3)
                {
                    message = "O patrimonio " + AntesTroca[0].ToString() + " vai ir para a Pa " + AntesTroca[1].ToString() + ",\n" +
                 "A Pa " + AntesTroca[1].ToString() +" Esta Sem nenhuma maquina"+ "\n"
                 + "Deseja prosseguir? ";
                    DialogResult result = MessageBox.Show(message, caption);
                    if (result == DialogResult.OK)
                    {

                        ImobilizadosDll.Dao.UpdateDao.TrocaPa(AntesTroca[0].ToString(), AntesTroca[2].ToString(), empresa);
                        MessageBox.Show("Troca de Pa efetuada com sucesso !");
                    }
                    else { MessageBox.Show("Nenhuma Troca foi Efetivada"); }
                }
                else
                {
                        message = "O patrimonio " + AntesTroca[0].ToString() + " vai ir para a Pa "+ AntesTroca[4].ToString() + ",\n" +
                        "E o patrimonio "+ AntesTroca[3].ToString()+" vai para a Pa "+ AntesTroca[1].ToString()+"\n"
                        +"Deseja prosseguir? ";
                       //  DialogResult result = MessageBox.Show(message, caption, buttons);
                          DialogResult result = MessageBox.Show(message, caption);
                    if (result == DialogResult.OK)
                    {
                        ImobilizadosDll.Dao.UpdateDao.TrocaPa(AntesTroca[3].ToString(),AntesTroca[2].ToString(),empresa);
                        ImobilizadosDll.Dao.UpdateDao.TrocaPa(AntesTroca[0].ToString(), AntesTroca[5].ToString(), empresa);
                        MessageBox.Show("Troca de Pa efetuada com sucesso !");
                    }
                    else { MessageBox.Show("Nenhuma Troca foi Efetivada"); }
                }
            }
        }

        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string empresa = comboEmpresa.SelectedIndex < 0 ? comboEmpresa.SelectedText : comboEmpresa.SelectedItem.ToString();

           List<string> PreencherCombo= ImobilizadosDll.TabelasDao.Tabelas.RetornaComboBoxPc(empresa);

            comboSetor.Items.Clear();

            if (PreencherCombo.Count>0)
            {
                foreach (var item in PreencherCombo)
                {
                    comboSetor.Items.Add(item.ToString().Trim().ToLower());
                }
            }
        }
    }
}
