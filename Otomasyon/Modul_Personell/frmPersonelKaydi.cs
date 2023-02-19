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
    public partial class frmPersonelKaydi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool Ac = false;
        int KullaniciID = -1;
        int BankaID = -1;
        int IlceID = -1;
        int IlID = -1;
        int KoilID = -1;
        int KoIlceID = -1;
        int DepartmanID = -1;
        string sifre = "";



        public frmPersonelKaydi()
        {
            InitializeComponent();
        }

        private void frmPersonelKaydi_Load(object sender, EventArgs e)
        {

        }

        
        public string CreatePassword()
        {
            char[] cr = "0123456789ABCDEFGHIJKLMNOPQRSTUCWXYZ".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                result += cr[r.Next(0, cr.Length - 1)].ToString();
                sifre = result;
            }

            return result;
        }


        void YeniKayit()
        {
            try
            {
                Fonksiyonlar.TBL_PERSONEL personel = new Fonksiyonlar.TBL_PERSONEL();
                Fonksiyonlar.TBL_KULLANICILAR kullanici = new Fonksiyonlar.TBL_KULLANICILAR();
                personel.PERSONELADI = txtIsim.Text;
                personel.PERSONELSOYADI = txtSoyisim.Text;
                personel.SICILNO = txtSicilNo.Text;
                personel.EMEKLISICILNO = txtEmekliSicilNo.Text;
                personel.EVADRESI = txtAdres.Text;
                personel.ILID = IlID;
                personel.ILCEID = IlceID;
                personel.PKODU = txtPostaKodu.Text;
                personel.TELEFON = txtEvTelefonu.Text;
                personel.GSM = txtGSM.Text;
                personel.KISISELMAILADRESI = txtMail.Text;
                personel.KURUMSALMAILADRESI = txtKurumsalMail.Text;
                personel.OKUL = txtOkul.Text;
                personel.BOLUM = txtBolum.Text;
                personel.BRANS = txtBrans.Text;
                personel.BASLANGICTARIHI = txtBasTarihi.Text;
                personel.BITISTARIHI = txtBitTarihi.Text;
                personel.BANKA = BankaID;
                personel.HESAPNO = txtHesapNo.Text;
                personel.IBANNO = txtIBAN.Text;
                personel.DEPARTMANID = DepartmanID;
                personel.UNVAN = txtUnvan.SelectedIndex.ToString();
                personel.GOREV = txtGorev.SelectedIndex.ToString();
                personel.CALISMATURU = txtCalismaTuru.SelectedIndex.ToString();
                personel.ISBASLANGICTARIHI = DateTime.Parse(txtIsBasTarihi.Text);
                personel.ISCIKISTARIHI = DateTime.Parse(txtIsBitTarihi.Text);
                if (rbtnATamamlandi.Checked = true) personel.ASKERLIKDURUMU = "Tamamlandı";
                else if (rbtnATecilli.Checked = true)
                {
                    personel.ASKERLIKDURUMU = "Tecilli";
                    personel.ASKETLIKTESCILTARIHI = DateTime.Parse(txtTecilTarih.Text);
                }
                else if (rbtnMuaf.Checked = true) personel.ASKERLIKDURUMU = "Muaf";
                personel.ACILDURUMKISIADI = txtAcilDurumAdi.Text;
                personel.ACILDURUMTELEFON = txtAcilDurumTel.Text;
                personel.ACILDURUMYAKINLIK = txtAcilDurumYekinlikDerece.Text;
                personel.TCSERI = txtKSeri.Text;
                personel.TCSERINO = txtKSeriNo.Text;
                personel.TCKIMLIKNO = txtTCNo.Text;
                personel.BABAADI = txtBabaAdi.Text;
                personel.ANAADI = txtAnneAdi.Text;
                personel.DOGUMYERI = txtDogumYeri.Text;
              //  personel.DOGUMTARIHI = DateTime.Parse(txtDogumTarihi.Text);
                personel.DIN = txtDin.SelectedIndex;
                personel.MEDENIHAL = txtMedeniHal.SelectedIndex;
                personel.KANGURUBU = txtKanGurubu.SelectedIndex ;
                personel.KOIL = KoilID;
                personel.KOILCE = KoIlceID;
                personel.CILTNO = txtCilt.Text;
                personel.AILESIRANO = txtAileSiraNo.Text;
                personel.SIRANO = txtSiraNo.Text;
                DB.TBL_PERSONEL.InsertOnSubmit(personel);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("Personel Kaydı Oluşturuldu.");
                if (Mesajlar.PersonelSistemi() == DialogResult.Yes)
                {
                    OpenFileDialog file = new OpenFileDialog();
                    //file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  
                    file.Filter = "HTML |*.html";
                    file.RestoreDirectory = true;
                    file.ShowDialog();
                    Fonksiyonlar.İslemler.HTMLmailURL = file.FileName;
                    file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";

                    kullanici.MAIL = txtKurumsalMail.Text;
                    kullanici.SIFRE = sifre;
                }
            }
            catch(Exception e)
            {
                Mesajlar.Hata(e);
            }
        }
        private void buttonEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl34_Click(object sender, EventArgs e)
        {

        }

        private void labelControl33_Click(object sender, EventArgs e)
        {

        }

        private void labelControl32_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtTecilTarih.Visible = true;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniKayit();
        }

        private void pctboxVesikalik_DragOver(object sender, DragEventArgs e)
        {
            pctboxVesikalik.DoDragDrop(pctboxVesikalik.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panelControl2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panelControl2_DragDrop(object sender, DragEventArgs e)
        {
            panelControl2.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            pctboxVesikalik.Image = null;
        }

        private void txtIsim_EditValueChanged(object sender, EventArgs e)
        {
            lblPersonelAdi.Text = txtIsim.Text;
        }

        private void sistemErişiminiKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sistemErişiminiAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mesajlar.PersonelKayit();
            //if ( == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
        }
    }
}