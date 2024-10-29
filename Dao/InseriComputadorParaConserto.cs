using ProjetoDeControleDeMateriaisMandadoParaConserto.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    public class InseriComputadorParaConserto
    {
        private MaskedTextBox Patrimonio;
        private MaskedTextBox Descricao;
        private ComboBox Modelo;
        private ComboBox SistemaOperacional;
        private DataTable TodosDadosDoPc = new DataTable();
        private int ultima = 0;
        private object valor = null;
        private string modelo = "";
        private string id_pa = "";

        public InseriComputadorParaConserto(MaskedTextBox patrimonio, MaskedTextBox Descricao ,ComboBox Modelo, ComboBox Sistema)
        {
            this.Patrimonio = patrimonio;
            this.Descricao = Descricao;
            this.Modelo = Modelo;
            this.SistemaOperacional = Sistema;
            InserirParaConserto();
        }

        public void RetornarTudoSobrePc()
        {
            TodosDadosDoPc = computadoresMapeadosEconsertado.Dao.montarTabelasDao.retornaTudoSobrePc(Patrimonio.Text);
        }
        public void ValidacaoPraVerSeJaEstaEmProcesso()
        {
            ultima = TodosDadosDoPc.Rows.Count - 1;
            if (
                   TodosDadosDoPc.Rows[ultima][11].ToString() != "" && TodosDadosDoPc.Rows[ultima][13].ToString() == "")
                    throw new Exception("Este computador ja esta em processo de conserto");
        }
        public void FazUpdateDoModelo()
        {
            if (Modelo.SelectedIndex >= 0) {
                modelo = Modelo.SelectedItem.ToString();
                computadoresMapeadosEconsertado.Dao.UpdateDao.InseririModelo(valor.ToString(), modelo);
            }
        }

        public void UpdateNecessariosParaConserto()
        {
            computadoresMapeadosEconsertado.Dao.InsersaoDao.InserirComputador(Descricao.Text, valor.ToString());
            computadoresMapeadosEconsertado.Dao.InsersaoDao.InserirPaTabelaTemp(valor.ToString(), id_pa);
            computadoresMapeadosEconsertado.Dao.UpdateDao.updatePaTi(valor.ToString());
        }
        public void InserirSistema ()
        {
            String Sistema = SistemaOperacional.SelectedIndex <= 0 ? "" : SistemaOperacional.SelectedItem.ToString();
            if (!Sistema.Equals(""))
                computadoresMapeadosEconsertado.Dao.UpdateDao.AtualizarComputador(valor.ToString(), Sistema);
        }

        public void InserirParaConserto()
        {
            try
            {
                RetornarTudoSobrePc();
                ValidacaoPraVerSeJaEstaEmProcesso();
                valor = TodosDadosDoPc.Rows[0][0];
                FazUpdateDoModelo();
                id_pa = TodosDadosDoPc.Rows[ultima][5].ToString();
                UpdateNecessariosParaConserto();
                InserirSistema();
                MessageBox.Show("Computador mandado para conserto com sucesso !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}

