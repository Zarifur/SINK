using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace assaginment_task
{
    public partial class Seller_info : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public SqlConnection conn;
        Log_In login;
        string userName;
        int id;
        public Seller_info(Log_In login, string userName, int id)
        {
            InitializeComponent();
            this.login = login;
            this.userName = userName;
            this.id = id;
            label9.Text = userName;
            string query = "SELECT * From [user] where userName=@UserName and access=@access";
            conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@access", "Seller");
            if (login.conn.State == ConnectionState.Closed)
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox1.Text = dr.GetValue(1).ToString();
                        textBox2.Text = dr.GetValue(3).ToString();
                        textBox3.Text = dr.GetValue(6).ToString();
                        textBox4.Text = dr.GetValue(2).ToString();
                        label11.Text = dr.GetValue(5).ToString();
                        try
                        {
                            Byte[] pic;
                            pic = (byte[])dr.GetValue(7);
                            MemoryStream ms = new MemoryStream(pic);
                            pictureBox1.Image = Image.FromStream(ms);
                            pictureBox3.Image = Image.FromStream(ms);
                        }
                        catch (Exception e)
                        {
                            pictureBox3.Image = Properties.Resources.pngwing_com__1_;
                            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        }

                    }
                }
                conn.Close();
            }
            

        }
 
        private byte[] SavedPhoto(Image picture)
        {
            MemoryStream ms = new MemoryStream();
            picture.Save(ms, picture.RawFormat);
            return ms.GetBuffer();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Seller seller = new Seller(login, userName, id);
            seller.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string quary = "update [user] set userName=@UserName,pass=@Password,email=@email,Mobile=@mobile,picture=@img where userName=@UserName";
            SqlCommand cmd = new SqlCommand(quary, conn);
            cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@mobile", textBox3.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@img", SavedPhoto(pictureBox1.Image));
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully ! ");

            }
            else
            {
                MessageBox.Show("Data not Updated ! ");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choce youre picture";
            OFD.Filter = "Image File(*.png;*.jpg) |*.png;*.jpg";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(OFD.FileName);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
