using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Collections;
using System.Threading.Tasks;

namespace Otomasyon.Fonksiyonlar
{
    class İslemler
    {
        public static string HTMLmailURL = "furkandemo";
        Fonksiyonlar.TBL_LOG Log = new Fonksiyonlar.TBL_LOG();
        int ID = AnaForm.Aktarma;

        public void Mail()
        {
            try
            {
                string isim = "";
                //Mail Gönderme
                MailMessage mail = new MailMessage();
                //Assign From mail address
                mail.From = new MailAddress("noreply@furkanozyurt.tk", "Hassas Mühendislik");
                //Set To mail address
                mail.To.Add("fzozyurt@outlook.com");
                mail.ReplyToList.Add(AnaForm.Kullanici.KURUMSALMAILADRESI.ToString());
                //Set Subject of mail
                mail.Subject = "vtvyhh";
                //Create Mail Body
                mail.Body = "demo";
                //for sending body as HTML
                mail.IsBodyHtml = true;
                //Create Instance of SMTP Class
                SmtpClient SmtpServer = new SmtpClient();
                //Assign Host
                SmtpServer.Host = "mail.furkanozyurt.tk ";
                //Assign Post Number
                SmtpServer.Port = 587;
                //Setting the credential for authentiicate the sender
                SmtpServer.Credentials = new System.Net.NetworkCredential("noreply@furkanozyurt.tk", "gvp33yoky0");
                //Enable teh Secure Soket Layer to Encrypte the connection 
                SmtpServer.EnableSsl = true;
                //Sending the message
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                
                Log.FORM = "Cari Açılış Kartı";
                Log.KULLANICIID = AnaForm.Kullanici.ID;
                Log.TARIHSAAT = DateTime.Now;
                Log.IPADRES = frmLoginform.IP;
            }
        }

    }
}
