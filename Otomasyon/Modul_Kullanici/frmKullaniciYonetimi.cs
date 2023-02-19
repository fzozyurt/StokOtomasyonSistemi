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

namespace Otomasyon.Modul_Kullanici
{
    public partial class frmKullaniciYonetimi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();

        int secim = -1;

        public frmKullaniciYonetimi()
        {
            InitializeComponent();
            this.Shown += FrmKullaniciYonetimi_Shown;
        }

        void Listele()
        {
            var lst = from s in DB.TBL_KULLANICILAR
                      select s;
            gridControl1.DataSource = lst;
        }

        private void FrmKullaniciYonetimi_Shown(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnYeniKullanici_Click(object sender, EventArgs e)
        {
            Formlar.KullaniciPanel();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {            
            Formlar.KullaniciPanel(true, secim);
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Mesajlar.Sil()==DialogResult.Yes)
            {
                DB.TBL_KULLANICILAR.DeleteOnSubmit(DB.TBL_KULLANICILAR.First(s => s.ID == secim));
                DB.SubmitChanges();
            }
                
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            secim = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
        }

        private void frmKullaniciYonetimi_Load(object sender, EventArgs e)
        {

        }
    }
}