using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StokEkstresi
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Data Source=DESKTOP-IHLCDJ5; Initial Catalog=Test; Integrated Security=True";

        private List<Stk> Stks { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Stk Combobox unu dolduruyoruz

            using SqlConnection connection = new(connectionString);
            using SqlCommand cmd = new("SELECT [ID], [MalKodu], [MalAdi] FROM [Test].[dbo].[STK]", connection);

            System.Data.DataTable dt = new();
            SqlDataAdapter da = new(cmd);
            da.Fill(dt);

            Stks = dt.AsEnumerable().Select(r => new Stk() { MalAdi = r.Field<string>("MalAdi"), MalKodu = r.Field<string>("MalKodu") }).ToList();

            CmbStk.Items.AddRange(Stks.Select(i => i.MalAdi).ToArray());

            #endregion

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if (CmbStk.SelectedItem == default || DtpTarihBaslangic.Value == default || DtpTarihBitis.Value == default)
            {
                MessageBox.Show("Mal kodu, Başlangıç ve Bitiş tarih kısımlarını boş bırakmayın.");
                return;
            }

            var cmbSelectedStk = Stks.First(i => i.MalAdi.Equals(CmbStk.SelectedItem));//seçilen stk

            var baslangicTarihi = Convert.ToInt32(DtpTarihBaslangic.Value.ToOADate());
            var bitisTarihi = Convert.ToInt32(DtpTarihBitis.Value.ToOADate());

            using SqlConnection connection = new(connectionString);

            using SqlCommand cmd = new("StokListele", connection);
            cmd.Parameters.Add(new SqlParameter("@Malkodu", cmbSelectedStk.MalKodu));
            cmd.Parameters.Add(new SqlParameter("@BaslangicTarihi", baslangicTarihi));
            cmd.Parameters.Add(new SqlParameter("@BitisTarihi", bitisTarihi));
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new(cmd);

            System.Data.DataTable stokDataList = new();
            adapter.Fill(stokDataList);
            DgvStokEkstreListesi.DataSource = stokDataList;
        }

        private void BtnCiktiAl_Click(object sender, EventArgs e)
        {
            if (DgvStokEkstreListesi.Rows.Count==0)
            {
                MessageBox.Show("Çıktı alınacak veri bulunamadı.");
                return;
            }

            //Not: COM References den Excel 16 kütüphanesi seçildi

            // excel oluştur  
            var app = new Microsoft.Office.Interop.Excel.Application();

            // excel in içine workbook oluştur
            var workbook = app.Workbooks.Add(Type.Missing);

            // uygulamanın arkasında excel açılsın
            app.Visible = true;

            // Sayfa1 diye bir worksheet oluştur ve bu worksheet i default yap
            _Worksheet worksheet = default;
            worksheet = workbook.Sheets["Sayfa1"];
            worksheet = workbook.ActiveSheet;

            // worksheet e isim ver 
            worksheet.Name = "Stok Ekstersi";

            // Excel deki sütunları doldur  
            for (int i = 1; i < DgvStokEkstreListesi.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DgvStokEkstreListesi.Columns[i - 1].HeaderText;
            }

            // excel deki satır ve hücreleri doldur
            for (int i = 0; i < DgvStokEkstreListesi.Rows.Count - 1; i++)
            {
                for (int j = 0; j < DgvStokEkstreListesi.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DgvStokEkstreListesi.Rows[i].Cells[j].Value.ToString();
                }
            }

            //kullanıcının masaüstünün dosya yolunu bul
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //excel dosyasına bugünün tarihini formatlayarak ver
            var fileName = DateTime.Now.ToString("yyyy-MM-dd");

            // dosyayı masaüstüne kaydet
            workbook.SaveAs($"{desktopPath}\\{fileName}.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        }

        private void BtnYazdir_Click(object sender, EventArgs e)
        {
            PrintDialog daraGridViewPrintDialog = new PrintDialog();
            daraGridViewPrintDialog.Document = printDocument1;
            daraGridViewPrintDialog.UseEXDialog = true;

            if (DialogResult.OK == daraGridViewPrintDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Stok Ekstresi";
                printDocument1.Print();

            }

        }

        private void PrintDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //create Bitmap and add/draw datagridview to it 
            Bitmap dataGridViewBitmap = new(DgvStokEkstreListesi.Width, DgvStokEkstreListesi.Height);

            DgvStokEkstreListesi.DrawToBitmap(dataGridViewBitmap, new System.Drawing.Rectangle(0, 0, DgvStokEkstreListesi.Width, DgvStokEkstreListesi.Height));

            e.Graphics.DrawImage(dataGridViewBitmap, 0, 0);
        }

    }
}
