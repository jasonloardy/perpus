Imports MySql.Data.MySqlClient

Public Class FormPeminjaman

    Private Sub btnanggota_Click(sender As Object, e As EventArgs) Handles btnanggota.Click
        FormAnggota.from = "peminjaman"
        FormAnggota.ShowDialog()
    End Sub

    Private Sub btnbuku_Click(sender As Object, e As EventArgs) Handles btnbuku.Click
        FormBuku.from = "peminjaman"
        FormBuku.ShowDialog()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM tb_keranjang ORDER BY no DESC"
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
        dgv.Columns(3).HeaderText = "Tgl. Pengembalian"
        dgv.Columns(3).Width = 150
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub querytambah()
        Dim q As String = "INSERT INTO tb_keranjang (kd_buku,judul,tgl_kembali) VALUES (@kd_buku, @judul, @tgl_kembali)"
        Querykeranjang(q, tbkdbuku.Text, tbjudulbuku.Text.ToUpper, Format(dtpkembalibuku.Value, "yyyy-MM-dd"))
        isigrid()
    End Sub
    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        querytambah()
    End Sub
    Sub kode()
        cmd = New MySqlCommand("SELECT kd_peminjaman FROM tb_peminjaman ORDER BY kd_peminjaman DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        Dim currentdate As DateTime = DateTime.Now
        Dim kd As String = "PJM" & currentdate.ToString("yyMM")
        If Not dr.HasRows Then
            tbkdpeminjaman.Text = kd & "000001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_peminjaman").ToString, 6)) + 1
            If Len(hitung) = 1 Then
                tbkdpeminjaman.Text = kd & "00000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdpeminjaman.Text = kd & "0000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdpeminjaman.Text = kd & "000" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdpeminjaman.Text = kd & "00" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdpeminjaman.Text = kd & "0" & hitung
            ElseIf Len(hitung) = 6 Then
                tbkdpeminjaman.Text = kd & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub resetkeranjang()
        Dim q As String = "TRUNCATE TABLE tb_keranjang"
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
    Sub simpanpeminjaman()
        Dim simpandetail As String = "INSERT INTO tb_peminjaman_detail (kd_peminjaman, kd_buku, tgl_kembali) " _
                                        & "SELECT '" & tbkdpeminjaman.Text & "', kd_buku, tgl_kembali FROM tb_keranjang"
        Query(simpandetail)
        Dim simpan As String = "INSERT INTO tb_peminjaman " _
                            & "VALUES ('" & tbkdpeminjaman.Text & "', '" & Format(dtppinjaman.Value, "yyyy-MM-dd") & "', '" & tbkdanggota.Text & "')"
        Query(simpan)
        MsgBox("Peminjaman berhasil!")
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim nplh As Integer
        nplh = MsgBox("Simpan peminjaman?", 48 + 4 + 256, "Konfirmasi")
        If nplh = 6 Then
            If tbkdanggota.Text = "" Then
                MsgBox("Masukkan data anggota!", 16, "Perhatian")
            ElseIf dgv.RowCount = 0 Then
                MsgBox("Data buku masih kosong!", 16, "Perhatian")
            Else
                simpanpeminjaman()
                reset()
            End If
        End If
    End Sub
End Class