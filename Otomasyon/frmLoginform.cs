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
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace Otomasyon
{
    public partial class frmLoginform : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();

        public static string IP = "";

        public frmLoginform()
        {
            InitializeComponent();
            txtKullanici.Focus();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                Fonksiyonlar.VW_KULLANICI_GIRIS Kullanici = DB.VW_KULLANICI_GIRIS.First(s => s.KURUMSALMAILADRESI == txtKullanici.Text.Trim() && s.SIFRE == txtSifre.Text.Trim());
                Fonksiyonlar.TBL_KULLANICI_LASTLOGIN lastlogın = new Fonksiyonlar.TBL_KULLANICI_LASTLOGIN();
                Kullanici.GRSPID = Kullanici.ID;
                lastlogın.KULLANICIID = Kullanici.ID;
                MessageBox.Show("demo" + Kullanici.ID);
                lastlogın.IPADRES = IP;
                lastlogın.TARIHSAAT = DateTime.Now;
                DB.SubmitChanges();
                this.Hide();
                AnaForm frm = new AnaForm(Kullanici);
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Kullanıcı adı ya da şifre hatalı!");
                return;
            }            
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
            frmAyar frm = new frmAyar();
            frm.ShowDialog();
        }

        private void frmLoginform_Load(object sender, EventArgs e)
        {
            IPadres();
        }

        public void IPadres()
        {
            var webClient = new WebClient();
            string dnsString = webClient.DownloadString("http://checkip.dyndns.org");
            dnsString = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(dnsString).Value;
            webClient.Dispose();
            IP = dnsString;
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            frmSifremiUnuttum frm = new frmSifremiUnuttum();
            frm.ShowDialog();
        }
    }
}