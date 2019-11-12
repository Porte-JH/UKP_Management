using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Main;

namespace Main
{
    class DBHelper
    {
        static string DB_NAME = "UKP_DB.dat";
        string ConnectionString = string.Format("Data Source={0};Version=3;", DB_NAME);

        public void Create_DB()
        {
            
            if (!System.IO.File.Exists(DB_NAME))
            {
                SQLiteConnection.CreateFile(DB_NAME);
            } else
            {
                Console.WriteLine("DB가 생성되어 있습니다.");
                return;
            }

        }

        public void OPEN_DB()
        {

            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.Open();

        }

        public void CLOSE_DB()
        {
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.Close();
        }

        public void CREATE_TABLE()
        {
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            string strsql = "CREATE TABLE IF NOT EXISTS Student" +
                            "(ID varchar(20), Name varchar(20))";
            SQLiteCommand cmd = new SQLiteCommand(strsql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void INSERT_TABLE(string ID, string Name)
        {
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            String insert_sql = "INSERT INTO Student" +
                                "(ID, Name) values ('" + ID + "','" + Name + "')";
            SQLiteCommand cmd = new SQLiteCommand(insert_sql, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
                    
        }

        public void SELECT_TABLE(string input_ID)
        {
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            DTO D = null;

            String select_sql = "SELECT * FROM Student where ID = '" + input_ID + "'";

            SQLiteCommand cmd = new SQLiteCommand(select_sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

          
        }
    }
}
