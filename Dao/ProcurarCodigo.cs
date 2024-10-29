using MySql.Data.MySqlClient;
using ProjetoDeControleDeMateriaisMandadoParaConserto.BancoConexao;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Querys;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    internal class ProcurarCodigo
    {
        public MySqlConnection con = null;
        private  Query Query;
        public List<Object[]> carregarTabela(string Numero)
        {
            List<Object[]> resultados = new List<Object[]>();

            try
            {
                con = new Banco().Conexao();
                con.Open();
                Query = new Query();
                String sql = Query.CarregarTabela;
                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("@numero", Numero);
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
