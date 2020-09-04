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
    public partial class frmsekreterdetay : Form
    {
        public frmsekreterdetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcnumara;

        private void frmsekreterdetay_Load(object sender, EventArgs e)
        {
            label2.Text = tcnumara;
            SqlCommand komut = new SqlCommand("select sekreteradsoyad from tbl_sekreterler where sekretertc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",label2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                label4.Text =dr[0].ToString();
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select*from tbl_doktorlar",bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            timer1.Start();

            SqlCommand branslar = new SqlCommand("select bransad from tbl_branslar",bgl.baglanti());
            SqlDataReader drbrans = branslar.ExecuteReader();
            while (drbrans.Read())
            {
                comboBox1.Items.Add(drbrans[0]);
            }
            bgl.baglanti().Close();

            



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frmdoktorpanel fr = new Frmdoktorpanel();
            fr.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBrans fr = new FrmBrans();
            fr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmrandevulistesi fr = new frmrandevulistesi();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string durum;
            if (checkBox1.Checked == true)
            {
                durum = "true";
            }
            else
            {
                durum = "false";
            }
            SqlCommand kaydet = new SqlCommand("insert into tbl_randevular (randevuid,randevutarih,randevusaat,randevubrans,randevudoktor,randevudurum,hastatc)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)",bgl.baglanti());
            kaydet.Parameters.AddWithValue("@p1",textBox1.Text);
            kaydet.Parameters.AddWithValue("@p2",maskedTextBox1.Text);
            kaydet.Parameters.AddWithValue("@p3",maskedTextBox2.Text);
            kaydet.Parameters.AddWithValue("@p4",comboBox1.Text);
            kaydet.Parameters.AddWithValue("@p5",comboBox2.Text);
            kaydet.Parameters.AddWithValue("@p6",durum);
            kaydet.Parameters.AddWithValue("@p7",maskedTextBox3.Text);
            kaydet.ExecuteNonQuery();
            bgl.baglanti().Close();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToLongTimeString();
            label11.Text= DateTime.Now.ToLongDateString();


            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand doktorlar = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1", bgl.baglanti());
            doktorlar.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader drdoktor = doktorlar.ExecuteReader();
            while (drdoktor.Read())
            {
                comboBox2.Items.Add(drdoktor[0] + " " + drdoktor[1]);
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand duyuru = new SqlCommand("insert into tbl_duyurular (duyuru)values(@p1)",bgl.baglanti());
            duyuru.Parameters.AddWithValue("@p1",richTextBox1.Text);
            duyuru.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Başarıyla Oluşturuldu");

        }
        public string id, tarih, saat, brans, doktor,durum, tcno;

        private void button7_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
                fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sabittc,durum1;
            sabittc = maskedTextBox3.Text;
            if (checkBox1.Checked==true)
            {
                durum1 = "true";
            }
            else
            {
                durum1="false";
            }
            SqlCommand guncelle = new SqlCommand("update tbl_randevular set randevutarih=@p2,randevusaat=@p3,randevubrans=@p4,randevudoktor=@p5,randevudurum=@p6,hastatc=@p7 where hastatc=@p8",bgl.baglanti());
            //guncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            guncelle.Parameters.AddWithValue("@p2",maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@p3", maskedTextBox2.Text);
            guncelle.Parameters.AddWithValue("@p4", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@p5", comboBox2.Text);
            guncelle.Parameters.AddWithValue("@p6", durum1);
            guncelle.Parameters.AddWithValue("@p7", maskedTextBox3.Text);
            guncelle.Parameters.AddWithValue("@p8", sabittc);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (durum=="true")
            {
                checkBox1.Checked = true;
            }
           
            textBox1.Text = id;
            maskedTextBox1.Text = tarih;
            maskedTextBox2.Text = saat;
            comboBox1.Text = brans;
            comboBox2.Text = doktor;
            maskedTextBox3.Text = tcno;

        }
    }
}
