Imports System.Data
Imports System.Data.OleDb
Imports Aerospike.Client

Public Class Conexao
    Dim StrlCaminho As String = "C:\Users\gamer\Documents\Database2.accdb"
    Dim cn As OleDbConnection
    Sub Conect()
        Dim Testeconect As Boolean
        cn = New OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA Source=" & StrlCaminho & "")
        Try
            cn.Open()
            Testeconect = True
        Catch ex As Exception
            Testeconect = False
        End Try
        If Testeconect = True Then
        Else
            Console.WriteLine("result error ")
        End If
        Call Table()
        'cn.Close()
    End Sub
    Sub Table()
        Dim Table As New OleDbCommand
        Dim clientesReader As OleDbDataReader
        Dim i As Integer = 0
        Table.Connection = cn
        Table.CommandText = "SELECT TableSoares.* FROM TableSoares;"
        clientesReader = Table.ExecuteReader()
        Try
            Dim readerTemRegistros As Boolean = clientesReader.Read
            While readerTemRegistros = True
                Console.WriteLine("Nome cabloco: " & clientesReader.GetValue(1).ToString)
                Console.WriteLine("Idade: " & clientesReader.GetValue(2).ToString)
                readerTemRegistros = clientesReader.Read()
            End While
        Catch ex As Exception

        End Try
        cn.Close()
    End Sub
End Class
