using System;
using System.Data.SQLite;
using System.Data;
using System.Collections.Generic;

namespace BancoDeDados
{
    public abstract class DBHelper<T>
    {
        protected static SQLiteConnection sqliteConnection;

        public DBHelper(string conn)
        {
            InitConnection(conn);
        }

        private void InitConnection(string conn)
        {
            if(sqliteConnection == null)
            {
                sqliteConnection = new SQLiteConnection(conn);
                sqliteConnection.Open();
            }
            else { 
                if(sqliteConnection.State != System.Data.ConnectionState.Open)
                {
                    sqliteConnection.Open();
                }
            }
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

        public abstract void CreateTable();
        public abstract void Insert(T t);
        public abstract void Update(T t);
        public abstract void Delete(T t);
        public abstract T Find(int id);
        public abstract List<T> FindAll();
        public abstract List<T> FindAll_Custom(string sql);

    }
}
