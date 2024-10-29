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
    public class RetiraDoConserto
    {
        private ComputadorDao _computadorDao = new ComputadorDao();
        private ComputadorSaida _computadorSaida = new ComputadorSaida();
        private MaskedTextBox Tnome;
        private MaskedTextBox TDescricao;
        private ComboBox Sistema;
        private CheckedListBox CheckBox;
        private DataTable TodosDadosDoPc = new DataTable();
        private DataTable tableTemp = new DataTable();
        string selectedValues = "";
        private object id_pc = null;
        private int ultima = 0;
        private String id_conserto = "";
        private String tabelaTemp_id = "";
        private String tabelaTemp_id_pa = "";



        public RetiraDoConserto(MaskedTextBox Patrimonio, MaskedTextBox Descricao, ComboBox Sistema, CheckedListBox CheckBox)
        {
            this.Tnome = Patrimonio;
            this.TDescricao = Descricao;
            this.Sistema = Sistema;
            this.CheckBox = CheckBox;
            RetiraConserto();
        }

        public void AgrupaCheckList()
        {
            if (CheckBox.CheckedItems != null)
            {
                foreach (object item in CheckBox.CheckedItems)
                {
                    selectedValues += item.ToString() + ",";
                }

                if (!string.IsNullOrEmpty(selectedValues))
                {
                    selectedValues = selectedValues.TrimEnd(',');
                }
            }
        }
        //PegaDadosDoPc
        public void IniciarProcesso()
        {
            TodosDadosDoPc = computadoresMapeadosEconsertado.Dao.montarTabelasDao.retornaTudoSobrePc(Tnome.Text);
            VerificaSeExistePc();
        }
        public void VerificaSeExistePc()
        {
            id_pc = TodosDadosDoPc.Rows[0][0].ToString();
            if (id_pc.ToString() == "")
                throw new Exception("Computador não Existente");
            ValidacaoParaVerSeEstaEmConserto();
        }
        public void ValidacaoParaVerSeEstaEmConserto()
        {
            ultima = TodosDadosDoPc.Rows.Count - 1;
            if (TodosDadosDoPc.Rows[ultima][9].ToString() == "" ||
                (TodosDadosDoPc.Rows[ultima][11].ToString() != "" && TodosDadosDoPc.Rows[ultima][13].ToString() != ""))
                throw new Exception("Este computador Não Esta em Processo de Conserto");
            id_conserto = TodosDadosDoPc.Rows[ultima][9].ToString();
            PegarDaDosDaMAquinaNaTabelaTemp();
        }
        public void PegarDaDosDaMAquinaNaTabelaTemp()
        {
            tableTemp = computadoresMapeadosEconsertado.Dao.montarTabelasDao.TabelaTemp(id_pc.ToString());
            int ultimo = tableTemp.Rows.Count - 1;
            tabelaTemp_id = tableTemp.Rows[ultimo][0].ToString();
            tabelaTemp_id_pa = tableTemp.Rows[ultimo][2].ToString();
            ConsertoFinalizadoProgramasUpdate();
        }
        public void ConsertoFinalizadoProgramasUpdate()
        {
            AgrupaCheckList();
            computadoresMapeadosEconsertado.Dao.UpdateDao.ConsertoFinalizadoComputador(TDescricao.Text, id_conserto);
            computadoresMapeadosEconsertado.Dao.UpdateDao.updateProgramasPc(selectedValues, id_pc.ToString());
            UpdateVoltaPraPaDeOrigemOuCondena();
        }
        public void UpdateVoltaPraPaDeOrigemOuCondena()
        {
            if (string.Equals(TDescricao.Text, "Condenado", StringComparison.OrdinalIgnoreCase) ||
                    (string.Equals(TDescricao.Text, "Condenada", StringComparison.OrdinalIgnoreCase)))
            {
                computadoresMapeadosEconsertado.Dao.UpdateDao.Condenar(id_pc.ToString());

            }
            else
            {
                computadoresMapeadosEconsertado.Dao.UpdateDao.retornarPaOrigem(id_pc.ToString(), tabelaTemp_id_pa);
            }
            DeletarTabelaTemporaria();
        }
        public void DeletarTabelaTemporaria()
        {
            computadoresMapeadosEconsertado.Dao.delete.DeletePaTemporaria(tabelaTemp_id);
            VrificaSeSistemaEstaMarcado();
        }
        public void VrificaSeSistemaEstaMarcado()
        {
            if (Sistema.SelectedItem != null)
            {
                String sistema = Sistema.SelectedItem.ToString();
                computadoresMapeadosEconsertado.Dao.UpdateDao.AtualizarComputador(id_pc.ToString(), sistema);
            }
        }
        private void RetiraConserto()
        {
            try
            {
                IniciarProcesso();
                MessageBox.Show("Baixa efetuado com sucesso no computador : " + Tnome.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
