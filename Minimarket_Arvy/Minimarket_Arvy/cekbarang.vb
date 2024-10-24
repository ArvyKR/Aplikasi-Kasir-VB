Public Class cekbarang
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
    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from barang where merk like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "barang")
        dgv.DataSource = ds.Tables("barang")
        kon.Close()
    End Sub

    Private Sub cekbarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
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

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Try
            Dim i As Integer
            i = dgv.CurrentRow.Index
            With dgv.Rows.Item(i)
                transbeli.cmbkdb.Text = .Cells(0).Value
                transbeli.txtmerk.Text = .Cells(1).Value
                transbeli.txtmotif.Text = .Cells(2).Value
                transbeli.txtharga.Text = .Cells(3).Value
                transbeli.txtjmlbrg.Text = .Cells(4).Value
                transbeli.txtsatuan.Text = .Cells(5).Value
                Me.Close()
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        barang.Show()
        Me.Close()

    End Sub
End Class