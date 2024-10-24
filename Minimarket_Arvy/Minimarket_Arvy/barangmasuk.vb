Public Class barangmasuk

    Sub bersih()
        txtkd.Text = ""
        txtmerk.Text = ""
        txtjmlbrg.Text = ""
        txtpersediaan.Text = ""
        txtmotif.Text = ""
    End Sub
    Sub mati()
        txtkd.Enabled = False
        txtmerk.Enabled = False
        txtpersediaan.Enabled = False
        txtjmlbrg.Enabled = False
        txtmotif.Enabled = False
        txtsatuan.Enabled = False
    End Sub
    Sub hidup()
        txtkd.Enabled = True
        txtjmlbrg.Enabled = True
    End Sub
    Sub ambilkdbrg()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select kode_barang from barang"
        cek = perintah.ExecuteReader
        While cek.Read
            txtkd.Items.Add(cek.Item("kode_barang"))
            
        End While
        kon.Close()
    End Sub
    Private Sub barangmasuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ambilkdbrg()
        mati()

    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        hidup()
        tambah.Enabled = False
        simpan.Enabled = True
        simpan.Text = "SIMPAN"
    End Sub

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        If txtkd.Text = "" Or txtmerk.Text = "" Or txtmotif.Text = "" Or txtpersediaan.Text = "" Or txtjmlbrg.Text = "" Then
            MsgBox("Mohon Lengkapi Isian Data Anda...", MsgBoxStyle.Information, "Konfirmasi")
        Else
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            If simpan.Text = "SIMPAN" Then
                txtpersediaan.Text = Val(txtpersediaan.Text) + Val(txtjmlbrg.Text)
                perintah.CommandText = "UPDATE barang SET jmlbrg='" & txtpersediaan.Text & "' WHERE kode_barang='" & txtkd.Text & "'"
            End If
            perintah.ExecuteNonQuery()
            kon.Close()
            MsgBox("Data Berhasil Disimpan...", MsgBoxStyle.Information, "Konfirmasi")
            bersih()
            mati()
            tambah.Enabled = True
            simpan.Enabled = False
        End If
    End Sub

    Private Sub txtkd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkd.SelectedIndexChanged
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from barang where kode_barang = '" & txtkd.Text & "'"
        cek = perintah.ExecuteReader
        cek.Read()

        If cek.HasRows Then
            txtkd.Text = cek.Item("kode_barang")
            txtmerk.Text = cek.Item("merk")
            txtmotif.Text = cek.Item("motif")
            txtpersediaan.Text = cek.Item("jmlbrg")
            txtsatuan.Text = cek.Item("satuan")
        End If
        kon.Close()
        
    End Sub

    Private Sub keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Me.Hide()
        menu_utama.Show()

    End Sub

    Private Sub batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles batal.Click
        mati()
        bersih()

    End Sub
End Class