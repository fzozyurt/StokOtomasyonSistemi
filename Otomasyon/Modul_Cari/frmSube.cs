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
    public partial class frmSube : DevExpress.XtraEditors.XtraForm
    {
        public bool Secim = false;
        bool Edit = false;
        int SecimID = -1;
        int YetkılıID = -1;
        int CarıID = AnaForm.Aktarma;

        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        public frmSube()
        {
            InitializeComponent();
            lbFirma.Text = CarıID.ToString();
        }

        private void rbDepartman_CheckedChanged(object sender, EventArgs e)
        {
            cbGMK.Visible = true;
            cbGMK.Enabled = true;
            lbİsim.Text = "Departman Adı";
            lbYisim.Text = "Departman Sorumlusu";
        }

        private void rbŞube_CheckedChanged(object sender, EventArgs e)
        {
            cbGMK.Enabled = false;
            cbGMK.Visible = false;
            lbYisim.Text = "Yetkili Adı";
        }

        private void rbBayi_CheckedChanged(object sender, EventArgs e)
        {
            cbGMK.Enabled = false;
            cbGMK.Visible = false;
            lbİsim.Text = "Bayi Firma Adı";
            lbYisim.Text = "Yetkili Adı";
        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.TBL_CARI_SUBE Grup = new Fonksiyonlar.TBL_CARI_SUBE();
                Grup.SUBEADI = txtIsım.Text;
                Grup.SUBEADRES = txtAdres.Text;
                Grup.SUBEYETKILI = YetkılıID;
             /*   Grup.SAVEDATE = DateTime.Now;
                Grup.SAVEUSER = AnaForm.UserID;*/
                DB.TBL_CARI_SUBE.InsertOnSubmit(Grup);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("Yeni Cari Grup Kaydı Oluşturuldu");
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        private void frmSube_Load(object sender, EventArgs e)
        {

        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cbGMK_CheckedChanged(object sender, EventArgs e)
        {
            txtAdres.Enabled = false;
            txtSehir.Enabled = false;
            txtPostaKodu.Enabled = false;
            txtUlke.Enabled = false;
            txtIlce.Enabled = false;
            Fonksiyonlar.TBL_CARILER Cari = DB.TBL_CARILER.First(s => s.ID == CarıID);
            txtAdres.Text = Cari.ADRES;
            txtSehir.Text = Cari.SEHIR;
            txtPostaKodu.Text = Cari.POSTAKODU;
            txtUlke.Text = Cari.ULKE;
            txtIlce.Text = Cari.ILCE;
        }

        void YetkiliAc(int ID)
        {
            try
            {
                YetkılıID = ID;
                Fonksiyonlar.TBL_CARİ_YETKILI Yetkılı = DB.TBL_CARİ_YETKILI.First(s => s.ID == YetkılıID);
                txtYetkılı.Text = Yetkılı.YETKILIADI+(" ")+Yetkılı.YETKILISOYADI;
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        private void txtYetkılı_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.Cari_Yetkili_List(true);
            if (ID > 0)
            {
                YetkiliAc(ID);
            }
            AnaForm.Aktarma = -1;
        }
    }
}