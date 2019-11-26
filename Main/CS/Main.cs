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
using MetroFramework.Forms;


namespace Main
{
    
    public partial class Main : MetroForm
    {

        DBHelper db = new DBHelper();
        DTO Student = new DTO();

        

        public string input_id;
        string input_pw;
        string Temp;
        

        

        string Date = DateTime.Now.ToString("yyyy-MM-dd / HH:mm");
        


        public Main()
        {

            InitializeComponent();
            

        }


        private void Main_Load(object sender, EventArgs e)
        {
            db.Create_DB();
            db.CREATE_TABLE();

            
        }


        public void Login_Sys(string input_id, string input_pw, IWebDriver sys_driver)
        {

            sys_driver.Url = "https://auth.kimpo.ac.kr/html/login.php";
            IWebElement sys_id = sys_driver.FindElement(By.Name("id"));
            sys_id.SendKeys(input_id);
            sys_driver.FindElement(By.Name("pw")).SendKeys(input_pw);
            sys_driver.FindElement(By.XPath("//*[@id='wrapper_login']/form/div/table[3]/tbody/tr[1]/td[3]/img")).Click();
            sys_driver.Url = "http://kpis4.kimpo.ac.kr:8000/hosting/group/kpis/html/kpis_main.php";
            Temp = sys_driver.FindElement(By.XPath("/html/body/div/table/tbody/tr/td/table/tbody/tr/td/div/div/div/span/b")).Text;
            Thread.Sleep(1000);
            sys_driver.FindElement(By.LinkText("정보광장")).Click();
            
            ///html/frameset/frameset/frame/html/body/table/tbody/tr/td/table/tbody/tr/td[1]/table/tbody/tr/td[1]/table/tbody/tr/td[2]/span
            //Temp = sys_driver.FindElement(By.XPath("/html/body/div/table/tbody/tr/td/table/tbody/tr/td/div/div/div/span/b")).Text;

            Student.Name = Temp.Substring(0, 3);
            Student.Service = "종합정보시스템";
            
            Student.Date = Date;

            if (checkBox1.Checked == true) Student.status = 1;
            else Student.status = 0;

            db.INSERT_TABLE(Student.input_id, Student.Name, Student.Service, Student.Date, Student.status);



        }

        public void Login_Check(string input_id, string input_pw, IWebDriver check_driver)
        {
            check_driver.Url = "https://check.kimpo.ac.kr";
            IWebElement check_id = check_driver.FindElement(By.XPath("//*[@id='username']"));
            check_id.SendKeys(input_id);
            check_driver.FindElement(By.XPath("//*[@id='passwd']")).SendKeys(input_pw);
            check_driver.FindElement(By.XPath("//*[@id='loginform']/button")).Click();
            Thread.Sleep(2000);
            Temp = check_driver.FindElement(By.XPath("/html/body/div[1]/div[2]/section[1]/div/ul/li[1]")).Text;
            Student.Name = Temp.Substring(5, 3);


            Student.Date = Date;
            Student.Service = "출석체크";

            if (checkBox1.Checked == true) Student.status = 1;
            else Student.status = 0;

            db.INSERT_TABLE(Student.input_id, Student.Name, Student.Service, Student.Date, Student.status);
        }

        public void Login_Ncs(string input_id, string input_pw, IWebDriver ncs_driver)
        {

            ncs_driver.Url = "https://ncs.kimpo.ac.kr/login";
            IWebElement ncs_id = ncs_driver.FindElement(By.XPath("//*[@id='loginId']"));
            ncs_id.SendKeys(input_id);
            ncs_driver.FindElement(By.XPath("//*[@id='password']")).SendKeys(input_pw);

            ncs_driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div/label[2]")).Click();
            ncs_driver.FindElement(By.XPath("//*[@id='loginBtn']")).Click();
            ///html/body/nav/div[2]/ul[2]/li/a/span
            Temp = ncs_driver.FindElement(By.XPath("html/body/nav/div[2]/ul[2]/li/a/span")).Text;
            Student.Name = Temp.Substring(0, 3);

            //MessageBox.Show(Name);

            Student.Date = Date;
            Student.Service = "NCS";


            if (checkBox1.Checked == true) Student.status = 1;
            else Student.status = 0;

            db.INSERT_TABLE(Student.input_id, Student.Name, Student.Service, Student.Date, Student.status);
            


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

        
        
        
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            input_id = textBox1.Text;
            input_pw = textBox2.Text;

            if(textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show(new Form { TopMost = true }, "아이디 또는 비밀번호를 제대로 입력해주세요.");
                return;
            }  else
            {
                Student.input_id = input_id;
            }

            textBox1.Text = "";
            textBox2.Text = "";

            int Now_Hour = int.Parse(DateTime.Now.ToString("hh"));
            
            var ChromeService = ChromeDriverService.CreateDefaultService();
            ChromeService.HideCommandPromptWindow = true;

            var IEService = InternetExplorerDriverService.CreateDefaultService();            
            IEService.HideCommandPromptWindow = true;

            var IEoptions = new InternetExplorerOptions();
            IEoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;


            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    IWebDriver sys_driver = new InternetExplorerDriver(IEService, IEoptions);
                    Login_Sys(input_id, input_pw, sys_driver);
                    
                    break;
                case 1:
                    
                    IWebDriver check_driver = new ChromeDriver(ChromeService);
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
                            MessageBox.Show(new Form { TopMost = true }, "출석체크가 가능한 시간이 아닙니다.");
                        }

                    }
                    
                    break;
                case 2:
                    
                    IWebDriver ncs_driver = new ChromeDriver(ChromeService);
                    Login_Ncs(input_id, input_pw, ncs_driver);
                                        
                    break;
                default:
                    MessageBox.Show(new Form { TopMost = true }, "항목을 선택해주세요...!");
                    break;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           CS.Log Login_Log = new CS.Log();
           Login_Log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CS.Data Login_Data = new CS.Data();
            Login_Data.ShowDialog();

            if (Login_Data.DialogResult == DialogResult.OK)
            {
                textBox1.Text = Login_Data.temp;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CS.Classroom cr = new CS.Classroom();
            cr.Show();

        }
    }
}

