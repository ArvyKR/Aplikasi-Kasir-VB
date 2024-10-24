Public Class barang

    Sub tampil()
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
    Sub bersih()
        txtkd.Text = ""
        txtmerk.Text = ""
        txtjmlbrg.Text = ""
        txtharga.Text = ""
        txtmotif.Text = ""
        txtsatuan.Text = ""
    End Sub
    Sub mati()
        txtkd.Enabled = False
        txtmerk.Enabled = False
        txtharga.Enabled = False
        txtjmlbrg.Enabled = False
        txtmotif.Enabled = False
        txtsatuan.Enabled = False
    End Sub
    Sub hidup()
        txtmerk.Enabled = True
        txtharga.Enabled = True
        txtjmlbrg.Enabled = True
        txtmotif.Enabled = True
        txtsatuan.Enabled = True
        munculsatuan()

    End Sub
    Sub munculsatuan()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "SELECT distinct satuan FROM barang"
        cek = perintah.ExecuteReader()
        txtsatuan.Items.Clear()
        Do While cek.Read
            txtsatuan.Items.Add(cek.Item("satuan"))
        Loop
        kon.Close()

    End Sub
    Sub nofaktur()
        Dim kode, nofaktur As String
        Dim no As Integer
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select kode_barang from barang order by kode_barang desc limit 1"
        cek = perintah.ExecuteReader
        cek.Read()
        If cek.HasRows Then
            kode = cek.Item("kode_barang")
            no = Val(Microsoft.VisualBasic.Right(kode, 3))
            no = no + 1
            nofaktur = "BA" + Format(dtp.Value, "yyyyMM") + Format(no, "0000")
            txtkd.Text = nofaktur
        Else
            txtkd.Text = "BA" + Format(dtp.Value, "yyyyMM") + "0001"
        End If
        cek.Close()
        kon.Close()
    End Sub
    Private Sub txtkd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkd.TextChanged
        kon.Close()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from barang where kode_barang='" & txtkd.Text & "'"
        cek = perintah.ExecuteReader
        cek.Read()
        If cek.HasRows Then
            txtmerk.Text = cek.Item("merk")
            txtmotif.Text = cek.Item("motif")
            txtharga.Text = cek.Item("harga")
            txtjmlbrg.Text = cek.Item("jmlbrg")
            txtsatuan.Text = cek.Item("satuan")
        Else
            txtmerk.Text = ""
            txtmotif.Text = ""
            txtharga.Text = ""
            txtjmlbrg.Text = ""
            txtsatuan.Text = ""
        End If
        kon.Close()
    End Sub

    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nofaktur()
        munculsatuan()
        mati()
        tampil()
        tambah.Enabled = True
        simpan.Enabled = False
        hapus.Enabled = False
        dgv.Columns(0).Width = 200
        dgv.Columns(1).Width = 250
        dgv.Columns(2).Width = 150
        dgv.Columns(3).Width = 150
        dgv.Columns(4).Width = 150
        dgv.Columns(5).Width = 150
        dgv.Font = New Font("Calibri", 11)
        dgv.Columns(0).HeaderText = "KODE BARANG"
        dgv.Columns(1).HeaderText = "MERK"
        dgv.Columns(2).HeaderText = "MOTIF"
        dgv.Columns(3).HeaderText = "HARGA"
        dgv.Columns(4).HeaderText = "JUMLAH BARANG"
        dgv.Columns(5).HeaderText = "SATUAN"
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Me.Hide()
        menu_utama.Show()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        nofaktur()
        hidup()
        tambah.Enabled = False
        simpan.Enabled = True
        hapus.Enabled = True
        simpan.Text = "SIMPAN"
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
                txtmerk.Text = .Cells(1).Value
                txtmotif.Text = .Cells(2).Value
                txtharga.Text = .Cells(3).Value
                txtjmlbrg.Text = .Cells(4).Value
                txtsatuan.Text = .Cells(5).Value
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        If txtkd.Text = "" Or txtmerk.Text = "" Or txtmotif.Text = "" Or txtharga.Text = "" Or txtjmlbrg.Text = "" Or txtsatuan.Text = "" Then
            MsgBox("Mohon Lengkapi Isian Data Anda...", MsgBoxStyle.Information, "Konfirmasi")
        Else
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            If simpan.Text = "SIMPAN" Then
                perintah.CommandText = "insert into barang values ('" & txtkd.Text & "','" & txtmerk.Text & "','" & txtmotif.Text & "','" & txtharga.Text & "','" &
                txtjmlbrg.Text & "','" & txtsatuan.Text & "')"
            Else
                perintah.CommandText = "UPDATE barang SET merk='" & txtmerk.Text & "',motif='" & txtmotif.Text & "',harga='" & txtharga.Text & "',jmlbrg='" & txtjmlbrg.Text & "',satuan='" & txtsatuan.Text & "' WHERE kode_barang='" & txtkd.Text & "'"
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
        perintah.CommandText = "delete from barang where kode_barang='" & txtkd.Text & "'"
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
        perintah.CommandText = "select * from barang where merk like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "barang")
        dgv.DataSource = ds.Tables("barang")
        kon.Close()
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub
End Class