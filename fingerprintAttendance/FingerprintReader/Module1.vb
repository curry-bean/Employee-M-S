Imports System.Data.OleDb
Module Module1
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader
    Public lst As ListViewItem
    Public Sub Connection()
        cn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\GrFingerSample.mdb")
        cn.Open()
    End Sub
End Module
