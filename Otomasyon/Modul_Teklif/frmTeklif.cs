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
using System.Reflection;

namespace Otomasyon.Modul_Teklif
{
    public partial class frmTeklif : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();

        int CariID = -1;
        int Yetkili = -1;
        int yetkiliOnay = -1;
        int Personel = -1;
        int TeklifID = -1;
        bool Edit = false;

        void Temizle()
        {
            CariID = -1;
            TeklifID = -1;
            Yetkili = -1;
            Edit = false;
            txtToplamOdeme.Text = "";
            txtCariAdi.Text = "";
            hlblTeklifNo.Text = "";
            txtTeklifTarihi.Text = DateTime.Now.ToShortDateString();
            txtGenelToplam.Text = "0.00";
            txtOnaylayan.Text = "";
            txtOnayTarihi.Text = DateTime.Now.ToShortDateString();

            AnaForm.Aktarma = -1;
            for (int i = gridView1.RowCount; i > -1; i--)
            {
                gridView1.DeleteRow(i);
            }
        }

        void FaturaGetir()
        {
            try
            {
                Fonksiyonlar.TBL_TEKLIF Teklif = DB.TBL_TEKLIF.First(s => s.ID == TeklifID);
                Yetkili = Teklif.YETKILIID.Value;
                Personel = Teklif.PERSONELID.Value;
                yetkiliOnay = Teklif.ONAYREDEDEN.Value;
                txtOnaylayan.Text = yetkiliOnay.ToString(); ;
                txtOnayTarihi.EditValue = Teklif.ONAYREDTARIHI;
                txtCariAdi.Text = DB.TBL_CARILER.First(s => s.ID == Teklif.CARIID).CARIADI;
                txtTeklifTarihi.EditValue = Teklif.TEKLIFTARIHI;
                var srg = from s in DB.VW_KALEMLER
                          where s.TEKLIFID == TeklifID
                          select s;
                foreach (Fonksiyonlar.VW_KALEMLER k in srg)
                {
                    gridView1.AddNewRow();
                    gridView1.SetFocusedRowCellValue("MIKTAR", k.MIKTAR);
                    gridView1.SetFocusedRowCellValue("BIRIMFIYAT", k.BIRIMFIYAT);
                    gridView1.SetFocusedRowCellValue("KDV", k.KDV);
                    gridView1.SetFocusedRowCellValue("BARKOD", k.STOKBARKOD);
                    gridView1.SetFocusedRowCellValue("STOKKODU", k.STOKKODU);
                    gridView1.SetFocusedRowCellValue("STOKADI", k.STOKADI);
                    gridView1.SetFocusedRowCellValue("BIRIM", k.STOKBIRIM);
                    gridView1.UpdateCurrentRow();
                }
            }
            catch (Exception EX)
            {
                Mesajlar.Hata(EX);
            }
        }

        void StokGetir(int StokID)
        {
            try
            {
                Fonksiyonlar.TBL_STOKLAR Stok = DB.TBL_STOKLAR.First(s => s.ID == StokID);
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("MIKTAR", 0);
                gridView1.SetFocusedRowCellValue("BARKOD", Stok.STOKBARKOD);
                gridView1.SetFocusedRowCellValue("STOKKODU", Stok.STOKKODU);
                gridView1.SetFocusedRowCellValue("STOKADI", Stok.STOKADI);
                gridView1.SetFocusedRowCellValue("BIRIM", Stok.STOKBIRIM);
                gridView1.SetFocusedRowCellValue("BIRIMFIYAT", Stok.STOKSATISFIYAT);
                gridView1.SetFocusedRowCellValue("KDV", Stok.STOKSATISKDV);
            }
            catch (Exception EX)
            {
                Mesajlar.Hata(EX);
            }
        }

