using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MetroFramework.Forms;

namespace Main.CS
{
    public partial class Log : MetroForm
    {

        DBHelper db = new DBHelper();
        String[] temp = new String[3];

        public Log()
        {
            InitializeComponent();
        }

        

        private void Log_Load(object sender, EventArgs e)
        {
            string select_sql = "SELECT * FROM Student";
            int cnt = 1;
            SQLiteConnection conn = new SQLiteConnection(db.ConnectionString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(select_sql, conn);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    ListViewItem lv_item;
                    
                    temp[0] = cnt.ToString();
                    temp[1] = reader["Date"].ToString();
                    temp[2] = reader["NAME"].ToString() + "(이)가 " +
                               reader["Service"].ToString() + " 에 접속" +
                               "    - " + reader["ID"];
                    lv_item = new ListViewItem(temp);
                    listView1.Items.Add(lv_item);
                    cnt++;
                }

            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
