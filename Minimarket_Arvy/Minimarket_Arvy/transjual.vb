Imports MySql.Data.MySqlClient

Public Class transjual
    Dim brg As Double
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
    End Sub
    Sub mati()
        nofak.Enabled = False
        dtp.Enabled = False
        an.Enabled = False
        notelp.Enabled = False
        cmbkd.Enabled = False
        txtbeli.Enabled = False
        jumlahharga.Enabled = False
    End Sub
    Sub hidup()
        nofak.Enabled = True
        dtp.Enabled = True
        an.Enabled = True
        notelp.Enabled = True
        cmbkd.Enabled = True
        txtbeli.Enabled = True
        jumlahharga.Enabled = True
    End Sub
    Private Sub transjual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ambilkdbrg()
        tampil()
        mati()

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
        End If
        kon.Close()
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbeli.TextChanged
        jumlahharga.Text = Val(txtbeli.Text) * Val(Label8.Text)
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from trans_penjualan where nofaktur like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_penjualan")
        dgv.DataSource = ds.Tables("trans_penjualan")
        kon.Close()
    End Sub

    Private Sub nofak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nofak.TextChanged
        
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

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        If nofak.Text = "" Or dtp.Text = "" Or an.Text = "" Or notelp.Text = "" Or cmbkd.Text = "" Or txtbeli.Text = "" Or jumlahharga.Text = "" Then
            MsgBox("Mohon Lengkapi Isian Data Anda...", MsgBoxStyle.Information, "Konfirmasi")

        Else
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            If Label16.Text >= txtbeli.Text Then
                If simpan.Text = "SIMPAN" Then
                    perintah.CommandText = "insert into trans_penjualan values ('" & nofak.Text & "','" & Format(dtp.Value, "yyyy-MM-dd") & "','" & an.Text & "','" & notelp.Text & "','" &
                    cmbkd.Text & "','" & txtbeli.Text & "','" & jumlahharga.Text & "')"
                    perintah.ExecuteNonQuery()
                    MsgBox("Data Berhasil Disimpan...", MsgBoxStyle.Information, "Konfirmasi")
                    For baris As Integer = 0 To dgv.Rows.Count - 1
                        Label15.Text = Val(Label16.Text) - Val(txtbeli.Text)
                        Dim kurang As String = "update barang set jmlbrg= '" & Label15.Text & "'WHERE kode_barang='" & cmbkd.Text & "'"
                        perintah = New MySqlCommand(kurang, kon)
                        perintah.ExecuteNonQuery()
                    Next
                Else
                    perintah.CommandText = "UPDATE trans_penjualan SET tgltransaksi='" & Format(dtp.Value, "yyyy-MM-dd") & "',atas_nama='" & an.Text & "',notelp='" & notelp.Text & "',kode_barang='" & cmbkd.Text & "',jml_beli='" & txtbeli.Text & "',jml_harga='" & jumlahharga.Text & "' WHERE nofaktur='" & nofak.Text & "'"
                    perintah.ExecuteNonQuery()
                    MsgBox("Data Berhasil Disimpan...", MsgBoxStyle.Information, "Konfirmasi")
                End If
            Else
                MsgBox("Stok barang tidak cukup", MsgBoxStyle.Critical, "Alert")
            End If
            kon.Close()
            tampil()
            bersih()
            mati()
            tambah.Enabled = True
            simpan.Enabled = False
            hapus.Enabled = True
        End If
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "delete from trans_penjualan where nofaktur='" & nofak.Text & "'"
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
End Class