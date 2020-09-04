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
    public partial class Frmdoktorpanel : Form
    {
        public Frmdoktorpanel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Frmdoktorpanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_doktorlar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand combo = new SqlCommand("select*from tbl_branslar", bgl.baglanti());
            SqlDataReader dr4 = combo.ExecuteReader();
            while (dr4.Read())
            {
                comboBox1.Items.Add(dr4[1]);
            }
            bgl.baglanti().Close();

        }
        string sabittc;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            sabittc= dataGridView1.Rows[secim].Cells[4].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into tbl_doktorlar (doktorad,doktorsoyad,doktorbrans,doktortc,doktorsifre)values(@p1,@p2,@p3,@p4,@p5)",bgl.baglanti()) ;
            ekle.Parameters.AddWithValue("@p1",textBox1.Text);
            ekle.Parameters.AddWithValue("@p2", textBox2.Text);
            ekle.Parameters.AddWithValue("@p3", comboBox1.Text);
            ekle.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            ekle.Parameters.AddWithValue("@p5", textBox3.Text);
            ekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Doktor Kaydı Başarıyla Yapılmıştır");

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from tbl_doktorlar where doktortc=@p1",bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update tbl_doktorlar set doktorad=@p1,doktorsoyad=@p2,doktorbrans=@p3,doktortc=@p4,doktorsifre=@p5 where doktortc=@p6",bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1",textBox1.Text);
            guncelle.Parameters.AddWithValue("@p2",textBox2.Text);
            guncelle.Parameters.AddWithValue("@p3",comboBox1.Text);
            guncelle.Parameters.AddWithValue("@p4",maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@p5",textBox3.Text);
            guncelle.Parameters.AddWithValue("@p6",sabittc);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
