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

namespace Main.CS
{
    public partial class Data : Form
    {

        DBHelper db = new DBHelper();
        DTO Student = new DTO();
        Main m = new Main();


        string temp;
        

        public Data()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            Student.input_id = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            string id = dataGridView1.Rows[pos].Cells[0].Value.ToString();
        }

        private void Data_Load(object sender, EventArgs e)
        {
            string select_sql = "SELECT * FROM Student where STATUS = '" + 0 + "'";

            SQLiteConnection conn = new SQLiteConnection(db.ConnectionString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(select_sql, conn);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    
                    dataGridView1.Rows.Add(new object[]
                    {
                        
                        reader.GetValue(reader.GetOrdinal("NAME")),
                        reader.GetValue(reader.GetOrdinal("ID"))


                    });


                }
                
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Student.input_id);

        }
    }
}
