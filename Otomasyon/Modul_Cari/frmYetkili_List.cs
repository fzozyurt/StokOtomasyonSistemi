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

namespace Otomasyon.Modul_Cari
{
    public partial class frmYetkili_List : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();

        public bool Secim = false;
        bool Edit = false;
        int SecimID = -1;
        int CariID = AnaForm.Aktarma;

        public frmYetkili_List()
        {
            InitializeComponent();
        }

        void Listele()
        {
            var lst = from s in DB.VW_CARI_YETKILI
                      where s.CARIID == CariID
                      select s;
            Liste.DataSource = lst;
        }

        void Sec()
        {
            try
            {
                Edit = true;
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            }
            catch (Exception)
            {
                Edit = false;
                SecimID = -1;
            }
        }

        private void frmYetkılı_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim && SecimID > 0)
            {
                AnaForm.Aktarma = SecimID;
                this.Close();
            }
        }
    }
}