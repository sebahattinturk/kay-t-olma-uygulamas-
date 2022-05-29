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
    public partial class Form3 : Form
    {
        public Form3()
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
            try
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sebokullanıcıgirişi.mdb");
                da = new OleDbDataAdapter("Select *From sebokullanıcı", baglanti);
                string sorgu = "Insert into sebokullanıcı(kuladı,şifre) values (@ad,@sifre)";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", textBox1.Text);
                komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                label4.Visible = true;
                label3.Visible = false;
            }
            catch
            {
                label3.Visible = true;
                label4.Visible = false;
            }
        }
    }
}
