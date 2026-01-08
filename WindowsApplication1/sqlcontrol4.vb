Imports System.Data.SqlClient



Public Class sqlcontrol4
    'Private dbcon As New SqlConnection("Server=10.0.0.2;Database=GeoTos;USER=sa;PASSWORD=@dm1n1str@t0r;")
    Private dbcon As New SqlConnection("Server=58.69.249.245;Database=GeoRecords;USER=sa;PASSWORD=@dm1n1str@t0r;")
    'For Remote
    ' Private dbcon As New SqlConnection("Server=58.69.249.245;Database=GeoRecords;USER=sa;PASSWORD=@dm1n1str@t0r;")
    Private dbcmd As SqlCommand

    'DB data
    Public DBDA As SqlDataAdapter
    Public DBDT As DataTable
    Public SqlDS As DataSet

    'Query Parameters

    Public params As New List(Of SqlParameter)

    ' QUERY STATISTICS
    Public RecordCount As Integer
    Public Exception As String


    Public Sub New()

    End Sub

    'ALLOW Coonnection string override
    Public Sub New(ByVal ConnectionString As String)
        dbcon = New SqlConnection(ConnectionString)


    End Sub
    'Execute query stats
    Public Sub ExecQuery(ByVal Query As String)
        RecordCount = 0
        Exception = ""
        Try
            dbcon.Open()
            'CREATE DB COMMAND
            dbcmd = New SqlCommand(Query, dbcon)

            'Load params into db command
            params.ForEach(Sub(p) dbcmd.Parameters.Add(p))

            'Clear params
            params.Clear()
            'Execute command & FIll dataset
            SqlDS = New DataSet
            DBDT = New DataTable
            DBDA = New SqlDataAdapter(dbcmd)
            RecordCount = DBDA.Fill(DBDT)

            'MsgBox("connected")

        Catch ex As Exception
            'CAPTURE ERROR
            Exception = "ExecQuery Error; " & vbNewLine & ex.Message

        Finally

            'CLose Connection
            If dbcon.State = ConnectionState.Open Then dbcon.Close()
        End Try
    End Sub
    'ADD PARAMS
    Public Sub AddParam(ByVal Name As String, ByVal value As Object)
        Dim NewParam As New SqlParameter(Name, value)
        params.Add(NewParam)

    End Sub
    'ERROR CHEcking
    Public Function HasException(Optional ByVal report As Boolean = False) As Boolean
        If String.IsNullOrEmpty(Exception) Then Return False
        If report = True Then MsgBox(Exception, MsgBoxStyle.Exclamation, " exception;")

        Return True


    End Function

    Public Function HasConnection() As Boolean
        Try
            dbcon.Open()

            dbcon.Close()
            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False

    End Function


    Public Sub AddRecord(ByVal Username As String, ByVal PAYTO As String, ByVal Amount As Decimal, ByVal Amountwords As String, ByVal strDate As String)
        Try
            Dim StrInsertRecord As String = "INSERT INTO bankchecks (username,payto,amount,amountwords,strdate)" & _
                                      "VALUES (" & _
                                      "'" & Username & "'," & _
                                      "'" & PAYTO & "'," & _
                                      "'" & Amount & "'," & _
                                      "'" & Amountwords & "'," & _
                                      "'" & strDate & "' "
            MsgBox(StrInsertRecord)

            dbcon.Open()
            dbcmd = New SqlCommand(StrInsertRecord, dbcon)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try





    End Sub

End Class


