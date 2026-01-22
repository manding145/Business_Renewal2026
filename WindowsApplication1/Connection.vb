Imports System.Data
Imports System.Data.SqlClient
Module Connection


    Public appointmentID_search, recordid_search As Integer
    Public namefile, myemail, mypassword, link_prefix, lblfname1, lbluserrole1 As String
    Public FormStatus As Boolean
    Public username, password, userfullname, userid1, userid, userlevelid, TypeCard As String
    Public formid As Integer
    Public Con As SqlConnection
    Public cmd As SqlCommand
    Public rdr As SqlDataReader = Nothing
    Public adp As SqlDataAdapter
    Public sbuldr As SqlCommandBuilder
    Public conn, PhoneNumber As String
    Public type_transaction As Integer
    Public Con1 As SqlConnection
    Public cmd1 As SqlCommand
    Public rdr1 As SqlDataReader = Nothing
    Public adp1 As SqlDataAdapter
    Public sbuldr1 As SqlCommandBuilder
    Public conn1 As String
    Public Con3 As SqlConnection
    Public cmd3 As SqlCommand
    Public rdr3 As SqlDataReader = Nothing
    Public adp3 As SqlDataAdapter
    Public sbuldr3 As SqlCommandBuilder
    Public conn3 As String
    Public Con4 As SqlConnection
    Public cmd4 As SqlCommand
    Public rdr4 As SqlDataReader = Nothing
    Public adp4 As SqlDataAdapter
    Public sbuldr4 As SqlCommandBuilder
    Public conn4 As String

    ''Public cs As String = "Server=RONALDORONOC123;Database=Queue;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs As String = "Server=RONALDORONOC123;Database=Master;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs2 As String = "Server=RONALDORONOC123;Database=GeoTos;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs1 As String = "Server=RONALDORONOC123;Database=CHO;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs3 As String = "Server=RONALDORONOC123;Database=CHO;User ID=sa;Password=@dm1n1$tr@t0r;"

    ''Public cs As String = "Server=10.0.0.2;Database=Master;User ID=sa;Password=@dm1n1str@t0r;"
    'Public cs1 As String = "Server=10.0.0.2;Database=CHO;User ID=sa;Password=@dm1n1str@t0r;"
    ''Public cs2 As String = "Server=10.0.0.2;Database=GeoTos;User ID=sa;Password=@dm1n1str@t0r;"
    ''Public cs3 As String = "Server=10.0.0.2;Database=CHO;User ID=sa;Password=@dm1n1str@t0r;"
    ''Public cs4 As String = "Server=10.0.0.2;Database=GeoRecords;User ID=sa;Password=@dm1n1str@t0r;"




    Public cs As String = "Server=" & My.Settings.Server & ";Database=GeoRecords;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"

    'Public cs5 As String = "Server=" & My.Settings.Server & ";Database=BPLS;User ID=sa;Password=@dm1n1str@t0r;"


    Public cs1 As String = "Server=" & My.Settings.Server & ";Database=CHO;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    Public cs2 As String = "Server=" & My.Settings.Server & ";Database=GeoTos;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    Public cs3 As String = "Server=" & My.Settings.Server & ";Database=CHO;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    Public cs4 As String = "Server=" & My.Settings.Server & ";Database=GeoRecords;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"


    'Public cs As String = "Server=" & My.Settings.Server & ";Database=Master;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs1 As String = "Server=" & My.Settings.Server & ";Database=CHO;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs2 As String = "Server=" & My.Settings.Server & ";Database=GeoTos;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs3 As String = "Server=" & My.Settings.Server & ";Database=CHO;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs4 As String = "Server=" & My.Settings.Server & ";Database=GeoRecords;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"

    'Public cs As String = "Server=RONALDORONOC123;Database=Master;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs2 As String = "Server=RONALDORONOC123;Database=GeoTos;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs1 As String = "Server=RONALDORONOC123;Database=CHO;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs3 As String = "Server=RONALDORONOC123;Database=CHO;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs4 As String = "Server=RONALDORONOC123;Database=GeoRecords;User ID=sa;Password=@dm1n1$tr@t0r;"
End Module
