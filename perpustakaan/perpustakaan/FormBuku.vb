Imports MySql.Data.MySqlClient

Public Class FormBuku
    Public mode As String
    Public id_data As String
    Public from As String
    Private Sub FormBuku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid()
        reset()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT tb.kd_buku,tb.judul,png.nama_pengarang,pbt.nama_penerbit,tb.tahun_terbit FROM tb_buku tb " _
                            & "JOIN tb_pengarang png ON tb.kd_pengarang = png.kd_pengarang " _
                            & "JOIN tb_penerbit pbt on tb.kd_penerbit = pbt.kd_penerbit"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgv.DataSource = ds.Tables(0)
            dgv.Refresh()
        Else
            dgv.DataSource = Nothing
        End If
        If dgv.RowCount > 0 Then
            judulgrid()
        End If
    End Sub
    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        dgv.Columns(0).HeaderText = "Kode buku"
        dgv.Columns(0).Width = 100
        dgv.Columns(1).HeaderText = "Judul buku"
        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(2).HeaderText = "Pengarang"
        dgv.Columns(2).Width = 100
        dgv.Columns(3).HeaderText = "Penerbit"
        dgv.Columns(3).Width = 100
        dgv.Columns(4).HeaderText = "Tahun Terbit"
        dgv.Columns(4).Width = 50
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub kode()
        cmd = New MySqlCommand("SELECT kd_buku FROM tb_buku ORDER BY kd_buku DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        Dim currentdate As DateTime = DateTime.Now
        Dim kd As String = "BKU" & currentdate.ToString("yyMM")
        If Not dr.HasRows Then
            tbkdbuku.Text = kd & "000001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_buku").ToString, 6)) + 1
            If Len(hitung) = 1 Then
                tbkdbuku.Text = kd & "00000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdbuku.Text = kd & "0000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdbuku.Text = kd & "000" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdbuku.Text = kd & "00" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdbuku.Text = kd & "0" & hitung
            ElseIf Len(hitung) = 6 Then
                tbkdbuku.Text = kd & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub bersih()
        tbkdbuku.Clear()
        tbjudulbuku.Clear()
        tbpengarang.Clear()
        tbpenerbit.Clear()
        tbtahun.Clear()
    End Sub
    Sub reset()
        tbjudulbuku.Enabled = False
        tbpengarang.Enabled = False
        tbpenerbit.Enabled = False
        tbtahun.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        bersih()
        btntambah.Enabled = True
        btntambah.Text = "Tambah"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub modesimpan()
        tbjudulbuku.Enabled = True
        tbpengarang.Enabled = True
        tbpenerbit.Enabled = True
        tbtahun.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        btntambah.Enabled = True
        btntambah.Text = "Simpan"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub GridToTextBox()
        dgv.Refresh()
        If dgv.RowCount > 0 Then
            Dim baris As Integer
            With dgv
                baris = .CurrentRow.Index
                id_data = .Item(0, baris).Value
                tbkdbuku.Text = .Item(0, baris).Value
                tbjudulbuku.Text = .Item(1, baris).Value
                tbpengarang.Text = .Item(2, baris).Value
                tbpenerbit.Text = .Item(3, baris).Value
                tbtahun.Text = .Item(4, baris).Value
            End With
        End If
    End Sub
    Sub querytambah()
        Dim q As String = "INSERT INTO tb_buku VALUES (@kd_buku, @judul, @kd_pengarang, @kd_penerbit, @tahun_terbit)"
        Querybuku(q, tbkdbuku.Text, tbjudulbuku.Text.ToUpper, Microsoft.VisualBasic.Right(tbpengarang.Text, 8), Microsoft.VisualBasic.Right(tbpenerbit.Text, 8), tbtahun.Text)
        MsgBox("Berhasil tambah data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryedit()
        Dim q As String = "UPDATE tb_buku SET judul=@judul,kd_pengarang=@kd_pengarang,kd_penerbit=@kd_penerbit,tahun_terbit=@tahun_terbit WHERE kd_buku = @kd_buku"
        Querybuku(q, id_data, tbjudulbuku.Text.ToUpper, Microsoft.VisualBasic.Right(tbpengarang.Text, 8), Microsoft.VisualBasic.Right(tbpenerbit.Text, 8), tbtahun.Text)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryhapus()
        cmd.CommandText = "SELECT * FROM tb_pinjaman_detail WHERE kd_buku = '" & id_data & "'"
        cmd.Connection = konek
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("buku tidak dapat dihapus!", 48, "Perhatian")
        Else
            dr.Close()
            Dim query As String = "DELETE FROM tb_buku WHERE kd_buku = @kd_buku"
            Querybuku(query, id_data, "", "", "", "")
            isigrid()
            MsgBox("Berhasil hapus data!", MsgBoxStyle.Information, "Informasi")
        End If
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If btntambah.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
            kode()
        Else
            If tbjudulbuku.Text = "" Then
                MsgBox("Lengkapi data yang kosong!", 16, "Informasi")
            Else
                If mode = "tambah" Then
                    querytambah()
                    reset()
                Else
                    queryedit()
                    reset()
                End If
            End If
        End If
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        mode = "edit"
        modesimpan()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin hapus buku " & tbjudulbuku.Text & " (" & tbkdbuku.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
            reset()
        End If
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        reset()
    End Sub

    Private Sub dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        reset()
        GridToTextBox()
        btntambah.Enabled = False
        btnedit.Enabled = True
        btnhapus.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormPengarang.from = "buku"
        FormPengarang.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormPenerbit.from = "buku"
        FormPenerbit.ShowDialog()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If from = "peminjaman" Then
            With FormPeminjaman
                .tbkdbuku.Text = tbkdbuku.Text
                .tbjudulbuku.Text = tbjudulbuku.Text
            End With
            Me.Close()
        End If
    End Sub
End Class