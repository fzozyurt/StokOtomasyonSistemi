using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using DevExpress.XtraEditors;

namespace Otomasyon
{
    public partial class frmSifremiUnuttum : MetroFramework.Forms.MetroForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();

        string Sifre = " ";
        string Kullaniciadi = "admin";
        string Mailaddr = "fzozyurt@outlook.com";
        string İsimSoyisim = "admin";

        public frmSifremiUnuttum()
        {
            InitializeComponent();
        }

        private void frmSifremiUnuttum_Load(object sender, EventArgs e)
        {

        }

        void Mail()
        {
            //Mail Gönderme
            MailMessage mail = new MailMessage();
        //Assign From mail address
        mail.From = new MailAddress("furkan.ozyurt3@gmail.com", "Hassas Mühendislik");
        //Set To mail address
        mail.To.Add(Mailaddr);
            //Set Subject of mail
            mail.Subject = "Şifre Sıfırlama";
            //Create Mail Body
            mail.Body = "Merhaba"+İsimSoyisim+","+ Environment.NewLine+"Otomasyon Kullanıcı Adınız :  " +Kullaniciadi+ "\nŞifreniz :  " + Sifre+ Environment.NewLine+ Environment.NewLine+"İyi Çalışmalar...";
            //for sending body as HTML
            mail.IsBodyHtml = true;
            //Create Instance of SMTP Class
            SmtpClient SmtpServer = new SmtpClient();
        //Assign Host
        SmtpServer.Host = "smtp.gmail.com";
            //Assign Post Number
            SmtpServer.Port = 587;
            //Setting the credential for authentiicate the sender
            SmtpServer.Credentials = new System.Net.NetworkCredential("furkan.ozyurt4@gmail.com", "furkanzeki1903");
            //Enable teh Secure Soket Layer to Encrypte the connection 
            SmtpServer.EnableSsl = true;
            //Sending the message
            SmtpServer.Send(mail);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Fonksiyonlar.TBL_KULLANICILAR Kullanici = DB.TBL_KULLANICILAR.First(s => s.KULLANICI == txtKullanici.Text.Trim() | s.MAIL == txtKullanici.Text.Trim());
                Sifre = Kullanici.SIFRE;
                Kullaniciadi = Kullanici.KULLANICI;
                Mailaddr = Kullanici.MAIL;
                İsimSoyisim = Kullanici.ISIM + " " + Kullanici.SOYISIM;
                MessageBox.Show("Şifreniz Mail Adresinize İletilmiştir.");
                Mail();
                this.Hide();
                frmLoginform frm = new frmLoginform();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Kullanıcı adı ");
                return;
            }
        }
    }
}