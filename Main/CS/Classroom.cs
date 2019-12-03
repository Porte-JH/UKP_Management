using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Main.CS
{
    public partial class Classroom : MetroForm
    {
        string dy = DateTime.Now.DayOfWeek.ToString();

        string num = "";

        int time = int.Parse(DateTime.Now.ToString("hh"));

        public Classroom()
        {
            InitializeComponent();
        }

        private void Classroom_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            num = metroTextBox1.Text;
            if (dy == "Tuesday")
            {
                if (num == "201")
                {
                    if (time >= 9 && time <= 12)
                    {
                        label1.Text = "사용중, 응용SW프로젝트 - 김재생";
                    }
                    else if (time >= 1 && time <= 3)
                    {
                        label1.Text = "사용중, 프로그래밍실습 - 김재생";
                    }
                    else if (time >= 4 && time <= 6)
                    {
                        label1.Text = "사용중, 컴퓨터통신 - 이연수";
                    }
                    else
                    {
                        label1.Text = "미사용중";
                    }
                }
                else if (num == "202")
                {
                    if (time >= 9 && time <= 12)
                    {
                        label1.Text = "사용중, DB어드민 - 김인범";
                    }
                    else if (time >= 1 && time <= 3)
                    {
                        label1.Text = "사용중, DB어드민 - 김인범";
                    }
                    else
                    {
                        label1.Text = "미사용중";
                    }
                }
                else if (num == "203")
                {
                    if (time >= 9 && time <= 12)
                    {
                        label1.Text = "사용중, 웹프로그래밍 실무 - 장계섭";
                    }
                    else if (time >= 1 && time <= 3)
                    {
                        label1.Text = "사용중, 캡스톤디자인 - 이형일";
                    }
                    else if (time >= 4 && time <= 6)
                    {
                        label1.Text = "사용중, 웹프로그래밍 실무 - 이형일";
                    }
                    else
                    {
                        label1.Text = "미사용중";
                    }
                }
            }
            else if (dy == "Wednesday")
            {
                if (num == "201")
                {
                    if (time >= 9 && time <= 12)
                    {
                        label1.Text = "사용중, 시스템분석설계 - 김재생";
                    }
                    else if (time >= 1 && time <= 3)
                    {
                        label1.Text = "사용중, 시스템분석설계 - 김새생";
                    }
                    else if (time >= 4 && time <= 6)
                    {
                        label1.Text = "사용중, 컴퓨터그래픽실습1 - 이호선";
                    }
                    else
                    {
                        label1.Text = "미사용중";
                    }
                }
                else if (num == "202")
                {
                    if (time >= 9 && time <= 12)
                    {
                        label1.Text = "사용중, loT프로그래밍실무 - 이종일";
                    }
                    else if (time >= 1 && time <= 3)
                    {
                        label1.Text = "사용중, 캡스톤디자인 - 이형일";
                    }
                    else
                    {
                        label1.Text = "미사용중.";
                    }
                }
                else if(num == "203")
                {
                    if(time >= 9 && time <= 12)
                    {
                        label1.Text = "사용중, 모바일프로그래밍실무 - 이형일";
                    }
                    else if(time >= 1 && time <= 3)
                    {
                        label1.Text = "사용중, 윈도우즈프로그래밍실무 - 이종일";
                    }
                    else if (time >= 4 && time <= 6)
                    {
                        label1.Text = "사용중, loT프로그래밍실무 - 이종일";
                    }
                    else
                    {
                        label1.Text = "미사용중.";
                    }
                }
            }
            else if(dy == "Thursday")
            {
                if (num == "201")
                {
                    if (time >= 9 && time <= 12)
                    {
                        label1.Text = "사용중, UNIX어드민 - 이정식";
                    }
                    else if (time >= 1 && time <= 3)
                    {
                        label1.Text = "사용중, UNIX기초 - 이정식";
                    }
                    else if (time >= 4 && time <= 6)
                    {
                        label1.Text = "사용중, 네트워크1 - 이정식";
                    }
                    else
                    {
                        label1.Text = "미사용중";
                    }
                }
                else if(num == "202")
                {
                    if (time >= 9 && time <= 11)
                    {
                        label1.Text = "사용중, 정보활용능력 - 이갑수";
                    }
                    else if (time >= 1 && time <= 3)
                    {
                        label1.Text = "사용중, 데이터베이스실습 - 김인범";
                    }
                    else if (time >= 4 && time <= 6)
                    {
                        label1.Text = "사용중, 자료구조 - 김영욱";
                    }
                    else
                    {
                        label1.Text = "미사용중";
                    }
                }
                else if(num == "203")
                {
                    if (time >= 9 && time <= 12)
                    {
                        label1.Text = "사용중, 객체지향프로그래밍실습 - 김정숙";
                    }
                    else if (time >= 1 && time <= 2)
                    {
                        label1.Text = "사용중, 정보활용능력 - 이갑수";
                    }
                    else
                    {
                        label1.Text = "미사용중";
                    }
                }
            } else
            {
                label1.Text = "현재 요일이 화, 수, 목이 아닙니다!";
            }
        }
    }
}
