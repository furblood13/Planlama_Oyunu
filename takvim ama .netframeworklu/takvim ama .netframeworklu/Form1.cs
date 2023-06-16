using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace takvim_ama.netframeworklu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=loginekrani;Integrated Security=True");


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lutfen bos alanlari doldurunuz");

            }
            else
            {



                conn.Open();
                string user;
                user = textBox1.Text;
                string password;
                password = textBox2.Text;
                SqlCommand komut = new SqlCommand("select * from Deneme where kullanici='" + user + "' and sifre='" + password + "'", conn);
                SqlDataReader oku = komut.ExecuteReader();
                
                if (oku.Read())
                {
                    MessageBox.Show("Sisteme Hosgeldin  " + user + " ");
                    Form2 gecis = new Form2();
                    gecis.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatali kullanici adi veya sifre");
                }
                conn.Close();
                   


            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            textBox3.Text= textBox1.Text;
            textBox2.Text= textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            string user;
            user = textBox3.Text;
            string password;
            password = textBox4.Text;
            string isim= textBox5.Text;
            string soyad= textBox6.Text;
            string tc= textBox7.Text;
            string telno= textBox8.Text;
            string mail= textBox9.Text;
            string adres= textBox10.Text;
            SqlCommand komut = new SqlCommand("select * from Deneme where kullanici='" + user + "'", conn);
            SqlDataReader oku = komut.ExecuteReader();
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text =="" || textBox7.Text == "" || textBox8.Text == ""
                || textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Lutfen tum alanlari doldurunuz");
                conn.Close();
            }
            else
            {
                if (oku.Read())
                {
                    MessageBox.Show("Bu kullanici adi zaten alinmis baska kullanici adi secin");
                }
                else
                {
                    oku.Close();
                    SqlCommand ekle = new SqlCommand("insert into Deneme (kullanici,sifre,Ad,Soyad,tc,telno,mail,adres) values " +
                        "('" + user + "','" + password + "','" + isim + "','" + soyad + "','" + tc + "','" + telno + "','" + mail + "','" + adres + "')", conn);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayit oldunuz,\n Giriş ekranına dönmek için Tamam'a basın");
                    SqlCommand ekle2 = new SqlCommand("insert into tarih (kullaniciT) values('" + user + "')", conn);
                    ekle2.ExecuteNonQuery();
                    tabControl1.SelectedTab = tabPage1;
                }

                conn.Close();
            }
        }
    }
}
