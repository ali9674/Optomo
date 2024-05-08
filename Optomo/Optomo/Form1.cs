using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optomo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar  = true;
                checkBox1.Text = "Gizle";
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            panel2.Hide();  
            panel1.Show();  
            panel1.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel2.BringToFront();

            panel1.Hide();
        }
    }
}
