using System;
using System.Data.SQLite;
using System.Data;
using System.Collections.Generic;

namespace BancoDeDados
{
    public abstract class DBHelper<T>
    {
        protected static SQLiteConnection sqliteConnection;
        protected static string Conn { get; set; }

        public DBHelper(string conn)
        {
            Conn = conn;
            InitConnection(conn);
            CreateTable();
        }

        private void InitConnection(string conn)
        {
            if(sqliteConnection == null)
            {
                //CreateDatabase(conn);
                sqliteConnection = new SQLiteConnection("Data Source="+conn+"; Version=3");
                sqliteConnection.Open();
            }
            else { 
                if(sqliteConnection.State != ConnectionState.Open)
                {
                    sqliteConnection.Open();
                }
            }
        }

        public void Close()
        {
            sqliteConnection.Close();
        }

        public void CreateDatabase(string path)
        {
            try
            {
                SQLiteConnection.CreateFile(path);
            }
            catch
            {
                throw;
            }
        }

        protected abstract void CreateTable();
        public abstract void Insert(T t);
        public abstract void Update(T t);
        public abstract void Delete(T t);
        public abstract T Find(int id);
        public abstract List<T> FindAll();
        public abstract List<dynamic> FindAll_Custom(string sql);

    }
}
