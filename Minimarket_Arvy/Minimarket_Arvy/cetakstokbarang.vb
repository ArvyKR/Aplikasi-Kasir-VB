Imports System.Drawing.Printing
Public Class cetakstokbarang
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Sub tampil()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select barang.kode_barang, barang.merk, barang.motif, barang.jmlbrg from barang"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "barang")
        dgv.DataSource = ds.Tables("barang")
        kon.Close()
    End Sub

    Private Sub PD_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 400, 500)
        PD.DefaultPageSettings = pagesetup
    End Sub
    Private Sub PD_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PD.PrintPage
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
        garis = "============================================================================"

        e.Graphics.DrawString("Rumah Wallpaper Arvy", f14b, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl. Bunga Raya", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("Hp: 0895-5446-7490", f10, Brushes.Black, centermargin, 40, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 50, tengah)

        e.Graphics.DrawString("Kode Barang", f10b, Brushes.Black, 10, 60)
        e.Graphics.DrawString("Merk", f10b, Brushes.Black, 125, 60)
        e.Graphics.DrawString("Motif", f10b, Brushes.Black, 230, 60)
        e.Graphics.DrawString("Jumlah", f10b, Brushes.Black, 330, 60)
        dgv.AllowUserToAddRows = True
        Dim tinggi As New Integer
        Dim i As New Long
        For baris As Integer = 0 To dgv.RowCount - 2
            tinggi += 15

            e.Graphics.DrawString(dgv.Rows(baris).Cells(0).Value.ToString, f10, Brushes.Black, 10, 60 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(1).Value.ToString, f10, Brushes.Black, 125, 60 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(2).Value.ToString, f10, Brushes.Black, 230, 60 + tinggi)
            e.Graphics.DrawString(dgv.Rows(baris).Cells(3).Value.ToString, f10, Brushes.Black, 330, 60 + tinggi)
        Next
    End Sub

    Private Sub cetakstokbarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from barang where kode_barang like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "barang")
        dgv.DataSource = ds.Tables("barang")
        kon.Close()
    End Sub
End Class