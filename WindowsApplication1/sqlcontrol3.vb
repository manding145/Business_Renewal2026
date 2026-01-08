Imports MySql.Data.MySqlClient
Module slqcontrol3





    Public Class sqlcontrol3
        Private dbcon As New MySqlConnection("datasource=10.0.14.117;database='safecity';username=usera2;password=passa2;")
        Private dbcmd As MySqlCommand

        'DB data
        Public DBDA As MySqlDataAdapter
        Public DBDT As DataTable
        Public SqlDS As DataSet
        Public bsource As BindingSource

        'Query Parameters

        Public params As New List(Of MySqlParameter)

        ' QUERY STATISTICS
        Public RecordCount As Integer
        Public Exception As String


        Public Sub New()

        End Sub

        'ALLOW Coonnection string override
        Public Sub New(ByVal ConnectionString As String)
            dbcon = New MySqlConnection(ConnectionString)



        End Sub
        'Execute query stats
        Public Sub ExecQuery(ByVal Query As String)
            RecordCount = 0
            Exception = ""
            Try
                dbcon.Open()
                'CREATE DB COMMAND
                dbcmd = New MySqlCommand(Query, dbcon)

                'Load params into db command
                params.ForEach(Sub(p) dbcmd.Parameters.Add(p))

                'Clear params
                params.Clear()
                'Execute command & FIll dataset
                SqlDS = New DataSet
                DBDT = New DataTable
                DBDA = New MySqlDataAdapter(dbcmd)
                bsource = New BindingSource

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
            Dim NewParam As New MySqlParameter(Name, value)
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
                dbcmd = New MySqlCommand(StrInsertRecord, dbcon)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try





        End Sub






    End Class



End Module
