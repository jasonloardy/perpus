Imports MySql.Data.MySqlClient

Public Class FormPengembalian

    Private Sub btnanggota_Click(sender As Object, e As EventArgs) Handles btnanggota.Click
        FormAnggota.from = "peminjaman"
        FormAnggota.ShowDialog()
    End Sub

    Private Sub btnbuku_Click(sender As Object, e As EventArgs) Handles btnbuku.Click
        FormDaftarBukuPeminjaman.ShowDialog()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM tb_keranjang_pengembalian ORDER BY no DESC"
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
        dgv.Columns(0).Visible = False
        dgv.Columns(1).HeaderText = "Kode Buku"
        dgv.Columns(1).Width = 100
        dgv.Columns(2).HeaderText = "Judul Buku"
        dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(3).HeaderText = "Jumlah Hari"
        dgv.Columns(3).Width = 100
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub querytambah()
        Dim q As String = "INSERT INTO tb_keranjang_pengembalian (kd_buku,judul,jmlhari) VALUES (@kd_buku, @judul, @jmlhari)"
        Querykeranjangpengembalian(q, tbkdbuku.Text, tbjudulbuku.Text.ToUpper, tbjmlhari.Text)
        isigrid()
    End Sub
    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        querytambah()
        tbkdbuku.Clear()
        tbjudulbuku.Clear()
        tbjmlhari.Clear()
    End Sub
    Sub kode()
        cmd = New MySqlCommand("SELECT kd_pengembalian FROM tb_pengembalian ORDER BY kd_pengembalian DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        Dim currentdate As DateTime = DateTime.Now
        Dim kd As String = "KBL" & currentdate.ToString("yyMM")
        If Not dr.HasRows Then
            tbkdpengembalian.Text = kd & "000001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_pengembalian").ToString, 6)) + 1
            If Len(hitung) = 1 Then
                tbkdpengembalian.Text = kd & "00000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdpengembalian.Text = kd & "0000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdpengembalian.Text = kd & "000" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdpengembalian.Text = kd & "00" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdpengembalian.Text = kd & "0" & hitung
            ElseIf Len(hitung) = 6 Then
                tbkdpengembalian.Text = kd & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub resetkeranjang()
        Dim q As String = "TRUNCATE TABLE tb_keranjang_pengembalian"
        Query(q)
    End Sub
    Sub reset()
        kode()
        tbkdanggota.Clear()
        tbnama.Clear()
        tbalamat.Clear()
        tbnotelp.Clear()
        tbrole.Clear()
        tbkdbuku.Clear()
        tbjudulbuku.Clear()
        tbjmlhari.Clear()
        resetkeranjang()
        isigrid()
    End Sub

    Private Sub FormPeminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reset()
    End Sub

    Private Sub btnhpsitem_Click(sender As Object, e As EventArgs) Handles btnhpsitem.Click
        Try
            Dim baris As Integer
            Dim no As Integer
            Dim kdbrg As String
            Dim nmbrg As String
            With dgv
                baris = .CurrentRow.Index
                no = .Item(0, baris).Value
                kdbrg = .Item(1, baris).Value
                nmbrg = .Item(2, baris).Value
            End With
            Dim nhps As Integer
            nhps = MsgBox("Hapus buku " & nmbrg & " (" & kdbrg & ") dari keranjang?", 48 + 4 + 256, "Konfirmasi")
            If nhps = 6 Then
                Dim queryhps As String = "DELETE FROM tb_keranjang_pengembalian WHERE no = " & no
                Query(queryhps)
                isigrid()
            End If
        Catch ex As Exception
            MsgBox("Silahkan pilih item buku!", 16, "Perhatian")
        End Try
    End Sub
    Sub simpanpengembalian()
        Dim simpandetail As String = "INSERT INTO tb_pengembalian_detail (kd_pengembalian, kd_buku) " _
                                        & "SELECT '" & tbkdpengembalian.Text & "', kd_buku FROM tb_keranjang_pengembalian"
        Query(simpandetail)
        For Each row As DataGridViewRow In dgv.Rows
            Dim kd_buku As String = row.Cells(1).Value.ToString
            Dim updatebuku As String = "UPDATE tb_peminjaman_detail SET status = '1' " _
                                     & "WHERE kd_peminjaman = '" & tbkdpeminjaman.Text & "' AND kd_buku = '" & kd_buku & "'"
            Query(updatebuku)
        Next
        Dim simpan As String = "INSERT INTO tb_pengembalian " _
                            & "VALUES ('" & tbkdpengembalian.Text & "', '" & Format(dtpkembali.Value, "yyyy-MM-dd") & "', '" & tbkdpeminjaman.Text & "')"
        Query(simpan)
        Dim nplh As Integer
        nplh = MsgBox("Pengembalian berhasil. Cetak bukti pengembalian?", 48 + 4 + 256, "Konfirmasi")
        If nplh = 6 Then
            CRViewer.pengembalian(tbkdpengembalian.Text)
            CRViewer.ShowDialog()
        End If
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim nplh As Integer
        nplh = MsgBox("Simpan pengembalian?", 48 + 4 + 256, "Konfirmasi")
        If nplh = 6 Then
            If dgv.RowCount = 0 Then
                MsgBox("Data buku masih kosong!", 16, "Perhatian")
            Else
                simpanpengembalian()
                tbkdpeminjaman.Clear()
                reset()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormDaftarPeminjaman.ShowDialog()
    End Sub

    Private Sub tbkdpeminjaman_TextChanged(sender As Object, e As EventArgs) Handles tbkdpeminjaman.TextChanged
        reset()
    End Sub
End Class