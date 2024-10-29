using System;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Querys
{
    public class Query
    {
        public String Achou = "Select id from computadorentrada where nome=@nome";

        public String acharIdDataEntrada = "select max(id) from datadeentrada where data_id=@idData;";

        public String SqlInserirComputadorVoltarUltimoId = "INSERT INTO computadorentrada(Nome, Marca, SistemaOperacional,  Programas) VALUES (@Nome, @Marca, @SistemaOperacional, @Programas);SELECT LAST_INSERT_ID();";

        public String InsereComputadorEntrada = "INSERT INTO datadeentrada(Descricao, data,data_id) VALUES (@Descricao,@data,@id);";

        public String InsereComputadorSaida = "INSERT INTO computadorsaida(Descricao , DataSaida,Computador_id,computadorEntrada_id) VALUES ( @Descricao, @DataSaida, @Computador_id,@computadorEntrada_id);";

        public String ResQuantiDataEntrada = "select count(data) from datadeentrada where data_id=@data_id;";

        public String ResQuantidadeDataSaida = "select count(DataSaida) from computadorsaida where computador_Id=@computador_id";

        public String UpdateNosPrograma = "update computadorentrada set programas=@programas where id=@id;";

        public String UpdateNosSistemaOperacional = "update computadorentrada set SistemaOperacional=@Operacional where id=@id;";

        public String selectTabela = "SELECT c.data,c.Descricao,entrada.Nome,entrada.Marca,entrada.SistemaOperacional,entrada.Programas,d.DataSaida,d.Descricao FROM computadorentrada AS entrada left JOIN datadeentrada AS c ON  c.data_id =entrada.id LEFT JOIN computadorsaida  AS d ON d.computadorEntrada_id=c.id;";

        public String FiltroPorNumero = "SELECT c.data,c.Descricao,entrada.Nome,entrada.Marca,entrada.SistemaOperacional,entrada.Programas,d.DataSaida,d.Descricao FROM computadorentrada AS entrada left JOIN datadeentrada AS c ON  c.data_id =entrada.id LEFT JOIN computadorsaida  AS d ON d.computadorEntrada_id=c.id where entrada.nome=@numero;";

        public String FiltroPorSistema = "SELECT c.data,c.Descricao,entrada.Nome,entrada.Marca,entrada.SistemaOperacional,entrada.Programas,d.DataSaida,d.Descricao FROM computadorentrada AS entrada left JOIN datadeentrada AS c ON  c.data_id =entrada.id LEFT JOIN computadorsaida  AS d ON d.computadorEntrada_id=c.id where entrada.SistemaOperacional=@sistema;";

        public String filtrossd = " SELECT * FROM computador INNER JOIN pa ON pa.id_pa = computador.fk_computador_Pa INNER JOIN grupos_pa ON grupos_pa.id_grupo = pa.fk_grupo_id inner join computador_conserto on computador.id_computador=computador_conserto.fk_computador where Descricao_problema_resolvido like '%ssd%';";//"SELECT c.data, c.Descricao, entrada.Nome, entrada.Marca, entrada.SistemaOperacional, entrada.Programas, d.DataSaida, d.Descricao FROM computadorentrada AS entrada left JOIN datadeentrada AS c ON c.data_id = entrada.id LEFT JOIN computadorsaida AS d ON d.computadorEntrada_id= c.id where d.Descricao like '%ssd%';";

        public String FiltroGrafico = "select count(conserto.data),conserto.data from produto inner join conserto on  produto.id=conserto.Produto_id where conserto.data  BETWEEN @data1 AND @data2  group by conserto.data;";

        public String SelectDelet = "Select * from Produto as p left join conserto as cs on p.id=cs.Produto_id where p.numero=@numero;";

        public String CarregarTabela = "SELECT p.id, p.Nome, p.Numero, p.quantidade_conserto, GROUP_CONCAT(Con.Data SEPARATOR ', ') AS Datas FROM Produto AS p LEFT JOIN Conserto AS Con ON p.id = Con.Produto_id where p.Numero = @numero GROUP BY p.Nome ORDER BY Con.Data ASC";

        public String UpdateConsertoIgualZero = "update produto set quantidade_conserto ='1' where produto.numero=@numero;";

        public String UpdateConsertoMaisUm = "UPDATE Produto AS p  Inner JOIN Conserto  on p.id=Conserto.Produto_id set p.quantidade_conserto = p.quantidade_conserto+1  where p.Numero= @numero ;";

        public String SqlInsertConserto = "INSERT INTO Conserto (Data,Produto_id) VALUES (@Data,@Produto_id;)";

        public String EncontarNumero="SELECT * FROM Produto AS p left JOIN Conserto ON p.id = Conserto.Produto_id WHERE Numero = @numero;";
        
        public String buscaMapPc=  "select * from computador inner join pa on pa.id_pa=computador.fk_computador_Pa inner join grupos_pa on grupos_pa.id_grupo=pa.fk_grupo_id; ";

        public String encontrePc = "SELECT * FROM computador INNER JOIN pa ON pa.id_pa = computador.fk_computador_Pa INNER JOIN grupos_pa ON grupos_pa.id_grupo = pa.fk_grupo_id where computador.patrimonio=@patrimonio;";

        public String quantidadePcGrupo = "SELECT COUNT(*) FROM computador INNER JOIN pa ON pa.id_pa = computador.fk_computador_Pa INNER JOIN grupos_pa ON grupos_pa.id_grupo = pa.fk_grupo_id WHERE grupos_pa.grupos = @grupo;";
        
      

    }
}
