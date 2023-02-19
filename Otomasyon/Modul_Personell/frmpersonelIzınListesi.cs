using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Personell
{
    public partial class frmpersonelIzınListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmpersonelIzınListesi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnPersonelDegistir.Visible = false;
            lblPersonelAdi.Visible = false;
            txtPersonelAdi.Visible = true;
        }

        private void izinTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmpersonelIzınListesi_Load(object sender, EventArgs e)
        {

        }
    }
}