Imports MySql.Data.MySqlClient

Public Class FormDaftarPeminjaman

    Private Sub FormDaftarPeminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT tp.tanggal,tp.kd_peminjaman,ta.kd_anggota,ta.nama,ta.alamat,ta.no_telp," _
                            & "CASE " _
                            & "WHEN ta.role = 'D' then 'Dosen' " _
                            & "WHEN ta.role = 'M' then 'Mahasiswa' " _
                            & "WHEN ta.role = 'P' then 'Pustakawan' " _
                            & "END AS role " _
                            & "FROM tb_peminjaman tp " _
                            & "JOIN tb_anggota ta ON tp.kd_anggota=ta.kd_anggota " _
                            & "JOIN tb_peminjaman_detail tpd ON tp.kd_peminjaman=tpd.kd_peminjaman " _
                            & "WHERE tpd.tgl_kembali IS NULL " _
                            & "GROUP by tp.kd_peminjaman"
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
            FormPengembalian.tbkdpeminjaman.Text = .Item(1, baris).Value
            FormPengembalian.tbkdanggota.Text = .Item(2, baris).Value
            FormPengembalian.tbnama.Text = .Item(3, baris).Value
            FormPengembalian.tbalamat.Text = .Item(4, baris).Value
            FormPengembalian.tbnotelp.Text = .Item(5, baris).Value
            FormPengembalian.tbrole.Text = .Item(6, baris).Value
            End With
        Me.Close()
    End Sub
End Class