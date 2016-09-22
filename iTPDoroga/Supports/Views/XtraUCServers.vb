Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class XtraUCServers
    Dim blServers As Boolean = False
    Dim blDataBases As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub XtraUCServers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
    End Sub

    Private Sub ComboBoxEditServers_Enter(sender As Object, e As EventArgs) Handles ComboBoxEditServers.Enter
        If blServers Then Exit Sub

        Dim dr As Data.DataRow = Nothing

        Me.ComboBoxEditServers.Enabled = False
        Me.ComboBoxEditServers.Properties.Items.Clear()
        SplashScreenManager.ShowForm(GetType(WaitFormServers))
        SplashScreenManager.Default.SetWaitFormCaption("Ожидайте...")
        SplashScreenManager.Default.SetWaitFormDescription("Получение списка серверов.")

        Try
            For Each dr In Sql.SqlDataSourceEnumerator.Instance.GetDataSources().Rows
                If dr("InstanceName").ToString = "" Then
                    ComboBoxEditServers.Properties.Items.Add(dr("ServerName"))
                Else
                    ComboBoxEditServers.Properties.Items.Add(dr("ServerName") & "\" & dr("InstanceName"))
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            XtraMessageBox.Show(String.Format("Ошибка при попытке соединения с SQL server:{0}{1}{0}",
                                              Global.Microsoft.VisualBasic.ChrW(10), ex.Message),
                                              "Система: установка соединения с БД.", MessageBoxButtons.OK,
                                              MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Ошибка при заполнении выпадающего списка:{0}{1}{0}",
                                              Global.Microsoft.VisualBasic.ChrW(10), ex.Message),
                                              "Система: список доступных серверов.", MessageBoxButtons.OK,
                                              MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Finally
            dr = Nothing
            Me.ComboBoxEditServers.Enabled = True
            blServers = True
            SplashScreenManager.CloseForm(False)
        End Try
    End Sub

    Private Sub ComboBoxEditDB_Enter(sender As Object, e As EventArgs) Handles ComboBoxEditDB.Enter
        If blDataBases Then Exit Sub

        Me.ComboBoxEditDB.Enabled = False
        Me.ComboBoxEditDB.Properties.Items.Clear()
        SplashScreenManager.ShowForm(GetType(WaitFormServers))
        SplashScreenManager.Default.SetWaitFormCaption("Ожидайте...")
        SplashScreenManager.Default.SetWaitFormDescription("Получение списка баз данных.")

        For Each row In GetDatabaseNames(Me.ComboBoxEditServers.Text, Me.TextEditUser.Text, Me.TextEditPassword.Text)
            Me.ComboBoxEditDB.Properties.Items.Add(row)
        Next

        Me.ComboBoxEditDB.Enabled = True
        blDataBases = True
        SplashScreenManager.CloseForm(False)
    End Sub

#Region "Пользовательские функции и процедуры"
    Public Shared Function GetDatabaseNames(ByVal serName As String, ByVal usrName As String, pswStr As String) As List(Of String)
        Dim connString As String
        Dim databaseNames As New List(Of String)

        connString = "Data Source=" & serName & ";initial catalog=master;user id=" & usrName & ";password=" & pswStr

        If Not String.IsNullOrWhiteSpace(connString) Then
            Using cn As SqlConnection = New SqlConnection(connString)
                ' Open the connection 
                cn.Open()

                Using cmd As SqlCommand = New SqlCommand()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_databases"

                    Using myReader As SqlDataReader = cmd.ExecuteReader()
                        While (myReader.Read())
                            databaseNames.Add(myReader.GetString(0))
                        End While
                    End Using
                End Using
            End Using
        End If

        Return databaseNames
    End Function
#End Region
End Class
