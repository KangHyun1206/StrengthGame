using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace strengthGame
{
    public partial class Login : Form
    {
        int pwd = 1234;
        Form1 Form1 = new Form1();
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(pwdBox.Text == "1234")
            {
                Form1.UserId = idBox.Text; //아이디명 > Form1 변수(UserId)로 전송
                MessageBox.Show("로그인 성공!");
                Form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("로그인 실패! (힌트 : 1234)");
            }
        }
    }
}
