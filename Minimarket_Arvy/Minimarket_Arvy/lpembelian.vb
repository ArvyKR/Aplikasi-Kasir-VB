Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class lpembelian
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim beli
    Sub totbeli()
        Dim hitung As Long = 0
        For baris As Long = 0 To dgv.RowCount - 1
            hitung = hitung + dgv.Rows(baris).Cells(7).Value
        Next
        beli = hitung
    End Sub

    Sub tampil()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_pembelian"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv.DataSource = ds.Tables("trans_pembelian")
        kon.Close()
    End Sub
    Private Sub lpembelian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub txtcari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.Click
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_pembelian where tgl_beli between'" & Format(dtp.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv.DataSource = ds.Tables("trans_pembelian")
        kon.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
    End Sub
    Private Sub PD_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 950, 500)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PD.PrintPage
        Dim f10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim f10b As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim f14b As New Font("Times New Roman", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim kanan As New StringFormat
        Dim tengah As New StringFormat
        kanan.Alignment = StringAlignment.Far
        tengah.Alignment = StringAlignment.Center

        Dim garis As String
        garis = "======================================================================================================================="

        totbeli()
        e.Graphics.DrawString("Rumah Wallpaper Arvy", f14b, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl. Bunga Raya", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("Hp: 0895-5446-7490", f10, Brushes.Black, centermargin, 40, tengah)
        'e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 50, tengah)
        e.Graphics.DrawString("Laporan Pembelian", f14b, Brushes.Black, centermargin, 50, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 80, tengah)

        e.Graphics.DrawString(Format(dtp.Value, "dd MMMM yyyy"), f10b, Brushes.Black, 10, 70)
        e.Graphics.DrawString("-", f10b, Brushes.Black, 130, 70)
        e.Graphics.DrawString(Format(DateTimePicker2.Value, "dd MMMM yyyy"), f10b, Brushes.Black, 140, 70)

        e.Graphics.DrawString("No Beli", f10b, Brushes.Black, 10, 90)
        e.Graphics.DrawString("Tanggal Beli", f10b, Brushes.Black, 120, 90)
        e.Graphics.DrawString("Nama Pemasok", f10b, Brushes.Black, 270, 90)
        e.Graphics.DrawString("Kode Barang", f10b, Brushes.Black, 390, 90)
        e.Graphics.DrawString("Merk", f10b, Brushes.Black, 500, 90)
        e.Graphics.DrawString("Jumlah Masuk", f10b, Brushes.Black, 590, 90)
        e.Graphics.DrawString("Harga Beli", f10b, Brushes.Black, 720, 90)
        e.Graphics.DrawString("Harga Satuan", f10b, Brushes.Black, 820, 90)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 100, tengah)

        dgv.AllowUserToAddRows = False
        Dim tinggi As New Integer
        Dim i As New Long
        For baris As Integer = 0 To dgv.RowCount - 1
            tinggi += 15

            e.Graphics.DrawString(dgv.Rows(baris).Cells(0).Value.ToString, f10, Brushes.Black, 10, 110 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(1).Value.ToString, f10, Brushes.Black, 120, 110 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(3).Value.ToString, f10, Brushes.Black, 270, 110 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(4).Value.ToString, f10, Brushes.Black, 390, 110 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(5).Value.ToString, f10, Brushes.Black, 500, 110 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(6).Value.ToString, f10, Brushes.Black, 590, 110 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(7).Value.ToString, f10, Brushes.Black, 720, 110 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(8).Value.ToString, f10, Brushes.Black, 820, 110 + tinggi)

        Next
        e.Graphics.DrawString("Total Pembelian : ", f10b, Brushes.Black, 600, 450)
        e.Graphics.DrawString(Format(beli, "Rp##,###"), f10b, Brushes.Black, 720, 450)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_pembelian where tgl_beli between'" & Format(dtp.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv.DataSource = ds.Tables("trans_pembelian")
        kon.Close()
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
    End Sub
End Class