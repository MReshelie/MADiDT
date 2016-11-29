Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository

Public Class XtraUCFileExplorer
    Public Shared ReadOnly MaxEntitiesCount As Integer = 80

    Public Sub New()
        InitializeComponent()

        Call Initialize()
    End Sub

    Private Sub myItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub Properties_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub breadCrumbEdit_Properties_NewNodeAdding(sender As Object, e As BreadCrumbNewNodeAddingEventArgs) Handles breadCrumbEdit.Properties.NewNodeAdding
        e.Node.PopulateOnDemand = True
    End Sub

    Private Sub breadCrumbEdit_Properties_ValidatePath(sender As Object, e As BreadCrumbValidatePathEventArgs) Handles breadCrumbEdit.Properties.ValidatePath
        If (Not Directory.Exists(e.Path)) Then
            e.ValidationResult = BreadCrumbValidatePathResult.Cancel
            Return
        End If

        e.ValidationResult = BreadCrumbValidatePathResult.CreateNodes
    End Sub

    Private Sub breadCrumbEdit_Properties_QueryChildNodes(sender As Object, e As BreadCrumbQueryChildNodesEventArgs) Handles breadCrumbEdit.Properties.QueryChildNodes
        'Add custom shortcuts to the 'Root' node
        If String.Equals(e.Node.Caption, "Root", StringComparison.Ordinal) Then
            InitBreadCrumbRootNode(e.Node)
            Return
        End If

        'Add local discs shortcuts to the 'Root' node
        If String.Equals(e.Node.Caption, "Мой компьютер", StringComparison.Ordinal) Then
            InitBreadCrumbComputerNode(e.Node)
            Return
        End If

        'Populate dynamic nodes
        Dim dir As String = e.Node.Path

        If (Not Directory.Exists(dir)) Then
            Return
        End If

        Dim subDirs As String() = GetSubFolders(dir)

        If subDirs.Length <= 0 Then
            Dim list As BindingList(Of ImageFileInfo) = New BindingList(Of ImageFileInfo)

            For Each fl As FileInfo In (New DirectoryInfo(dir)).GetFiles()
                list.Add(New ImageFileInfo(fl.Name, fl.FullName, fl.Extension.Substring(1), fl.CreationTime, Image.FromFile(fl.FullName), False))
            Next

            Me.GridControlФото.DataSource = list
            Me.WinExplorerViewФото.RefreshData()
            Me.WinExplorerViewФото.ColumnSet.LargeImageColumn = WinExplorerViewФото.Columns("FileImg")
            Me.WinExplorerViewФото.ColumnSet.DescriptionColumn = Me.WinExplorerViewФото.Columns("FilePath")
            Me.WinExplorerViewФото.ColumnSet.TextColumn = Me.WinExplorerViewФото.Columns("FileName")
            Me.WinExplorerViewФото.ColumnSet.CheckBoxColumn = Me.WinExplorerViewФото.Columns("FileCheck")
            Me.WinExplorerViewФото.OptionsView.ShowCheckBoxes = True
            Me.WinExplorerViewФото.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Large
        End If

        Dim i As Integer = 0

        Do While i < subDirs.Length
            e.Node.ChildNodes.Add(CreateNode(subDirs(i)))
            i += 1
        Loop
    End Sub

#Region "Пользовательские процелуры и функции"
    ''' <summary>
    ''' Установка начального пути
    ''' </summary>
    Private Sub Initialize()
        breadCrumbEdit.Path = Application.StartupPath()

        For Each driveInfo As DriveInfo In GetFixedDrives()
            breadCrumbEdit.Properties.History.Add(New BreadCrumbHistoryItem(driveInfo.RootDirectory.ToString()))
        Next driveInfo
    End Sub

    ''' <summary>
    ''' Функция: Получение листа доступных накопителей 
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function GetFixedDrives() As IEnumerable(Of DriveInfo)
        For Each driveInfo As DriveInfo In DriveInfo.GetDrives()
            If driveInfo.DriveType <> DriveType.Fixed Then
                Continue For
            End If

            Yield driveInfo
        Next driveInfo
    End Function

    'Get all subfolders contained within the target directory
    Public Shared Function GetSubFolders(ByVal rootDir As String) As String()
        Dim subDirs As String() = GetSubDirs(rootDir)

        If subDirs Is Nothing Then
            Return New String() {}
        End If

        If subDirs.Length <= MaxEntitiesCount Then
            Return subDirs
        End If

        Dim res As String() = New String(MaxEntitiesCount - 1) {}

        Array.Copy(subDirs, res, res.Length)
        Return res
    End Function

    'Get the names of the subdirectories
    Public Shared Function GetSubDirs(ByVal dir As String) As String()
        Dim subDirs As String() = Nothing

        Try
            subDirs = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly)
        Catch
        End Try

        Return subDirs
    End Function

    ''' <summary>
    ''' Процедура: Инициализация главных ветвей
    ''' </summary>
    ''' <param name="node"></param>
    Private Sub InitBreadCrumbRootNode(ByVal node As BreadCrumbNode)
        node.ChildNodes.Add(New BreadCrumbNode("Рабочий стол", Environment.GetFolderPath(Environment.SpecialFolder.Desktop)))
        node.ChildNodes.Add(New BreadCrumbNode("Windows", Environment.GetFolderPath(Environment.SpecialFolder.Windows)))
        node.ChildNodes.Add(New BreadCrumbNode("Program Files", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)))
    End Sub

    ''' <summary>
    ''' Процедура: Инициализация ветви компьютер
    ''' </summary>
    ''' <param name="node"></param>
    Private Sub InitBreadCrumbComputerNode(ByVal node As BreadCrumbNode)
        For Each driveInfo As DriveInfo In GetFixedDrives()
            node.ChildNodes.Add(New BreadCrumbNode(driveInfo.Name, driveInfo.RootDirectory))
        Next driveInfo
    End Sub

    ''' <summary>
    ''' Функция: создание ветви
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Protected Function CreateNode(ByVal path As String) As BreadCrumbNode
        Dim folderName As String = New DirectoryInfo(path).Name

        Return New BreadCrumbNode(folderName, folderName, True)
    End Function
#End Region
End Class
