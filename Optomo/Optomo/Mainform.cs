using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Optomo
{
    public partial class Mainmenu : Form
    {
        public Mainmenu()
        {
            InitializeComponent();

        }

        private void Mainform_Load(object sender, EventArgs e)
        {
           // label7.Text = DateTime.Now.ToString("dd:MM:yyyy");  tarih biçimi
        }

        public class yuvarlakbuton : Button
        {

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                int radius = 20; // Oval köşe yarıçapı
                GraphicsPath gp = new GraphicsPath();

                // Sol üst köşe
                gp.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);
                // Sağ üst köşe
                gp.AddArc(new Rectangle(Width - radius * 2, 0, radius * 2, radius * 2), 270, 90);
                // Sağ alt köşe
                gp.AddArc(new Rectangle(Width - radius * 2, Height - radius * 2, radius * 2, radius * 2), 0, 90);
                // Sol alt köşe ve kalan kısmı
                gp.AddArc(new Rectangle(0, Height - radius * 2, radius * 2, radius * 2), 90, 90);
                gp.CloseFigure();

                this.Region = new Region(gp);


            }
        }
        public class OvalTextBox : TextBox
        {


            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                int radius = 20; // Oval köşe yarıçapı
                GraphicsPath gp = new GraphicsPath();
                
                // Sol üst köşe
                gp.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);
                // Sağ üst köşe
                gp.AddArc(new Rectangle(Width - radius * 2, 0, radius * 2, radius * 2), 270, 90);
                // Sağ alt köşe
                gp.AddArc(new Rectangle(Width - radius * 2, Height - radius * 2, radius * 2, radius * 2), 0, 90);
                // Sol alt köşe ve kalan kısmı
                gp.AddArc(new Rectangle(0, Height - radius * 2, radius * 2, radius * 2), 90, 90);
                gp.CloseFigure();

                this.Region = new Region(gp);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {            
           

        }

        private void Hasta_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Reset_colour();
            label1.BackColor = Color.FromArgb(255, 128, 0);
            Test.Hide();
            Hasta.Show();

        }
        public void Reset_colour()
        {            // the color when it is not selected
            label1.BackColor = Color.FromArgb(79, 116, 146);
            label2.BackColor = Color.FromArgb(79, 116, 146);
            label3.BackColor = Color.FromArgb(79, 116, 146);
            label4.BackColor = Color.FromArgb(79, 116, 146);
            label5.BackColor = Color.FromArgb(79, 116, 146);

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Reset_colour();
            label2.BackColor = Color.FromArgb(255, 128, 0);
            Test.Show();
            Hasta.Hide();
                      
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            //label4.BackColor = Color.FromArgb(79, 116, 146);   mavi !!
           

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Reset_colour();
            label3.BackColor = Color.FromArgb(255, 128, 0);


        }

        private void label4_Click(object sender, EventArgs e)
        {
            Reset_colour();
            label4.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Reset_colour();
            label5.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void Mainmenu_Load(object sender, EventArgs e)
        {
            

        }

        private void yuvarlakbuton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Text);
        }
    }
}
