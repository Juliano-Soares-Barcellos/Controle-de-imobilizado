using System;


namespace ImobilizadosDll.model
{
    public class ImobilizadosModel
    {
        public int id_Imobilizado { get; set; }

        public string Patrimonio { get; set; }

        public string Item { get; set; }

        public int Fk_Grupos { get; set; }

        public int fk_contabil { get; set; }

        public string Estado_de_Conservacao { get; set; }

        public DateTime Data_Compra { get; set; }

        public string Nota_Fiscal { get; set; }

        public string Fornecedor { get; set; }

        public double Valor { get; set; }

        public string Vida_util { get; set; }

        public int Fk_empresa { get; set; }

        public Double Depreciacao { get; set; }

        public Grupos_paModel grupo;

        public classificacao_contabilModel contabil;

        public EmpresaModel empresa;

        public ImobilizadosModel()
        {
            grupo = new Grupos_paModel();

            contabil = new classificacao_contabilModel();

            empresa = new EmpresaModel();
        }

    }
}
