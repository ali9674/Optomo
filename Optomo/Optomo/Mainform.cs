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
using System.IO;
using System.Net.NetworkInformation;

namespace Optomo
{





    public partial class Mainmenu : Form
    {
        public Makina main_machine;
        public static Doktor currenct_docor;
        public string image_path;
       
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
            cekim.Visible = false;
            Test.Visible = false;
            Hasta.Visible = true;
          //  Test.Hide();
       //  Hasta.Show();
            //cekim.Hide();
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

            cekim.Visible = false; 
            Test.Visible = true;
            Hasta.Visible = false;
            //Test.Show();
             //   Hasta.Hide();
             //  cekim.Hide();

        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            //label4.BackColor = Color.FromArgb(79, 116, 146);   mavi !!


        }

        private void label3_Click(object sender, EventArgs e)
        {
            Reset_colour();
            label3.BackColor = Color.FromArgb(255, 128, 0);
            cekim.Visible = true;//cekim.Show(); 
            Test.Visible = false;//Test.Hide();
            Hasta.Visible = false;//Hasta.Hide();


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
            timer1.Start();
             main_machine = new Makina();
            
            
            
            

        }

        private void yuvarlakbuton1_Click(object sender, EventArgs e)
        {
             string connectionString = "Server=PC\\ALı;Database=Optomo;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM hastalar where id = @id and doktor_id=@did";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                { // ARAMA BUTONU 
                    cmd.Parameters.AddWithValue("@id", int.Parse(ovalTextBox2.Text));
                    cmd.Parameters.AddWithValue("@did", int.Parse(currenct_docor.Get_id.ToString()));

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if( !reader.HasRows) {       // kayıt varmı kopntrol et 
                            MessageBox.Show("kayıt bulunamadı");
                            return;
                        }

                        while (reader.Read()) {
                            textBox1.Text = reader["id"].ToString();
                            textBox2.Text = reader["name"].ToString();
                            textBox3.Text = reader["surname"].ToString();
                            textBox4.Text = reader["sex"].ToString();
                            textBox5.Text = reader["bdate"].ToString();
                            textBox6.Text = reader["doktor_id"].ToString();
                            // for images
                            byte[] imageBytes = (byte[])reader["image"];
                            Image image;
                            MemoryStream ms = new MemoryStream(imageBytes);
                             pictureBox6.Image = Image.FromStream(ms);
                            

                        }

                        reader.Close();
                    }//TRY END

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }




            }

        }
        public void info_clear()
        {
            pictureBox6.Image = null;
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            info_clear(); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            info_clear();
            button9.Show();
            button10.Hide();
            button11.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            info_clear();
            button9.Hide();
            button10.Show();
            button11.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            info_clear();      
            button9.Hide();
            button10.Hide();
            button11.Show();
            panel3.Show();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    image_path = openFileDialog.FileName;
                    pictureBox6.Load(image_path);
                }


            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=PC\\ALı;Database=Optomo;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO hastalar (id, name, surname,sex,bdate,doktor_id,image) VALUES (@id, @name,@surname,@sex,@bdate,@doktor_id,@image)";
                byte [] image_byte = System.IO.File.ReadAllBytes(image_path);

                SqlCommand insert_cmd = new SqlCommand(insertQuery, connection);
                insert_cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                insert_cmd.Parameters.AddWithValue("@name", textBox2.Text);
                insert_cmd.Parameters.AddWithValue("@surname", textBox3.Text);
                insert_cmd.Parameters.AddWithValue("@sex", textBox4.Text);
                insert_cmd.Parameters.AddWithValue("@bdate", DateTime.Parse(textBox5.Text));
                insert_cmd.Parameters.AddWithValue("@doktor_id",int.Parse(textBox6.Text));
                insert_cmd.Parameters.AddWithValue("@image", image_byte);
                insert_cmd.ExecuteNonQuery();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=PC\\ALı;Database=Optomo;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM hastalar where id = @id";
                    using(SqlCommand delete = new SqlCommand(query,connection))
                    {
                        connection.Open();
                        delete.Parameters.AddWithValue("@id",int.Parse(ovalTextBox2.Text));

                        int deleted_rows = delete.ExecuteNonQuery();

                        MessageBox.Show($"{deleted_rows} Kayıt Başarıyla Silindi");
                           if (deleted_rows <= 0)
                            MessageBox.Show("Kayıt Bulunamadı");

                        info_clear();
                    }


                }
                catch( Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=PC\\ALı;Database=Optomo;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE hastalar SET name = @name, surname = @surname, sex = @sex, bdate = @bdate, doktor_id = @doktor_id WHERE id = @id";

                using (SqlCommand update_cmd = new SqlCommand(updateQuery, connection))
                {
                    update_cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    update_cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    update_cmd.Parameters.AddWithValue("@surname", textBox3.Text);
                    update_cmd.Parameters.AddWithValue("@sex", textBox4.Text);
                    update_cmd.Parameters.AddWithValue("@bdate", DateTime.Parse(textBox5.Text));
                    update_cmd.Parameters.AddWithValue("@doktor_id", int.Parse(textBox6.Text));

                    update_cmd.ExecuteNonQuery();   

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string connectionString = "Server=PC\\ALı;Database=Optomo;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM hastalar where doktor_id = @did";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@did", int.Parse(currenct_docor.Get_id.ToString()));
                        SqlDataReader reader = cmd.ExecuteReader();
                        int i = 0;
                        listView1.Items.Clear();
                        while (reader.Read())
                        {
                            if (i == 3)
                                break;
                            listView1.Items.Add(reader["id"].ToString());
                            listView1.Items[i].SubItems.Add(reader["name"].ToString());
                            listView1.Items[i].SubItems.Add(reader["surname"].ToString());
                            i++;
                        }


                    }
                }
                if (!(currenct_docor is null))
                    main_machine.Controlled_by = currenct_docor;

            }//end try
            catch 
            {
               // MessageBox.Show("Geçersiz kullanıcı adı ve şifre !!");
                //timer1.Stop();  
            }
           


        }



        private void label4_Click_1(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show(currenct_docor.Get_id.ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {
           
        }
    }
    public class Doktor
    {
        public string KullanıcıAdı;
        string Sifre;
        private long DoktorNo;
        public string Ad;
        public string Soyad;

        public long Get_id
        {
            get { return DoktorNo; }
            set { DoktorNo = value; }
        }

        public Doktor(string id,string psw ,long doktor_id,string ad,string soyad)
        {
            KullanıcıAdı = id;Sifre = psw;DoktorNo = doktor_id;Ad = ad;Soyad = soyad;   

        }

        public void Hasta_Goster(int doktor_id)
        {
            //metot
        }


    }// end of the Doctor class

    public class Makina// makine bilgieri
    {
        public bool kapapk_durumu;
        public bool xray_durumu;
        public double Platform_konum;
        public int tarama_acısı;
        public int projeksiyonNo;
        public Doktor Controlled_by;
    }
    public class Test
    {
        public Makina current_machine;// bağlanacak cihaz
        public Test(Makina running_machine)
        {
            current_machine = running_machine;
        }
        public bool X_Ray_test()
        {
            // FONKSİYON GÖVDESİ !!
            if (true) //test başarıyla geçildiyse true döndür
                return true;
            else
                return false;
        }
        public bool Platform_motion_test()
        {
            // FONKSİYON GÖVDESİ !!
            if (true) //test başarıyla geçildiyse true döndür
                return true;
            else
                return false;
        }
        public bool kapak_Test()
        {
            // FONKSİYON GÖVDESİ !!
            if (true) //test başarıyla geçildiyse true döndür
                return true;
            else
                return false;
        }
        public bool acısal_haraket_testi()
        {
            // FONKSİYON GÖVDESİ !!
            if (true) //test başarıyla geçildiyse true döndür
                return true;
            else
                return false;
        }

    }

}



