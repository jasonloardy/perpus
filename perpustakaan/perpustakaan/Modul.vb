Imports MySql.Data.MySqlClient

Module Modul
    Public strkon As String = "server=localhost;user=root;database=perpustakaan;Convert Zero Datetime=True"
    Public konek As MySqlConnection = New MySqlConnection(strkon)
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As New MySqlCommand
    Public dt As DataTable
    Public dr As MySqlDataReader
    Public dtgl As String
    Public Function koneksi() As Boolean
        Try
            If konek.State = ConnectionState.Closed Then
                konek.Open()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Koneksi ke database bermasalah!", 48, "Perhatian")
            Application.Exit()
            Return False
        End Try
    End Function
    Sub Query(ByVal query As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Function querycb(ByVal query As String)
        da = New MySqlDataAdapter(query, konek)
        Dim dt As New DataTable()
        da.Fill(dt)
        Return dt
    End Function
    Sub Querypenerbit(ByVal query As String, ByVal kd_penerbit As String, ByVal nama_penerbit As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_penerbit", kd_penerbit)
                cmd.Parameters.AddWithValue("@nama_penerbit", nama_penerbit)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub Querypengarang(ByVal query As String, ByVal kd_pengarang As String, ByVal nama_pengarang As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_pengarang", kd_pengarang)
                cmd.Parameters.AddWithValue("@nama_pengarang", nama_pengarang)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub Querybuku(ByVal query As String, ByVal kd_buku As String, ByVal judul As String, ByVal kd_pengarang As String, ByVal kd_penerbit As String, ByVal tahun_terbit As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_buku", kd_buku)
                cmd.Parameters.AddWithValue("@judul", judul)
                cmd.Parameters.AddWithValue("@kd_pengarang", kd_pengarang)
                cmd.Parameters.AddWithValue("@kd_penerbit", kd_penerbit)
                cmd.Parameters.AddWithValue("@tahun_terbit", tahun_terbit)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub Queryanggota(ByVal query As String, ByVal kd_anggota As String, ByVal nama As String, ByVal alamat As String, ByVal no_telp As String, ByVal role As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_anggota", kd_anggota)
                cmd.Parameters.AddWithValue("@nama", nama)
                cmd.Parameters.AddWithValue("@alamat", alamat)
                cmd.Parameters.AddWithValue("@no_telp", no_telp)
                cmd.Parameters.AddWithValue("@role", role)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub Querykeranjang(ByVal query As String, ByVal kd_buku As String, ByVal judul As String, ByVal tgl_kembali As Date)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_buku", kd_buku)
                cmd.Parameters.AddWithValue("@judul", judul)
                cmd.Parameters.AddWithValue("@tgl_kembali", tgl_kembali)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
End Module
