<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPengembalian
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
        Me.tbkdanggota = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbkdpeminjaman = New System.Windows.Forms.TextBox()
        Me.btnanggota = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbkdpengembalian = New System.Windows.Forms.TextBox()
        Me.dtpkembali = New System.Windows.Forms.DateTimePicker()
        Me.tbrole = New System.Windows.Forms.TextBox()
        Me.tbnotelp = New System.Windows.Forms.TextBox()
        Me.tbalamat = New System.Windows.Forms.TextBox()
        Me.tbnama = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbjmlhari = New System.Windows.Forms.TextBox()
        Me.btninput = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnbuku = New System.Windows.Forms.Button()
        Me.tbjudulbuku = New System.Windows.Forms.TextBox()
        Me.tbkdbuku = New System.Windows.Forms.TextBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.btnbatal = New System.Windows.Forms.Button()
        Me.btnhpsitem = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbkdanggota
        '
        Me.tbkdanggota.Enabled = False
        Me.tbkdanggota.Location = New System.Drawing.Point(445, 19)
        Me.tbkdanggota.Name = "tbkdanggota"
        Me.tbkdanggota.Size = New System.Drawing.Size(143, 20)
        Me.tbkdanggota.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbkdpeminjaman)
        Me.GroupBox1.Controls.Add(Me.btnanggota)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbkdpengembalian)
        Me.GroupBox1.Controls.Add(Me.dtpkembali)
        Me.GroupBox1.Controls.Add(Me.tbrole)
        Me.GroupBox1.Controls.Add(Me.tbnotelp)
        Me.GroupBox1.Controls.Add(Me.tbalamat)
        Me.GroupBox1.Controls.Add(Me.tbnama)
        Me.GroupBox1.Controls.Add(Me.tbkdanggota)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(860, 106)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transaksi Peminjaman"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(276, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 20)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Kd. Peminjaman"
        '
        'tbkdpeminjaman
        '
        Me.tbkdpeminjaman.Enabled = False
        Me.tbkdpeminjaman.Location = New System.Drawing.Point(108, 71)
        Me.tbkdpeminjaman.Name = "tbkdpeminjaman"
        Me.tbkdpeminjaman.Size = New System.Drawing.Size(162, 20)
        Me.tbkdpeminjaman.TabIndex = 19
        '
        'btnanggota
        '
        Me.btnanggota.Enabled = False
        Me.btnanggota.Location = New System.Drawing.Point(594, 19)
        Me.btnanggota.Name = "btnanggota"
        Me.btnanggota.Size = New System.Drawing.Size(32, 20)
        Me.btnanggota.TabIndex = 12
        Me.btnanggota.Text = "..."
        Me.btnanggota.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(650, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Jenis"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(650, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "No. Telepon"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(359, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Alamat"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(359, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Nama"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(359, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Kd. Anggota"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Tgl. Pengembalian"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Kd. Pengembalian"
        '
        'tbkdpengembalian
        '
        Me.tbkdpengembalian.Location = New System.Drawing.Point(108, 19)
        Me.tbkdpengembalian.Name = "tbkdpengembalian"
        Me.tbkdpengembalian.Size = New System.Drawing.Size(200, 20)
        Me.tbkdpengembalian.TabIndex = 10
        '
        'dtpkembali
        '
        Me.dtpkembali.Location = New System.Drawing.Point(108, 45)
        Me.dtpkembali.Name = "dtpkembali"
        Me.dtpkembali.Size = New System.Drawing.Size(200, 20)
        Me.dtpkembali.TabIndex = 9
        '
        'tbrole
        '
        Me.tbrole.Enabled = False
        Me.tbrole.Location = New System.Drawing.Point(722, 71)
        Me.tbrole.Name = "tbrole"
        Me.tbrole.Size = New System.Drawing.Size(100, 20)
        Me.tbrole.TabIndex = 5
        '
        'tbnotelp
        '
        Me.tbnotelp.Enabled = False
        Me.tbnotelp.Location = New System.Drawing.Point(722, 45)
        Me.tbnotelp.Name = "tbnotelp"
        Me.tbnotelp.Size = New System.Drawing.Size(100, 20)
        Me.tbnotelp.TabIndex = 4
        '
        'tbalamat
        '
        Me.tbalamat.Enabled = False
        Me.tbalamat.Location = New System.Drawing.Point(445, 71)
        Me.tbalamat.Name = "tbalamat"
        Me.tbalamat.Size = New System.Drawing.Size(181, 20)
        Me.tbalamat.TabIndex = 3
        '
        'tbnama
        '
        Me.tbnama.Enabled = False
        Me.tbnama.Location = New System.Drawing.Point(445, 45)
        Me.tbnama.Name = "tbnama"
        Me.tbnama.Size = New System.Drawing.Size(181, 20)
        Me.tbnama.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbjmlhari)
        Me.GroupBox2.Controls.Add(Me.btninput)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnbuku)
        Me.GroupBox2.Controls.Add(Me.tbjudulbuku)
        Me.GroupBox2.Controls.Add(Me.tbkdbuku)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(860, 48)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Input Buku"
        '
        'tbjmlhari
        '
        Me.tbjmlhari.Enabled = False
        Me.tbjmlhari.Location = New System.Drawing.Point(632, 19)
        Me.tbjmlhari.Name = "tbjmlhari"
        Me.tbjmlhari.Size = New System.Drawing.Size(141, 20)
        Me.tbjmlhari.TabIndex = 22
        '
        'btninput
        '
        Me.btninput.Location = New System.Drawing.Point(779, 18)
        Me.btninput.Name = "btninput"
        Me.btninput.Size = New System.Drawing.Size(75, 23)
        Me.btninput.TabIndex = 11
        Me.btninput.Text = "Input"
        Me.btninput.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Kd. Buku"
        '
        'btnbuku
        '
        Me.btnbuku.Location = New System.Drawing.Point(176, 19)
        Me.btnbuku.Name = "btnbuku"
        Me.btnbuku.Size = New System.Drawing.Size(32, 20)
        Me.btnbuku.TabIndex = 6
        Me.btnbuku.Text = "..."
        Me.btnbuku.UseVisualStyleBackColor = True
        '
        'tbjudulbuku
        '
        Me.tbjudulbuku.Location = New System.Drawing.Point(214, 19)
        Me.tbjudulbuku.Name = "tbjudulbuku"
        Me.tbjudulbuku.Size = New System.Drawing.Size(412, 20)
        Me.tbjudulbuku.TabIndex = 7
        '
        'tbkdbuku
        '
        Me.tbkdbuku.Location = New System.Drawing.Point(70, 19)
        Me.tbkdbuku.Name = "tbkdbuku"
        Me.tbkdbuku.Size = New System.Drawing.Size(100, 20)
        Me.tbkdbuku.TabIndex = 6
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 178)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(860, 218)
        Me.dgv.TabIndex = 5
        '
        'btnsimpan
        '
        Me.btnsimpan.Location = New System.Drawing.Point(791, 402)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(75, 23)
        Me.btnsimpan.TabIndex = 19
        Me.btnsimpan.Text = "Simpan"
        Me.btnsimpan.UseVisualStyleBackColor = True
        '
        'btnbatal
        '
        Me.btnbatal.Location = New System.Drawing.Point(710, 402)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(75, 23)
        Me.btnbatal.TabIndex = 20
        Me.btnbatal.Text = "Batal"
        Me.btnbatal.UseVisualStyleBackColor = True
        '
        'btnhpsitem
        '
        Me.btnhpsitem.Location = New System.Drawing.Point(12, 402)
        Me.btnhpsitem.Name = "btnhpsitem"
        Me.btnhpsitem.Size = New System.Drawing.Size(91, 23)
        Me.btnhpsitem.TabIndex = 21
        Me.btnhpsitem.Text = "Hapus Item"
        Me.btnhpsitem.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(109, 402)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FormPengembalian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 437)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnhpsitem)
        Me.Controls.Add(Me.btnsimpan)
        Me.Controls.Add(Me.btnbatal)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormPengembalian"
        Me.Text = "FormPengembalian"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbkdanggota As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnanggota As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbkdpengembalian As System.Windows.Forms.TextBox
    Friend WithEvents dtpkembali As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbrole As System.Windows.Forms.TextBox
    Friend WithEvents tbnotelp As System.Windows.Forms.TextBox
    Friend WithEvents tbalamat As System.Windows.Forms.TextBox
    Friend WithEvents tbnama As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btninput As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnbuku As System.Windows.Forms.Button
    Friend WithEvents tbjudulbuku As System.Windows.Forms.TextBox
    Friend WithEvents tbkdbuku As System.Windows.Forms.TextBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents btnbatal As System.Windows.Forms.Button
    Friend WithEvents btnhpsitem As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbkdpeminjaman As System.Windows.Forms.TextBox
    Friend WithEvents tbjmlhari As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
