Public Class tbarangmasuk
    Sub tampil()
        kon.Open()
        perintah.Connection = kon
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select trans_pembelian.no_beli,trans_pembelian.kode_barang, trans_pembelian.merk, trans_pembelian.jml_masuk, trans_pembelian.tgl_beli from trans_pembelian"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv.DataSource = ds.Tables("trans_pembelian")
        kon.Close()
    End Sub
    Private Sub tbarangmasuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        perintah.CommandType = CommandType.Text
        perintah.CommandText = "select trans_pembelian.no_beli,trans_pembelian.kode_barang, trans_pembelian.merk, trans_pembelian.jml_masuk from trans_pembelian where no_beli like '" & txtcari.Text & "%'"
        mda.SelectCommand = perintah
        ds.Tables.Clear()
        mda.Fill(ds, "trans_pembelian")
        dgv.DataSource = ds.Tables("trans_pembelian")
        kon.Close()
    End Sub
End Class