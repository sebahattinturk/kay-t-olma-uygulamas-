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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataSet set = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete *From sebokullanıcı Where kuladı=@ad and şifre=@şifre";
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sebokullanıcıgirişi.mdb");
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@şifre", textBox2.Text);
            MessageBox.Show("Girdiğiniz Bilgiler Uyuşuyor İse Kullanıcı Silindi!", "Sistem");
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
