Imports System.Text
Imports DevExpress.XtraBars.Docking2010.Views.WindowsUI
Imports System.Collections.ObjectModel

' The data model defined by this file serves as a representative example of a strongly-typed
' model that supports notification when members are added, removed, or modified.  The property
' names chosen coincide with data bindings in the standard item WindowsUIViewApplications.
'
' Applications may use this model as a starting point and build on it, or discard it entirely and
' replace it with something appropriate to their needs.

''' <summary>
''' Base class for <see cref="SampleDataItem"/> and <see cref="SampleDataGroup"/> that
''' defines properties common to both.
''' </summary>
Public Class SampleDataCommon
    Private subtitleCore, imagePathCore, descriptionCore, titleCore As String

    Public ReadOnly Property Title() As String
        Get
            Return titleCore
        End Get
    End Property

    Public ReadOnly Property Subtitle() As String
        Get
            Return subtitleCore
        End Get
    End Property

    Public ReadOnly Property ImagePath() As String
        Get
            Return imagePathCore
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return descriptionCore
        End Get
    End Property

    Public Sub New(ByVal title As String, ByVal subtitle As String, ByVal imagePath As String, ByVal description As String)
        titleCore = title
        subtitleCore = subtitle
        imagePathCore = imagePath
        descriptionCore = description
    End Sub

    Public Sub New()
    End Sub
End Class
''' <summary>
''' Generic item data model.
''' </summary>
Public Class SampleDataItem
    Inherits SampleDataCommon

    Private contentCore, groupNameCore As String, indexItemCore As Integer

    Public Sub New(ByVal title As String, ByVal subtitle As String, ByVal imagePath As String, ByVal description As String, ByVal content As String, ByVal groupName As String, indexItem As Integer)
        MyBase.New(title, subtitle, imagePath, description)
        contentCore = content
        groupNameCore = groupName
        indexItemCore = indexItem
    End Sub

    Public ReadOnly Property Content() As String
        Get
            Return contentCore
        End Get
    End Property

    Public ReadOnly Property GroupName() As String
        Get
            Return groupNameCore
        End Get
    End Property

    Public ReadOnly Property IndexItem() As Integer
        Get
            Return indexItemCore
        End Get
    End Property
End Class
''' <summary>
''' Generic group data model.
''' </summary>
Public Class SampleDataGroup
    Inherits SampleDataCommon
    Private nameCore As String
    Private itemsCore As Collection(Of SampleDataItem)

    Public Sub New(ByVal name As String)
        MyBase.New()
        Me.nameCore = name
        itemsCore = New Collection(Of SampleDataItem)()
    End Sub

    Public Sub New(ByVal name As String, ByVal title As String, ByVal subtitle As String, ByVal imagePath As String, ByVal description As String)
        MyBase.New(title, subtitle, imagePath, description)
        Me.nameCore = name
        itemsCore = New Collection(Of SampleDataItem)()
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return nameCore
        End Get
    End Property

    Public ReadOnly Property Items() As Collection(Of SampleDataItem)
        Get
            Return itemsCore
        End Get
    End Property

    Public Function AddItem(ByVal tile As SampleDataItem) As Boolean
        If Not itemsCore.Contains(tile) Then
            itemsCore.Add(tile)
            Return True
        End If
        Return False
    End Function
