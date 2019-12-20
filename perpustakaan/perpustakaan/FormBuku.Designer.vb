<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuku
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
        Me.tbcari = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbpenerbit = New System.Windows.Forms.TextBox()
        Me.tbpengarang = New System.Windows.Forms.TextBox()
        Me.tbtahun = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbjudulbuku = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbkdbuku = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnbatal = New System.Windows.Forms.Button()
        Me.btnhapus = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(9, 32)
        Me.dgv.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 24
        Me.dgv.Size = New System.Drawing.Size(564, 326)
        Me.dgv.TabIndex = 0
        '
        'tbcari
        '
        Me.tbcari.Location = New System.Drawing.Point(74, 10)
        Me.tbcari.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbcari.Name = "tbcari"
        Me.tbcari.Size = New System.Drawing.Size(500, 20)
        Me.tbcari.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.tbpenerbit)
        Me.GroupBox1.Controls.Add(Me.tbpengarang)
        Me.GroupBox1.Controls.Add(Me.tbtahun)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbjudulbuku)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbkdbuku)
        Me.GroupBox1.Location = New System.Drawing.Point(578, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(300, 146)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Buku"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(239, 93)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 19)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Cari"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(239, 67)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 19)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Cari"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbpenerbit
        '
        Me.tbpenerbit.Location = New System.Drawing.Point(93, 93)
        Me.tbpenerbit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbpenerbit.Name = "tbpenerbit"
        Me.tbpenerbit.Size = New System.Drawing.Size(143, 20)
        Me.tbpenerbit.TabIndex = 14
        '
        'tbpengarang
        '
        Me.tbpengarang.Location = New System.Drawing.Point(93, 68)
        Me.tbpengarang.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbpengarang.Name = "tbpengarang"
        Me.tbpengarang.Size = New System.Drawing.Size(143, 20)
        Me.tbpengarang.TabIndex = 13
        '
        'tbtahun
        '
        Me.tbtahun.Location = New System.Drawing.Point(93, 117)
        Me.tbtahun.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbtahun.Name = "tbtahun"
        Me.tbtahun.Size = New System.Drawing.Size(76, 20)
        Me.tbtahun.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 119)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Tahun Terbit :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 95)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Penerbit :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 71)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Pengarang :"
        '
        'tbjudulbuku
        '
        Me.tbjudulbuku.Location = New System.Drawing.Point(93, 46)
        Me.tbjudulbuku.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbjudulbuku.Name = "tbjudulbuku"
        Me.tbjudulbuku.Size = New System.Drawing.Size(204, 20)
        Me.tbjudulbuku.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 48)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Judul Buku :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Kode Buku :"
        '
        'tbkdbuku
        '
        Me.tbkdbuku.Enabled = False
        Me.tbkdbuku.Location = New System.Drawing.Point(93, 23)
        Me.tbkdbuku.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbkdbuku.Name = "tbkdbuku"
        Me.tbkdbuku.Size = New System.Drawing.Size(143, 20)
        Me.tbkdbuku.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Pencarian :"
        '
        'btnbatal
        '
        Me.btnbatal.Location = New System.Drawing.Point(821, 161)
        Me.btnbatal.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(56, 19)
        Me.btnbatal.TabIndex = 7
        Me.btnbatal.Text = "Batal"
        Me.btnbatal.UseVisualStyleBackColor = True
        '
        'btnhapus
        '
        Me.btnhapus.Location = New System.Drawing.Point(760, 161)
        Me.btnhapus.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnhapus.Name = "btnhapus"
        Me.btnhapus.Size = New System.Drawing.Size(56, 19)
        Me.btnhapus.TabIndex = 6
        Me.btnhapus.Text = "Hapus"
        Me.btnhapus.UseVisualStyleBackColor = True
        '
        'btnedit
        '
        Me.btnedit.Location = New System.Drawing.Point(700, 161)
        Me.btnedit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(56, 19)
        Me.btnedit.TabIndex = 5
        Me.btnedit.Text = "Edit"
        Me.btnedit.UseVisualStyleBackColor = True
        '
        'btntambah
        '
        Me.btntambah.Location = New System.Drawing.Point(639, 161)
        Me.btntambah.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(56, 19)
        Me.btntambah.TabIndex = 4
        Me.btntambah.Text = "Tambah"
        Me.btntambah.UseVisualStyleBackColor = True
        '
        'FormBuku
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 368)
        Me.Controls.Add(Me.btnbatal)
        Me.Controls.Add(Me.btnhapus)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btntambah)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tbcari)
        Me.Controls.Add(Me.dgv)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FormBuku"
        Me.Text = "FormBuku"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents tbcari As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbpenerbit As System.Windows.Forms.TextBox
    Friend WithEvents tbpengarang As System.Windows.Forms.TextBox
    Friend WithEvents tbtahun As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbjudulbuku As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbkdbuku As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnbatal As System.Windows.Forms.Button
    Friend WithEvents btnhapus As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents btntambah As System.Windows.Forms.Button
End Class
