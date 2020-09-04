using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class Frmgirisler : Form
    {
        public Frmgirisler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmhastagiriş fr = new Frmhastagiriş();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDoktorgiris fr = new FrmDoktorgiris();
            fr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSekretergiris fr = new FrmSekretergiris();
            fr.Show();
            this.Hide();
        }
    }
}
