using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Personell
{
    partial class frmpersonelIzınListesi
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
            this.izinTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gönderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yazdırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinFormuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPersonelAdi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblPersonelAdi = new System.Windows.Forms.Label();
            this.btnPersonelDegistir = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // izinTanımlaToolStripMenuItem
            // 
            this.izinTanımlaToolStripMenuItem.Name = "izinTanımlaToolStripMenuItem";
            this.izinTanımlaToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.izinTanımlaToolStripMenuItem.Text = "Kaydet";
            this.izinTanımlaToolStripMenuItem.Click += new System.EventHandler(this.izinTanımlaToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izinTanımlaToolStripMenuItem,
            this.gönderToolStripMenuItem,
            this.yazdırToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(932, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gönderToolStripMenuItem
            // 
            this.gönderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mailToolStripMenuItem,
            this.sMSToolStripMenuItem});
            this.gönderToolStripMenuItem.Name = "gönderToolStripMenuItem";
            this.gönderToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.gönderToolStripMenuItem.Text = "Gönder";
            // 
            // mailToolStripMenuItem
            // 
            this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
            this.mailToolStripMenuItem.Size = new System.Drawing.Size(113, 26);
            this.mailToolStripMenuItem.Text = "Mail";
            // 
            // sMSToolStripMenuItem
            // 
            this.sMSToolStripMenuItem.Name = "sMSToolStripMenuItem";
            this.sMSToolStripMenuItem.Size = new System.Drawing.Size(113, 26);
            this.sMSToolStripMenuItem.Text = "SMS";
            // 
            // yazdırToolStripMenuItem
            // 
            this.yazdırToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izinFormuToolStripMenuItem});
            this.yazdırToolStripMenuItem.Name = "yazdırToolStripMenuItem";
            this.yazdırToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.yazdırToolStripMenuItem.Text = "Yazdır";
            // 
            // izinFormuToolStripMenuItem
            // 
            this.izinFormuToolStripMenuItem.Name = "izinFormuToolStripMenuItem";
            this.izinFormuToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.izinFormuToolStripMenuItem.Text = "İzin Formu";
            // 
            // txtPersonelAdi
            // 
            this.txtPersonelAdi.Location = new System.Drawing.Point(110, 5);
            this.txtPersonelAdi.Name = "txtPersonelAdi";
            this.txtPersonelAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPersonelAdi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TCKIMLIKNO", "TC Kimlik No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PERSONELADI", "Personel Adı")});
            this.txtPersonelAdi.Properties.DisplayMember = "PERSONELADI";
            this.txtPersonelAdi.Properties.NullText = "";
            this.txtPersonelAdi.Size = new System.Drawing.Size(339, 22);
            this.txtPersonelAdi.TabIndex = 0;
            this.txtPersonelAdi.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(1, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Personel Adı :";
            // 
            // lblPersonelAdi
            // 
            this.lblPersonelAdi.AutoSize = true;
            this.lblPersonelAdi.Location = new System.Drawing.Point(107, 7);
            this.lblPersonelAdi.Name = "lblPersonelAdi";
            this.lblPersonelAdi.Size = new System.Drawing.Size(42, 17);
            this.lblPersonelAdi.TabIndex = 2;
            this.lblPersonelAdi.Text = "label1";
            // 
            // btnPersonelDegistir
            // 
            this.btnPersonelDegistir.Location = new System.Drawing.Point(360, 4);
            this.btnPersonelDegistir.Name = "btnPersonelDegistir";
            this.btnPersonelDegistir.Size = new System.Drawing.Size(122, 23);
            this.btnPersonelDegistir.TabIndex = 3;
            this.btnPersonelDegistir.Text = "Personel Değiştir";
            this.btnPersonelDegistir.UseVisualStyleBackColor = true;
            this.btnPersonelDegistir.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblPersonelAdi);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnPersonelDegistir);
            this.panelControl1.Controls.Add(this.txtPersonelAdi);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 28);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(932, 39);
            this.panelControl1.TabIndex = 4;
            // 
            // frmpersonelIzınListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 542);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmpersonelIzınListesi";
            this.Text = "frmpersonelIzınListesi";
            this.Load += new System.EventHandler(this.frmpersonelIzınListesi_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem izinTanımlaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraEditors.LookUpEdit txtPersonelAdi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label lblPersonelAdi;
        private System.Windows.Forms.Button btnPersonelDegistir;
        private System.Windows.Forms.ToolStripMenuItem gönderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yazdırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinFormuToolStripMenuItem;
        private PanelControl panelControl1;
    }
}