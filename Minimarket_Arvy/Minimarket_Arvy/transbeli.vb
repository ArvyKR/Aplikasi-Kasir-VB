Public Class transbeli
    Dim jumbrg As Double

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
    Sub ambilkdb()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select kode_barang from barang"
        cek = perintah.ExecuteReader
        While cek.Read
            cmbkdb.Items.Add(cek.Item("kode_barang"))
        End While
        kon.Close()
    End Sub
    Sub ambilkdp()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select kode_pemasok from pemasok"
        cek = perintah.ExecuteReader
        While cek.Read
            cmbkdp.Items.Add(cek.Item("kode_pemasok"))
        End While
        kon.Close()
    End Sub
    Sub bersih()
        nobeli.Text = ""
        cmbkdp.Text = ""
        nama.Text = ""
        cmbkdb.Text = ""
        txtmerk.Text = ""
        txtmotif.Text = ""
        txtharga.Text = ""
        txtjmlbrg.Text = ""
        txtsatuan.Text = ""
        txtjumlahmasuk.Text = ""
        hargabeli.Text = ""
        hargasatuan.Text = ""
    End Sub
    Sub mati()
        nobeli.Enabled = False
        cmbkdp.Enabled = False
        nama.Enabled = False
        cmbkdb.Enabled = False
        txtmerk.Enabled = False
        txtjumlahmasuk.Enabled = False
        hargabeli.Enabled = False
        hargasatuan.Enabled = False
        hapus.Enabled = False
        simpan.Enabled = False
        batal.Enabled = False
    End Sub
    Sub hidup()
        cmbkdp.Enabled = True
        nama.Enabled = True
        cmbkdb.Enabled = True
        txtmerk.Enabled = True
        txtjumlahmasuk.Enabled = True
        hargabeli.Enabled = True
        hargasatuan.Enabled = True
        hapus.Enabled = True
        simpan.Enabled = True
        batal.Enabled = True
    End Sub
    Sub nofaktur()
        Dim kode, no_beli As String
        Dim no As Integer
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select no_beli from trans_pembelian order by no_beli desc limit 1"
        cek = perintah.ExecuteReader
        cek.Read()
        If cek.HasRows Then
            kode = cek.Item("no_beli")
            no = Val(Microsoft.VisualBasic.Right(kode, 3))
            no = no + 1
            no_beli = "BE" + Format(dtp.Value, "yyyyMM") + Format(no, "0000")
            nobeli.Text = no_beli
        Else
            nobeli.Text = "BE" + Format(dtp.Value, "yyyyMM") + "0001"
        End If
        cek.Close()
        kon.Close()
    End Sub
    Private Sub transbeli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ambilkdb()
        ambilkdp()
        tampil()
        mati()
        nofaktur()
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub cmbkdp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbkdp.SelectedIndexChanged
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pemasok where kode_pemasok = '" & cmbkdp.Text & "'"
        cek = perintah.ExecuteReader
        cek.Read()

        If cek.HasRows Then
            cmbkdp.Text = cek.Item("kode_pemasok")
            nama.Text = cek.Item("nama")
        End If
        kon.Close()
    End Sub

    Private Sub cmbkdb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbkdb.SelectedIndexChanged
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from barang where kode_barang = '" & cmbkdb.Text & "'"
        cek = perintah.ExecuteReader
        cek.Read()

        If cek.HasRows Then
            cmbkdb.Text = cek.Item("kode_barang")
            txtmerk.Text = cek.Item("merk")
            txtmotif.Text = cek.Item("motif")
            txtharga.Text = cek.Item("harga")
            txtjmlbrg.Text = cek.Item("jmlbrg")
            txtsatuan.Text = cek.Item("satuan")
        End If
        kon.Close()
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_pembelian where no_beli like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv.DataSource = ds.Tables("trans_pembelian")
        kon.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cekbarang.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cekpemasok.Show()

    End Sub

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        'barang
        txtjmlbrg.Text = Val(txtjmlbrg.Text) + Val(txtjumlahmasuk.Text)
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "UPDATE barang SET harga='" & txtharga.Text & "',jmlbrg='" & txtjmlbrg.Text & "' WHERE kode_barang='" & cmbkdb.Text & "'"
        perintah.ExecuteNonQuery()
        kon.Close()
        barang.tampil()
        'transbeli
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "insert into trans_pembelian values('" & nobeli.Text & "','" & Format(dtp.Value, "yyyy-MM-dd") & "','" & cmbkdp.Text & "','" & nama.Text & "','" & cmbkdb.Text & "','" & txtmerk.Text & "','" & txtjumlahmasuk.Text & "','" & hargabeli.Text & "','" & hargasatuan.Text & "')"
        perintah.ExecuteNonQuery()
        kon.Close()
        tampil()
        MsgBox("Data Berhasil Disimpan...", MsgBoxStyle.Information, "Konfirmasi")
        bersih()
        mati()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = False
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

        nobeli.Enabled = False
        Try
            Dim i As Integer
            i = dgv.CurrentRow.Index
            With dgv.Rows.Item(i)
                hidup()
                txtjumlahmasuk.Enabled = True
                hargabeli.Enabled = True
                tambah.Enabled = False
                simpan.Enabled = True
                hapus.Enabled = True
                nobeli.Text = .Cells(0).Value
                dtp.Text = .Cells(1).Value
                cmbkdp.Text = .Cells(2).Value
                nama.Text = .Cells(3).Value
                cmbkdb.Text = .Cells(4).Value
                txtjumlahmasuk.Text = .Cells(6).Value
                hargabeli.Text = .Cells(7).Value
                hargasatuan.Text = .Cells(8).Value
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Me.Close()
        menu_utama.Show()

    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "delete from trans_pembelian where no_beli='" &
        nobeli.Text & "' and kode_barang='" & cmbkdb.Text & "' and kode_pemasok='" &
        cmbkdp.Text & "'"
        perintah.ExecuteNonQuery()
        kon.Close()
        MsgBox("Data Terpilih Sudah Terhapus", MsgBoxStyle.Information, "Pesan")
        tampil()
        bersih()
        mati()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = False

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub hargabeli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hargabeli.TextChanged
        hargasatuan.Text = Val(hargabeli.Text) / Val(txtjumlahmasuk.Text)
    End Sub
End Class