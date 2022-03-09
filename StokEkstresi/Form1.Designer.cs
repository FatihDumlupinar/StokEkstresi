
namespace StokEkstresi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DgvStokEkstreListesi = new System.Windows.Forms.DataGridView();
            this.BtnAra = new System.Windows.Forms.Button();
            this.DtpTarihBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpTarihBitis = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCiktiAl = new System.Windows.Forms.Button();
            this.BtnYazdir = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.CmbStk = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStokEkstreListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvStokEkstreListesi
            // 
            this.DgvStokEkstreListesi.AllowUserToAddRows = false;
            this.DgvStokEkstreListesi.AllowUserToDeleteRows = false;
            this.DgvStokEkstreListesi.AllowUserToResizeColumns = false;
            this.DgvStokEkstreListesi.AllowUserToResizeRows = false;
            this.DgvStokEkstreListesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvStokEkstreListesi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvStokEkstreListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvStokEkstreListesi.Location = new System.Drawing.Point(12, 94);
            this.DgvStokEkstreListesi.MultiSelect = false;
            this.DgvStokEkstreListesi.Name = "DgvStokEkstreListesi";
            this.DgvStokEkstreListesi.ReadOnly = true;
            this.DgvStokEkstreListesi.RowHeadersWidth = 51;
            this.DgvStokEkstreListesi.RowTemplate.Height = 29;
            this.DgvStokEkstreListesi.Size = new System.Drawing.Size(815, 317);
            this.DgvStokEkstreListesi.TabIndex = 0;
            // 
            // BtnAra
            // 
            this.BtnAra.Location = new System.Drawing.Point(731, 43);
            this.BtnAra.Name = "BtnAra";
            this.BtnAra.Size = new System.Drawing.Size(96, 42);
            this.BtnAra.TabIndex = 1;
            this.BtnAra.Text = "Ara";
            this.BtnAra.UseVisualStyleBackColor = true;
            this.BtnAra.Click += new System.EventHandler(this.BtnAra_Click);
            // 
            // DtpTarihBaslangic
            // 
            this.DtpTarihBaslangic.Location = new System.Drawing.Point(160, 54);
            this.DtpTarihBaslangic.Name = "DtpTarihBaslangic";
            this.DtpTarihBaslangic.Size = new System.Drawing.Size(250, 27);
            this.DtpTarihBaslangic.TabIndex = 2;
            this.DtpTarihBaslangic.Value = new System.DateTime(2016, 11, 24, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Başlangıç";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bitiş";
            // 
            // DtpTarihBitis
            // 
            this.DtpTarihBitis.Location = new System.Drawing.Point(450, 52);
            this.DtpTarihBitis.Name = "DtpTarihBitis";
            this.DtpTarihBitis.Size = new System.Drawing.Size(250, 27);
            this.DtpTarihBitis.TabIndex = 4;
            this.DtpTarihBitis.Value = new System.DateTime(2017, 1, 24, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(416, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "STK";
            // 
            // BtnCiktiAl
            // 
            this.BtnCiktiAl.Location = new System.Drawing.Point(764, 417);
            this.BtnCiktiAl.Name = "BtnCiktiAl";
            this.BtnCiktiAl.Size = new System.Drawing.Size(63, 35);
            this.BtnCiktiAl.TabIndex = 9;
            this.BtnCiktiAl.Text = "Çıktı";
            this.BtnCiktiAl.UseVisualStyleBackColor = true;
            this.BtnCiktiAl.Click += new System.EventHandler(this.BtnCiktiAl_Click);
            // 
            // BtnYazdir
            // 
            this.BtnYazdir.Location = new System.Drawing.Point(684, 417);
            this.BtnYazdir.Name = "BtnYazdir";
            this.BtnYazdir.Size = new System.Drawing.Size(63, 35);
            this.BtnYazdir.TabIndex = 10;
            this.BtnYazdir.Text = "Yazdır";
            this.BtnYazdir.UseVisualStyleBackColor = true;
            this.BtnYazdir.Click += new System.EventHandler(this.BtnYazdir_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage_1);
            // 
            // CmbStk
            // 
            this.CmbStk.FormattingEnabled = true;
            this.CmbStk.Location = new System.Drawing.Point(12, 54);
            this.CmbStk.Name = "CmbStk";
            this.CmbStk.Size = new System.Drawing.Size(125, 28);
            this.CmbStk.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 464);
            this.Controls.Add(this.CmbStk);
            this.Controls.Add(this.BtnYazdir);
            this.Controls.Add(this.BtnCiktiAl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpTarihBitis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpTarihBaslangic);
            this.Controls.Add(this.BtnAra);
            this.Controls.Add(this.DgvStokEkstreListesi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Stok Ekstresi";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvStokEkstreListesi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvStokEkstreListesi;
        private System.Windows.Forms.Button BtnAra;
        private System.Windows.Forms.DateTimePicker DtpTarihBaslangic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpTarihBitis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCiktiAl;
        private System.Windows.Forms.Button BtnYazdir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ComboBox CmbStk;
    }
}

