using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Otomasyon.Modul_Cari
{
    public partial class frmCariAcilisKarti : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();
        Fonksiyonlar.TBL_LOG Log = new Fonksiyonlar.TBL_LOG();
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-7ICMR01\\SQLEXPRESS;Database=Otomasyon;Integrated Security=true;");
        
        // XtraMessageBox.Show(txtUlke.EditValue.ToString());


        bool Edit = false;
        int CariID = -1;
        int GrupID = -1;
        int IliskiID = -1;
        string ulkeID = "";
        string SehirID = "";
        string BolgeID = "";

        public frmCariAcilisKarti()
        {
            InitializeComponent();
        }

        private void frmCariAcilisKarti_Load(object sender, EventArgs e)
        {
            lblCariKodu.Text = Numaralar.CariKodNumarasi();
            Sirala();            
        }

        public void Ac()
        {
            try
            {
                Edit = true;
                CariID = -1 ;
                Fonksiyonlar.TBL_CARILER Cari = DB.TBL_CARILER.First(s => s.ID == CariID);
                txtAdres.Text = Cari.ADRES;
                txtCariAdi.Text = Cari.CARIADI;
                lblCariKodu.Text = Cari.CARIKODU;
                txtFax1.Text = Cari.FAX1;
                txtFax2.Text = Cari.FAX2;
                txtIlce.Text = Cari.ILCE;
                txtMail.Text = Cari.MAILINFO;
                txtSehir.Text = Cari.SEHIR;
                txtTelefon1.Text = Cari.TELEFON1;
                txtTelefon2.Text = Cari.TELEFON2;
                txtPostaKodu.Text = Cari.POSTAKODU;
                txtUlke.Text = Cari.ULKE;
                txtFirmaSektor.Text = Cari.FIRMASEKTOR;
                txtVergiDairesi.Text = Cari.VERGIDAIRESI;
                txtVergiNo.Text = Cari.VERGINO;
                txtWebAdresi.Text = Cari.WEBADRES;
                txtAciklama.Text = Cari.ACIKLAMA;
                GrupAc(Cari.GRUPID.Value);
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void Temizle()
        {
            foreach (Control CT in groupControl1.Controls)
                if (CT is DevExpress.XtraEditors.TextEdit || CT is DevExpress.XtraEditors.ButtonEdit) CT.Text = "";

            foreach (Control CE in groupControl2.Controls)
                if (CE is DevExpress.XtraEditors.TextEdit || CE is DevExpress.XtraEditors.ButtonEdit || CE is DevExpress.XtraEditors.MemoEdit) CE.Text = "";
            lblCariKodu.Text = Numaralar.CariKodNumarasi();
            Edit = false;
            CariID = -1;
            GrupID = -1;
            AnaForm.Aktarma = -1;
        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.TBL_CARILER Cari = new Fonksiyonlar.TBL_CARILER();
                Cari.ADRES = txtAdres.Text;
                Cari.CARIADI = txtCariAdi.Text;
                Cari.CARIKODU = lblCariKodu.Text;
                Cari.FIRMASEKTOR = txtFirmaSektor.Text;
                Cari.FAX1 = txtFax1.Text;
                Cari.FAX2 = txtFax2.Text;
                Cari.GRUPID = GrupID;
                Cari.ILCE = txtSehir.Text;
                Cari.MAILINFO = txtMail.Text;
                Cari.SEHIR = txtSehir.Text;
                Cari.POSTAKODU = txtPostaKodu.Text;
                Cari.TELEFON1 = txtTelefon1.Text;
                Cari.TELEFON2 = txtTelefon2.Text;
                Cari.ULKE = txtUlke.Text;
                Cari.VERGIDAIRESI = txtVergiDairesi.Text;
                Cari.VERGINO = txtVergiNo.Text;
                Cari.WEBADRES = txtWebAdresi.Text;
                Cari.ACIKLAMA = txtAciklama.Text;
                Cari.SAVEDATE = DateTime.Now;
                Cari.SAVEUSER = AnaForm.UserID;
                DB.TBL_CARILER.InsertOnSubmit(Cari);
                DB.SubmitChanges();
                CariID = Cari.ID;
                Edit = true;
                Mesajlar.YeniKayit("Yeni Cari Kaydı Oluşturulmuştur.");
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
                Edit = false;
                CariID = -1;
                Log.FORM = "Cari Açılış Kartı";
                Log.KULLANICIID = AnaForm.Kullanici.ID;
                Log.IPADRES = frmLoginform.IP;
                Log.LOGBILGISI = e.Message;
            }

        }

        void Guncelle()
        {
            try
            {
                Fonksiyonlar.TBL_CARILER Cari = DB.TBL_CARILER.First(s => s.ID == CariID);
                Cari.ADRES = txtAdres.Text;
                Cari.CARIADI = txtCariAdi.Text;
                Cari.CARIKODU = lblCariKodu.Text;
                Cari.FIRMASEKTOR = txtFirmaSektor.Text;
                Cari.FAX1 = txtFax1.Text;
                Cari.FAX2 = txtFax2.Text;
                Cari.GRUPID = GrupID;
                Cari.ILCE = txtIlce.Text;
                Cari.MAILINFO = txtMail.Text;
                Cari.SEHIR = txtSehir.Text;
                Cari.POSTAKODU = txtPostaKodu.Text;
                Cari.TELEFON1 = txtTelefon1.Text;
                Cari.TELEFON2 = txtTelefon2.Text;
                Cari.ULKE = txtUlke.Text;
                Cari.VERGIDAIRESI = txtVergiDairesi.Text;
                Cari.VERGINO = txtVergiNo.Text;
                Cari.WEBADRES = txtWebAdresi.Text;
                Cari.ACIKLAMA = txtAciklama.Text;
                Cari.EDITDATE = DateTime.Now;
                Cari.EDITUSER = AnaForm.UserID;
                DB.SubmitChanges();
                Mesajlar.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
                Log.FORM = "Cari Açılış Kartı";
                Log.KULLANICIID = AnaForm.Kullanici.ID;
                Log.IPADRES = frmLoginform.IP;
                Log.LOGBILGISI = e.Message;
            }
        }

        void Sil()
        {
            try
            {
                DB.TBL_CARILER.DeleteOnSubmit(DB.TBL_CARILER.First(s => s.ID == CariID));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
                Log.FORM = "Cari Açılış Kartı";
                Log.KULLANICIID = AnaForm.Kullanici.ID;
                Log.IPADRES = frmLoginform.IP;
                Log.LOGBILGISI = e.Message;
            }
        }

        void TahsilatListele()
        {
            var lst = from s in DB.VW_TAHSILAT_KULLANICI
                      where s.CARIID.Value == CariID
                      select s;
            txtSehir.Properties.DataSource = lst;
        }

        void UlkeListele()
        {

            var lst = from s in DB.Ulkeler
                      select s;
            txtUlke.Properties.DataSource = lst;
        }

        void GrupListele()
        {
            var lst = from s in DB.TBL_CARIGRUPLARI
                      select s;
            txtGrupAdi.Properties.DataSource = lst;
        }

        void IliskiListele()
        {
            var lst = from s in DB.TBL_CARI_ILISKI
                      select s;
            txtIlıskı.Properties.DataSource = lst;
        }

        void SehirListele()
        {
            var lst = from s in DB.Iller
                      
                      select s;
            txtSehir.Properties.DataSource = lst;
        }

        void IlceListele()
        {
            var lst = from s in DB.Ilceler
                      select s;
            txtIlce.Properties.DataSource = lst;
        }

        void YetkiliListele()
        {
            var lst = from s in DB.VW_CARI_YETKILI_SUBE
                      where s.CARIID.Value == CariID
                      select s;
            lstYetkılı.DataSource = lst;

        }

        void CariListele()
        {
            var lst = from s in DB.TBL_CARILER
                      select s;
            txtCariAdi.Properties.DataSource = lst;
        }

        void Sirala()
        {
            SektorList();
            UlkeListele();
            SehirListele();
            IlceListele();
            TahsilatListele();
            SehirListele();
            GrupListele();
            GridIslemList();
            CariListele();
           // IliskiListele();
        }

        void GridIslemList()
        {
            var LST = from s in DB.TBL_CARILER
                      where s.CARIADI.Contains(txtCariAdi.Text) && s.CARIKODU.Contains(lblCariKodu.Text)
                      select s;
            lstIslem.DataSource = LST;
        }

        

        void GrupAc(int ID)
        {
            try
            {
                GrupID = ID;
                Fonksiyonlar.TBL_CARIGRUPLARI Grup = DB.TBL_CARIGRUPLARI.First(s => s.ID == GrupID);
                txtGrupAdi.Text = Grup.GRUPADI;
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void IliskiAc(int ID)
        {
            try
            {
                IliskiID = ID;
                Fonksiyonlar.TBL_CARI_ILISKI Iliski = DB.TBL_CARI_ILISKI.First(s => s.ID == IliskiID);
                txtIlıskı.Text = Iliski.ILISKIADI;
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void SektorList()
        {
            var LSTE = from s in DB.TBL_CARI_SEKTOR
                      select s;
            txtFirmaSektor.Properties.DataSource = LSTE;
        }

        void IlList()
        {
            var LSTE = from s in DB.Iller
                       select s;
            txtFirmaSektor.Properties.DataSource = LSTE;
        }



        private void txtGrupKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.CariGruplari(true);
            if (ID > 0)
            {
                GrupAc(ID);

            }
            AnaForm.Aktarma = -1;
        }

        //private void lblCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    int ID = Formlar.CariListesi(true);
        //    if (ID > 0)
        //    {
        //        Ac(ID);
        //    }
        //    AnaForm.Aktarma = -1;
        //}

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Edit && CariID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Edit && CariID > 0 && Mesajlar.Sil() == DialogResult.Yes) Sil();
        }

        private void şubeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnaForm.Aktarma = CariID;
            Formlar.Cari_Sube();
        }

        private void txtCariAdi_EditValueChanged(object sender, EventArgs e)
        {
            txtCariAdi.Text = txtCariAdi.Text.ToUpper();
            txtCariAdi.SelectionStart = txtCariAdi.Text.Length;
        }

        private void txtCariAdi_EnabledChanged(object sender, EventArgs e)
        {
            txtCariAdi.Text = txtCariAdi.Text.ToUpper();
            txtCariAdi.SelectionStart = txtCariAdi.Text.Length;
        }

        private void txtCariAdi_TextChanged(object sender, EventArgs e)
        {
            txtCariAdi.Text = txtCariAdi.Text.ToUpper();
            txtCariAdi.SelectionStart = txtCariAdi.Text.Length;
        }

        private void txtIlıskı_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.Cariiliski(true);
            if (ID > 0)
            {
                GrupAc(ID);

            }
            AnaForm.Aktarma = -1;
        }

        private void txtUlke_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            XtraMessageBox.Show(txtCariAdi.EditValue.ToString());
        }

        private void txtCariAdi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Ac();

        }

        private void txtPostaKodu_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
                if (txtPostaKodu.Text.Length > 4)
                {
                    Fonksiyonlar.VW_IL_ILCE il = DB.VW_IL_ILCE.First(s => s.PostaKodu == txtPostaKodu.Text);
               
                    txtUlke.EditValue = il.UlkeId;
                    txtSehir.EditValue = il.IlId;
                    txtIlce.EditValue = il.IlceId;
                if (il.PostaKodu != txtPostaKodu.Text) MessageBox.Show("DeğerYok", "degergir");
                    
                }
        }
    }
}