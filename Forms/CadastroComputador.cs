using MySql.Data.MySqlClient;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class CadastroComputador : Form
    {
        private const string textoServer = "Digite a tag de serviço";
        private const string textoPatrimonio = "Digite o Patrimonio";
        private const string textoValor = "Digite o valor da compra";
        private const string textoModelo = "Selecione ou digite o modelo";
        private const string textoProcessador = "Digite o processador";
        private const string textoNota = "Digite sua nota fiscal";
        private const string textoSistemaOperacional = "Selecione ou digite o sistema operacional";
        public string retornoTextEmBranco = "";


        public CadastroComputador()
        {
            InitializeComponent();
            configText();
            comboboxpreenchidaModelo(comboModelo);
            configurarTexto();
        }


        private void panel18_MouseEnter(object sender, EventArgs e)
        {
            this.panel18.Size = new System.Drawing.Size(200, 100);
        }


        private void panel2_Click(object sender, EventArgs e)
        {
            verificaNaoTaEscritoVoltaProLocal();
        }


        private void panel18_MouseLeave(object sender, EventArgs e)
        {
            this.panel18.Size = new System.Drawing.Size(200, 39);
        }


        public void verificaNaoTaEscritoVoltaProLocal()
        {
            verificaLbLabel(textServerTag,  textoServer);
            verificaLbLabel(textPatrimonio, textoPatrimonio);
            verificaLbLabel(maskedTextBox4, textoValor);
            verificaLbLabel(textProcessador,textoProcessador);
            verificaComboLabel(comboModelo, textoModelo);
            verificaComboLabel(comboSistema, textoSistemaOperacional);

        }

        private void textServerTag_MouseClick(object sender, MouseEventArgs e)
        {
            verificaText(textServerTag, textoServer);
        }


        private void textPatrimonio_Click(object sender, EventArgs e)
        {
            verificaText(textPatrimonio, textoPatrimonio);
        }

        private void maskedTextBox4_Click(object sender, EventArgs e)
        {
            verificaText(maskedTextBox4, textoValor);
        }

        private void textProcessador_Click(object sender, EventArgs e)
        {
            verificaText(textProcessador, textoProcessador);
        }
        public void verificaComboBox(ComboBox combo, string texto)
        {
           
            if (combo.Text.Equals(texto))
                combo.Text = "";
        }

        public void verificaText(MaskedTextBox textBox, string texto)
        {
           
            if (textBox.Text.Equals(texto))
            {
                textBox.Text = "";
            }
        }


        public void verificaLbLabel(MaskedTextBox textBox, string texto)
        {
            textBox.Mask = null;
            if (textBox.Text.Equals("") || textBox.Text == null )
               
                textBox.Text = texto;
               
        }

        public void verificaComboLabel(ComboBox combo, string texto)
        {
            if (combo.Text.Equals("") || combo.Text == null)
            {
                combo.Text = texto;
            }
        }



        private void comboModelo_Click(object sender, EventArgs e)
        {
            verificaComboBox(comboModelo,  textoModelo);

        }

        private void comboSistema_Click(object sender, EventArgs e)
        {
            verificaComboBox(comboSistema, textoSistemaOperacional);
        }

        private void panel17_Click(object sender, EventArgs e)
        {
            verificaNaoTaEscritoVoltaProLocal();
        }

        private void textBoxKey(MaskedTextBox textBox, string nomeText)
        {
            if (textBox != null)
            {
                textBox.KeyPress += (sender, e) => maskedTextBox1_KeyPress(sender, e, textBox, returnMask(nomeText));
            }
        }

        private string returnMask(string nomeTexto)
        {
            switch (nomeTexto)
            {
                case "patrimonio":
                    return "0000";
                case "tag":
                    return "AAAAAAAA"; // Mascara para permitir letras e números
                case "processador":
                    return "AAAAA";
                case "valor":
                    return "000000000";
                default:
                    return "";
            }
        }


        // O evento de não deixar entrar letras nos inputs
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e, MaskedTextBox textBox, string mask)
        {
            textBox.Mask = mask;

            bool permiteLetras = mask == "AAAAAAAA" || mask == "AAAAA";

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !permiteLetras)
            {
                e.Handled = true;
            }
        }

        // Adicionando os eventos para cada input
        private void configurarTexto()
        {
            textBoxKey(textPatrimonio, "patrimonio");
            textBoxKey(textServerTag, "tag");
            textBoxKey(maskedTextBox4, "valor");
            textBoxKey(textProcessador, "processador");
        }


        private void ConfigurarTextBoxComTextoInicial(string textoInicial, MaskedTextBox textBox = null, ComboBox combo = null)
            {
           
                if  (textBox !=null)
                {
                  textBox.Enter += (sender, e) => TextBox_Enter(sender, e, textoInicial);
                  textBox.Leave += (sender, e) => TextBox_Leave(sender, e, textoInicial);
                }
               
                if (combo!=null)
                {
                    combo.Enter += (sender, e) => TextBox_Enter(sender, e, textoInicial);
                    combo.Leave += (sender, e) => TextBox_Leave(sender, e, textoInicial);
                }
            }

            private void TextBox_Enter(object sender, EventArgs e, string textoInicial)
            {
                verificaNaoTaEscritoVoltaProLocal();
            }

            private void TextBox_Leave(object sender, EventArgs e, string textoInicial)
            {
                     verificaNaoTaEscritoVoltaProLocal();
            }

            private void configText()
            {
                ConfigurarTextBoxComTextoInicial(textoServer,textServerTag, null);
                ConfigurarTextBoxComTextoInicial(textoPatrimonio,textPatrimonio, null);
                ConfigurarTextBoxComTextoInicial(textoValor,maskedTextBox4, null);
                ConfigurarTextBoxComTextoInicial(textoProcessador,textProcessador, null);
                ConfigurarTextBoxComTextoInicial(textoSistemaOperacional,null, comboSistema);
                ConfigurarTextBoxComTextoInicial(textoModelo,null, comboModelo);
            }

   

        public void comboboxpreenchidaModelo(ComboBox combo)
        {
             ComputadorDao _computadorDao = new ComputadorDao();
             combo.Items.Clear();
            foreach (String item in _computadorDao.carregarCombobox())
            {
                combo.Items.Add(item);
            }
        }

        public Boolean validaEntradaDados(string texto,MaskedTextBox textBox=null, ComboBox combo =null)
        {
            if (textBox != null)
            {
                if (textBox.Text.Equals(texto) || textBox.Text.Equals(""))
                {
                    retornoTextEmBranco = textBox.Text;

                    if (textBox.Text.Equals(""))
                    {
                        retornoTextEmBranco = "Atenção todos os campos são necessarios";
                    }
                    
                    return false;
                }
            }
            if (combo != null)
            {
                if (combo.Text.Equals("")  || combo.Text.Equals(texto))
                {
                    retornoTextEmBranco = combo.Text;

                    if (combo.Text.Equals(""))
                    {
                        retornoTextEmBranco = "Atenção todos os campos são necessarios";
                    }

                    return false;
                }

            }

            return true;
        }

        public Boolean validaSeNaoTemTextEmBranco()
        {
            if (validaEntradaDados(textoPatrimonio, textPatrimonio) != true
               || validaEntradaDados(textoServer, textServerTag) != true
               || validaEntradaDados(textoValor, maskedTextBox4) != true
               || validaEntradaDados(textoProcessador, textProcessador) != true
               || validaEntradaDados(textoSistemaOperacional, null, comboSistema) != true
               || validaEntradaDados(textoModelo, null, comboModelo) != true)
            {
                MessageBox.Show(retornoTextEmBranco);
                return false;
            }
            return true;
        }

        public Boolean validaQuantidadeDeCaracteres(string texto,MaskedTextBox textBox=null ,ComboBox combo=null,string tag = null)
        {
            if (textBox != null && tag == null)
            {
                retornoTextEmBranco =$"{"Quantidade de caracteres invalidos no"}{texto.Substring(8)}";
                return textBox.TextLength > 2 ? true : false;
            }
            else if(textBox != null && !string.IsNullOrEmpty(tag))
            {
                retornoTextEmBranco = $"{"Quantidade de caracteres invalidos na"}{texto.Substring(8)}";
                return textBox.TextLength > 4 ? true : false;
            }

            if (combo != null)
            {
                retornoTextEmBranco = $"{"Quantidade de caracteres invalidos no"}{texto.Substring(21)}";
                return combo.Text.Length > 6 ? true : false;
            }
            return false;
        }
        public Boolean validaQuantidadeCertaCaracteres()
        {

            if (validaQuantidadeDeCaracteres(textoPatrimonio, textPatrimonio) != true
               || validaQuantidadeDeCaracteres(textoServer, textServerTag,null,"tag") != true
               || validaQuantidadeDeCaracteres(textoValor, maskedTextBox4) != true
               || validaQuantidadeDeCaracteres(textoProcessador, textProcessador) != true
               || validaQuantidadeDeCaracteres(textoSistemaOperacional, null, comboSistema) != true
               || validaQuantidadeDeCaracteres(textoModelo, null, comboModelo) != true)
            {
                MessageBox.Show(retornoTextEmBranco);
                return false;
            }
            return true;
        }
        public void setarText()
        {
            textPatrimonio.Text = "";
            textServerTag.Text = "";
            comboSistema.Text = "";
            comboModelo.Text = "";
            textProcessador.Text = "";
            maskedTextBox4.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (validaSeNaoTemTextEmBranco() && validaQuantidadeCertaCaracteres())
            {
                DateTime data = DateTime.Now;
                MySqlParameter[] parametro = new MySqlParameter[] 
                {
                    new MySqlParameter("@patrimonio",textPatrimonio.Text),
                    new MySqlParameter("@tag_servico", textServerTag.Text),
                    new MySqlParameter("@sistemasOperacionais", comboSistema.Text),
                    new MySqlParameter("@marca",comboModelo.Text),
                    new MySqlParameter("@processador",textProcessador.Text),
                    new MySqlParameter("@Valor",maskedTextBox4.Text),
                    new MySqlParameter("@empresa","Maximidia"),
                    new MySqlParameter("@conservacao","BOM"),
                    new MySqlParameter("@DataCompra", data)
                    
                };
                int rowns =computadoresMapeadosEconsertado.Dao.InsersaoDao.inserirComputadorNovo(parametro);

                MessageBox.Show(rowns > 0 ? "Computador inserido com sucesso" : "Computador não inserido");
                setarText();
                verificaNaoTaEscritoVoltaProLocal();
            }
            else
            {
                MessageBox.Show("Computador não inserido");

            }

        }

        private void textPatrimonio_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

