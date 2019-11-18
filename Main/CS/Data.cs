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
        DTO Student;
        

        public Data()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Data_Load(object sender, EventArgs e)
        {
            db.OPEN_DB();
            db.SELECT_TABLE_DATA(Student.input_id);

           

        }
    }
}
