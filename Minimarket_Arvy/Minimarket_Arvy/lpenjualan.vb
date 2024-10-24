Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class lpenjualan
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog

    Dim totalpenjualan, clean
    Sub total()
        Dim hitung As Long = 0
        For baris As Long = 0 To dgv.RowCount - 1
            hitung = hitung + dgv.Rows(baris).Cells(6).Value
        Next
        totalpenjualan = hitung
    End Sub
    Sub tampil()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_penjualan"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_penjualan")
        dgv.DataSource = ds.Tables("trans_penjualan")
        kon.Close()
    End Sub
    Sub tampilbayar()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pembayaran"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pembayaran")
        dgv3.DataSource = ds.Tables("pembayaran")
        kon.Close()
    End Sub
    Sub totbersih()
        Dim hitung As Long = 0
        For baris As Long = 0 To dgv3.RowCount - 1
            hitung = hitung + dgv3.Rows(baris).Cells(5).Value
        Next
        clean = hitung
    End Sub
    Private Sub lpenjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampilbayar()
        tampil()
        dgv.AllowUserToAddRows = True
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.Click
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_penjualan where tgltransaksi between'" & Format(dtp.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_penjualan")
        dgv.DataSource = ds.Tables("trans_penjualan")
        kon.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
    End Sub

    Private Sub PD_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 830, 600)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PD.PrintPage
        Dim f10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim f10b As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim f14b As New Font("Times New Roman", 14, FontStyle.Bold)
        Dim f8 As New Font("Times New Roman", 8, FontStyle.Regular)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim kanan As New StringFormat
        Dim tengah As New StringFormat
        kanan.Alignment = StringAlignment.Far
        tengah.Alignment = StringAlignment.Center


        Dim garis As String
        garis = "================================================================================================================="

        total()
        totbersih()
        e.Graphics.DrawString("Rumah Wallpaper Arvy", f14b, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl. Bunga Raya", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("Hp: 0895-5446-7490", f10, Brushes.Black, centermargin, 40, tengah)
        'e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 50, tengah)
        e.Graphics.DrawString("Laporan Penjualan", f14b, Brushes.Black, centermargin, 50, tengah)

        e.Graphics.DrawString(Format(dtp.Value, "dd MMMM yyyy"), f10b, Brushes.Black, 10, 70)
        e.Graphics.DrawString("-", f10b, Brushes.Black, 130, 70)
        e.Graphics.DrawString(Format(DateTimePicker2.Value, "dd MMMM yyyy"), f10b, Brushes.Black, 140, 70)

        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 80, tengah)

        e.Graphics.DrawString("No Faktur", f10b, Brushes.Black, 10, 90)
        e.Graphics.DrawString("Tanggal Transaksi", f10b, Brushes.Black, 110, 90)
        e.Graphics.DrawString("Atas Nama", f10b, Brushes.Black, 270, 90)
        e.Graphics.DrawString("No Telp", f10b, Brushes.Black, 390, 90)
        e.Graphics.DrawString("Kode Barang", f10b, Brushes.Black, 500, 90)
        e.Graphics.DrawString("Jumlah Beli", f10b, Brushes.Black, 620, 90)
        e.Graphics.DrawString("Jumlah Harga", f10b, Brushes.Black, 720, 90)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 100, tengah)

        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 560, tengah)
        e.Graphics.DrawString("Total Penjualan : ", f10, Brushes.Black, 600, 570)
        e.Graphics.DrawString(Format(clean, "Rp##,##0"), f10, Brushes.Black, 720, 570)

        dgv.AllowUserToAddRows = False
        Dim tinggi As New Integer
        Dim i As New Long
        For baris As Integer = 0 To dgv.RowCount - 1
            tinggi += 15

            e.Graphics.DrawString(dgv.Rows(baris).Cells(0).Value.ToString, f10, Brushes.Black, 10, 105 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(1).Value.ToString, f10, Brushes.Black, 110, 105 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(2).Value.ToString, f10, Brushes.Black, 270, 105 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(3).Value.ToString, f10, Brushes.Black, 390, 105 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(4).Value.ToString, f10, Brushes.Black, 500, 105 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(5).Value.ToString, f10, Brushes.Black, 620, 105 + tinggi)
            e.Graphics.DrawString(dgv3.Rows(baris).Cells(5).Value.ToString, f10, Brushes.Black, 720, 105 + tinggi)
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_penjualan where tgltransaksi between'" & Format(dtp.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_penjualan")
        dgv.DataSource = ds.Tables("trans_penjualan")
        perintah.CommandText = "select * from pembayaran where tglbayar between'" & Format(dtp.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pembayaran")
        dgv3.DataSource = ds.Tables("pembayaran")
        kon.Close()

        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

    End Sub
End Class