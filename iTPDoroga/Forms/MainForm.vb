Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Docking2010.Views.WindowsUI
Imports DevExpress.XtraBars.Docking2010.Customization
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports System.Configuration
Imports System.Configuration.ConfigurationManager
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraSplashScreen

Partial Public Class MainForm
    Inherits XtraForm

    Private dataSource As SampleDataSource
    Private groupsItemDetailPage As Dictionary(Of SampleDataGroup, PageGroup)
    Private ucLoginAction As FlyoutAction = New FlyoutAction()
    Private ucServersAction As FlyoutAction = New FlyoutAction()
    Private clAppAction As FlyoutAction = New FlyoutAction()

    Dim _ucLogin As New XtraUCLogin()
    Dim _ucServers As New XtraUCServers()
    Dim blUCServers As Boolean = False

    Public Sub New()
        InitializeComponent()

        Me.windowsUIViewMain.AddDocument(_ucLogin)
        ucLoginAction.Caption = "Идентификация пользователя:"
        ucLoginAction.Commands.Add(FlyoutCommand.OK)
        ucLoginAction.Commands.Add(FlyoutCommand.Cancel)
        Me.windowsUIViewMain.AddDocument(_ucServers)
        ucServersAction.Caption = "Формирование строки подключения к БД:"
        ucServersAction.Commands.Add(FlyoutCommand.OK)
        ucServersAction.Commands.Add(FlyoutCommand.Cancel)
        clAppAction.Caption = "Сообщение системы:"
        clAppAction.Description = "Завершение работы приложения."
        closeAppFlyout.FlyoutButtons = MessageBoxButtons.OK
        closeAppFlyout.Action = clAppAction

        windowsUIViewMain.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.False
        dataSource = New SampleDataSource()
        groupsItemDetailPage = New Dictionary(Of SampleDataGroup, PageGroup)()

        If (Not ConnectionDB()) Then Return

        AddHandler Me.windowsUIViewMain.QueryControl, AddressOf windowsUIViewMain_QueryControl
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TimerServers.Enabled = True
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.windowsUIViewMain.ActivateContainer(ucLoginFlyout)
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If gblExit Then Exit Sub

        If Me.windowsUIViewMain.ShowFlyoutDialog(closeAppFlyout) = System.Windows.Forms.DialogResult.OK Then
            gblExit = True
            e.Cancel = False
            Me.TimerServers.Enabled = False
        End If
    End Sub

    Private Sub TimerServers_Tick(sender As Object, e As EventArgs) Handles TimerServers.Tick
        If blUCServers = False Then Exit Sub

        blUCServers = False
        Me.TimerServers.Enabled = False
        Me.windowsUIViewMain.ActivateContainer(ucServersFlyout)
    End Sub

    ' Assigning a required content for each auto generated Document
    Sub windowsUIViewMain_QueryControl(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs)
        If e.Document Is addLoginDocument Then
            e.Control = New iTPDoroga.XtraUCLogin()
            Console.WriteLine("Панель логинов...")
        End If

        If e.Document Is openServersDocument Then
            e.Control = New iTPDoroga.XtraUCServers()
            Console.WriteLine("Панель серверов...")
        End If

        If e.Document Is closeAppFlyout Then
            'e.Control = New iTPDoroga.XtraUCServers()
            Console.WriteLine("Панель завершения...")
        End If

        If e.Control Is Nothing Then
            e.Control = New System.Windows.Forms.Control()
        End If
    End Sub

    Private Sub windowsUIViewMain_FlyoutHidden(sender As Object, e As FlyoutResultEventArgs) Handles windowsUIViewMain.FlyoutHidden
        Select Case sender.ActiveDocument.ControlName.ToString
            Case "XtraUCLogin"
                If e.Result = System.Windows.Forms.DialogResult.OK Then
                    If _ucLogin.ComboBoxEditPerson.Properties.Items.Count > 1 Then
                        ' Проверка доступа пользователя и его права
                        If Trim(_ucLogin.ComboBoxEditPerson.Text).Split(" ")(0) = "Администратор" AndAlso Trim(_ucLogin.TextEditPassword.Text) = "sandozik" Then
                            pUserL = "A"
                            pUserF = "Администратор системы"
                            pUserS = "Полный доступ"
                        Else
                            pUserL = "U"
                        End If

                        Call CreateLayout()
                    Else
                        If Trim(_ucLogin.ComboBoxEditPerson.Text).Split(" ")(0) = "Администратор" AndAlso Trim(_ucLogin.TextEditPassword.Text) = "sandozik" Then
                            blUCServers = True
                        Else
                            XtraMessageBox.Show(String.Format("Ошибка при вводе пароля.{0}{0}Система будет перезапущена.",
                                          Global.Microsoft.VisualBasic.ChrW(10)),
                                        "Система: идентификация пользователя.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            gblExit = True
                            Application.Restart()
                        End If
                    End If
                Else
                    gblExit = True
                    Me.windowsUIViewMain.ShowFlyoutDialog(closeAppFlyout)
                    Application.Exit()
                End If
            Case "XtraUCServers"
                If e.Result = System.Windows.Forms.DialogResult.OK Then
                    ToggleConfigEncryption("iTPDoroga.exe", SetConnectionString(_ucServers.ComboBoxEditServers.Text,
                                                                                _ucServers.ComboBoxEditDB.Text,
                                                                                _ucServers.TextEditUser.Text, _ucServers.TextEditPassword.Text), "DorogaConnectionString")
                    gblExit = True
                    Application.Restart()
                Else
                    gblExit = True
                    Me.windowsUIViewMain.ShowFlyoutDialog(closeAppFlyout)
                    Application.Exit()
                End If
        End Select
    End Sub

#Region "Пользовательские функции и процедуры"
    ''' <summary>
    ''' Функция: Проверка существования соединения с БД на SQL server
    ''' </summary>
    Private Function ConnectionDB() As Boolean
        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration("iTPDoroga.exe")
        Dim section As ConnectionStringsSection = DirectCast(config.GetSection("connectionStrings"), ConnectionStringsSection)

        If section.SectionInformation.IsProtected Then
            ' Удаление криптования секции файла конфигурации.
            section.SectionInformation.UnprotectSection()
        End If

        gConnMain.ConnectionString = My.Settings.DorogaConnectionString

        Try
            Me.windowsUIViewMain.SplashScreenProperties.LoadingDescription = "Устанавливается соединения с сервером БД"

            Call ConnectDBExtracted(25)

            gConnMain.Open()
            gblConn = True
            Me.windowsUIViewMain.SplashScreenProperties.LoadingDescription = "Соединение с сервером БД установлено"
        Catch ex As Exception
            gblConn = False
            Me.windowsUIViewMain.SplashScreenProperties.LoadingDescription = "Соединение с сервером БД не установлено"
        Finally
            gConnMain.Close()
        End Try

        Call ConnectDBExtracted(20)

        If gblConn Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CreateLayout()
        SplashScreenManager.ShowForm(GetType(WaitFormMain))
        SplashScreenManager.Default.SetWaitFormCaption("Ожидайте...")
        SplashScreenManager.Default.SetWaitFormDescription("Идет построение главной страницы.")

        For Each group As SampleDataGroup In dataSource.Data.Groups
            ' Проверка статуса пользователя
            If pUserL <> "A" And group.Name = "Сервис" Then Continue For

            mainTileContainer.Buttons.Add(New DevExpress.XtraBars.Docking2010.WindowsUIButton(group.Title, Nothing, -1, DevExpress.XtraBars.Docking2010.ImageLocation.AboveText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, Nothing, True, -1, True, Nothing, False, False, True, Nothing, group, -1, False, False))

            Dim pageGroup As New PageGroup()

            pageGroup.Parent = mainTileContainer
            pageGroup.Caption = group.Title
            windowsUIViewMain.ContentContainers.Add(pageGroup)
            groupsItemDetailPage.Add(group, CreateGroupItemDetailPage(group, pageGroup))

            For Each item As SampleDataItem In group.Items
                If group.Name = "Сервис" Then
                    Dim itemDetailPage As New ItemDetailPagePerson(item)

                    itemDetailPage.Dock = DockStyle.Fill

                    Dim document As BaseDocument = windowsUIViewMain.AddDocument(itemDetailPage)

                    Call CreateDetailItem(document, item, pageGroup)
                Else
                    Dim itemDetailPage As New ItemDetailPage(item)

                    itemDetailPage.Dock = DockStyle.Fill

                    Dim document As BaseDocument = windowsUIViewMain.AddDocument(itemDetailPage)

                    Call CreateDetailItem(document, item, pageGroup)
                End If
            Next item
        Next group

        windowsUIViewMain.ActivateContainer(mainTileContainer)
        AddHandler mainTileContainer.ButtonClick, AddressOf buttonClick
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub CreateDetailItem(ByVal _doc As BaseDocument, ByVal _item As SampleDataItem, ByVal _pageGroup As PageGroup)
        _doc.Caption = _item.Title
        _pageGroup.Items.Add(TryCast(_doc, Document))
        CreateTile(TryCast(_doc, Document), _item).ActivationTarget = _pageGroup
    End Sub

    Private Function CreateTile(ByVal document As Document, ByVal item As SampleDataItem) As Tile
        Dim tile As New Tile()

        tile.Document = document
        tile.Group = item.GroupName
        tile.Tag = item
        tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.BottomLeft, Point.Empty, 9))
        tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.Manual, New Point(0, 100), 12))
        tile.Appearances.Normal.BackColor = Color.FromArgb(140, 140, 140)
        tile.Appearances.Hovered.BackColor = tile.Appearances.Normal.BackColor
        tile.Appearances.Selected.BackColor = tile.Appearances.Hovered.BackColor
        tile.Appearances.Normal.BorderColor = Color.FromArgb(140, 140, 140)
        tile.Appearances.Hovered.BorderColor = tile.Appearances.Normal.BorderColor
        tile.Appearances.Selected.BorderColor = tile.Appearances.Hovered.BorderColor

        AddHandler tile.Click, AddressOf tile_Click
        windowsUIViewMain.Tiles.Add(tile)
        mainTileContainer.Items.Add(tile)
        Return tile
    End Function

    Private Function CreateTileItemElement(ByVal text As String, ByVal alignment As TileItemContentAlignment, ByVal location As Point, ByVal fontSize As Single) As TileItemElement
        Dim element As New TileItemElement()

        element.TextAlignment = alignment

        If Not location.IsEmpty Then
            element.TextLocation = location
        End If

        element.Appearance.Normal.Options.UseFont = True
        element.Appearance.Normal.Font = New Font(New FontFamily("Segoe UI Symbol"), fontSize)
        element.Text = text
        Return element
    End Function

    Private Sub tile_Click(ByVal sender As Object, ByVal e As TileClickEventArgs)
        Dim page As PageGroup = (TryCast((TryCast(e.Tile, Tile)).ActivationTarget, PageGroup))

        If page IsNot Nothing Then
            page.Parent = mainTileContainer
            page.SetSelected((TryCast(e.Tile, Tile)).Document)
        End If
    End Sub

    Private Function CreateGroupItemDetailPage(ByVal group As SampleDataGroup, ByVal child As PageGroup) As PageGroup
        Dim page As New GroupDetailPage(group, child)
        Dim pageGroup As PageGroup = page.PageGroup
        Dim document As BaseDocument = windowsUIViewMain.AddDocument(page)

        pageGroup.Parent = mainTileContainer
        pageGroup.Items.Add(TryCast(document, Document))
        windowsUIViewMain.ContentContainers.Add(pageGroup)
        windowsUIViewMain.ActivateContainer(pageGroup)
        Return pageGroup
    End Function

    Private Sub buttonClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.ButtonEventArgs)
        Dim tileGroup As SampleDataGroup = (TryCast(e.Button.Properties.Tag, SampleDataGroup))

        If tileGroup IsNot Nothing Then
            windowsUIViewMain.ActivateContainer(groupsItemDetailPage(tileGroup))

            Console.WriteLine(String.Format("groupsItemDetailPage({0}) = {1}", tileGroup, groupsItemDetailPage(tileGroup).Caption))
        End If
    End Sub
#End Region
End Class
