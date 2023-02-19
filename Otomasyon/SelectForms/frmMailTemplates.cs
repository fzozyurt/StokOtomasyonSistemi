using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;

namespace Otomasyon.Mail_Templates
{
    public partial class frmMailTemplates : DevExpress.XtraEditors.XtraForm
    {
        public frmMailTemplates()
        {
            InitializeComponent();
        }

        private void frmMailTemplates_Load(object sender, EventArgs e)
        {
            /*string secilenDizin;
            FolderBrowserDialog fBrowser = new FolderBrowserDialog();
            fBrowser.ShowDialog();
            if (cbSecim.SelectedIndex == 0)
            {
                secilenDizin = "C:\Users\fzozy\Downloads\Compressed\1_12_DosyaIslemleri\DosyaIslemleri";
            }

            DizinIceriginiListeyeEkle(secilenDizin);
        }

        private void DizinIceriginiListeyeEkle(string dizin)
        {
            string[] dizindekiKlasorler = Directory.GetDirectories(dizin);
            string[] dizindekiDosyalar = Directory.GetFiles(dizin);
            foreach (string klasor in dizindekiKlasorler)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(klasor);
                string klasorAdi = dirInfo.Name;
                DateTime olsTarihi = dirInfo.CreationTime;

                ListViewItem item = new ListViewItem(klasorAdi);
                item.SubItems.Add("Klasör");
                item.SubItems.Add("");
                item.SubItems.Add(olsTarihi.ToString("dd.MM.yyyy HH:mm"));

                dizinIcerigiListView.Items.Add(item);
            }
            foreach (string dosya in dizindekiDosyalar)
            {
                FileInfo fileInfo = new FileInfo(dosya);

                string dosyaAdi = fileInfo.Name;
                long byteBoyut = fileInfo.Length;
                DateTime olsTarihi = fileInfo.CreationTime;
                gridView1.Items.Add(item);
            }
        }*/
        }
    }
}