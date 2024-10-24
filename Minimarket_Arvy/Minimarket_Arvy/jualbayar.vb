Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Public Class jualbayar
    Dim disc, totbay, sisa As Double
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim sisastok As Double
    Sub ambilkdbrg()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select kode_barang from barang"
        cek = perintah.ExecuteReader
        While cek.Read
            cmbkd.Items.Add(cek.Item("kode_barang"))
        End While
        kon.Close()
    End Sub
    Sub tampilpembayaran()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pembayaran"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pembayaran")
        dgv1.DataSource = ds.Tables("pembayaran")
        kon.Close()
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
    Sub bersih()
        nofak.Text = ""
        dtp.Text = ""
        an.Text = ""
        notelp.Text = ""
        cmbkd.Text = ""
        txtbeli.Text = ""
        jumlahharga.Text = ""
        Label12.Text = ""
        Label17.Text = ""
        txtdiskon.Text = ""
        totbersih.Text = ""
        txtdibayar.Text = ""
        kembalian.Text = ""
        status.Text = ""
    End Sub
    Sub mati()
        nofak.Enabled = False
        dtp.Enabled = False
        an.Enabled = False
        notelp.Enabled = False
        cmbkd.Enabled = False
        txtbeli.Enabled = False
        jumlahharga.Enabled = False
        Label12.Enabled = False
        txtdiskon.Enabled = False
        totbersih.Enabled = False
        txtdibayar.Enabled = False
        kembalian.Enabled = False
        status.Enabled = False
        hapus.Enabled = False
        simpan.Enabled = False
        batal.Enabled = False
    End Sub
    Sub hidup()
        dtp.Enabled = True
        an.Enabled = True
        notelp.Enabled = True
        cmbkd.Enabled = True
        txtbeli.Enabled = True
        jumlahharga.Enabled = True
        Label12.Enabled = True
        txtdiskon.Enabled = True
        totbersih.Enabled = True
        txtdibayar.Enabled = True
        kembalian.Enabled = True
        status.Enabled = True
        hapus.Enabled = True
        simpan.Enabled = True
        batal.Enabled = True
    End Sub
    Sub nofaktur()
        Dim kode, nofaktur As String
        Dim no As Integer
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select nofaktur from trans_penjualan order by nofaktur desc limit 1"
        cek = perintah.ExecuteReader
        cek.Read()
        If cek.HasRows Then
            kode = cek.Item("nofaktur")
            no = Val(Microsoft.VisualBasic.Right(kode, 3))
            no = no + 1
            nofaktur = "JU" + Format(dtp.Value, "yyyyMM") + Format(no, "0000")
            nofak.Text = nofaktur
        Else
            nofak.Text = "JU" + Format(dtp.Value, "yyyyMM") + "0001"
        End If
        cek.Close()
        kon.Close()
    End Sub
    Private Sub cmbkd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbkd.SelectedIndexChanged
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from barang where kode_barang = '" & cmbkd.Text & "'"
        cek = perintah.ExecuteReader
        cek.Read()

        If cek.HasRows Then
            cmbkd.Text = cek.Item("kode_barang")
            Label8.Text = cek.Item("harga")
            Label12.Text = cek.Item("merk")
            Label14.Text = cek.Item("motif")
            Label16.Text = cek.Item("jmlbrg")
            satuan.Text = cek.Item("satuan")
        End If
        kon.Close()
    End Sub

    Private Sub keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Me.Close()
        menu_utama.Show()

    End Sub

    Private Sub jualbayar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
        dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
        tampil()
        mati()
        ambilkdbrg()
        tampilpembayaran()
        nofaktur()
    End Sub

    Private Sub txtbeli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbeli.TextChanged
        jumlahharga.Text = Val(txtbeli.Text) * Val(Label8.Text)
        Label17.Text = jumlahharga.Text

        sisastok = Val(Label16.Text) - Val(txtbeli.Text)
        Label15.Text = sisastok
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        nofaktur()
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

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        simpan.Text = "Edit"
        nofak.Enabled = False
        Try
            Dim i As Integer
            i = dgv.CurrentRow.Index
            With dgv.Rows.Item(i)
                hidup()
                tambah.Enabled = False
                nofak.Text = .Cells(0).Value
                dtp.Text = .Cells(1).Value
                an.Text = .Cells(2).Value
                notelp.Text = .Cells(3).Value
                cmbkd.Text = .Cells(4).Value
                txtbeli.Text = .Cells(5).Value
                jumlahharga.Text = .Cells(6).Value
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_penjualan where nofaktur like '" & txtcari.Text & "%'"
        perintah.CommandText = "select * from pembayaran where nofaktur like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_penjualan")
        dgv.DataSource = ds.Tables("trans_penjualan")
        mda.Fill(ds, "pembayaran")
        dgv1.DataSource = ds.Tables("pembayaran")
        kon.Close()
    End Sub

    Private Sub txtdiskon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiskon.TextChanged
        disc = Val(Label17.Text) * Val(txtdiskon.Text) / 100
        totbay = Val(Label17.Text) - disc
        totbersih.Text = Format(totbay, "Rp.###,###,###")
    End Sub

    Private Sub txtdibayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdibayar.TextChanged
        sisa = Val(txtdibayar.Text) - totbay
        kembalian.Text = sisa
    End Sub

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click

        If nofak.Text = "" Or dtp.Text = "" Or an.Text = "" Or notelp.Text = "" Or cmbkd.Text = "" Or txtbeli.Text = "" Or jumlahharga.Text = "" Or txtdiskon.Text = "" Or txtdibayar.Text = "" Or status.Text = "" Then
            MsgBox("Mohon Lengkapi Isian Data Anda...", MsgBoxStyle.Information, "Konfirmasi")
        Else
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            If txtbeli.Text <= Val(Label16.Text) Then
                If simpan.Text = "SIMPAN" Then
                    perintah.CommandText = "insert into trans_penjualan values ('" & nofak.Text & "','" & Format(dtp.Value, "yyyy-MM-dd") & "','" & an.Text & "','" & notelp.Text & "','" &
                    cmbkd.Text & "','" & txtbeli.Text & "','" & jumlahharga.Text & "')"
                    perintah.ExecuteNonQuery()
                    perintah.CommandText = "insert into pembayaran values ('" & nofak.Text & "','" & an.Text & "','" & Format(dtp.Value, "yyyy-MM-dd") & "','" & Label17.Text & "','" &
                    txtdiskon.Text & "','" & totbay & "','" & txtdibayar.Text & "','" & sisa & "','" & status.Text & "')"
                    perintah.ExecuteNonQuery()
                    MsgBox("Data Berhasil Disimpan...", MsgBoxStyle.Information, "Konfirmasi")
                    For baris As Integer = 0 To dgv.Rows.Count - 2
                        Dim kurang As String = "update barang set jmlbrg= '" & sisastok & "' WHERE kode_barang='" & cmbkd.Text & "'"
                        perintah = New MySqlCommand(kurang, kon)
                        perintah.ExecuteNonQuery()
                    Next
                    PPD.Document = PD
                    PPD.ShowDialog()
                    'PD.Print()
                Else
                    perintah.CommandText = "UPDATE trans_penjualan SET tgltransaksi='" & Format(dtp.Value, "yyyy-MM-dd") & "',atas_nama='" & an.Text & "',notelp='" & notelp.Text & "',kode_barang='" & cmbkd.Text & "',jml_beli='" & txtbeli.Text & "',jml_harga='" & jumlahharga.Text & "' WHERE nofaktur='" & nofak.Text & "'"
                    perintah.ExecuteNonQuery()
                    perintah.CommandText = "UPDATE pembayaran SET atas_nama='" & an.Text & "',tglbayar='" & Format(dtp.Value, "yyyy-MM-dd") & "',totalbelanja='" & Label17.Text & "',diskon='" & txtdiskon.Text & "',totbersih='" & totbay & "',dibayar='" & txtdibayar.Text & "',sisabayar='" & sisa & "',status='" & status.Text & "' WHERE nofaktur='" & nofak.Text & "'"
                    perintah.ExecuteNonQuery()
                    MsgBox("Data Berhasil Disimpan...", MsgBoxStyle.Information, "Konfirmasi")
                End If
            Else
                MsgBox("Stok barang tidak cukup", MsgBoxStyle.Critical, "Alert")
            End If
            kon.Close()
            tampil()
            tampilpembayaran()
            bersih()
            mati()
            tambah.Enabled = True
            simpan.Enabled = False
            hapus.Enabled = True
        End If
    End Sub
    Private Sub PD_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 300, 500)
        PD.DefaultPageSettings = pagesetup
    End Sub
    Private Sub PD_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PD.PrintPage
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
        Dim i As New Long


        Dim garis As String
        Dim tinggi As New Integer
        
        garis = "================================================================================================================="
        tinggi += 20

        e.Graphics.DrawString("Rumah Wallpaper Arvy", f14b, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl. Bunga Raya", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("Hp: 0895-5446-7490", f10, Brushes.Black, centermargin, 40, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 50, tengah)
        e.Graphics.DrawString("Nota Penjualan", f14b, Brushes.Black, centermargin, 60, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 145, tengah)
        e.Graphics.DrawString("Kasir", f10b, Brushes.Black, 10, 90)
        e.Graphics.DrawString(menu_utama.username.Text, f10, Brushes.Black, 100, 90)
        e.Graphics.DrawString(DateTimePicker1.Value, f10, Brushes.Black, 10, 135)

        e.Graphics.DrawString("Atas Nama", f10b, Brushes.Black, 10, 105)
        e.Graphics.DrawString(an.Text, f10, Brushes.Black, 100, 105)

        e.Graphics.DrawString("No Faktur", f10b, Brushes.Black, 10, 120)
        e.Graphics.DrawString(nofak.Text, f10, Brushes.Black, 100, 120)

        e.Graphics.DrawString("Merk", f10b, Brushes.Black, 10, 155)
        e.Graphics.DrawString(Label12.Text, f10, Brushes.Black, 10, 155 + tinggi)

        e.Graphics.DrawString("Motif", f10b, Brushes.Black, 80, 155)
        e.Graphics.DrawString(Label14.Text, f10, Brushes.Black, 80, 155 + tinggi)

        e.Graphics.DrawString("Qty", f10b, Brushes.Black, 180, 155)
        e.Graphics.DrawString(txtbeli.Text, f10, Brushes.Black, 180, 155 + tinggi)
        e.Graphics.DrawString(satuan.Text, f10, Brushes.Black, 200, 155 + tinggi)

        e.Graphics.DrawString("Harga", f10b, Brushes.Black, 245, 155)
        e.Graphics.DrawString(Label8.Text, f10, Brushes.Black, 245, 155 + tinggi)

        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 255, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 145 + tinggi, tengah)


        e.Graphics.DrawString("Total Belanja", f10b, Brushes.Black, 10, 265)
        e.Graphics.DrawString(Label17.Text, f10, Brushes.Black, 140, 265)
        e.Graphics.DrawString("Rp.", f10, Brushes.Black, 110, 265)

        e.Graphics.DrawString("Diskon", f10b, Brushes.Black, 10, 280)
        e.Graphics.DrawString(txtdiskon.Text, f10, Brushes.Black, 140, 280)
        e.Graphics.DrawString("%", f10, Brushes.Black, 165, 280)

        e.Graphics.DrawString("Total Bayar", f10b, Brushes.Black, 10, 295)
        e.Graphics.DrawString(totbersih.Text, f10, Brushes.Black, 140, 295)
        'e.Graphics.DrawString("Rp.", f10, Brushes.Black, 260, 295)

        e.Graphics.DrawString("Dibayar", f10b, Brushes.Black, 10, 315)
        e.Graphics.DrawString(txtdibayar.Text, f10, Brushes.Black, 140, 315)
        e.Graphics.DrawString("Rp.", f10, Brushes.Black, 110, 315)

        e.Graphics.DrawString("Kembalian", f10b, Brushes.Black, 10, 335)
        e.Graphics.DrawString(kembalian.Text, f10, Brushes.Black, 140, 335)
        e.Graphics.DrawString("Rp.", f10, Brushes.Black, 110, 335)

        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 305, tengah)

        e.Graphics.DrawString("Thank You", f10b, Brushes.Black, centermargin, 450, tengah)
        e.Graphics.DrawString("Please Come Again", f10b, Brushes.Black, centermargin, 465, tengah)

        'For baris As Integer = 0 To dgv.RowCount - 1


        'e.Graphics.DrawString(dgv.Rows(baris).Cells(0).Value.ToString, f10, Brushes.Black, 10, 110 + tinggi)
        'e.Graphics.DrawString(dgv.Rows(baris).Cells(1).Value.ToString, f10, Brushes.Black, 100, 110 + tinggi)
        'e.Graphics.DrawString(dgv.Rows(baris).Cells(3).Value.ToString, f10, Brushes.Black, 200, 110 + tinggi)
        'e.Graphics.DrawString(dgv.Rows(baris).Cells(4).Value.ToString, f10, Brushes.Black, 310, 110 + tinggi)
        'e.Graphics.DrawString(dgv.Rows(baris).Cells(5).Value.ToString, f10, Brushes.Black, 400, 110 + tinggi)

        'Next
        
    End Sub

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Try
            Dim i As Integer
            i = dgv1.CurrentRow.Index
            With dgv1.Rows.Item(i)
                hidup()
                tambah.Enabled = False
                nofak.Text = .Cells(0).Value
                an.Text = .Cells(1).Value
                dtp.Text = .Cells(2).Value
                Label17.Text = .Cells(3).Value
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tbarang.Show()

    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "delete from trans_penjualan where nofaktur='" & nofak.Text & "'"
        perintah.ExecuteNonQuery()
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "delete from pembayaran where nofaktur='" & nofak.Text & "'"
        perintah.ExecuteNonQuery()
        kon.Close()
        MsgBox("Data Terpilih Sudah Terhapus", MsgBoxStyle.Information, "Pesan")
        tampil()
        tampilpembayaran()
        bersih()
        mati()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = True
    End Sub
End Class