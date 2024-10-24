Public Class cekpemasok
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
    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select * from pemasok where nama like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "pemasok")
        dgv.DataSource = ds.Tables("pemasok")
        kon.Close()
    End Sub

    Private Sub cekpemasok_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
        dgv.Columns(0).Width = 100
        dgv.Columns(1).Width = 300
        dgv.Columns(2).Width = 300
        dgv.Columns(3).Width = 200
        dgv.Font = New Font("Calibri", 12)
        dgv.Columns(0).HeaderText = "KODE"
        dgv.Columns(1).HeaderText = "NAMA PEMASOK"
        dgv.Columns(2).HeaderText = "ALAMAT PEMASOK"
        dgv.Columns(3).HeaderText = "NO. TELEPON"
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Try
            Dim i As Integer
            i = dgv.CurrentRow.Index
            With dgv.Rows.Item(i)
                transbeli.cmbkdp.Text = .Cells(0).Value
                transbeli.nama.Text = .Cells(1).Value
                Me.Close()
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pemasok.Show()
        Me.Close()

    End Sub
End Class