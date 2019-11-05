using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Windows.Forms;
using System.Threading;
using System.Data.SQLite;
namespace Main
{

    public partial class Main : Form
    {
        private SQLiteConnection conn = null;
        public Main()
        {

            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {

            string DbFile = "MyDatabase.dat";
            string ConnectionString = string.Format("Data Source={0};Version=3;", DbFile);

            try
            {
                if (!System.IO.File.Exists(DbFile))
                {
                    SQLiteConnection.CreateFile(DbFile);  // SQLite DB 생성
                }
                else  // 기능 동작 여부 확인을 위해서 추가했지만 불필요
                {
                    MessageBox.Show("DB 생성되어 있습니다");
                    return;
                }

                // 테이블 생성 코드
                SQLiteConnection sqliteConn = new SQLiteConnection(ConnectionString);
                sqliteConn.Open();

                string strsql = "CREATE TABLE IF NOT EXISTS DATA (Id varchar(20), pw varchar(20))";

                SQLiteCommand cmd = new SQLiteCommand(strsql, sqliteConn);
                cmd.ExecuteNonQuery();
                sqliteConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }


        public void Login_Sys(string input_id, string input_pw, IWebDriver sys_driver)
        {

            sys_driver.Url = "https://auth.kimpo.ac.kr/html/login.php";
            IWebElement sys_id = sys_driver.FindElement(By.Name("id"));
            sys_id.SendKeys(input_id);
            sys_driver.FindElement(By.Name("pw")).SendKeys(input_pw);
            sys_driver.FindElement(By.XPath("//*[@id='wrapper_login']/form/div/table[3]/tbody/tr[1]/td[3]/img")).Click();
            sys_driver.Url = "http://kpis4.kimpo.ac.kr:8000/hosting/group/kpis/html/kpis_main.php";

            sys_driver.FindElement(By.LinkText("정보광장")).Click();
        }

        public void Login_Check(string input_id, string input_pw, IWebDriver check_driver)
        {
            check_driver.Url = "https://check.kimpo.ac.kr";
            IWebElement check_id = check_driver.FindElement(By.XPath("//*[@id='username']"));
            check_id.SendKeys(input_id);
            check_driver.FindElement(By.XPath("//*[@id='passwd']")).SendKeys(input_pw);
            check_driver.FindElement(By.XPath("//*[@id='loginform']/button")).Click();
        }

        public void Login_Ncs(string input_id, string input_pw, IWebDriver ncs_driver)
        {

            ncs_driver.Url = "https://ncs.kimpo.ac.kr/login";
            IWebElement ncs_id = ncs_driver.FindElement(By.XPath("//*[@id='loginId']"));
            ncs_id.SendKeys(input_id);
            ncs_driver.FindElement(By.XPath("//*[@id='password']")).SendKeys(input_pw);

            ncs_driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div/label[2]")).Click();
            ncs_driver.FindElement(By.XPath("//*[@id='loginBtn']")).Click();
        }

        public void Check(IWebDriver check_driver, string link_value)
        {
            var check_num = textBox3.Text;
            check_driver.Url = "https://check.kimpo.ac.kr/index.php/student/AttendCheck/" + link_value;
            //MessageBox.Show(check_driver.Url);
            Thread.Sleep(1000);
            check_driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/ul[1]/li[2]/span[3]/div/div[1]/div/input")).SendKeys(check_num);
            check_driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/ul[1]/li[2]/span[3]/div/button")).Click();
        }

        public void Save_Data(string id, string pw, SQLiteConnection sqliteConn, SQLiteCommand cmd)
        {
            if(checkBox1.Checked == true)
            {
                sqliteConn.Open();
                string sql = "insert into members (id, pw) values ('" + id + "', '" + pw + "')";
                cmd = new SQLiteCommand(sql, sqliteConn);
                cmd.ExecuteNonQuery();
                sqliteConn.Close();
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            var input_id = textBox1.Text;
            var input_pw = textBox2.Text;
            int Now_Hour = int.Parse(DateTime.Now.ToString("hh"));

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    IWebDriver sys_driver = new InternetExplorerDriver();
                    Login_Sys(input_id, input_pw, sys_driver);
                    //Save_Data(input_id, input_pw, sqliteConn, cmd);
                    break;
                case 1:
                    IWebDriver check_driver = new ChromeDriver();
                    Login_Check(input_id, input_pw, check_driver);

                    if (textBox3.Text != "")
                    {
                        string link_value;
                        check_driver.Url = "https://check.kimpo.ac.kr/index.php/student/main";
                        if (Now_Hour == 9)
                        {
                            IWebElement First_Class = check_driver.FindElement(By.XPath("//*[@id='schedule']/ul/li[1]"));
                            link_value = First_Class.GetAttribute("lid");
                            First_Class.Click();
                            Check(check_driver, link_value);

                        }
                        else if (Now_Hour == 1)
                        {
                            IWebElement Second_Class = check_driver.FindElement(By.XPath("//*[@id='schedule']/ul/li[4]"));
                            link_value = Second_Class.GetAttribute("lid");
                            Second_Class.Click();
                            Check(check_driver, link_value);

                        }
                        else if (Now_Hour == 4)
                        {
                            IWebElement Third_Class = check_driver.FindElement(By.XPath("//*[@id='schedule']/ul/li[7]"));
                            link_value = Third_Class.GetAttribute("lid");
                            Third_Class.Click();
                            Check(check_driver, link_value);

                        }
                        else
                        {
                            MessageBox.Show("출석체크가 가능한 시간이 아닙니다.");
                        }

                    }

                    break;
                case 2:
                    IWebDriver ncs_driver = new ChromeDriver();
                    Login_Ncs(input_id, input_pw, ncs_driver);
                    break;
                default:
                    MessageBox.Show("항목을 선택해주세요...!");
                    break;
            }



        }

        
    }
}

