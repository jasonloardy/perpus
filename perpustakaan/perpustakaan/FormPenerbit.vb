Imports MySql.Data.MySqlClient

Public Class FormPenerbit
    Public id_data As String
    Public mode As String
    Public from As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid()
        reset()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM tb_penerbit"
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
        dgv.Columns(0).HeaderText = "Kode Penerbit"
        dgv.Columns(1).HeaderText = "Nama Penerbit"
        dgv.Columns(0).Width = 150
        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub kode()
        cmd = New MySqlCommand("SELECT kd_penerbit FROM tb_penerbit ORDER BY kd_penerbit DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            tbkdpenerbit.Text = "PBT00001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_penerbit").ToString, 5)) + 1
            If Len(hitung) = 1 Then
                tbkdpenerbit.Text = "PBT0000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdpenerbit.Text = "PBT000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdpenerbit.Text = "PBT00" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdpenerbit.Text = "PBT0" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdpenerbit.Text = "PBT" & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub bersih()
        tbkdpenerbit.Clear()
        tbnamapenerbit.Clear()
    End Sub
    Sub reset()
        tbnamapenerbit.Enabled = False
        bersih()
        btntambah.Enabled = True
        btntambah.Text = "Tambah"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub modesimpan()
        tbnamapenerbit.Enabled = True
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
                tbkdpenerbit.Text = .Item(0, baris).Value
                tbnamapenerbit.Text = .Item(1, baris).Value
            End With
        End If
    End Sub
    Sub querytambah()
        Dim q As String = "INSERT INTO tb_penerbit VALUES (@kd_penerbit, @nama_penerbit)"
        Querypenerbit(q, tbkdpenerbit.Text, tbnamapenerbit.Text.ToUpper)
        MsgBox("Berhasil tambah data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryedit()
        Dim q As String = "UPDATE tb_penerbit SET nama_penerbit = @nama_penerbit WHERE kd_penerbit = @kd_penerbit"
        Querypenerbit(q, id_data, tbnamapenerbit.Text.ToUpper)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryhapus()
        cmd.CommandText = "SELECT * FROM tb_buku WHERE kd_penerbit = '" & id_data & "'"
        cmd.Connection = konek
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("penerbit tidak dapat dihapus!", 48, "Perhatian")
        Else
            dr.Close()
            Dim query As String = "DELETE FROM tb_penerbit WHERE kd_penerbit = @kd_penerbit"
            Querypenerbit(query, id_data, "")
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
            If tbnamapenerbit.Text = "" Then
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
        nhps = MsgBox("Yakin hapus penerbit " & tbnamapenerbit.Text & " (" & tbkdpenerbit.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
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
        If from = "buku" Then
            FormBuku.tbpenerbit.Text = tbnamapenerbit.Text & " - " & tbkdpenerbit.Text
            Me.Close()
        End If
    End Sub
End Class
