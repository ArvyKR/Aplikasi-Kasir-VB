<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tbarang
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tambah = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 61)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(720, 252)
        Me.dgv.TabIndex = 0
        '
        'txtcari
        '
        Me.txtcari.Location = New System.Drawing.Point(30, 35)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(353, 20)
        Me.txtcari.TabIndex = 84
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(26, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(266, 20)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Cek Data Barang Berdasarkan Merk"
        '
        'tambah
        '
        Me.tambah.Location = New System.Drawing.Point(409, 32)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(136, 23)
        Me.tambah.TabIndex = 85
        Me.tambah.Text = "Tambah Data Barang"
        Me.tambah.UseVisualStyleBackColor = True
        '
        'tbarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 452)
        Me.Controls.Add(Me.tambah)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgv)
        Me.Name = "tbarang"
        Me.Text = "tbarang"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tambah As System.Windows.Forms.Button
End Class
