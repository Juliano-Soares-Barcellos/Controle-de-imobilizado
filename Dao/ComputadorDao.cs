
using MySql.Data.MySqlClient;
using ProjetoDeControleDeMateriaisMandadoParaConserto.BancoConexao;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Model;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    internal class ComputadorDao
    {

        private MySqlConnection con = null;
        private Query sql;
        private MySqlTransaction Transacao;


        public int AcharPcs(String computador)
        {
            int id = -1;
            con = new Banco().Conexaopcs();
            con.Open();

            try
            {
                sql = new Query();
                MySqlCommand cmd = new MySqlCommand(sql.Achou, con);
                cmd.Parameters.AddWithValue("@Nome", computador);
                object tese = cmd.ExecuteScalar();

                if (tese != null)
                {
                    id = Convert.ToInt32(tese);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "-----------" + ex.ToString());
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return id;
        }


        public void inserirComputadorEntrada(Computador computador, String Descricao, DateTime data)
        {
            con = new Banco().Conexaopcs();
            con.Open();
            try
            {

                MySqlCommand comando = con.CreateCommand();
                Transacao = con.BeginTransaction();
                comando.Transaction = Transacao;
                sql = new Query();
                comando.CommandText = sql.SqlInserirComputadorVoltarUltimoId; // esta é a query
                comando.Parameters.AddWithValue("@Nome", computador.Nome);
                comando.Parameters.AddWithValue("@Marca", computador.Marca);
                comando.Parameters.AddWithValue("@SistemaOperacional", computador.Sistema);
                comando.Parameters.AddWithValue("@Programas", computador.Programas);

                int id = Convert.ToInt32(comando.ExecuteScalar()); //executando tudo e voltando o id
                if (con != null)
                {
                    Transacao.Commit();
                    con.Close();

                }
                InsereDataEntrada(Descricao, id);
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao executar o comando SQL: " + ex.Message);
                Console.WriteLine(ex.Message);
                Transacao.Rollback();
            }
            finally
            {
                Transacao.Dispose();
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        public void InserirComputadorSaida(ComputadorSaida computador)
        {
            con = new Banco().Conexaopcs();
            con.Open();
            try
            {
                Transacao = con.BeginTransaction();
                MySqlCommand comandos = con.CreateCommand();
                comandos.Transaction = Transacao;
                sql = new Query();
                comandos.CommandText = sql.InsereComputadorSaida;

                comandos.Parameters.AddWithValue("@Descricao", computador.DescricaoSaida);
                comandos.Parameters.AddWithValue("@DataSaida", DateTime.Now);
                comandos.Parameters.AddWithValue("@computador_id", computador.Computador_id.Id);
                comandos.Parameters.AddWithValue("@computadorEntrada_id", computador.computadorEntrada_id);
                comandos.ExecuteNonQuery();
                Transacao.Commit();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao executar o comando SQL: " + ex.Message);
                Transacao.Rollback();
            }
            finally
            {
                Transacao.Dispose();
                con.Close();
            }
        }

        public void updaterComputador(Computador computador) //nao esqueca de me usar depois do InserirComputadorSaida
        {
            con = new Banco().Conexaopcs();
            con.Open();
            try
            {
                MySqlCommand comando = con.CreateCommand();
                Transacao = con.BeginTransaction();
                comando.Transaction = Transacao;
                sql = new Query();
                comando.CommandText =sql.UpdateNosPrograma;
                comando.Parameters.AddWithValue("@programas", computador.Programas);
                comando.Parameters.AddWithValue("@id", computador.Id);
                int rown = comando.ExecuteNonQuery();
                Transacao.Commit();
                Console.WriteLine(rown);
            }
            catch (MySqlException e)
            {
                Transacao.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                Transacao.Dispose();
                con.Close();
            }

        }

        public void updateSistema(Computador computador) //nao esqueca de me usar depois do InserirComputadorSaida
        {
            con = new Banco().Conexaopcs();
            con.Open();
            try
            {
                MySqlCommand comando = con.CreateCommand();
                Transacao = con.BeginTransaction();
                comando.Transaction = Transacao;
                sql = new Query();
                comando.CommandText = sql.UpdateNosSistemaOperacional;
                comando.Parameters.AddWithValue("@Operacional", computador.Sistema);
                comando.Parameters.AddWithValue("@id", computador.Id);
                int rown = comando.ExecuteNonQuery();
                Transacao.Commit();
                Console.WriteLine(rown);
            }
            catch (MySqlException e)
            {
                Transacao.Rollback();
                MessageBox.Show(e.Message);
            }
            finally
            {
                Transacao.Dispose();
                con.Close();
            }

        }


        public void InsereDataEntrada(String Descricao, int id)
        {
            con = new Banco().Conexaopcs();
            con.Open();
            try
            {
                MySqlCommand dataentrada = con.CreateCommand();
                Transacao = con.BeginTransaction();
                dataentrada.Transaction = Transacao;
                sql = new Query();
                dataentrada.CommandText = sql.InsereComputadorEntrada;
                dataentrada.Parameters.AddWithValue("@Descricao", Descricao);
                dataentrada.Parameters.AddWithValue("@data", DateTime.Now);
                dataentrada.Parameters.AddWithValue("@id", id);
                dataentrada.Parameters.AddWithValue("@computadorsaida_id", 1);
                int rown=dataentrada.ExecuteNonQuery();
                Transacao.Commit();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao executar o comando SQL: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Transacao.Dispose();
                con.Close();
            }
        }

        public List<int> CompararTamanhoData(ComputadorSaida computador)
        {
            List<int> resultados = new List<int>();
            int TamanhoDataSaida = 0;
            con = new Banco().Conexaopcs();
            con.Open();
            try
            {
                sql = new Query();
                MySqlCommand cmd = new MySqlCommand(sql.ResQuantiDataEntrada,con);
                cmd.Parameters.AddWithValue("@data_id", computador.Computador_id.Id);
                int TanhoDataEn = Convert.ToInt32(cmd.ExecuteScalar());
                TamanhoDataSaida = this.TamanhoDataSaida(computador);
                resultados.Add(TanhoDataEn);
                resultados.Add(TamanhoDataSaida);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                con.Close();
            }
            return resultados;
        }

        public int TamanhoDataSaida(ComputadorSaida computador)
        {
            int TanhoDataEn = 0;
            con = new Banco().Conexaopcs();
            con.Open();
            try
            {
                sql = new Query();
                MySqlCommand cmd = new MySqlCommand(sql.ResQuantidadeDataSaida,con);
                cmd.Parameters.AddWithValue("@computador_id", computador.Computador_id.Id);
                TanhoDataEn = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                con.Close();
            }

            return TanhoDataEn;
        }

        public int AcharIdDataEntrada(int IdData)
        {
            int id = 0;
            con = new Banco().Conexaopcs();
            con.Open();

            try
            {
                sql = new Query();
                MySqlCommand cmd = new MySqlCommand(sql.acharIdDataEntrada, con);
                cmd.Parameters.AddWithValue("@idData", IdData);
               object iddata = cmd.ExecuteScalar();

                if (iddata != null || !iddata.ToString().Equals("{}"))
                {
                    id = Convert.ToInt32(iddata);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return id;
        }


        public List<String> carregarCombobox()
        {
            List<String> resultados = new List<String>();

            try
            {
                con = new Banco().Conexaopcs();
                con.Open();
                 string sql = "select Marca from computadorentrada ;";
                MySqlCommand comando = new MySqlCommand(sql, con);
             
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    String marca = reader["Marca"].ToString();

                    if (!resultados.Contains(marca))
                    { 
                    resultados.Add(marca);
                    }
                }

           
                reader.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultados;
        }
    }

}




