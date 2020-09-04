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
    public partial class FrmSekretergiris : Form
    {
        public FrmSekretergiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmSekretergiris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select *from tbl_sekreterler where sekretertc=@p1 and sekretersifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr2 = komut.ExecuteReader();
            if(dr2.Read())
            {
                frmsekreterdetay fr = new frmsekreterdetay();
                fr.tcnumara = maskedTextBox1.Text;
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Yanlış Şifre Ya Da Kullanıcı Adı");
                    }
            bgl.baglanti().Close();

        }
    }
}
