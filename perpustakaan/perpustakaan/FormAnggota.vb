Imports MySql.Data.MySqlClient

Public Class FormAnggota
    Public mode As String
    Public id_data As String
    Public from As String
    Private Sub Formanggota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid()
        reset()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT kd_anggota,nama,alamat,no_telp, " _
                            & "CASE " _
                            & "WHEN role = 'D' then 'Dosen' " _
                            & "WHEN role = 'M' then 'Mahasiswa' " _
                            & "WHEN role = 'P' then 'Pustakawan' " _
                            & "END " _
                            & "FROM tb_anggota"
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
        dgv.Columns(0).HeaderText = "Kode Anggota"
        dgv.Columns(0).Width = 100
        dgv.Columns(1).HeaderText = "Nama Anggota"
        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(2).HeaderText = "Alamat"
        dgv.Columns(2).Width = 100
        dgv.Columns(3).HeaderText = "No. Telepon"
        dgv.Columns(3).Width = 100
        dgv.Columns(4).HeaderText = "Role"
        dgv.Columns(4).Width = 100
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub kode()
        cmd = New MySqlCommand("SELECT kd_anggota FROM tb_anggota ORDER BY kd_anggota DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        Dim currentdate As DateTime = DateTime.Now
        Dim kd As String = "AGT"
        If Not dr.HasRows Then
            tbkdanggota.Text = kd & "00001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_anggota").ToString, 5)) + 1
            If Len(hitung) = 1 Then
                tbkdanggota.Text = kd & "0000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdanggota.Text = kd & "000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdanggota.Text = kd & "00" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdanggota.Text = kd & "0" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdanggota.Text = kd & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub bersih()
        tbkdanggota.Clear()
        tbnama.Clear()
        tbalamat.Clear()
        tbnotelp.Clear()
        cbrole.SelectedIndex = -1
    End Sub
    Sub reset()
        tbnama.Enabled = False
        tbalamat.Enabled = False
        tbnotelp.Enabled = False
        cbrole.Enabled = False
        bersih()
        btntambah.Enabled = True
        btntambah.Text = "Tambah"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub modesimpan()
        tbnama.Enabled = True
        tbalamat.Enabled = True
        tbnotelp.Enabled = True
        cbrole.Enabled = True
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
                tbkdanggota.Text = .Item(0, baris).Value
                tbnama.Text = .Item(1, baris).Value
                tbalamat.Text = .Item(2, baris).Value
                tbnotelp.Text = .Item(3, baris).Value
                cbrole.Text = .Item(4, baris).Value
            End With
        End If
    End Sub
    Sub querytambah()
        Dim q As String = "INSERT INTO tb_anggota VALUES (@kd_anggota, @nama, @alamat, @no_telp, @role)"
        Queryanggota(q, tbkdanggota.Text, tbnama.Text.ToUpper, tbalamat.Text, tbnotelp.Text, Microsoft.VisualBasic.Left(cbrole.Text, 1))
        MsgBox("Berhasil tambah data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryedit()
        Dim q As String = "UPDATE tb_anggota SET nama=@nama,alamat=@alamat,no_telp=@no_telp,role=@role WHERE kd_anggota = @kd_anggota"
        Queryanggota(q, tbkdanggota.Text, tbnama.Text.ToUpper, tbalamat.Text, tbnotelp.Text, Microsoft.VisualBasic.Left(cbrole.Text, 1))
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryhapus()
        cmd.CommandText = "SELECT * FROM tb_pinjaman_detail WHERE kd_anggota = '" & id_data & "'"
        cmd.Connection = konek
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("anggota tidak dapat dihapus!", 48, "Perhatian")
        Else
            dr.Close()
            Dim query As String = "DELETE FROM tb_anggota WHERE kd_anggota = @kd_anggota"
            Queryanggota(query, id_data, "", "", "", "")
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
            If tbnama.Text = "" Then
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
        nhps = MsgBox("Yakin hapus anggota " & tbnama.Text & " (" & tbkdanggota.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
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

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If from = "peminjaman" Then
            With FormPeminjaman
                .tbkdanggota.Text = tbkdanggota.Text
                .tbnama.Text = tbnama.Text
                .tbalamat.Text = tbalamat.Text
                .tbnotelp.Text = tbnotelp.Text
                .tbrole.Text = cbrole.Text
            End With
            Me.Close()
        End If
    End Sub
End Class