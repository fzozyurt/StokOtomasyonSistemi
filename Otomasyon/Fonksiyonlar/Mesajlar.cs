using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomasyon.Fonksiyonlar
{
    class Mesajlar
    {
        AnaForm MesajForm = new AnaForm();
        public void YeniKayit(string Mesaj)
        {
            MesajForm.Mesaj("Yeni Kayıt Girişi", Mesaj);            
        }

        public DialogResult PersonelSistemi()
        {
            return MessageBox.Show("Sistem Kaydı", "Yeni Sistem Kaydı Oluşturulsun mu ?", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        }

        public DialogResult Cikis()
        {
            return MessageBox.Show("Çıkış", "Programı Kapatmak İstiyormusun ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public DialogResult Guncelle()
        {
            return MessageBox.Show("Seçili kayıt güncellenecektir.\n Güncelleme işlemini onaylıyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public DialogResult Sil()
        {
            return MessageBox.Show("Seçili kayıt kalıcı olarak silinecektir.\n Silme işlemini onaylıyor musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void Guncelle(bool Guncelleme)
        {
            MesajForm.Mesaj("Kayıt Güncelleme", "Kayıt güncellenmiştir.");
        }

        public void Hata(Exception Hata)
        {
            MesajForm.Mesaj("Hata Oluştu", Hata.Message);
        }

        public void FormAcilis(string FormAdi)
        {
            MesajForm.Mesaj("", FormAdi+ " formu açıldı.");
        }

        public void FormKapanis(string FormAdi)
        {
            MesajForm.Mesaj("", FormAdi + " formu kapatıldı.");
        }

        public void PersonelKayit()
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.Yes)
            {
                
            }
        }
    }
}

