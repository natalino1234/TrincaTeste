using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using Modelos;

namespace BancoDeDados.Impl
{
    public class UsuarioDAO : DBHelper<Usuario>
    {

        public UsuarioDAO(string conn) : base (conn)
        {
        }

        protected override void CreateTable()
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Usuario(
                                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                login VARCHAR(255), 
                                senha VARCHAR(255),
                                nome VARCHAR(255),
                                authtoken VARCHAR(255)
                            );";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete(Usuario t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = @"
                            DELETE FROM Usuario WHERE ID = "+t.Id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Usuario Find(int id)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario Where Id =" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Usuario Usuario = new Usuario(
                            Convert.ToInt32(dt.Rows[0]["id"].ToString()),
                            dt.Rows[0]["login"].ToString(),
                            dt.Rows[0]["senha"].ToString(),
                            dt.Rows[0]["nome"].ToString(),
                            dt.Rows[0]["authtoken"].ToString()
                        );
                        return Usuario;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<Usuario> FindAll()
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            List<Usuario> UsuarioList = new List<Usuario>();
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario";
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Usuario Usuario = new Usuario(
                                Convert.ToInt32(dr["id"].ToString()),
                                dr["login"].ToString(),
                                dr["senha"].ToString(),
                                dr["nome"].ToString(),
                                dr["authtoken"].ToString()
                            );
                            UsuarioList.Add(Usuario);
                        }
                    }
                }
            return UsuarioList;
        }

        public override List<Usuario> FindAll_Custom(string sql)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            List<Usuario> UsuarioList = new List<Usuario>();
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Usuario Usuario = new Usuario(
                                Convert.ToInt32(dr["id"].ToString()),
                                dr["login"].ToString(),
                                dr["senha"].ToString(),
                                dr["nome"].ToString(),
                                dr["authtoken"].ToString()
                            );
                            UsuarioList.Add(Usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UsuarioList;
        }

        public override void Insert(Usuario t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText =
                            "INSERT INTO Usuario " +
                            "(" +
                                "login, " +
                                "senha, " +
                                "nome, " +
                                "authtoken" +
                            ") " +
                            "VALUES " +
                            "(" +
                                "\"" + t.Login + "\", " +
                                "\"" + t.Senha + "\", " +
                                "\"" + t.Nome + "\", " +
                                "\"" + t.AuthToken + "\" " +
                            ")";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(Usuario t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText =
                            "UPDATE Usuario " +
                            "Set " +
                            "login = \"" + t.Nome + "\", " +
                            "senha = \"" + t.Senha + "\", " +
                            "nome = \"" + t.Nome + "\", " +
                            "authtoken = \"" + t.AuthToken + "\" " +
                            "WHERE ID = " + t.Id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
