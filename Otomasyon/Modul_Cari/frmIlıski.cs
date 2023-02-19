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
    public partial class frmIlıski : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();

        public bool Secim = false;
        bool Edit = false;
        int SecimID = -1;


        public frmIlıski()
        {
            InitializeComponent();
        }

        private void frmIlıski_Load(object sender, EventArgs e)
        {
            //Listele();
        }

        void Temizle()
        {
            txtIlıskıAdi.Text = "";
            Edit = false;
            SecimID = -1;
            //Listele();
        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.TBL_CARI_ILISKI iliski = new Fonksiyonlar.TBL_CARI_ILISKI();
                iliski.ILISKIADI = txtIlıskıAdi.Text;
                iliski.SAVEDATE = DateTime.Now;
                iliski.SAVEUSER = AnaForm.UserID;
                DB.TBL_CARI_ILISKI.InsertOnSubmit(iliski);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("Yeni İlişki Kaydı Oluşturuldu");
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void Guncelle()
        {
            try
            {
                Fonksiyonlar.TBL_CARI_ILISKI iliski = DB.TBL_CARI_ILISKI.First(s => s.ID == SecimID);
                iliski.ILISKIADI = txtIlıskıAdi.Text;
                iliski.EDITDATE = DateTime.Now;
                iliski.EDITUSER = AnaForm.UserID;
                DB.SubmitChanges();
                Mesajlar.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void Sil()
        {
            try
            {
                DB.TBL_CARI_ILISKI.DeleteOnSubmit(DB.TBL_CARI_ILISKI.First(s => s.ID == SecimID));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

     /*   void Listele()
        {
            var ilst = from s in DB.TBL_CARI_ILISKI
                      select s;
            IliskiList.DataSource = ilst;
        }
        */
        void Sec()
        {
            try
            {
                Edit = true;
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtIlıskıAdi.Text = gridView1.GetFocusedRowCellValue("ILISKIADI").ToString();
            }
            catch (Exception)
            {
                Edit = false;
                SecimID = -1;
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Edit && SecimID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();
            //Listele();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Edit && SecimID > 0 && Mesajlar.Sil() == DialogResult.Yes) Sil();
        }
    }
}