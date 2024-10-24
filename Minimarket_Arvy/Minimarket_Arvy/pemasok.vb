Public Class pemasok

    Sub tampil()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pemasok"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pemasok")
        dgv.DataSource = ds.Tables("pemasok")
        kon.Close()
    End Sub
    Sub bersih()
        txtalamat.Text = ""
        txthp.Text = ""
        txtkd.Text = ""
        txtnama.Text = ""
    End Sub
    Sub mati()
        txtalamat.Enabled = False
        txthp.Enabled = False
        txtkd.Enabled = False
        txtnama.Enabled = False
    End Sub
    Sub hidup()
        txtalamat.Enabled = True
        txthp.Enabled = True
        txtnama.Enabled = True
    End Sub
    Sub nofaktur()
        Dim kode, nofaktur As String
        Dim no As Integer
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select kode_pemasok from pemasok order by kode_pemasok desc limit 1"
        cek = perintah.ExecuteReader
        cek.Read()
        If cek.HasRows Then
            kode = cek.Item("kode_pemasok")
            no = Val(Microsoft.VisualBasic.Right(kode, 3))
            no = no + 1
            nofaktur = "PE" + Format(dtp.Value, "yyyyMM") + Format(no, "0000")
            txtkd.Text = nofaktur
        Else
            txtkd.Text = "PE" + Format(dtp.Value, "yyyyMM") + "0001"
        End If
        cek.Close()
        kon.Close()
    End Sub
    Private Sub txtkd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkd.TextChanged
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pemasok where kode_pemasok='" & txtkd.Text & "'"
        cek = perintah.ExecuteReader
        cek.Read()
        If cek.HasRows Then
            txtnama.Text = cek.Item("nama")
            txtalamat.Text = cek.Item("alamat")
            txthp.Text = cek.Item("notelp")
        Else
            txtnama.Text = ""
            txtalamat.Text = ""
            txthp.Text = ""
        End If
        kon.Close()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        nofaktur()
        hidup()
        tambah.Enabled = False
        simpan.Enabled = True
        hapus.Enabled = True
        simpan.Text = "SIMPAN"
    End Sub

    Private Sub keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Me.Close()
        menu_utama.Show()
    End Sub

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        If txtkd.Text = "" Or txtnama.Text = "" Or txtalamat.Text = "" Or txthp.Text = "" Then
            MsgBox("Mohon Lengkapi Isian Data Anda...", MsgBoxStyle.Information, "Konfirmasi")
        Else
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            If simpan.Text = "SIMPAN" Then
                perintah.CommandText = "insert into pemasok values ('" & txtkd.Text & "','" &
                txtnama.Text & "','" & txtalamat.Text & "','" & txthp.Text & "')"
            Else
                perintah.CommandText = "UPDATE pemasok SET nama='" & txtnama.Text & "',alamat='" & txtalamat.Text & "',notelp='" & txthp.Text & "' WHERE kode_pemasok='" & txtkd.Text & "'"
            End If
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

    Private Sub pemasok_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nofaktur()
        mati()
        tampil()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = False
        dgv.Columns(0).Width = 200
        dgv.Columns(1).Width = 250
        dgv.Columns(2).Width = 150
        dgv.Columns(3).Width = 150
        dgv.Font = New Font("Calibri", 11)
        dgv.Columns(0).HeaderText = "KODE PEMASOK"
        dgv.Columns(1).HeaderText = "NAMA PEMASOK"
        dgv.Columns(2).HeaderText = "ALAMAT"
        dgv.Columns(3).HeaderText = "NO HP"
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        simpan.Text = "EDIT"
        txtkd.Enabled = False
        Try
            Dim i As Integer
            i = dgv.CurrentRow.Index
            With dgv.Rows.Item(i)
                hidup()
                tambah.Enabled = False
                simpan.Enabled = True
                hapus.Enabled = True
                txtkd.Text = .Cells(0).Value
                txtnama.Text = .Cells(1).Value
                txtalamat.Text = .Cells(2).Value
                txthp.Text = .Cells(3).Value
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "delete from pemasok where kode_pemasok='" & txtkd.Text & "'"
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

    Private Sub batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles batal.Click
        bersih()
        mati()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = True
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pemasok where nama like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pemasok")
        dgv.DataSource = ds.Tables("pemasok")
        kon.Close()
    End Sub
End Class