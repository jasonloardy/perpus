Imports MySql.Data.MySqlClient

Public Class FormPengarang
    Public id_data As String
    Public mode As String
    Public from As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid()
        reset()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM tb_pengarang"
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
        dgv.Columns(0).HeaderText = "Kode pengarang"
        dgv.Columns(1).HeaderText = "Nama pengarang"
        dgv.Columns(0).Width = 150
        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub kode()
        cmd = New MySqlCommand("SELECT kd_pengarang FROM tb_pengarang ORDER BY kd_pengarang DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            tbkdpengarang.Text = "PNG00001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_pengarang").ToString, 5)) + 1
            If Len(hitung) = 1 Then
                tbkdpengarang.Text = "PNG0000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdpengarang.Text = "PNG000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdpengarang.Text = "PNG00" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdpengarang.Text = "PNG0" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdpengarang.Text = "PNG" & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub bersih()
        tbkdpengarang.Clear()
        tbnamapengarang.Clear()
    End Sub
    Sub reset()
        tbnamapengarang.Enabled = False
        bersih()
        btntambah.Enabled = True
        btntambah.Text = "Tambah"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub modesimpan()
        tbnamapengarang.Enabled = True
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
                tbkdpengarang.Text = .Item(0, baris).Value
                tbnamapengarang.Text = .Item(1, baris).Value
            End With
        End If
    End Sub
    Sub querytambah()
        Dim q As String = "INSERT INTO tb_pengarang VALUES (@kd_pengarang, @nama_pengarang)"
        Querypengarang(q, tbkdpengarang.Text, tbnamapengarang.Text.ToUpper)
        MsgBox("Berhasil tambah data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryedit()
        Dim q As String = "UPDATE tb_pengarang SET nama_pengarang = @nama_pengarang WHERE kd_pengarang = @kd_pengarang"
        Querypengarang(q, id_data, tbnamapengarang.Text.ToUpper)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryhapus()
        cmd.CommandText = "SELECT * FROM tb_buku WHERE kd_pengarang = '" & id_data & "'"
        cmd.Connection = konek
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("pengarang tidak dapat dihapus!", 48, "Perhatian")
        Else
            dr.Close()
            Dim query As String = "DELETE FROM tb_pengarang WHERE kd_pengarang = @kd_pengarang"
            Querypengarang(query, id_data, "")
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
            If tbnamapengarang.Text = "" Then
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
        nhps = MsgBox("Yakin hapus pengarang " & tbnamapengarang.Text & " (" & tbkdpengarang.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
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
            FormBuku.tbpengarang.Text = tbnamapengarang.Text & " - " & tbkdpengarang.Text
            Me.Close()
        End If
    End Sub
End Class
