using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computadoresMapeadosEconsertado.consultas
{
    public class Query
    {
        public String filtrossd = " SELECT * FROM computador INNER JOIN pa ON pa.id_pa = computador.fk_computador_Pa INNER JOIN grupos_pa ON grupos_pa.id_grupo = pa.fk_grupo_id inner join computador_conserto on computador.id_computador=computador_conserto.fk_computador where Descricao_problema_resolvido like '%ssd%';";

        public String buscaMapPc = "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id; ";

        public String quantidadePcGrupo = "SELECT COUNT(*) FROM computador INNER JOIN pa ON pa.id_pa = computador.fk_computador_Pa INNER JOIN grupos_pa ON grupos_pa.id_grupo = pa.fk_grupo_id WHERE grupos_pa.grupos = @grupo;";

        public String computadores_consertados = "SELECT * FROM computador INNER JOIN pa ON pa.id_pa = computador.fk_computador_Pa INNER JOIN grupos_pa ON grupos_pa.id_grupo = pa.fk_grupo_id inner join computador_conserto on computador.id_computador=computador_conserto.fk_computador;";

        public String LocalizacaoPa = "SELECT * FROM computador  INNER JOIN pa ON computador.fk_computador_Pa = pa.id_pa INNER JOIN grupos_pa  ON grupos_pa .id_grupo = pa.fk_grupo_id;";

        public String acharPcDetalhado = "SELECT * FROM computador left JOIN computador_conserto ON computador.id_computador = computador_conserto.fk_computador inner JOIN pa ON pa.id_pa = computador.fk_computador_Pa inner JOIN grupos_pa ON grupos_pa.id_grupo = pa.fk_grupo_id WHERE patrimonio=@patrimonio;;";

        public String InserirConsertoInicial = "insert into computador_conserto (data_entrada,Descricao_problema,fk_computador)values(@dataEntrada,@DescricaoProblema,@fk_computador);";

        public String queryAtualizacaoSistemaOpPc = "UPDATE computador SET sistemasOperacionais= @sistema WHERE id_computador = @IdComputador";

        public String consertoFinalizado = "update computador_conserto set descricao_problema_resolvido=@descricao ,data_conserto_finalizado=@dataFinalizado where id_conserto = @idConserto;";

        public String UpdateNosPrograma = "update computador set programa=@programa where id_computador=@id_computador;";

        public String InserirTabelaTemp = "insert into temp_conserto (fk_computador,fk_pa)values (@fk_computador,@fk_pa);";

        public String mudarParaTi = "update computador set fk_computador_pa = 340 where id_computador =  @id_computador;";

        public String selectTabelaTemp = "select * from temp_conserto where fk_computador = @id_computador;";

        public String retornarPaDeOrigem = "update computador set fk_computador_pa = @fk_pa where id_computador=@id_computador;";

        public String Condenar = "update computador set Conservacao = Condenada where id_computador=@id_computador;";

        public String DeletePaTemp = "delete from temp_conserto where id_tempConserto=@id_tempConserto;";

        public String atualizaModeloDoPc = "update computador set marca=@marca where id_computador = @id_computador;";

        public String acharPcsPeloSistema = "SELECT * FROM computador INNER JOIN pa ON pa.id_pa = computador.fk_computador_Pa INNER JOIN grupos_pa ON grupos_pa.id_grupo = pa.fk_grupo_id inner join computador_conserto on computador.id_computador=computador_conserto.fk_computador where sistemasOperacionais=@sistemasOperacionais;";

        public String TagFiltroCompMapeamento = "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa and tag_servico = @Resfiltro;";

        public String gruposFiltroCompMapeamento= "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa and grupos = @Resfiltro;";

        public String memoria= "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa and tipo_memoria Like @Resfiltro;";

        public String processador= "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa and Processador Like @Resfiltro;";

        public String paFiltroCompMapeamento= "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa and pa = @Resfiltro;";

        public String TalkfiltroCompMapeamento= "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa and Talk_id = @Resfiltro;";

        public String PatrifiltroCompMapeamento= "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa and patrimonio = @Resfiltro;";

        public String TodfiltroCompMapeamento = "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa= @empresa and grupos not in ('condenada','Deposito');";

        public String TodClub = "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id where empresa = 'clube maxivida' or grupos like '%clube%' and grupos not in ('condenada','Deposito');";

        public String imobilizados = "";

        public String MapeamentoDePcs = "select * from computador right join pa on computador.fk_computador_Pa=pa.id_pa  inner join grupos_pa on pa.fk_grupo_id=grupos_pa.id_grupo   where fk_grupo_id=1 order by pa.pa asc;";

        public string inserirComputador = "INSERT INTO computador(patrimonio,tag_servico,sistemasOperacionais,marca,processador,Valor,empresa,conservacao,DataCompra,fk_computador_Pa) VALUES (@patrimonio,@tag_servico,@sistemasOperacionais,@marca,@processador,@Valor,@empresa,@conservacao,@DataCompra,351);";
    }

}
