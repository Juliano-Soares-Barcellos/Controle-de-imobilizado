using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    public class CadastroComputadorDao
    {

    public String pontoNoFloat(MaskedTextBox valorEmString)
    {
        Double valor = Double.Parse(valorEmString.Text, CultureInfo.InvariantCulture);

        string valorStr = valor.ToString("F0", CultureInfo.InvariantCulture);

        int length = valorStr.Length;
        if (length > 2)
        { 
            valorStr = valorStr.Insert(length - 2, ".");
        }
        else
        {
            valorStr = "0." + valorStr.PadLeft(2, '0');
        }

        return valorStr;
    }



}
}
