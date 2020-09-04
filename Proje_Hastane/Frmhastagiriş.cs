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

namespace Proje_Hastane
{
    public partial class Frmhastagiriş : Form
    {
        public Frmhastagiriş()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frmhastakayıt fr = new Frmhastakayıt();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select*from tbl_hastalar where hastatc=@p1 and hastasifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                
                Frmhastadetay fr = new Frmhastadetay();
                fr.tc = maskedTextBox1.Text;


                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Tc ya da şifre");
            }
            bgl.baglanti().Close();

        }
    }
}
