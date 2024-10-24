Public Class Form1

    Sub formmatikasir()
        menu_utama.Button5.Visible = False
        menu_utama.Button6.Visible = False
        menu_utama.Button8.Visible = False
        menu_utama.Button10.Visible = False
        menu_utama.Button9.Visible = False
        menu_utama.Button13.Visible = False
        menu_utama.Button11.Visible = False
        menu_utama.Button3.Visible = False
        tbarang.tambah.Visible = False
    End Sub
    Sub formhidup()
        menu_utama.Button4.Visible = True
        menu_utama.Button5.Visible = True
        menu_utama.Button6.Visible = True
        menu_utama.Button8.Visible = True
        menu_utama.Button10.Visible = True
        menu_utama.Button9.Visible = True
        menu_utama.Button13.Visible = True
        menu_utama.Button11.Visible = True
        menu_utama.Button3.Visible = True
        menu_utama.Button1.Visible = True
        menu_utama.Button2.Visible = True
    End Sub
    Sub bersih()
        txtid.Text = ""
        txtpass.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            perintah.CommandText = "select * from pengguna where username =('" & txtid.Text & "') and userpass=MD5('" & txtpass.Text & "') and useraktif=1"
            cek = perintah.ExecuteReader
            cek.Read()
            If cek.HasRows Then
                user = txtid.Text
                menu_utama.lbluserfullname.Text = cek.Item("userfullname")
                menu_utama.username.Text = cek.Item("username")
                cek.Close()
                MsgBox("Selamat Datang... Anda Telah Bisa Mengakses Halaman Menu Utama", MsgBoxStyle.Information, "Konfirmasi")
                menu_utama.Show()
                Me.Hide()
                bersih()

                If menu_utama.lbluserfullname.Text = "Admin" Then
                    formhidup()
                Else
                    formmatikasir()
                End If
            Else
                MsgBox("ANDA TIDAK BISA LOGIN", MsgBoxStyle.Critical, "INFORMATION")
                txtid.Clear()
                txtpass.Clear()
                txtid.Focus()
            End If
            kon.Close()
        Catch ex As Exception
            MsgBox("TIDAK ADA KONEKSI", MsgBoxStyle.Critical, "INFORMATION")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
