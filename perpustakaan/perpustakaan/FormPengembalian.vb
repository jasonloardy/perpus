Imports MySql.Data.MySqlClient

Public Class FormPengembalian

    Private Sub btnanggota_Click(sender As Object, e As EventArgs)
        FormAnggota.from = "peminjaman"
        FormAnggota.ShowDialog()
    End Sub

    Private Sub btnbuku_Click(sender As Object, e As EventArgs) Handles btnbuku.Click
        FormDaftarBukuPeminjaman.ShowDialog()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT no, kd_buku, judul, " _
                            & "CONCAT(IF(TIMESTAMPDIFF(DAY, tgl_kembali, CURDATE())>0,'Telat ','Sisa '), " _
                            & "ABS(TIMESTAMPDIFF(DAY, tgl_kembali, CURDATE())), ' hari') AS jmlhari " _
                            & "FROM tb_keranjang ORDER BY no DESC"
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
        Dim q As String = "INSERT INTO tb_keranjang (kd_buku,judul,tgl_kembali) VALUES (@kd_buku, @judul, @tgl_kembali)"
        Querykeranjang(q, tbkdbuku.Text, tbjudulbuku.Text.ToUpper, tbjmlhari.Text)
        isigrid()
    End Sub
    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        querytambah()
        tbkdbuku.Clear()
        tbjudulbuku.Clear()
        tbjmlhari.Clear()
    End Sub
    Sub resetkeranjang()
        Dim q As String = "TRUNCATE TABLE tb_keranjang"
        Query(q)
    End Sub
    Sub reset()
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
                Dim queryhps As String = "DELETE FROM tb_keranjang WHERE no = " & no
                Query(queryhps)
                isigrid()
            End If
        Catch ex As Exception
            MsgBox("Silahkan pilih item buku!", 16, "Perhatian")
        End Try
    End Sub
    Sub simpanpengembalian()
        For Each row As DataGridViewRow In dgv.Rows
            Dim kd_buku As String = row.Cells(1).Value.ToString
            Dim updatebuku As String = "UPDATE tb_peminjaman_detail SET tgl_kembali = '" & Format(dtpkembali.Value, "yyyy-MM-dd") & "'" _
                                     & "WHERE kd_peminjaman = '" & tbkdpeminjaman.Text & "' AND kd_buku = '" & kd_buku & "'"
            Query(updatebuku)
        Next
        Dim nplh As Integer
        nplh = MsgBox("Pengembalian berhasil", MsgBoxStyle.Information, "Informasi")
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