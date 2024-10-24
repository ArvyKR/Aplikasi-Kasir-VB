<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cetakstokbarang
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
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 56)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(446, 279)
        Me.dgv.TabIndex = 1
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Cooper Black", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(16, 341)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(442, 54)
        Me.Button8.TabIndex = 23
        Me.Button8.Text = "CETAK STOK BARANG"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'txtcari
        '
        Me.txtcari.Location = New System.Drawing.Point(16, 30)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(421, 20)
        Me.txtcari.TabIndex = 81
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(324, 20)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Cek Data Barang Berdasarkan Kode Barang"
        '
        'cetakstokbarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 405)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.dgv)
        Me.Name = "cetakstokbarang"
        Me.Text = "cetakstokbarang"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