End Class
''' <summary>
''' Generic data model.
''' </summary>
Friend Class SampleDataModel
    Private groupsCore As Collection(Of SampleDataGroup)

    Public Sub New()
        groupsCore = New Collection(Of SampleDataGroup)()
    End Sub

    Public ReadOnly Property Groups() As Collection(Of SampleDataGroup)
        Get
            Return groupsCore
        End Get
    End Property

    Private Function GetGroup(ByVal name As String) As SampleDataGroup
        For Each group In groupsCore
            If group.Name = name Then
                Return group
            End If
        Next group

        Return Nothing
    End Function

    Public Function AddItem(ByVal tile As SampleDataItem) As Boolean
        If tile Is Nothing Then
            Return False
        End If

        Dim groupName As String = If(tile.GroupName Is Nothing, "", tile.GroupName)
        Dim thisGroup As SampleDataGroup = GetGroup(groupName)

        If thisGroup Is Nothing Then
            thisGroup = New SampleDataGroup(groupName)
            groupsCore.Add(thisGroup)
        End If

        Return thisGroup.AddItem(tile)
    End Function

    Private Function ContainsGroup(ByVal name As String) As Boolean
        Return GetGroup(name) IsNot Nothing
    End Function

    Public Sub CreateGroup(ByVal name As String, ByVal title As String, ByVal subtitle As String, ByVal imagePath As String, ByVal description As String)
        If ContainsGroup(name) Then
            Return
        End If

        Dim group As New SampleDataGroup(name, title, subtitle, imagePath, description)

        groupsCore.Add(group)
    End Sub
End Class
''' <summary>
''' Creates a collection of groups and items with hard-coded content.
''' 
''' SampleDataSource initializes with placeholder data rather than live production
''' data so that sample data is provided at both design-time and run-time.
''' </summary>
Friend Class SampleDataSource
    Private dataCore As SampleDataModel

    Public Sub New()
        dataCore = New SampleDataModel()

        Dim ITEM_CONTENT As String = String.Format("Item Content: {0}" & vbLf & vbLf & "{0}" & vbLf & vbLf & "{0}" & vbLf & vbLf & "{0}" & vbLf & vbLf & "{0}" & vbLf & vbLf & "{0}", "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat")

        dataCore.CreateGroup("Group-1", "Group Title: 1", "Group Subtitle: 1", GetType(MainForm).Namespace & ".DarkGray.png", "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante")
        dataCore.AddItem(New SampleDataItem("Item Title: 1", "Item Subtitle: 1", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-1", 1))
        dataCore.AddItem(New SampleDataItem("Item Title: 2", "Item Subtitle: 2", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-1", 2))
        dataCore.AddItem(New SampleDataItem("Item Title: 3", "Item Subtitle: 3", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-1", 3))
        dataCore.AddItem(New SampleDataItem("Item Title: 4", "Item Subtitle: 4", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-1", 4))
        dataCore.AddItem(New SampleDataItem("Item Title: 5", "Item Subtitle: 5", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-1", 5))

        dataCore.CreateGroup("Group-2", "Group Title: 2", "Group Subtitle: 2", GetType(MainForm).Namespace & ".LightGray.png", "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante")
        dataCore.AddItem(New SampleDataItem("Item Title: 1", "Item Subtitle: 1", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-2", 1))
        dataCore.AddItem(New SampleDataItem("Item Title: 2", "Item Subtitle: 2", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-2", 2))
        dataCore.AddItem(New SampleDataItem("Item Title: 3", "Item Subtitle: 3", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-2", 3))

        dataCore.CreateGroup("Group-3", "Group Title: 3", "Group Subtitle: 3", GetType(MainForm).Namespace & ".MediumGray.png", "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante")
        dataCore.AddItem(New SampleDataItem("Item Title: 1", "Item Subtitle: 1", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-3", 1))
        dataCore.AddItem(New SampleDataItem("Item Title: 2", "Item Subtitle: 2", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-3", 2))
        dataCore.AddItem(New SampleDataItem("Item Title: 3", "Item Subtitle: 3", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-3", 3))
        dataCore.AddItem(New SampleDataItem("Item Title: 4", "Item Subtitle: 4", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-3", 4))
        dataCore.AddItem(New SampleDataItem("Item Title: 5", "Item Subtitle: 5", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-3", 5))
        dataCore.AddItem(New SampleDataItem("Item Title: 6", "Item Subtitle: 6", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-3", 6))
        dataCore.AddItem(New SampleDataItem("Item Title: 7", "Item Subtitle: 7", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-3", 7))

        dataCore.CreateGroup("Group-4", "Group Title: 4", "Group Subtitle: 4", GetType(MainForm).Namespace & ".LightGray.png", "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante")
        dataCore.AddItem(New SampleDataItem("Item Title: 1", "Item Subtitle: 1", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-4", 1))
        dataCore.AddItem(New SampleDataItem("Item Title: 2", "Item Subtitle: 2", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-4", 2))
        dataCore.AddItem(New SampleDataItem("Item Title: 3", "Item Subtitle: 3", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-4", 3))
        dataCore.AddItem(New SampleDataItem("Item Title: 4", "Item Subtitle: 4", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-4", 4))
        dataCore.AddItem(New SampleDataItem("Item Title: 5", "Item Subtitle: 5", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-4", 5))
        dataCore.AddItem(New SampleDataItem("Item Title: 6", "Item Subtitle: 6", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-4", 6))

        dataCore.CreateGroup("Group-5", "Group Title: 5", "Group Subtitle: 5", GetType(MainForm).Namespace & ".MediumGray.png", "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante")
        dataCore.AddItem(New SampleDataItem("Item Title: 1", "Item Subtitle: 1", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-5", 1))
        dataCore.AddItem(New SampleDataItem("Item Title: 2", "Item Subtitle: 2", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-5", 2))
        dataCore.AddItem(New SampleDataItem("Item Title: 3", "Item Subtitle: 3", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-5", 3))
        dataCore.AddItem(New SampleDataItem("Item Title: 4", "Item Subtitle: 4", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-5", 4))

        dataCore.CreateGroup("Group-6", "Group Title: 6", "Group Subtitle: 6", GetType(MainForm).Namespace & ".DarkGray.png", "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante")
        dataCore.AddItem(New SampleDataItem("Item Title: 1", "Item Subtitle: 1", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6", 1))
        dataCore.AddItem(New SampleDataItem("Item Title: 2", "Item Subtitle: 2", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6", 2))
        dataCore.AddItem(New SampleDataItem("Item Title: 3", "Item Subtitle: 3", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6", 3))
        dataCore.AddItem(New SampleDataItem("Item Title: 4", "Item Subtitle: 4", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6", 4))
        dataCore.AddItem(New SampleDataItem("Item Title: 5", "Item Subtitle: 5", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6", 5))
        dataCore.AddItem(New SampleDataItem("Item Title: 6", "Item Subtitle: 6", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6", 6))
        dataCore.AddItem(New SampleDataItem("Item Title: 7", "Item Subtitle: 7", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6", 7))
        dataCore.AddItem(New SampleDataItem("Item Title: 8", "Item Subtitle: 8", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6", 8))

        'Console.WriteLine("pUserL = " & pUserL)
        'If pUserL = "A" Then
        dataCore.CreateGroup("Сервис", "Сервис", "Настройки системы", GetType(MainForm).Namespace & ".support.png", "Описание группы: Настройка системы, персонализация пользователей, установка параметров расчета.")
        dataCore.AddItem(New SampleDataItem("Персонализация пользователей", "Администрирование учетных данных", GetType(MainForm).Namespace & ".personID.png", "Регистрация, редактирование, удаление учетных записей пользователей системы. Администрирование прав доступа пользователя.", ITEM_CONTENT, "Сервис", 3))
        dataCore.AddItem(New SampleDataItem("Настройка параметров", "Параметризация системы и настройка алгоритма", GetType(MainForm).Namespace & ".control-panel-icon.png", "Добавление, редактирование, удаление параметров на контроллерах визуальных элементов системы. Администрирование параметров.", ITEM_CONTENT, "Сервис", 5))
        'dataCore.AddItem(New SampleDataItem("Item Title: 2", "Item Subtitle: 2", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6"))
        'dataCore.AddItem(New SampleDataItem("Item Title: 3", "Item Subtitle: 3", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6"))
        'dataCore.AddItem(New SampleDataItem("Item Title: 4", "Item Subtitle: 4", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6"))
        'dataCore.AddItem(New SampleDataItem("Item Title: 5", "Item Subtitle: 5", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6"))
        'dataCore.AddItem(New SampleDataItem("Item Title: 6", "Item Subtitle: 6", GetType(MainForm).Namespace & ".MediumGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6"))
        'dataCore.AddItem(New SampleDataItem("Item Title: 7", "Item Subtitle: 7", GetType(MainForm).Namespace & ".DarkGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6"))
        'dataCore.AddItem(New SampleDataItem("Item Title: 8", "Item Subtitle: 8", GetType(MainForm).Namespace & ".LightGray.png", "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.", ITEM_CONTENT, "Group-6"))
        'End If
    End Sub

    Public ReadOnly Property Data() As SampleDataModel
        Get
            Return dataCore
        End Get
    End Property
End Class
