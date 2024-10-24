<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class barangmasuk
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtmotif = New System.Windows.Forms.TextBox()
        Me.batal = New System.Windows.Forms.Button()
        Me.simpan = New System.Windows.Forms.Button()
        Me.tambah = New System.Windows.Forms.Button()
        Me.keluar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtjmlbrg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtmerk = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtkd = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtpersediaan = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtsatuan = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtmotif
        '
        Me.txtmotif.Location = New System.Drawing.Point(177, 151)
        Me.txtmotif.Name = "txtmotif"
        Me.txtmotif.Size = New System.Drawing.Size(142, 20)
        Me.txtmotif.TabIndex = 107
        '
        'batal
        '
        Me.batal.Location = New System.Drawing.Point(181, 307)
        Me.batal.Name = "batal"
        Me.batal.Size = New System.Drawing.Size(75, 23)
        Me.batal.TabIndex = 106
        Me.batal.Text = "Batal"
        Me.batal.UseVisualStyleBackColor = True
        '
        'simpan
        '
        Me.simpan.Location = New System.Drawing.Point(100, 307)
        Me.simpan.Name = "simpan"
        Me.simpan.Size = New System.Drawing.Size(75, 23)
        Me.simpan.TabIndex = 104
        Me.simpan.Text = "SIMPAN"
        Me.simpan.UseVisualStyleBackColor = True
        '
        'tambah
        '
        Me.tambah.Location = New System.Drawing.Point(19, 307)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(75, 23)
        Me.tambah.TabIndex = 103
        Me.tambah.Text = "Tambah"
        Me.tambah.UseVisualStyleBackColor = True
        '
        'keluar
        '
        Me.keluar.Location = New System.Drawing.Point(262, 307)
        Me.keluar.Name = "keluar"
        Me.keluar.Size = New System.Drawing.Size(75, 23)
        Me.keluar.TabIndex = 102
        Me.keluar.Text = "Keluar"
        Me.keluar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(202, 25)
        Me.Label9.TabIndex = 101
        Me.Label9.Text = "Input Data Barang"
        '
        'txtjmlbrg
        '
        Me.txtjmlbrg.Location = New System.Drawing.Point(177, 227)
        Me.txtjmlbrg.Name = "txtjmlbrg"
        Me.txtjmlbrg.Size = New System.Drawing.Size(142, 20)
        Me.txtjmlbrg.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 227)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Jumlah Barang"
        '
        'txtmerk
        '
        Me.txtmerk.Location = New System.Drawing.Point(177, 120)
        Me.txtmerk.Name = "txtmerk"
        Me.txtmerk.Size = New System.Drawing.Size(142, 20)
        Me.txtmerk.TabIndex = 94
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 20)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Merk"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 20)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Motif"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Kode Barang"
        '
        'txtkd
        '
        Me.txtkd.FormattingEnabled = True
        Me.txtkd.Location = New System.Drawing.Point(177, 86)
        Me.txtkd.Name = "txtkd"
        Me.txtkd.Size = New System.Drawing.Size(142, 21)
        Me.txtkd.TabIndex = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Persediaan"
        '
        'txtpersediaan
        '
        Me.txtpersediaan.Location = New System.Drawing.Point(177, 189)
        Me.txtpersediaan.Name = "txtpersediaan"
        Me.txtpersediaan.Size = New System.Drawing.Size(142, 20)
        Me.txtpersediaan.TabIndex = 108
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Satuan"
        '
        'txtsatuan
        '
        Me.txtsatuan.Location = New System.Drawing.Point(177, 266)
        Me.txtsatuan.Name = "txtsatuan"
        Me.txtsatuan.Size = New System.Drawing.Size(142, 20)
        Me.txtsatuan.TabIndex = 112
        '
        'barangmasuk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 449)
        Me.Controls.Add(Me.txtsatuan)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtkd)
        Me.Controls.Add(Me.txtpersediaan)
        Me.Controls.Add(Me.txtmotif)
        Me.Controls.Add(Me.batal)
        Me.Controls.Add(Me.simpan)
        Me.Controls.Add(Me.tambah)
        Me.Controls.Add(Me.keluar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtjmlbrg)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtmerk)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "barangmasuk"
        Me.Text = "barangmasuk"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtmotif As System.Windows.Forms.TextBox
    Friend WithEvents batal As System.Windows.Forms.Button
    Friend WithEvents simpan As System.Windows.Forms.Button
    Friend WithEvents tambah As System.Windows.Forms.Button
    Friend WithEvents keluar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtjmlbrg As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtmerk As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtkd As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtpersediaan As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtsatuan As System.Windows.Forms.TextBox
End Class
