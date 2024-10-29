using MySql.Data.MySqlClient;
using ProjetoDeControleDeMateriaisMandadoParaConserto.BancoConexao;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Querys;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    internal class TabelaDao
    {
        private MySqlConnection con = null;
        private Query sql;


        public List<Object[]> TodaTabela()
        {
            con = new Banco().Conexaopcs();
            con.Open();



            List<Object[]> resultados = new List<Object[]>();

            try
            {
                sql = new Query();
                MySqlCommand comando = new MySqlCommand(sql.selectTabela, con);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Object[] row = new Object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }

                    resultados.Add(row);
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


       
        public List<Object[]> pegarNumnero(String numero)
        {
            con = new Banco().Conexaopcs();
            con.Open();

            List<Object[]> resultados = new List<Object[]>();

            try
            {
                sql = new Query();
                MySqlCommand comando = new MySqlCommand(sql.FiltroPorNumero, con);
                comando.Parameters.AddWithValue("@numero", numero);


                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Object[] row = new Object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }

                    resultados.Add(row);
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


        public List<Object[]> pegarSistema(String sistema)
        {
            con = new Banco().Conexaopcs();
            con.Open();

            List<Object[]> resultados = new List<Object[]>();

            try
            {
                sql = new Query();
                MySqlCommand comando = new MySqlCommand(sql.FiltroPorSistema, con);
                comando.Parameters.AddWithValue("@sistema", sistema);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Object[] row = new Object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }

                    resultados.Add(row);
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

        public List<Object[]> ssd()
        {
            con = new Banco().Conexao();
            con.Open();

            List<Object[]> resultados = new List<Object[]>();

            try
            {
                sql = new Query();
                MySqlCommand comando = new MySqlCommand(sql.filtrossd, con);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Object[] row = new Object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }

                    resultados.Add(row);
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





