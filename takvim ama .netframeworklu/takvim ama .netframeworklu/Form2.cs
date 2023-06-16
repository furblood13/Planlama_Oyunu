using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace takvim_ama.netframeworklu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            

            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            string baslik = "", tarih = "",metin="";
            metin = textBox1.Text;
            baslik = textBox2.Text;
            tarih = (dateTimePicker1.Value.ToString("yyyy MM dd HH:mm"));
            string[] bilgiler = { baslik, tarih,metin };
            ListViewItem list=new ListViewItem(bilgiler);
            if (baslik != ""&& metin!="")
            {
                listView1.Items.Add(list);
               

            }
            else
            {
                MessageBox.Show("Lutfen bos alanlari doldurunuz");
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            listView1.Columns.Add("Baslik", 100);
            listView1.Columns.Add("Tarih", 100);
            listView1.Columns.Add("Icerik", 30);

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                textBox2.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;


            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[0].Text= textBox2.Text;
                listView1.SelectedItems[0].SubItems[2].Text = textBox1.Text;


            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        SoundPlayer player = new SoundPlayer();
        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime currentTime = DateTime.Now;
            DateTime alarmTime = dateTimePicker1.Value;
            if(currentTime.Day==alarmTime.Day&& currentTime.Hour==alarmTime.Hour&& currentTime.Minute == alarmTime.Minute)
            {
                timer1.Stop();
                button3.BackColor= Color.Red;
                button3.Enabled = true;
                player.SoundLocation = @"D:\denemee\alarm.wav";
                player.PlayLooping(); 
                MessageBox.Show(textBox2.Text+ " icin zaman geldi");
                
                
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.Stop();
            button3.BackColor = Color.White;
        }
    }
}
