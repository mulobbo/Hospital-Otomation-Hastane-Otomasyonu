using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcno;
        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            
            maskedTextBox1.Text = tcno;
            SqlCommand komut = new SqlCommand("Select *from tbl_doktorlar where doktortc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",tcno);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = Convert.ToString(dr[1]);
                textBox2.Text = Convert.ToString(dr[2]);
                comboBox1.Text = Convert.ToString(dr[3]);
                textBox3.Text = Convert.ToString(dr[5]);



            }
            bgl.baglanti().Close();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            string sabittc = maskedTextBox1.Text;
            SqlCommand guncelle = new SqlCommand("update tbl_doktorlar set doktorad=@p1,doktorsoyad=@p2,doktorbrans=@p3,doktortc=@p4,doktorsifre=@p5 where doktortc=@p6",bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1",textBox1.Text);
            guncelle.Parameters.AddWithValue("@p2",textBox2.Text);		

            guncelle.Parameters.AddWithValue("@p3",textBox3.Text);
            guncelle.Parameters.AddWithValue("@p4",maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@p5",textBox3.Text);
            guncelle.Parameters.AddWithValue("@p6",sabittc);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();

        }
    }
}
