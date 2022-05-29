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
    public partial class Form6 : Form
    {
        public Form6()
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
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sebokullanıcıgirişi1.mdb");
            da = new OleDbDataAdapter("Select *From sebokullanıcı1", baglanti);
            string sorgu = "Insert into sebokullanıcı1(isim,soyad,email) values (@isim,@soyad,@email)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@isim", textBox1.Text);
            komut.Parameters.AddWithValue("@soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@email", textBox3.Text);
            Form2 frm2 = new Form2();
            frm2.label3.Text = textBox1.Text;
            frm2.label5.Text = textBox2.Text;
            frm2.label7.Text = textBox3.Text;
            frm2.Show();
            this.Close();
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
