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
    public partial class Frmhastakayıt : Form
    {
        public Frmhastakayıt()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_hastalar (hastaad,hastasoyad,hastatc,hastatelefon,hastasifre,hastacinsiyet)values(@a1,@a2,@a3,@a4,@a5,@a6)",bgl.baglanti());

            komut.Parameters.AddWithValue("@a1", textBox1.Text);
            komut.Parameters.AddWithValue("@a2", textBox2.Text);
            komut.Parameters.AddWithValue("@a3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@a4", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@a5", textBox3.Text);
            komut.Parameters.AddWithValue("@a6", comboBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz: " + textBox3.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
