Imports MySql.Data.MySqlClient
Module Module1
    Public strkon As String = "server=localhost;uid=root;pwd='';database=minimarket2022009a;Convert Zero Datetime=True"
    Public kon As New MySqlConnection(strkon)
    Public perintah As New MySqlCommand
    Public cek As MySqlDataReader
    Public simpan As Boolean
    Public mda As New MySqlDataAdapter
    Public ds As New DataSet
    Public user As String
    Public login
End Module
