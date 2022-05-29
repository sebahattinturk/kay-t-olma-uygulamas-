using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kullanıcıgirişiuygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataSet set = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad, sifre;
            ad = textBox1.Text;
            sifre = textBox2.Text;
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sebokullanıcıgirişi.mdb");
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select *From sebokullanıcı Where kuladı='" + textBox1.Text + "'and şifre='" + textBox2.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                label4.Visible = true;
                label3.Visible = false;
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sebokullanıcıgirişi1.mdb");
                da = new OleDbDataAdapter("Select *From sebokullanıcı1", baglanti);
                string sorgu = "Insert into sebokullanıcı1(isim,soyad,email) values (@isim,@soyad,@email)";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@isim", frm2.label3.Text);
                komut.Parameters.AddWithValue("@soyad", frm2.label5.Text);
                komut.Parameters.AddWithValue("@email", frm2.label7.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                label3.Visible = true;
                label4.Visible = false;
                for (int i = 1; i < 150; i++)
                {
                    this.Left += 3;
                    this.Left -= 3;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sebokullanıcıgirişi.mdb");
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From sebokullanıcı", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            Form5 frm5 = new Form5();
            frm5.dataGridView1.DataSource = tablo;
            baglanti.Close();
            if (checkBox1.Checked == true)
            {
                frm5.Show();
            }
            if (checkBox1.Checked == false)
            {
                MessageBox.Show("Sadece Yöneticiler Girebilir!", "Sistem");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "sebo123")
            {
                checkBox1.Visible = true;
            }
            else
            {
                MessageBox.Show("Yönetici Kodu Yanlış!", "Sistem");
                checkBox1.Visible = false;
                checkBox1.Checked = false;
            }
        }
    }
}
