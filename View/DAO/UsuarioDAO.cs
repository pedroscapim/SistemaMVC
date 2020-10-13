using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Entidades;

namespace View.DAO
{
    class UsuarioDAO
    {
        internal int Inserir(UsuarioEnt objtabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();

                //con conversa/instansia com bd cn estancia/recebendo a função da sqlcommand

                cn.CommandText = "INSERT INTO cadtelefone([nome],[telefone]) VALUES (@nome, @telefone)";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objtabela.Nome;
                cn.Parameters.Add("telefone", SqlDbType.VarChar).Value = objtabela.Telefone;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;

                //vai retornar de quem chamou!



            }

        }

        internal int Deletar(UsuarioEnt objtabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();

                cn.CommandText = "DELETE FROM cadtelefone WHERE id=@id ";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objtabela.Nome;
                cn.Parameters.Add("telefone", SqlDbType.VarChar).Value = objtabela.Telefone;
                cn.Parameters.Add("id", SqlDbType.Int).Value = objtabela.Id;



                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }   
        internal int Alterar(UsuarioEnt objtabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();

                //con conversa/instansia com bd cn estancia/recebendo a função da sqlcommand

                cn.CommandText = "UPDATE cadtelefone SET nome=@nome, telefone=@telefone WHERE id=@id ";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objtabela.Nome;
                cn.Parameters.Add("telefone", SqlDbType.VarChar).Value = objtabela.Telefone;
                cn.Parameters.Add("id", SqlDbType.Int).Value = objtabela.Id;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;

                //vai retornar de quem chamou!



            }
        }

        public List<UsuarioEnt> Consulta(UsuarioEnt objtabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();

                //con conversa/instansia com bd cn estancia/recebendo a função da sqlcommand

                cn.CommandText = " SELECT * FROM CADTELEFONE WHERE nome LIKE @nome";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objtabela.Nome + "%";
                cn.Connection = con;
                SqlDataReader dr;
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                dr = cn.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Nome = Convert.ToString(dr["Nome"]);
                        dado.Telefone = Convert.ToString(dr["Telefone"]);

                        lista.Add(dado);

                    }
                }
                return lista;

            }
        }

        internal List<UsuarioEnt> Lista()
        {

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();

                //con conversa/instansia com bd cn estancia/recebendo a função da sqlcommand

                cn.CommandText = " SELECT * FROM CADTELEFONE";
                cn.Connection = con;
                SqlDataReader dr;
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                dr = cn.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Nome = Convert.ToString(dr["Nome"]);
                        dado.Telefone = Convert.ToString(dr["Telefone"]);

                        lista.Add(dado);

                    }
                }
                return lista;
            }
        }
    }
}
