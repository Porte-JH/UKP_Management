using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Main;
using System.Collections;

namespace Main
{
    class DBHelper
    {
        static string DB_NAME = "UKP_DB.dat";
        string ConnectionString = string.Format("Data Source={0};Version=3;", DB_NAME);

        static List<string> temp = new List<string>();

        public static void Create_DB()
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
                            "(ID varchar(20), Name varchar(20), FDATE varchar(30), BDATE varchar(30), STATUS integer" +
                            ")";
            SQLiteCommand cmd = new SQLiteCommand(strsql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void INSERT_TABLE(string ID, string Name, string FDATE, string BDATE, int STATUS)
        {
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            

            string insert_sql = "INSERT INTO Student" +
                                "(ID, Name, FDATE, BDATE, STATUS) values ('" + ID + "','" + Name + 
                                "', '" + FDATE + "', '" + BDATE + "', '" + STATUS + "')";
            SQLiteCommand cmd = new SQLiteCommand(insert_sql, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
                    
        }

        public void SELECT_TABLE_LOG(string input_ID)
        {
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            

            string select_sql = "SELECT * FROM Student where ID = '" + input_ID + "'";

            SQLiteCommand cmd = new SQLiteCommand(select_sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

          
        }

        public DTO SELECT_TABLE_DATA(string input_ID)
        {
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.Open();
                        
            string select_sql = "SELECT * FROM Student where ID = '" + input_ID + "' and STATUS = '" + 1 + "'";



            SQLiteCommand cmd = new SQLiteCommand(select_sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();


            return ;
        }
    }
}
