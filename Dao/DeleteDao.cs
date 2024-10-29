using MySql.Data.MySqlClient;
using ProjetoDeControleDeMateriaisMandadoParaConserto.BancoConexao;
using ProjetoDeControleDeMateriaisMandadoParaConserto.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Dao
{
    class DeleteDao
    {
        MySqlConnection con = null;

        public void deletarProduto(String numero)
        {
            int rowns = 0;
            List<Object[]> ArrayDeletar = new List<Object[]>(); ;
            try
            {
                con = new Banco().Conexao();
                Query sql= new Query();
                con.Open();
                String Sql = sql.SelectDelet;
                MySqlCommand comando = new MySqlCommand(Sql, con);
                comando.Parameters.AddWithValue("@numero", numero);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Object[] row = new Object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }
                    ArrayDeletar.Add(row);
                }
                reader.Close();
                Console.WriteLine();

                if (ArrayDeletar.Count > 0)
                {
                    int produtoStatus = Convert.ToInt32(ArrayDeletar[0][3].ToString());
                    int produtoId = Convert.ToInt32(ArrayDeletar[0][0].ToString());

                    if (ArrayDeletar[0][6] == null || string.IsNullOrEmpty(ArrayDeletar[0][6].ToString()))
                        {
                        String id=ArrayDeletar[0][0].ToString();
                        string sqlDeleteUltimoConserto = "DELETE FROM produto WHERE id=@id ;";
                        MySqlCommand deleteProduto = new MySqlCommand(sqlDeleteUltimoConserto, con);
                        deleteProduto.Parameters.Clear();

                        deleteProduto.Parameters.AddWithValue("@id", id);
                        rowns = deleteProduto.ExecuteNonQuery();
                        MessageBox.Show("Produto excluido com sucesso !!!");

                    }
                    else
                    {
                        int consertoId = Convert.ToInt32(ArrayDeletar[0][6].ToString());

                        if (produtoStatus == 1 || produtoStatus == 0)
                        {
                            String sql0 = "delete from Conserto where Produto_id=@id;";
                            MySqlCommand deleteConserto = new MySqlCommand(sql0, con);
                            deleteConserto.Parameters.AddWithValue("@id", consertoId);
                            deleteConserto.ExecuteNonQuery();

                            string sql1 = "delete from Produto where id=@idProduto;";
                            MySqlCommand deleteProduto = new MySqlCommand(sql1, con);
                            deleteProduto.Parameters.AddWithValue("@idProduto", produtoId);
                            deleteProduto.ExecuteNonQuery();
                        }
                        else if (produtoStatus >= 2)
                        {
                            string sqlCount = "SELECT COUNT(*) FROM Conserto WHERE Produto_id=@id;";
                            MySqlCommand countConsertos = new MySqlCommand(sqlCount, con);
                            countConsertos.Parameters.AddWithValue("@id", produtoId);
                            int quantidadeConsertos = Convert.ToInt32(countConsertos.ExecuteScalar());

                            if (quantidadeConsertos >= 0)
                            {
                                // Obtém a data do último registro de Conserto relacionado ao produto
                                string sqlUltimaData = "SELECT MAX(Data) FROM Conserto WHERE Produto_id=@id;";
                                MySqlCommand selectUltimaData = new MySqlCommand(sqlUltimaData, con);
                                selectUltimaData.Parameters.AddWithValue("@id", produtoId);
                                object ultimaData = selectUltimaData.ExecuteScalar();

                                if (ultimaData != DBNull.Value)
                                {
                                    // Deleta o último registro de Conserto usando a data do último conserto
                                    string sqlDeleteUltimoConserto = "DELETE FROM Conserto WHERE Produto_id=@id AND Data=@data;";
                                    MySqlCommand deleteUltimoConserto = new MySqlCommand(sqlDeleteUltimoConserto, con);
                                    deleteUltimoConserto.Parameters.Clear();

                                    deleteUltimoConserto.Parameters.AddWithValue("@id", produtoId);
                                    deleteUltimoConserto.Parameters.AddWithValue("@data", ultimaData);
                                    rowns = deleteUltimoConserto.ExecuteNonQuery();

                                }

                                // Atualiza a quantidade de consertos subtraindo 1
                                string sqlUpdateQuantidadeConserto = "UPDATE Produto SET quantidade_conserto = quantidade_conserto - @rowns WHERE id=@idProduto;";
                                MySqlCommand updateQuantidadeConserto = new MySqlCommand(sqlUpdateQuantidadeConserto, con);
                                updateQuantidadeConserto.Parameters.AddWithValue("@idProduto", produtoId);
                                updateQuantidadeConserto.Parameters.AddWithValue("@rowns", rowns);
                                updateQuantidadeConserto.ExecuteNonQuery();
                            }
                        }


                        MessageBox.Show("Produto Excluido com sucesso !!!");

                    }
                }
                else
                {
                    MessageBox.Show("Produto não encontrado");
                }
            }

            catch (MySqlException ex)
            {

                Console.WriteLine($"Erro no banco de dados:\n\n{ex.Message}\n\nStackTrace:\n{ex.StackTrace}");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
