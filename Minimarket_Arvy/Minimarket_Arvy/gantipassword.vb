Public Class gantipassword

    Sub bersih()
        user.Text = ""
        pass.Text = ""
        newpass.Text = ""
        repass.Text = ""
    End Sub
    Private Sub user_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles user.KeyPress
        If e.KeyChar = Chr(13) Then
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            perintah.CommandText = "select * from pengguna where username ='" & user.Text & "'"
            If Not cek.HasRows Then
                MsgBox("Username salah")
                user.Focus()
                user.Text = ""
            Else
                pass.Focus()
            End If
        End If
    End Sub

    Private Sub pass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles pass.KeyPress
        If e.KeyChar = Chr(13) Then
            kon.Open()
            perintah.Connection = kon
            perintah.CommandType = CommandType.Text
            perintah.CommandText = "select * from pengguna where userpass ='" & pass.Text & "' and username = '" & user.Text & "'"
            If Not cek.HasRows Then
                MsgBox("Password salah")
                pass.Focus()
                pass.Text = ""
            Else
                newpass.Focus()
            End If
        End If
    End Sub


    Private Sub newpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles newpass.KeyPress
        If e.KeyChar = Chr(13) Then
            If newpass.Text = "" Then
                MsgBox("Password baru belum  dibuat")
                repass.Focus()
            Else
                repass.Focus()
            End If
        End If
    End Sub


    Private Sub repass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles repass.KeyPress
        Dim pesan As String
        If e.KeyChar = Chr(13) Then
            If newpass.Text <> repass.Text Then
                MsgBox("Password Konfirmasi tidak sesuai")
                repass.Focus()
                repass.Clear()
            Else
                pesan = MsgBox("Yakin password akan diganti?", vbYesNo, "Informasi")
                If pesan = vbYes Then
                    kon.Open()
                    perintah.Connection = kon
                    perintah.CommandType = CommandType.Text
                    perintah.CommandText = "update pengguna set userpass = MD5('" & repass.Text & "') where username ='" & user.Text & "'"
                    perintah.ExecuteNonQuery()
                    MsgBox("Password Berhasil diubah")
                    bersih()
                Else
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        menu_utama.Show()
    End Sub
End Class