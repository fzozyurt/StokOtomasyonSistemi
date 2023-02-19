namespace Otomasyon.Modul_Kullanici
{
    partial class frmKullaniciPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtKullanici = new DevExpress.XtraEditors.TextEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.rbtnAktif = new System.Windows.Forms.RadioButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSifreT = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtIsim = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoyisim = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtKullaniciKodu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.rbtnPasif = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullanici.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifreT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyisim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciKodu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 18);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kullanıcı Adı";
            // 
            // txtKullanici
            // 
            this.txtKullanici.Location = new System.Drawing.Point(96, 15);
            this.txtKullanici.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(161, 22);
            this.txtKullanici.TabIndex = 0;
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = global::Otomasyon.Properties.Resources.Kaydet24x24;
            this.btnKaydet.Location = new System.Drawing.Point(278, 12);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(106, 42);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // rbtnAktif
            // 
            this.rbtnAktif.AutoSize = true;
            this.rbtnAktif.Location = new System.Drawing.Point(278, 160);
            this.rbtnAktif.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnAktif.Name = "rbtnAktif";
            this.rbtnAktif.Size = new System.Drawing.Size(55, 21);
            this.rbtnAktif.TabIndex = 6;
            this.rbtnAktif.Text = "Aktif";
            this.rbtnAktif.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 50);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Şifre";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(96, 47);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.UseSystemPasswordChar = true;
            this.txtSifre.Size = new System.Drawing.Size(161, 22);
            this.txtSifre.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 82);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 16);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Şifre (Tekrar)";
            // 
            // txtSifreT
            // 
            this.txtSifreT.Location = new System.Drawing.Point(96, 79);
            this.txtSifreT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSifreT.Name = "txtSifreT";
            this.txtSifreT.Properties.UseSystemPasswordChar = true;
            this.txtSifreT.Size = new System.Drawing.Size(161, 22);
            this.txtSifreT.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 114);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "İsim";
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(96, 111);
            this.txtIsim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(161, 22);
            this.txtIsim.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 146);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(44, 16);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Soyisim";
            // 
            // txtSoyisim
            // 
            this.txtSoyisim.Location = new System.Drawing.Point(96, 143);
            this.txtSoyisim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoyisim.Name = "txtSoyisim";
            this.txtSoyisim.Size = new System.Drawing.Size(161, 22);
            this.txtSoyisim.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 178);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(77, 16);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Kullanıcı Türü";
            // 
            // txtKullaniciKodu
            // 
            this.txtKullaniciKodu.EditValue = "Normal";
            this.txtKullaniciKodu.Location = new System.Drawing.Point(96, 175);
            this.txtKullaniciKodu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKullaniciKodu.Name = "txtKullaniciKodu";
            this.txtKullaniciKodu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtKullaniciKodu.Properties.Items.AddRange(new object[] {
            "Yönetici",
            "Normal"});
            this.txtKullaniciKodu.Size = new System.Drawing.Size(161, 22);
            this.txtKullaniciKodu.TabIndex = 5;
            // 
            // btnTemizle
            // 
            this.btnTemizle.ImageOptions.Image = global::Otomasyon.Properties.Resources.Sil32x32;
            this.btnTemizle.Location = new System.Drawing.Point(278, 62);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(106, 42);
            this.btnTemizle.TabIndex = 9;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.ImageOptions.Image = global::Otomasyon.Properties.Resources.Kapat24x24;
            this.btnKapat.Location = new System.Drawing.Point(278, 111);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(106, 42);
            this.btnKapat.TabIndex = 10;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // rbtnPasif
            // 
            this.rbtnPasif.AutoSize = true;
            this.rbtnPasif.Checked = true;
            this.rbtnPasif.Location = new System.Drawing.Point(278, 188);
            this.rbtnPasif.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnPasif.Name = "rbtnPasif";
            this.rbtnPasif.Size = new System.Drawing.Size(56, 21);
            this.rbtnPasif.TabIndex = 7;
            this.rbtnPasif.TabStop = true;
            this.rbtnPasif.Text = "Pasif";
            this.rbtnPasif.UseVisualStyleBackColor = true;
            // 
            // frmKullaniciPanel
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKapat;
            this.ClientSize = new System.Drawing.Size(401, 228);
            this.Controls.Add(this.rbtnPasif);
            this.Controls.Add(this.rbtnAktif);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtIsim);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtSoyisim);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtSifreT);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtKullanici);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtKullaniciKodu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKullaniciPanel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Paneli";
            this.Load += new System.EventHandler(this.frmKullaniciPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKullanici.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifreT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyisim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciKodu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtKullanici;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private System.Windows.Forms.RadioButton rbtnAktif;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtSifreT;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtIsim;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtSoyisim;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit txtKullaniciKodu;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private System.Windows.Forms.RadioButton rbtnPasif;
    }
}