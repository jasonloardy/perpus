Imports MySql.Data.MySqlClient

Public Class FormDaftarBukuPeminjaman

    Private Sub FormDaftarPeminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT tb.kd_buku,tb.judul,tpd.tgl_kembali,IF(tpd.status=0,'Belum Kembali','Sudah Kembali') AS status," _
                            & "TIMESTAMPDIFF(DAY, tpd.tgl_kembali, CURDATE()) AS jmlhari " _
                            & "FROM tb_peminjaman_detail tpd " _
                            & "JOIN tb_buku tb ON tpd.kd_buku = tb.kd_buku " _
                            & "LEFT JOIN tb_keranjang tk ON tpd.kd_buku=tk.kd_buku " _
                            & "WHERE tpd.kd_peminjaman = '" & FormPengembalian.tbkdpeminjaman.Text & "' and tpd.status='0' AND tk.kd_buku IS NULL"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgv.DataSource = ds.Tables(0)
            dgv.Refresh()
        Else
            dgv.DataSource = Nothing
        End If
        If dgv.RowCount > 0 Then
            'judulgrid()
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        With dgv
            Dim baris As Integer = .CurrentRow.Index
            If .Item(3, baris).Value = "Belum Kembali" Then
                FormPengembalian.tbkdbuku.Text = .Item(0, baris).Value
                FormPengembalian.tbjudulbuku.Text = .Item(1, baris).Value
                Me.Close()
            End If
        End With
    End Sub
End Class