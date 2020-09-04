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
    public partial class FrmDoktorgiris : Form
    {
        public FrmDoktorgiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand giris = new SqlCommand("select*from tbl_doktorlar where doktortc=@p1 and doktorsifre=@p2",bgl.baglanti());
            giris.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            giris.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.doktortc = maskedTextBox1.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Ya Da Şifre");
            }
        }

        private void FrmDoktorgiris_Load(object sender, EventArgs e)
        {

        }
    }
}
