using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadosDll.Consulta
{
    public class Query
    {

        public string GruposImobilizadoPC = "select * from computador inner join pa on pa.id_pa=computador.fk_computador_pa inner join grupos_pa on pa.fk_grupo_id=grupos_pa.id_grupo where grupos=@resfiltro and empresa=@empresa;";

        public string GrupoImobilizados = "select * from imobilizados left join grupos_pa on grupos_pa.id_grupo=imobilizados.fk_grupos  left join classificacao_contabil on classificacao_contabil.Id_classificacao_contabil = imobilizados.fk_contabil inner join empresas on empresas.id_empresas= imobilizados.Fk_Empresa where grupos=@resfiltro and fk_empresa=@empresa;";

        public string retornaPatrimonioImob = "select * from imobilizados  left join grupos_pa on grupos_pa.id_grupo=imobilizados.fk_grupos left join classificacao_contabil on classificacao_contabil.Id_classificacao_contabil = imobilizados.fk_contabil inner join empresas on empresas.id_empresas= imobilizados.Fk_Empresa  where patrimonio=@resfiltro and fk_empresa=@empresa;";

        public string retornaPatrimonioPc = "select* from computador inner join pa on pa.id_pa=computador.fk_computador_pa inner join grupos_pa on pa.fk_grupo_id= grupos_pa.id_grupo where patrimonio = @resfiltro and empresa = @empresa;";

        public string retornaProcuraItem = "select * from imobilizados left join grupos_pa on grupos_pa.id_grupo=imobilizados.fk_grupos left join classificacao_contabil on classificacao_contabil.Id_classificacao_contabil = imobilizados.fk_contabil inner join empresas on empresas.id_empresas= imobilizados.Fk_Empresa where item like @resfiltro and fk_empresa=@empresa;";

        public string procuraTagPc = "select * from computador inner join pa on pa.id_pa=computador.fk_computador_pa inner join grupos_pa on pa.fk_grupo_id=grupos_pa.id_grupo where tag_servico=@resfiltro and empresa=@empresa;";

        public string retornaProcuraTodosImobEmpresa = "select * from imobilizados left join grupos_pa on grupos_pa.id_grupo=imobilizados.fk_grupos left join classificacao_contabil on classificacao_contabil.Id_classificacao_contabil = imobilizados.fk_contabil inner join empresas on empresas.id_empresas= imobilizados.Fk_Empresa where fk_empresa=@empresa";

        public string retornaProcuraPcEmpresa = "select* from computador inner join pa on pa.id_pa=computador.fk_computador_pa inner join grupos_pa on pa.fk_grupo_id= grupos_pa.id_grupo where  empresa = @empresa;";

        public string setor = "SELECT grupos FROM imobilizados inner join grupos_pa on imobilizados.Fk_grupos=grupos_pa.id_grupo where fk_empresa=@empresa group by grupos;";

        public string acharPa = "SELECT * FROM pa inner join grupos_pa on pa.fk_grupo_id=grupos_pa.id_grupo where grupos=@grupos and pa=@pas;";

        public string trocarPa = "update computador set fk_computador_Pa = @estrangeira where patrimonio=@patrimonio and empresa=@empresa;";

        public string RetornaPcFiltro = "select * from computador where fk_computador_Pa=@pa and empresa=@empresa";

        public string setorPc = "SELECT * FROM computador inner join pa on computador.fk_computador_Pa=pa.id_pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa group by grupos;";
    }
}
