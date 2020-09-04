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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmBrans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }


        string sabitid;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            sabitid = dataGridView1.Rows[secim].Cells[0].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into tbl_branslar (bransid,bransad)values(@p1,@p2)",bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1", textBox1.Text);
            ekle.Parameters.AddWithValue("@p2", textBox2.Text);
            ekle.ExecuteNonQuery();
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from tbl_branslar where bransid=@p1",bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", textBox1.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update tbl_branslar set bransid=@p1,bransad=@p2 where bransid=@p3",bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            guncelle.Parameters.AddWithValue("@p2", textBox2.Text);
            guncelle.Parameters.AddWithValue("@p3", sabitid);
            guncelle.ExecuteNonQuery();


            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
