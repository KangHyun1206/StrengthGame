using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJangGoo05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void gamestart_Click(object sender, EventArgs e)
        {
            //panel1.Visible = true;
            //panel2.Visible = false;
            //gameItr.Visible = false;

            
            pictureBox1.Image = Properties.Resources.s3
                ;

        }

        private void gamemethod_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            gameItr.Visible = true;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            gameItr.Visible = false;
        }

        private void Mjb_pic_Click(object sender, EventArgs e)
        {
            


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
    
}
