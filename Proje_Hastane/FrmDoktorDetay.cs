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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        public string doktortc;

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            label2.Text = doktortc;
            SqlCommand adsoyad = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktortc='"+doktortc+"'",bgl.baglanti());
            SqlDataReader dr = adsoyad.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_randevular where randevudoktor='"+label4.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDüzenle fr = new FrmDoktorBilgiDüzenle();
            fr.tcno = label2.Text;
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
        }
    }
}
