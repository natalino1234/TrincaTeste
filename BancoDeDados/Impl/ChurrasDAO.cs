using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Modelos;

namespace BancoDeDados.Impl
{
    public class ChurrasDAO : DBHelper<Churras>
    {

        public ChurrasDAO(string conn) : base (conn)
        {
        }

        protected override void CreateTable()
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Churras(
                                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                id_usuario INTEGER, 
                                Nome VARCHAR(255), 
                                Observacoes VARCHAR(255), 
                                dataChurras DATETIME,
                                valor_individual DECIMAL(10,2),
                                bebida_incluida INTEGER
                            );";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete(Churras t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = @"
                            DELETE FROM Churras WHERE ID = "+t.Id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Churras Find(int id)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Churras Where Id =" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Churras churras = new Churras(
                            Convert.ToInt32(dt.Rows[0]["id"].ToString()),
                            Convert.ToInt32(dt.Rows[0]["id_usuario"].ToString()),
                            dt.Rows[0]["observacoes"].ToString(),
                            dt.Rows[0]["nome"].ToString(),
                            Convert.ToDateTime(dt.Rows[0]["dataChurras"].ToString()),
                            Convert.ToDouble(dt.Rows[0]["valor_individual"].ToString()),
                            Convert.ToBoolean(dt.Rows[0]["bebida_incluida"].ToString())
                        );
                        return churras;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<Churras> FindAll()
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            List<Churras> churrasList = new List<Churras>();
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Churras";
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Churras churras = new Churras(
                                Convert.ToInt32(dr["id"].ToString()),
                                Convert.ToInt32(dr["id_usuario"].ToString()),
                                dr["observacoes"].ToString(),
                                dr["nome"].ToString(),
                                Convert.ToDateTime(dr["dataChurras"].ToString()),
                                Convert.ToDouble(dr["valor_individual"].ToString()),
                                Convert.ToBoolean(dr["bebida_incluida"].ToString())
                            );
                            churrasList.Add(churras);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return churrasList;
        }

        public override List<Churras> FindAll_Custom(string sql)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            List<Churras> churrasList = new List<Churras>();
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
                            Churras churras = new Churras(
                                Convert.ToInt32(dr["id"].ToString()),
                                Convert.ToInt32(dr["id_usuario"].ToString()),
                                dr["observacoes"].ToString(),
                                dr["nome"].ToString(),
                                Convert.ToDateTime(dr["dataChurras"].ToString()),
                                Convert.ToDouble(dr["valor_individual"].ToString()),
                                Convert.ToBoolean(dr["bebida_incluida"].ToString())
                            );
                            ChurrasParticipanteDAO partDao = new ChurrasParticipanteDAO(Conn);

                            churras.participantes = partDao.FindAll_Custom("Select * from ChurrasParticipante where id_churras = "+churras.Id);
                            churrasList.Add(churras);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return churrasList;
        }

        public override void Insert(Churras t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText =
                            "INSERT INTO Churras " +
                            "(" +
                                "id_usuario, " +
                                "Nome, " +
                                "Observacoes, " +
                                "dataChurras, " +
                                "valor_individual, " +
                                "bebida_incluida" +
                            ") " +
                            "VALUES " +
                            "(" +
                                "" + t.Id_usuario + ", " +
                                "\"" + t.Nome + "\", " +
                                "\"" + t.Observacoes + "\", " +
                                "\"" + t.Data.ToString("yyyy-MM-dd") + "\", " +
                                "" + t.ValorParticipante + ", " +
                                "" + (t.BebidaIncluida ? 1 : 0) + " " +
                            ")";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(Churras t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText =
                            "UPDATE Churras " +
                            "Set " +
                            "Nome = \"" + t.Nome + "\", " +
                            "Observacoes = \"" + t.Observacoes + "\", " +
                            "dataChurras = \"" + t.Data.ToString("yyyy-MM-dd") + "\", " +
                            "valor_individual = \"" + t.ValorParticipante + "\", " +
                            "bebida_incluida = \"" + (t.BebidaIncluida?1:0) + "\" " +
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
