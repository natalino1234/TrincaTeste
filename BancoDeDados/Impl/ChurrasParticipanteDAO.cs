using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Modelos;

namespace BancoDeDados.Impl
{
    public class ChurrasParticipanteDAO : DBHelper<ChurrasParticipante>
    {

        public ChurrasParticipanteDAO(string conn) : base (conn)
        {
        }

        protected override void CreateTable()
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS ChurrasParticipante(
                                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                id_churras VARCHAR(255), 
                                nome_participante VARCHAR(255), 
                                pago int(1)
                            );";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete(ChurrasParticipante t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = @"
                            DELETE FROM ChurrasParticipante WHERE ID = "+t.Id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override ChurrasParticipante Find(int id)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ChurrasParticipante Where Id =" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ChurrasParticipante ChurrasParticipante = new ChurrasParticipante(
                            Convert.ToInt32(dt.Rows[0]["id"].ToString()),
                            Convert.ToInt32(dt.Rows[0]["id_churras"].ToString()),
                            dt.Rows[0]["nome_participante"].ToString(),
                            Convert.ToBoolean(dt.Rows[0]["pago"].ToString())
                        );
                        return ChurrasParticipante;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<ChurrasParticipante> FindAll()
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            List<ChurrasParticipante> ChurrasParticipanteList = new List<ChurrasParticipante>();
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ChurrasParticipante";
                    da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            ChurrasParticipante ChurrasParticipante = new ChurrasParticipante(
                                Convert.ToInt32(dr["id"].ToString()),
                                Convert.ToInt32(dr["id_churras"].ToString()),
                                dr["nome_participante"].ToString(),
                                Convert.ToBoolean(dr["pago"].ToString())
                            );
                            ChurrasParticipanteList.Add(ChurrasParticipante);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ChurrasParticipanteList;
        }


        public override List<ChurrasParticipante> FindAll_Custom(string sql)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            List<ChurrasParticipante> ChurrasParticipanteList = new List<ChurrasParticipante>();
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
                            ChurrasParticipante ChurrasParticipante = new ChurrasParticipante(
                                Convert.ToInt32(dr["id"].ToString()),
                                Convert.ToInt32(dr["id_churras"].ToString()),
                                dr["nome_participante"].ToString(),
                                Convert.ToBoolean(dr["pago"].ToString())
                            );
                            ChurrasParticipanteList.Add(ChurrasParticipante);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ChurrasParticipanteList;
        }

        public override void Insert(ChurrasParticipante t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText =
                            "INSERT INTO ChurrasParticipante " +
                            "(" +
                                "id_churras, " +
                                "nome_participante, " +
                                "pago, " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "\"" + t.Id_churras + "\", " +
                                "\"" + t.Nome_participante + "\", " +
                                "" + (t.Pago ? 1 : 0) + " " +
                            ")";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(ChurrasParticipante t)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText =
                            "UPDATE ChurrasParticipante " +
                            "Set " +
                            "id_churras = \"" + t.Id_churras + "\", " +
                            "nome_participante = \"" + t.Nome_participante + "\", " +
                            "pago = \"" + (t.Pago?1:0) + "\" " +
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
