Public Class FormUtama

    Private Sub DataBukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataBukuToolStripMenuItem.Click
        FormBuku.ShowDialog()
    End Sub

    Private Sub DataPenerbitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPenerbitToolStripMenuItem.Click
        FormPenerbit.ShowDialog()
    End Sub

    Private Sub DataPengarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPengarangToolStripMenuItem.Click
        FormPengarang.ShowDialog()
    End Sub

    Private Sub FormUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub DataAnggotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataAnggotaToolStripMenuItem.Click
        FormAnggota.ShowDialog()
    End Sub

    Private Sub PeminjamanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeminjamanToolStripMenuItem.Click
        FormPeminjaman.ShowDialog()
    End Sub

    Private Sub PengembalianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengembalianToolStripMenuItem.Click
        FormPengembalian.ShowDialog()
    End Sub
End Class