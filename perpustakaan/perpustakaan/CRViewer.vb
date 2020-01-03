Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class CRViewer
    Dim cryReport As New ReportDocument
    Dim RepLocation = Path.GetFullPath( _
            Path.Combine(Application.StartupPath, "..\..\"))
    Sub peminjaman(ByVal kd_peminjaman As String)
        cryReport.Load(RepLocation & "CRPeminjaman.rpt")
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_peminjaman", kd_peminjaman)
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
    Sub pengembalian(ByVal kd_pengembalian As String)
        cryReport.Load(RepLocation & "CRPengembalian.rpt")
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_pengembalian", kd_pengembalian)
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
    Sub lappeminjaman()
        cryReport.Load(RepLocation & "CRLapPeminjaman.rpt")
        cryReport.Refresh()
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
    Sub lappengembalian()
        cryReport.Load(RepLocation & "CRLapPengembalian.rpt")
        cryReport.Refresh()
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
End Class