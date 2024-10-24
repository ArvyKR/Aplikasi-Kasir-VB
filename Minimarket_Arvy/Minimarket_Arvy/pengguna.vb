Public Class pengguna

    Sub tampil()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pengguna"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pengguna")
        dgv.DataSource = ds.Tables("pengguna")
        kon.Close()
    End Sub
    Sub tampiluser(ByVal sql As String)
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = sql
        mda.SelectCommand = perintah
        Dim datas As New DataSet
        mda.Fill(datas, "pengguna")
        dgv.DataSource = datas.Tables("pengguna")
        kon.Close()
    End Sub
    Sub bersih()
        txtuser.Text = ""
        txtpass.Text = ""
        txtfull.Text = ""
        cmbstatus.Text = ""
    End Sub
    Sub mati()
        txtuser.Enabled = False
        txtpass.Enabled = False
        txtfull.Enabled = False
        cmbstatus.Enabled = False
    End Sub
    Sub hidup()
        txtuser.Enabled = True
        txtpass.Enabled = True
        txtfull.Enabled = True
        cmbstatus.Enabled = True
        simpan.Enabled = True
    End Sub
    Private Sub txtuser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.TextChanged
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pengguna where username='" & txtuser.Text & "'"
        cek = perintah.ExecuteReader
        cek.Read()
        If cek.HasRows Then
            txtfull.Text = cek.Item("userfullname")
            cmbstatus.Text = cek.Item("useraktif")
        Else
            txtfull.Text = ""
            cmbstatus.Text = ""
        End If
        kon.Close()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        hidup()
        tambah.Enabled = False
        simpan.Enabled = True
        hapus.Enabled = True
        simpan.Text = "SIMPAN"
    End Sub

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        If txtuser.Text = "" Or txtfull.Text = "" Or txtpass.Text = "" Or cmbstatus.Text = "" Then
            MsgBox("Mohon Lengkapi Isian Data Anda...", MsgBoxStyle.Information, "Konfirmasi")
        Else
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            If simpan.Text = "SIMPAN" Then
                perintah.CommandText = "insert into pengguna values ('" & txtuser.Text & "','" &
            txtfull.Text & "',MD5('" & txtpass.Text & "'),'" & cmbstatus.Text & "')"
            Else
                perintah.CommandText = "UPDATE pengguna SET userfullname='" & txtfull.Text & "',userpass='" & txtpass.Text & "',useraktif='" & cmbstatus.Text & "' WHERE username='" & txtuser.Text & "'"
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

    Private Sub pengguna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mati()
        tampil()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = True
        dgv.Columns(0).Width = 200
        dgv.Columns(1).Width = 250
        dgv.Columns(2).Width = 150
        dgv.Columns(3).Width = 150
        dgv.Font = New Font("Calibri", 11)
        dgv.Columns(0).HeaderText = "USERNAME"
        dgv.Columns(1).HeaderText = "FULLNAME"
        dgv.Columns(2).HeaderText = "PASSWORD"
        dgv.Columns(3).HeaderText = "USER AKTIF"
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        simpan.Text = "Edit"
        txtuser.Enabled = False
        Try
            Dim i As Integer
            i = dgv.CurrentRow.Index
            With dgv.Rows.Item(i)
                hidup()
                tambah.Enabled = False
                txtuser.Text = .Cells(0).Value
                txtfull.Text = .Cells(1).Value
                txtpass.Text = .Cells(2).Value
                cmbstatus.Text = .Cells(3).Value
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles batal.Click
        bersih()
        mati()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = True
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "delete from pengguna where username='" & txtuser.Text & "'"
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

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pengguna where username like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pengguna")
        dgv.DataSource = ds.Tables("pengguna")
        kon.Close()
    End Sub

    Private Sub keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Me.Hide()
        menu_utama.Show()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class