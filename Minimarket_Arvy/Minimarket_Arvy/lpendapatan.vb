Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class lpendapatan
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim jual, beli, barang, laba, clean
    Sub untung()
        laba = clean - beli
    End Sub
    Sub totjual()
        Dim hitung As Long = 0
        For baris As Long = 0 To dgv1.RowCount - 1
            hitung = hitung + dgv1.Rows(baris).Cells(6).Value
        Next
        jual = hitung
    End Sub
    Sub totbeli()
        Dim hitung As Long = 0
        For baris As Long = 0 To dgv2.RowCount - 1
            hitung = hitung + dgv2.Rows(baris).Cells(7).Value
        Next
        beli = hitung
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

    Sub tampilbarang()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from barang"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "barang")
        dgv.DataSource = ds.Tables("barang")
        kon.Close()
    End Sub
    Sub tampiljual()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_penjualan"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_penjualan")
        dgv1.DataSource = ds.Tables("trans_penjualan")
        kon.Close()
    End Sub
    Sub tampilbeli()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_pembelian"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv2.DataSource = ds.Tables("trans_pembelian")
        kon.Close()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_penjualan where tgltransaksi between'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_penjualan")
        dgv1.DataSource = ds.Tables("trans_penjualan")
        perintah.CommandText = "select * from trans_pembelian where tgl_beli between'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv2.DataSource = ds.Tables("trans_pembelian")
        kon.Close()
    End Sub

    Private Sub lpendapatan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
        tampilbayar()
        tampilbarang()
        tampiljual()
        tampilbeli()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
    End Sub
    Private Sub PD_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 300, 400)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PD.PrintPage
        Dim f10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim f10b As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim f14b As New Font("Times New Roman", 14, FontStyle.Bold)
        Dim f8b As New Font("Times New Roman", 8, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim kanan As New StringFormat
        Dim tengah As New StringFormat
        kanan.Alignment = StringAlignment.Far
        tengah.Alignment = StringAlignment.Center

        Dim garis As String
        garis = "================================================================================================================="

        totjual()
        totbeli()
        totbersih()
        laba = clean - beli

        e.Graphics.DrawString("Rumah Wallpaper Arvy", f14b, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl. Bunga Raya", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("Hp: 0895-5446-7490", f10, Brushes.Black, centermargin, 40, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 50, tengah)
        e.Graphics.DrawString("Laporan Pendapatan", f14b, Brushes.Black, centermargin, 60, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 80, tengah)

        e.Graphics.DrawString(Format(DateTimePicker1.Value, "dd MMMM yyyy"), f8b, Brushes.Black, 10, 90)
        e.Graphics.DrawString("-", f8b, Brushes.Black, 110, 90)
        e.Graphics.DrawString(Format(DateTimePicker2.Value, "dd MMMM yyyy"), f8b, Brushes.Black, 120, 90)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 100, tengah)

        e.Graphics.DrawString("Total Penjualan : ", f10, Brushes.Black, 10, 120)
        e.Graphics.DrawString(Format(clean, " Rp##,###"), f10, Brushes.Black, 190, 120)
        e.Graphics.DrawString("Total Pembelian : ", f10, Brushes.Black, 10, 135)
        e.Graphics.DrawString(Format(beli, " Rp##,###"), f10, Brushes.Black, 190, 135)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 150, tengah)
        e.Graphics.DrawString("Total Pendapatan/Untung : ", f10, Brushes.Black, 10, 160)
        e.Graphics.DrawString(Format(laba, " Rp##,###"), f10, Brushes.Black, 190, 160)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_pembelian where tgl_beli between'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv2.DataSource = ds.Tables("trans_pembelian")
        perintah.CommandText = "select * from pembayaran where tglbayar between'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pembayaran")
        dgv3.DataSource = ds.Tables("pembayaran")
        kon.Close()
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
    End Sub
End Class