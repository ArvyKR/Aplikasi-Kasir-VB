<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class barang
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
        Me.txtsatuan = New System.Windows.Forms.ComboBox()
        Me.txtharga = New System.Windows.Forms.TextBox()
        Me.txtmotif = New System.Windows.Forms.TextBox()
        Me.batal = New System.Windows.Forms.Button()
        Me.hapus = New System.Windows.Forms.Button()
        Me.simpan = New System.Windows.Forms.Button()
        Me.tambah = New System.Windows.Forms.Button()
        Me.keluar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtjmlbrg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtmerk = New System.Windows.Forms.TextBox()
        Me.txtkd = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtsatuan
        '
        Me.txtsatuan.FormattingEnabled = True
        Me.txtsatuan.Location = New System.Drawing.Point(202, 256)
        Me.txtsatuan.Name = "txtsatuan"
        Me.txtsatuan.Size = New System.Drawing.Size(142, 21)
        Me.txtsatuan.TabIndex = 88
        '
        'txtharga
        '
        Me.txtharga.Location = New System.Drawing.Point(202, 188)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.Size = New System.Drawing.Size(142, 20)
        Me.txtharga.TabIndex = 87
        '
        'txtmotif
        '
        Me.txtmotif.Location = New System.Drawing.Point(202, 150)
        Me.txtmotif.Name = "txtmotif"
        Me.txtmotif.Size = New System.Drawing.Size(142, 20)
        Me.txtmotif.TabIndex = 86
        '
        'batal
        '
        Me.batal.Location = New System.Drawing.Point(206, 306)
        Me.batal.Name = "batal"
        Me.batal.Size = New System.Drawing.Size(75, 23)
        Me.batal.TabIndex = 85
        Me.batal.Text = "Batal"
        Me.batal.UseVisualStyleBackColor = True
        '
        'hapus
        '
        Me.hapus.Location = New System.Drawing.Point(287, 306)
        Me.hapus.Name = "hapus"
        Me.hapus.Size = New System.Drawing.Size(75, 23)
        Me.hapus.TabIndex = 84
        Me.hapus.Text = "Hapus"
        Me.hapus.UseVisualStyleBackColor = True
        '
        'simpan
        '
        Me.simpan.Location = New System.Drawing.Point(125, 306)
        Me.simpan.Name = "simpan"
        Me.simpan.Size = New System.Drawing.Size(75, 23)
        Me.simpan.TabIndex = 83
        Me.simpan.Text = "SIMPAN"
        Me.simpan.UseVisualStyleBackColor = True
        '
        'tambah
        '
        Me.tambah.Location = New System.Drawing.Point(44, 306)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(75, 23)
        Me.tambah.TabIndex = 82
        Me.tambah.Text = "Tambah"
        Me.tambah.UseVisualStyleBackColor = True
        '
        'keluar
        '
        Me.keluar.Location = New System.Drawing.Point(705, 361)
        Me.keluar.Name = "keluar"
        Me.keluar.Size = New System.Drawing.Size(75, 23)
        Me.keluar.TabIndex = 81
        Me.keluar.Text = "Keluar"
        Me.keluar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(37, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(202, 25)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Input Data Barang"
        '
        'txtcari
        '
        Me.txtcari.Location = New System.Drawing.Point(396, 54)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(353, 20)
        Me.txtcari.TabIndex = 79
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(392, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(266, 20)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Cek Data Barang Berdasarkan Merk"
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(396, 80)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(384, 275)
        Me.dgv.TabIndex = 77
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(38, 254)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Satuan"
        '
        'txtjmlbrg
        '
        Me.txtjmlbrg.Location = New System.Drawing.Point(202, 226)
        Me.txtjmlbrg.Name = "txtjmlbrg"
        Me.txtjmlbrg.Size = New System.Drawing.Size(142, 20)
        Me.txtjmlbrg.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(38, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Jumlah Barang"
        '
        'txtmerk
        '
        Me.txtmerk.Location = New System.Drawing.Point(202, 119)
        Me.txtmerk.Name = "txtmerk"
        Me.txtmerk.Size = New System.Drawing.Size(142, 20)
        Me.txtmerk.TabIndex = 73
        '
        'txtkd
        '
        Me.txtkd.Location = New System.Drawing.Point(202, 87)
        Me.txtkd.Name = "txtkd"
        Me.txtkd.Size = New System.Drawing.Size(142, 20)
        Me.txtkd.TabIndex = 72
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 20)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Harga"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 20)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Merk"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 20)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Motif"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Kode Barang"
        '
        'dtp
        '
        Me.dtp.Location = New System.Drawing.Point(92, 346)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(200, 20)
        Me.dtp.TabIndex = 89
        Me.dtp.Visible = False
        '
        'barang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 408)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.txtsatuan)
        Me.Controls.Add(Me.txtharga)
        Me.Controls.Add(Me.txtmotif)
        Me.Controls.Add(Me.batal)
        Me.Controls.Add(Me.hapus)
        Me.Controls.Add(Me.simpan)
        Me.Controls.Add(Me.tambah)
        Me.Controls.Add(Me.keluar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtjmlbrg)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtmerk)
        Me.Controls.Add(Me.txtkd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "barang"
        Me.Text = "barang"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtsatuan As System.Windows.Forms.ComboBox
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents txtmotif As System.Windows.Forms.TextBox
    Friend WithEvents batal As System.Windows.Forms.Button
    Friend WithEvents hapus As System.Windows.Forms.Button
    Friend WithEvents simpan As System.Windows.Forms.Button
    Friend WithEvents tambah As System.Windows.Forms.Button
    Friend WithEvents keluar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtjmlbrg As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtmerk As System.Windows.Forms.TextBox
    Friend WithEvents txtkd As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
End Class
