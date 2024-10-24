Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class pembayaran
    Dim disc, totbay, sisa As Double
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim dibayarr, sisaa
    Sub dbyr()
        Dim hitung As Long = 0
        For baris As Long = 0 To dgv.RowCount - 1
            hitung = hitung + dgv.Rows(baris).Cells(6).Value
        Next
        dibayarr = hitung
    End Sub
    Sub sis()
        Dim hitung As Long = 0
        For baris As Long = 0 To dgv.RowCount - 1
            hitung = hitung + dgv.Rows(baris).Cells(7).Value
        Next
        sisaa = hitung
    End Sub

    Sub tampil()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pembayaran"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pembayaran")
        dgv.DataSource = ds.Tables("pembayaran")
        kon.Close()
    End Sub
    Sub ambilnofak()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select nofaktur from trans_penjualan"
        cek = perintah.ExecuteReader
        While cek.Read
            cmbnofak.Items.Add(cek.Item("nofaktur"))

        End While
        kon.Close()
    End Sub
    Sub bersih()
        cmbnofak.Text = ""
        an.Text = ""
        Label12.Text = ""
        txtdiskon.Text = ""
        totbersih.Text = ""
        txtdibayar.Text = ""
        kembalian.Text = ""
        status.Text = ""
    End Sub
    Sub mati()
        cmbnofak.Enabled = False
        an.Enabled = False
        Label12.Enabled = False
        txtdiskon.Enabled = False
        totbersih.Enabled = False
        txtdibayar.Enabled = False
        kembalian.Enabled = False
        status.Enabled = False
    End Sub
    Sub hidup()
        cmbnofak.Enabled = True
        an.Enabled = True
        Label12.Enabled = True
        txtdiskon.Enabled = True
        totbersih.Enabled = True
        txtdibayar.Enabled = True
        kembalian.Enabled = True
        status.Enabled = True
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pembayaran where nofaktur like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pembayaran")
        dgv.DataSource = ds.Tables("pembayaran")
        kon.Close()
    End Sub

    Private Sub cmbnofak_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbnofak.SelectedIndexChanged
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_penjualan where nofaktur = '" & cmbnofak.Text & "'"
        cek = perintah.ExecuteReader
        cek.Read()

        If cek.HasRows Then
            cmbnofak.Text = cek.Item("kode_barang")
            an.Text = cek.Item("atas_nama")
            Label12.Text = cek.Item("jml_harga")
        End If
        kon.Close()
    End Sub
    Private Sub PD_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 500, 500)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub notelp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiskon.TextChanged
        disc = Val(Label12.Text) * Val(txtdiskon.Text) / 100
        totbay = Val(Label12.Text) - disc
        totbersih.Text = Format(totbay, "Rp###,###,###")
    End Sub

    Private Sub pembayaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ambilnofak()
        mati()
        tampil()

    End Sub

    Private Sub txtdibayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdibayar.TextChanged
        sisa = Val(txtdibayar.Text) - totbay
        kembalian.Text = sisa
    End Sub

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        If cmbnofak.Text = "" Or an.Text = "" Or dtp.Text = "" Or txtdiskon.Text = "" Or txtdibayar.Text = "" Or status.Text = "" Then
            MsgBox("Mohon Lengkapi Isian Data Anda...", MsgBoxStyle.Information, "Konfirmasi")
        Else
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            If simpan.Text = "SIMPAN" Then
                perintah.CommandText = "insert into pembayaran values ('" & cmbnofak.Text & "','" & an.Text & "','" & Format(dtp.Value, "yyyy-MM-dd") & "','" & Label12.Text & "','" &
                txtdiskon.Text & "','" & totbay & "','" & txtdibayar.Text & "','" & sisa & "','" & status.Text & "')"
            Else
                perintah.CommandText = "UPDATE pembayaran SET atas_nama='" & an.Text & "',tglbayar='" & Format(dtp.Value, "yyyy-MM-dd") & "',totalbelanja='" & Label12.Text & "',diskon='" & txtdiskon.Text & "',totbersih='" & totbay & "',dibayar='" & txtdibayar.Text & "',sisabayar='" & sisa & "',status='" & status.Text & "' WHERE nofaktur='" & cmbnofak.Text & "'"
            End If
            PPD.Document = PD
            PPD.ShowDialog()
            perintah.ExecuteNonQuery()
            kon.Close()
            tampil()
            MsgBox("Data Berhasil Disimpan...", MsgBoxStyle.Information, "Konfirmasi")
            bersih()
            mati()
            tambah.Enabled = True
            simpan.Enabled = False
            hapus.Enabled = True
            
        End If
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        hidup()
        tambah.Enabled = False
        simpan.Enabled = True
        hapus.Enabled = True
        simpan.Text = "SIMPAN"
    End Sub

    Private Sub batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles batal.Click
        bersih()
        mati()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = True
    End Sub

    Private Sub keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Me.Close()
        menu_utama.Show()

    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "delete from pembayaran where nofaktur='" & cmbnofak.Text & "'"
        perintah.ExecuteNonQuery()
        kon.Close()
        MsgBox("Data Terpilih Sudah Terhapus", MsgBoxStyle.Information, "Pesan")
        tampil()
        bersih()
        mati()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = True
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        simpan.Text = "Edit"
        cmbnofak.Enabled = False
        Try
            Dim i As Integer
            i = dgv.CurrentRow.Index
            With dgv.Rows.Item(i)
                hidup()
                tambah.Enabled = False
                cmbnofak.Text = .Cells(0).Value
                an.Text = .Cells(1).Value
                dtp.Text = .Cells(2).Value
                Label12.Text = .Cells(3).Value
                txtdiskon.Text = .Cells(4).Value
                totbersih.Text = .Cells(5).Value
                txtdibayar.Text = .Cells(6).Value
                kembalian.Text = .Cells(7).Value
                status.Text = .Cells(8).Value
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()
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
        garis = "================================================================================================================="

        sis()
        dbyr()
        e.Graphics.DrawString("Rumah Wallpaper Arvy", f14b, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl. Bunga Raya", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("Hp: 0895-5446-7490", f10, Brushes.Black, centermargin, 40, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 50, tengah)
        e.Graphics.DrawString("Nota Penjualan", f14b, Brushes.Black, centermargin, 60, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 80, tengah)

        e.Graphics.DrawString("No Faktur", f10b, Brushes.Black, 10, 90)
        e.Graphics.DrawString("Atas Nama", f10b, Brushes.Black, 100, 90)
        e.Graphics.DrawString("Total Belanja", f10b, Brushes.Black, 200, 90)
        e.Graphics.DrawString("Diskon", f10b, Brushes.Black, 310, 90)
        e.Graphics.DrawString("Total Bersih", f10b, Brushes.Black, 400, 90)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 100, tengah)

        Dim tinggi As New Integer
        Dim i As New Long
        'For baris As Integer = 0 To dgv.RowCount - 1
        'tinggi += 15

        'e.Graphics.DrawString(dgv.Rows(baris).Cells(0).Value.ToString, f10, Brushes.Black, 10, 110 + tinggi)
        'e.Graphics.DrawString(dgv.Rows(baris).Cells(1).Value.ToString, f10, Brushes.Black, 100, 110 + tinggi)
        'e.Graphics.DrawString(dgv.Rows(baris).Cells(3).Value.ToString, f10, Brushes.Black, 200, 110 + tinggi)
        'e.Graphics.DrawString(dgv.Rows(baris).Cells(4).Value.ToString, f10, Brushes.Black, 310, 110 + tinggi)
        'e.Graphics.DrawString(dgv.Rows(baris).Cells(5).Value.ToString, f10, Brushes.Black, 400, 110 + tinggi)

        'Next
        e.Graphics.DrawString(cmbnofak.Text, f10, Brushes.Black, 10, 110 + tinggi)
        e.Graphics.DrawString(an.Text, f10, Brushes.Black, 100, 110 + tinggi)
        e.Graphics.DrawString(Label12.Text, f10, Brushes.Black, 200, 110 + tinggi)
        e.Graphics.DrawString(txtdiskon.Text, f10, Brushes.Black, 310, 110 + tinggi)
        e.Graphics.DrawString(totbersih.Text, f10, Brushes.Black, 400, 110 + tinggi)

        'e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 255, tengah)
        'e.Graphics.DrawString("Dibayar", f10b, Brushes.Black, 10, 265)
        'e.Graphics.DrawString(Format(dibayarr, "Rp##,##0"), f10, Brushes.Black, 350, 265)
        'e.Graphics.DrawString("Sisa Bayar", f10b, Brushes.Black, 10, 280)
        'e.Graphics.DrawString(Format(sisaa, "Rp##,##0"), f10, Brushes.Black, 350, 280)
        'e.Graphics.DrawString("Status", f10b, Brushes.Black, 10, 295)
        'e.Graphics.DrawString(dgv.Rows(0).Cells(8).Value.ToString, f10, Brushes.Black, 350, 295)
        'e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 305, tengah)
    End Sub
End Class