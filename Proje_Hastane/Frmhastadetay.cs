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
    public partial class Frmhastadetay : Form
    {
        public Frmhastadetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();
        
        private void Frmhastadetay_Load(object sender, EventArgs e)
        {
            label2.Text = tc;
            //AD SOYAD ÇEKME
            SqlCommand komut = new SqlCommand("select hastaad,hastasoyad from tbl_hastalar where hastatc=@p1",bgl.baglanti());
           komut.Parameters.AddWithValue("@p1", label2.Text);
           SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                label4.Text=dr[0]+" "+dr[1];

            }
            bgl.baglanti().Close();
            //RANDEVU GEÇMİŞİ
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_randevular where hastatc='"+label2.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //BRANŞLARI ÇEKME
            SqlCommand komut2 = new SqlCommand("select bransad from tbl_branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]);
            }


            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read())
            {
                comboBox2.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_randevular where randevubrans='"+comboBox1.Text+"' and randevudoktor='"+comboBox2.Text+"' and randevudurum=0",bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frmbilgiduzenle fr = new Frmbilgiduzenle();
            fr.tcno = label2.Text;
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand randevual = new SqlCommand("update tbl_randevular set randevudurum=1,hastatc=@p1,hastasikayet=@p2 where randevuid=@p3",bgl.baglanti());
            randevual.Parameters.AddWithValue("@p1",label2.Text);
            randevual.Parameters.AddWithValue("@p2", richTextBox1.Text);
            randevual.Parameters.AddWithValue("@p3", textBox1.Text);
            randevual.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı");



        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[secim].Cells[0].Value.ToString();
        }
    }
}