        private void btnStokSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int StokID = Formlar.StokListesi(true);
            if (StokID > 0)
            {
                StokGetir(StokID);
            }
            AnaForm.Aktarma = -1;

        }

        public frmTeklif()
        {
            InitializeComponent();
        }

        private void frmTeklif_Load(object sender, EventArgs e)
        {
            txtTeklifTarihi.Text = DateTime.Now.ToShortDateString();
            txtOnayTarihi.Text = DateTime.Now.ToShortDateString();
            kontrol();
            UrunList();
            CariList();
        }

        private void frmTeklif_Shown(object sender, EventArgs e)
        {
            if (Edit) FaturaGetir();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal Miktar = 0, BirimFiyat = 0, Toplam = 0;

                if (e.Column.Name != "colTOPLAM")
                {
                    Miktar = decimal.Parse(gridView1.GetFocusedRowCellValue("MIKTAR").ToString());
                    if (gridView1.GetFocusedRowCellValue("BIRIMFIYAT").ToString() != "") BirimFiyat = decimal.Parse(gridView1.GetFocusedRowCellValue("BIRIMFIYAT").ToString());
                    Toplam = Miktar * BirimFiyat;

                    gridView1.SetFocusedRowCellValue("TOPLAM", Toplam);
                    Hesapla();
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        void UrunList()
        {
            var lst = from s in DB.TBL_STOKLAR
                      select s;
            lstStok.DataSource = lst;
                      
        }

        void kontrol()
        {
            if (hlblTeklifNo.Text != "TA 00000")
            {
                hlblTeklifNo.Visible = true;
                hllblSiparisNo.Visible = true;
                labelControl15.Visible = true;
                labelControl19.Visible = true;
                labelControl20.Visible = true;
            }
        }

        void CariList()
        {
            var clist = from s in DB.TBL_CARILER
                      select s;
            txtCariAdi.Properties.DataSource = clist;
           // CariID =
            
        }

        void Hesapla()
        {
            try
            {
                decimal BirimFiyat = 0, Miktar = 0, GenelToplam = 0, AraToplam = 0, KDV = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    BirimFiyat = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    Miktar = decimal.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString()) / 100 + 1;
                    AraToplam += Miktar * BirimFiyat;
                    GenelToplam += decimal.Parse(gridView1.GetRowCellValue(i, "TOPLAM").ToString()) * KDV;
                }

                txtToplamOdeme.Text = AraToplam.ToString("0.00");
                txtPlanlanmamisTutar.Text = (GenelToplam - AraToplam).ToString("0.00");
                txtGenelToplam.Text = GenelToplam.ToString("0.00");
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.CariListesi(true);
            if (ID > 0) CariSec(ID);
            AnaForm.Aktarma = -1;
        }

        void CariSec(int ID)
        {
            try
            {
                CariID = ID;
                Fonksiyonlar.TBL_CARILER Cari = DB.TBL_CARILER.First(s => s.ID == CariID);
                txtCariAdi.Text = Cari.CARIADI;
            }
            catch (Exception EX)
            {
                Mesajlar.Hata(EX);
            }

        }



        void YeniTeklifKaydet()
        {
            try
            {
                Fonksiyonlar.TBL_TEKLIF Teklif = new Fonksiyonlar.TBL_TEKLIF();
                Teklif.SATISTURARI = decimal.Parse(txtGenelToplam.Text);
                Teklif.TEKLIFTARIHI = DateTime.Parse(txtTeklifTarihi.Text);
                Teklif.SAVEDATE = DateTime.Now;
                Teklif.SAVEUSER = AnaForm.UserID;
                DB.TBL_TEKLIF.InsertOnSubmit(Teklif);
                DB.SubmitChanges();
                TeklifID = Teklif.ID.Value;
                Fonksiyonlar.TBL_STOKHAREKETLERI[] StokHareketi = new Fonksiyonlar.TBL_STOKHAREKETLERI[gridView1.RowCount];
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    StokHareketi[i] = new Fonksiyonlar.TBL_STOKHAREKETLERI();
                    StokHareketi[i].BIRIMFIYAT = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    StokHareketi[i].FATURAID = TeklifID;
                    StokHareketi[i].GCKODU = "C";
                    StokHareketi[i].KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString());
                    StokHareketi[i].MIKTAR = int.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    StokHareketi[i].STOKKODU = gridView1.GetRowCellValue(i, "STOKKODU").ToString();
                    StokHareketi[i].TIPI = "Satış Faturası";
                    StokHareketi[i].SAVEDATE = DateTime.Now;
                    StokHareketi[i].SAVEUSER = AnaForm.UserID;
                    DB.TBL_STOKHAREKETLERI.InsertOnSubmit(StokHareketi[i]);
                }
                DB.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI CariHareket = new Fonksiyonlar.TBL_CARIHAREKETLERI();
                CariHareket.ACIKLAMA = hlblTeklifNo.Text + " nolu Teklif";
                CariHareket.CARIID = CariID;
                CariHareket.TARIH = DateTime.Now;
                CariHareket.TIPI = "TK";
                CariHareket.EVRAKTURU = "Fiyat Teklifi";
                CariHareket.EVRAKID = Teklif.ID;
                CariHareket.SAVEDATE = DateTime.Now;
                CariHareket.SAVEUSER = AnaForm.UserID;
                DB.TBL_CARIHAREKETLERI.InsertOnSubmit(CariHareket);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("Yeni Fatura Kaydı Başarı İle Yapılmıştır.");
                kontrol();
                Temizle();
            }
            catch (Exception EX)
            {
                Mesajlar.Hata(EX);
            }
        }

        void TeklifGuncelle()
        {
            try
            {
                Fonksiyonlar.TBL_TEKLIF teklif = DB.TBL_TEKLIF.First(s => s.ID == TeklifID);
                teklif.CARIID = CariID;
                teklif.SATISTURARI = decimal.Parse(txtGenelToplam.Text);
                teklif.EDITDATE = DateTime.Now;
                teklif.EDITUSER = AnaForm.Aktarma;
                DB.SubmitChanges();
                DB.TBL_STOKHAREKETLERI.DeleteAllOnSubmit(DB.TBL_STOKHAREKETLERI.Where(s => s.TEKLIFID == TeklifID));
                DB.SubmitChanges();
                Fonksiyonlar.TBL_STOKHAREKETLERI[] StokHareketi = new Fonksiyonlar.TBL_STOKHAREKETLERI[gridView1.RowCount];
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    StokHareketi[i] = new Fonksiyonlar.TBL_STOKHAREKETLERI();
                    StokHareketi[i].BIRIMFIYAT = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    StokHareketi[i].TEKLIFID = TeklifID;
                    StokHareketi[i].GCKODU = "-";
                    StokHareketi[i].KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString());
                    StokHareketi[i].MIKTAR = int.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    StokHareketi[i].STOKKODU = gridView1.GetRowCellValue(i, "STOKKODU").ToString();
                    StokHareketi[i].TIPI = "Satış Faturası";
                    StokHareketi[i].SAVEDATE = DateTime.Now;
                    StokHareketi[i].SAVEUSER = AnaForm.UserID;
                    DB.TBL_STOKHAREKETLERI.InsertOnSubmit(StokHareketi[i]);
                }
                DB.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI CariHareket = DB.TBL_CARIHAREKETLERI.First(s => s.CARIID == CariID&s.EVRAKID==TeklifID);
                /*ca.EDITDATE = DateTime.Now;
                CariHareket.EDITUSER = AnaForm.UserID;
                DB.SubmitChanges();*/
                Mesajlar.Guncelle(true);
                Temizle();
            }
            catch (Exception EX)
            {
                Mesajlar.Hata(EX);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }



        private void btnFaturaYazdir_Click(object sender, EventArgs e)
        {
            var srg = DB.VW_TEKLIF.Where(s => s.TEKLIFNO == hlblTeklifNo.Text);

            DataSet ds = new DataSet();
            ds.Tables.Add(LINQToDataTable(srg));

            rprTeklif rpr = new rprTeklif();
            rpr.DataSource = ds;
            rpr.SendToBack();
        }

        public DataTable LINQToDataTable<T>(IEnumerable<T> Lnqlst)
        {
            DataTable dt = new DataTable();


            PropertyInfo[] columns = null;

            if (Lnqlst == null) return dt;

            foreach (T Record in Lnqlst)
            {

                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void txtCariAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.CariListesi(true);
            if (ID > 0) CariSec(ID);
            AnaForm.Aktarma = -1;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void teklifFormuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*var srg = DB.VW_FATURALAR.Where(s => s.FATURANO == txtTeklifNo.Text);
            DataSet ds = new DataSet();
            ds.Tables.Add(LINQToDataTable(srg));
            rprTeklif rpr = new rprTeklif();
            rpr.DataSource = ds;
            rpr.SendToBack();

        }

        public DataTable LINQToDataTable<T>(IEnumerable<T> Lnqlst)
        {
            DataTable dt = new DataTable();


            PropertyInfo[] columns = null;

            if (Lnqlst == null) return dt;

            foreach (T Record in Lnqlst)
            {

                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;*/

        }

        private void tabOdemePlani_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCariAdi_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtCariAdi_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //__UrunId = Convert.ToInt32(lupUrunler.EditValue);
            CariID = Convert.ToInt32(txtCariAdi.EditValue);
        }
    }
}