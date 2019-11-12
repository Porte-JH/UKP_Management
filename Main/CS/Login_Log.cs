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
    public partial class Login_Log : Form
    {
        DBHelper db;
        DTO dto;

        public Login_Log()
        {
            InitializeComponent();
            try
            {
                db.OPEN_DB();
                


            }
            catch
            {

            }
            


        }
        
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
