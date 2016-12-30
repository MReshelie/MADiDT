Imports System.ComponentModel
Imports System.Data.Linq
Imports System.IO
Imports DevExpress.Utils.Win
Imports DevExpress.XtraBars.Forms
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraSplashScreen

Public Class XtraUCPersonRecord
    Inherits EditFormUserControl

    Dim db As New DataClassesDorogaDataContext
    Dim iСотрудник As Integer
    Dim iSlider As Integer = 0
    Dim newRow As Boolean = False
    Dim riLookUpEditСтепень As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditСтепень"}
    Dim riLookUpEditДолжность As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditДолжность"}
    Dim riLookUpEditФакультет As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditФакультет"}
    Dim riLookUpEditКонтакт As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditКонтакт"}
    Dim riMemoEditКонтакт As New RepositoryItemMemoEdit() With {.Name = "riMemoEditКонтакт", .WordWrap = True}
    Dim riTextEditКонтакт As New RepositoryItemTextEdit() With {.Name = "riTextEditКонтакт"}
    Dim riLookUpEditАдрес As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditАдрес"}
    Dim riMemoEditАдрес As New RepositoryItemMemoEdit() With {.Name = "riMemoEditАдрес", .WordWrap = True}
    Dim riLookUpEditEmail As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditEmail"}
    Dim riMemoEditEmail As New RepositoryItemMemoEdit() With {.Name = "riMemoEditEmail", .WordWrap = True}
    Dim riLookUpEditФото As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditФото"}
    Dim riPictureEditФото As New RepositoryItemPictureEdit() With {.Name = "riPictureEditФото"}
    Dim riPopupCEdit As New RepositoryItemPopupContainerEdit() With {.Name = "riPopupCEdit"}
    Dim riCheckEditФото As New RepositoryItemCheckEdit() With {.Name = "riCheckEditФото"}
    Dim riMemoEditФото As New RepositoryItemMemoEdit() With {.Name = "riMemoEditФото", .WordWrap = True}
    Dim riLookUpEditПароль As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditПароль"}
    Dim riMemoEditПароль As New RepositoryItemMemoEdit() With {.Name = "riMemoEditПароль", .WordWrap = True}
    Dim riTextEditПаспорт As New RepositoryItemTextEdit() With {.Name = "riTextEditПаспорт"}
    Dim riMemoEditПаспорт As New RepositoryItemMemoEdit() With {.Name = "riMemoEditПаспорт", .WordWrap = True}

    Public Sub New()
        InitializeComponent()

        Me.NavBarControlPersona.Visible = False
        Me.riPopupCEdit.Properties.PopupControl = Me.PopupContainerControlФото
        Me.riPictureEditФото.SizeMode = PictureSizeMode.Zoom
    End Sub

    Private Sub XtraUCPersonRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        iСотрудник = CType(Me.TextEditКодСотрудник.EditValue, Integer)
        Me.LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Me.TimerSlider.Enabled = True

        If (Not DBConnect()) Then Return
        If (Not SliderPhoto(New DataClassesDorogaDataContext(), CType(Me.TextEditКодСотрудник.Text, Integer))) Then Return

        AddHandler riLookUpEditФото.Leave, AddressOf riLookUpEditФото_Leave
        AddHandler riPictureEditФото.MouseHover, AddressOf riPictureEditФото_MouseHover
        AddHandler riPictureEditФото.MouseLeave, AddressOf riPictureEditФото_MouseLeave
        AddHandler riPopupCEdit.Popup, AddressOf riPopupCEdit_Popup
        AddHandler riPopupCEdit.CloseUp, AddressOf riPopupCEdit_CloseUp
        AddHandler riPopupCEdit.QueryPopUp, AddressOf riPopupCEdit_QueryPopUp
        AddHandler riPopupCEdit.QueryResultValue, AddressOf riPopupCEdit_QueryResultValue
    End Sub

    Private Sub XtraUCPersonRecord_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Me.TimerSlider.Enabled = False
    End Sub

    Private Sub NavBarControlPersona_ActiveGroupChanged(sender As Object, e As NavBarGroupEventArgs) Handles NavBarControlPersona.ActiveGroupChanged
        Me.NavigationFramePersona.SelectedPage = CType(Me.NavigationFramePersona.Pages.FindFirst(Function(x) CStr(x.Tag) = e.Group.Caption), NavigationPage)
    End Sub

    Private Sub TimerSlider_Tick(sender As Object, e As EventArgs) Handles TimerSlider.Tick
        If Me.ImageSliderPersona.Images.Count = 1 Then Exit Sub

        If iSlider > 30 Then
            If Me.ImageSliderPersona.GetCurrentImageIndex + 1 = Me.ImageSliderPersona.Images.Count Then
                Me.ImageSliderPersona.SlideFirst()
                Me.ImageSliderPersona.SetCurrentImageIndex(0)
            Else
                Me.ImageSliderPersona.SlideNext()
            End If

            iSlider = 0
        Else
            iSlider += 1
        End If
    End Sub

#Region "Процедуры работы с записями SQL Server"
    Private Sub GridControlФото_EmbeddedNavigator_ButtonClick(sender As Object, e As NavigatorButtonClickEventArgs) Handles GridControlФото.EmbeddedNavigator.ButtonClick
        Dim view As ColumnView = CType(Me.GridControlФото.FocusedView, ColumnView)

        db = New DataClassesDorogaDataContext()

        Select Case e.Button.ButtonType
            Case NavigatorButtonType.EndEdit
                If view.UpdateCurrentRow() Then
                    Try
                        If newRow = False Then
                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("датаИсправил"), Date.Today)

                            If pUserF = "Администратор системы" Then
                                view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"), String.Format("{0}, [{1}]", Trim(pUserF), Trim(pUserS)))
                            Else
                                view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"), String.Format("{0} {1}.", Trim(pUserF), Mid(Trim(pUserS), 1, 1)))
                            End If
                        End If


                        Try
                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("кодСотрудник"), CType(Me.TextEditКодСотрудник.Text, Integer))
                            db.p_SaveФото(IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодФото"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодФото"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодСотрудник"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодСотрудник"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Тип_фото"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Тип_фото"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Источник"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Источник"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Хранилище"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Хранилище"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("База"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("База"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Оригинал"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Оригинал"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаЗаписал"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаЗаписал"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаИсправил"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаИсправил"))),
                                     IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Примечание"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Примечание"))))
                            newRow = False
                        Catch ex As ChangeConflictException
                            XtraMessageBox.Show(String.Format("Ошибка при записи в БД: таблица [{2}] БД:{0}{0}{1}.",
                                         Global.Microsoft.VisualBasic.ChrW(10), ex, SourceName(view.Name)),
                                       "Система: новая запись в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        End Try
                    Catch ex As Exception
                        XtraMessageBox.Show(String.Format("Конфликты при записи в БД: таблица [{2}] БД:{0}{0}{1}.",
                                         Global.Microsoft.VisualBasic.ChrW(10), ex.Message, SourceName(view.Name)),
                                       "Система: запись данных в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                        For Each occ As ObjectChangeConflict In db.ChangeConflicts
                            occ.Resolve(RefreshMode.OverwriteCurrentValues)
                        Next

                        If (Not DBConnect()) Then Return
                    End Try
                End If

                e.Handled = True
            Case NavigatorButtonType.Remove
                If XtraMessageBox.Show(String.Format("Таблица: {0}{1}Удалить текущую запись ?", SourceName(view.Name), Global.Microsoft.VisualBasic.ChrW(10)),
                             "Система: удаление записи из БД", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    If DeleteRec(view.Name, db, CType(view.GetRowCellValue(view.FocusedRowHandle, view.Columns.ColumnByFieldName("кодФото")), Integer)) Then
                        view.DeleteRow(view.FocusedRowHandle)
                        Me.GridControlФото.RefreshDataSource()
                    End If

                    e.Handled = True
                End If
        End Select

        If (Not SliderPhoto(db, CType(Me.TextEditКодСотрудник.Text, Integer))) Then Return
    End Sub

    Private Sub GridViewФото_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridViewФото.InitNewRow
        Dim view As GridView = CType(sender, GridView)

        newRow = True
        view.Columns("Источник").OptionsColumn.AllowEdit = False
        view.SetRowCellValue(view.FocusedRowHandle, view.Columns("датаЗаписал"), Date.Today)
        view.SetRowCellValue(view.FocusedRowHandle, view.Columns("База"), TotalPhoto(CType(Me.TextEditКодСотрудник.Text, Integer)))

        If pUserF = "Администратор системы" Then
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"), String.Format("{0}, [{1}]", Trim(pUserF), Trim(pUserS)))
        Else
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"), String.Format("{0} {1}.", Trim(pUserF), Mid(Trim(pUserS), 1, 1)))
        End If

        view.Columns("Записал").OptionsColumn.ReadOnly = True
        view.Columns("датаЗаписал").OptionsColumn.ReadOnly = True
        view.Columns("Исправил").OptionsColumn.ReadOnly = True
        view.Columns("датаИсправил").OptionsColumn.ReadOnly = True
        view.FocusedColumn = view.Columns("Тип_фото")
    End Sub
#End Region

#Region "Пользовательские методы для компонентов Repository"
    Private Sub riLookUpEditФото_Leave(sender As Object, e As System.EventArgs)
        Dim view As GridView = TryCast(Me.GridControlФото.FocusedView, GridView)

        ' Проверка выбора типа фотографии
        If Trim(CType(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Тип_фото")), String)) <> "0" Then
            view.Columns("Источник").OptionsColumn.AllowEdit = True
        End If
    End Sub
    Private Sub riPictureEditФото_MouseHover(sender As Object, e As EventArgs)
        If (TryCast(sender, PictureEdit)).Image IsNot Nothing Then
            SplashScreenManager.ShowImage(ResizeImage((TryCast(sender, PictureEdit)).Image, New Size(512, 384)), True, True, SplashImagePainter.Painter)
            SplashImagePainter.Painter.ViewInfo.Stage = String.Empty
            SplashScreenManager.Default.Invalidate()
        End If
    End Sub
    Private Sub riPictureEditФото_MouseLeave(sender As Object, e As EventArgs)
        If (TryCast(sender, PictureEdit)).Image IsNot Nothing Then
            SplashScreenManager.HideImage()
        End If
    End Sub
    Private Sub riPopupCEdit_Popup(sender As Object, e As System.EventArgs)
        Dim view As GridView = TryCast(Me.GridControlФото.FocusedView, GridView)
        Dim edit As PopupContainerEdit = TryCast(sender, PopupContainerEdit)

        ' Проверка заполненности полей идентификации пользователя
        If Trim(Me.TextEditФамилия.Text).Length = 0 Then
            If edit.IsPopupOpen Then
                edit.ClosePopup()
            End If

            XtraMessageBox.Show(String.Format("Не внесена фамилия пользователя!!!"),
                                           "Система: запись данных в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Trim(Me.TextEditИмя.Text).Length = 0 Then
            If edit.IsPopupOpen Then
                edit.ClosePopup()
            End If

            XtraMessageBox.Show(String.Format("Не внесено имя пользователя!!!"),
                                           "Система: запись данных в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub
    Private Sub riPopupCEdit_CloseUp(ByVal sender As Object, ByVal e As CloseUpEventArgs)
        If e.Value Is Nothing Then Exit Sub

        db = New DataClassesDorogaDataContext()

        Dim edit As PopupContainerEdit = TryCast(sender, PopupContainerEdit)
        Dim view As GridView = TryCast(Me.GridControlФото.FocusedView, GridView)

        view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Хранилище"), String.Format("{0}\[{1} {2} {3} {4}]{5}",
                                                                             (From _dr In db.p_GetDBInfo() Select _dr.Drive).First() + ":\Doroga\Photo",
                                                                                             Me.TextEditФамилия.Text,
                                                                                             Me.TextEditИмя.Text,
                                                                                             Me.TextEditОтчество.Text,
                                                                                             String.Format("{0}", Date.Now.ToString("ddMMyyy-HHmm")),
                                                                                             Path.GetExtension(CType(e.Value, String))))
        view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Оригинал"), New System.Data.Linq.Binary(ImageToByteArray(Image.FromFile(CType(e.Value, String)))))
        edit.Text = e.Value.ToString
    End Sub
    Private Sub riPopupCEdit_QueryResultValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.QueryResultValueEventArgs)
        For Each cntrl As Control In Me.PopupContainerControlФото.Controls
            If cntrl.Name = "cntrFolders" Then
                For Each ccntrl As Control In cntrl.Controls
                    If ccntrl.Name = "LayoutControlUCFE" Then
                        For Each cccntrl As Control In ccntrl.Controls
                            If cccntrl.Name = "PanelControlPhoto" Then
                                For Each ccccntrl As Control In cccntrl.Controls
                                    If ccccntrl.Name = "ucPhoto" Then
                                        For Each _property In ccccntrl.GetType().GetProperties()
                                            If _property.Name = "DescriptionPhoto" Then
                                                e.Value = String.Format("{0}", ccccntrl.GetType().GetProperty(_property.Name).GetValue(ccccntrl, Nothing))
                                                Exit Sub
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub riPopupCEdit_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
        Me.PopupContainerControlФото.Size = New Size(620, 330)
        Me.PopupContainerControlФото.Controls.Add(New XtraUCFileExplorer() With {.Dock = DockStyle.Fill, .Name = "cntrFolders"})
    End Sub
#End Region

#Region "Пользовательские процедуры и функции"
    ''' <summary>
    ''' Процедура: Настройка свойств, наименований и механизмов колонок таблиц контролера
    ''' </summary>
    ''' <param name="view"></param>
    Private Sub GVSetings(ByVal view As GridView)
        Select Case view.Name
            Case "GridViewКонтакт"
                Call InitRILookUpEdit(Me.riLookUpEditКонтакт)
                Call riLookUpEditData1(1, Me.riLookUpEditКонтакт)

                view.Columns("Тип_Контакт").ColumnEdit = Me.riLookUpEditКонтакт
                view.Columns("Тип_Контакт").Caption = "Тип контакта"
                Me.riTextEditКонтакт.Mask.MaskType = Mask.MaskType.RegEx
                Me.riTextEditКонтакт.Mask.EditMask = "((\+\d)?\(\d{3}\))?\d{3}-\d\d-\d\d"
                view.Columns("Контакт").ColumnEdit = Me.riTextEditКонтакт
                view.Columns("Контакт").Caption = "Номер контакта"
                view.Columns("датаЗаписал").Caption = "Дата записи"
                view.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                view.Columns("датаИсправил").Caption = "Дата исправления"
                view.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                view.Columns("Записал").OptionsColumn.AllowEdit = False
                view.Columns("Исправил").OptionsColumn.AllowEdit = False
                view.Columns("Примечание").ColumnEdit = Me.riMemoEditКонтакт
                view.Columns("кодКонтакт").Visible = False
                view.Columns("кодСотрудник").Visible = False
            Case "GridViewEmail"
                Call InitRILookUpEdit(Me.riLookUpEditEmail)
                Call riLookUpEditData1(3, Me.riLookUpEditEmail)

                view.Columns("Тип_email").ColumnEdit = Me.riLookUpEditEmail
                view.Columns("Тип_email").Caption = "Тип электронной почты"
                view.Columns("email").Caption = "Электронная почта"
                view.Columns("датаЗаписал").Caption = "Дата записи"
                view.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                view.Columns("датаИсправил").Caption = "Дата исправления"
                view.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                view.Columns("Записал").OptionsColumn.AllowEdit = False
                view.Columns("Исправил").OptionsColumn.AllowEdit = False
                view.Columns("Примечание").ColumnEdit = Me.riMemoEditEmail
                view.Columns("кодEmail").Visible = False
                view.Columns("кодСотрудник").Visible = False
            Case "GridViewАдрес"
                Call InitRILookUpEdit(Me.riLookUpEditАдрес)
                Call riLookUpEditData1(2, Me.riLookUpEditАдрес)

                view.Columns("типАдрес").ColumnEdit = Me.riLookUpEditАдрес
                view.Columns("типАдрес").Caption = "Тип адреса"
                view.Columns("Почтовый_индекс").Caption = "Почтовый индекс"
                view.Columns("Субъект_РФ__регион_").Caption = "Субъект РФ (регион)"
                view.Columns("Наименование_района").Caption = "Район"
                view.Columns("Наименование_города").Caption = "Город"
                view.Columns("Наименование_населенного_пункта").Caption = "Населенный пункт"
                view.Columns("Наименование_улицы").Caption = "Улица"
                view.Columns("Номер_дома__владение_").Caption = "Д (влд)"
                view.Columns("Корпус__строение_").Caption = "К (стр)"
                view.Columns("Квартира__офис_").Caption = "Кв (оф)"
                view.Columns("датаЗаписал").Caption = "Дата записи"
                view.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                view.Columns("датаИсправил").Caption = "Дата исправления"
                view.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                view.Columns("Записал").OptionsColumn.AllowEdit = False
                view.Columns("Исправил").OptionsColumn.AllowEdit = False
                view.Columns("Примечание").ColumnEdit = Me.riMemoEditEmail
                view.Columns("кодАдрес").Visible = False
                view.Columns("кодСотрудник").Visible = False
            Case "GridViewПаспорт"
                view.Columns("Код_подразделения").ColumnEdit = Me.riTextEditПаспорт
                view.Columns("Код_подразделения").Caption = "Код подразделения"
                Me.riTextEditПаспорт.Mask.MaskType = Mask.MaskType.RegEx
                Me.riTextEditПаспорт.Mask.EditMask = "\d{3}-\d{3}"
                view.Columns("датаЗаписал").Caption = "Дата записи"
                view.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                view.Columns("датаИсправил").Caption = "Дата исправления"
                view.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                view.Columns("Записал").OptionsColumn.AllowEdit = False
                view.Columns("Исправил").OptionsColumn.AllowEdit = False
                view.Columns("Примечание").ColumnEdit = Me.riMemoEditПаспорт
                view.Columns("кодПаспорт").Visible = False
                view.Columns("кодСотрудник").Visible = False
            Case "GridViewФото"
                'http://metanit.com/sharp/adonet/2.14.php
                Call InitRILookUpEdit(Me.riLookUpEditФото)
                Call riLookUpEditData1(5, Me.riLookUpEditФото)

                Me.riLookUpEditФото.SearchMode = SearchMode.AutoComplete
                Me.riLookUpEditФото.AutoSearchColumnIndex = 1

                view.Columns("Тип_фото").ColumnEdit = Me.riLookUpEditФото
                view.Columns("Тип_фото").Caption = "Тип фотографии"
                view.Columns("Источник").ColumnEdit = Me.riPopupCEdit
                view.Columns("Источник").Caption = "Папка пользовательских фотографий"
                view.Columns("Источник").OptionsColumn.AllowEdit = False
                view.Columns("Хранилище").Caption = "Папка на сервере БД"
                view.Columns("Хранилище").OptionsColumn.AllowEdit = False
                view.Columns("База").ColumnEdit = Me.riCheckEditФото
                view.Columns("База").Caption = "Основная"
                view.Columns("Оригинал").ColumnEdit = riPictureEditФото
                view.Columns("Оригинал").Caption = "Оригинал"
                view.Columns("датаЗаписал").Caption = "Дата записи"
                view.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                view.Columns("датаИсправил").Caption = "Дата исправления"
                view.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                view.Columns("Записал").OptionsColumn.AllowEdit = False
                view.Columns("Исправил").OptionsColumn.AllowEdit = False
                view.Columns("Примечание").ColumnEdit = Me.riMemoEditФото
                view.Columns("кодФото").Visible = False
                view.Columns("кодСотрудник").Visible = False
            Case "GridViewБезопасность"
                Call InitRILookUpEdit(Me.riLookUpEditПароль)
                Call riLookUpEditData1(4, Me.riLookUpEditПароль)

                view.Columns("IDAuthor").Caption = "Руководитель"
                view.Columns("IDAuthor").VisibleIndex = 1
                view.Columns("IDLevel").ColumnEdit = Me.riLookUpEditПароль
                view.Columns("IDLevel").Caption = "Статус пользователя"
                view.Columns("IDLevel").VisibleIndex = 2
                view.Columns("Passport1").Caption = "Пароль"
                view.Columns("Passport2").Caption = "Пароль (повтор)"
                view.Columns("Дата_записи").Caption = "Дата записи"
                view.Columns("Дата_записи").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("Дата_записи").OptionsColumn.AllowEdit = False
                view.Columns("Дата_исправления").Caption = "Дата исправления"
                view.Columns("Дата_исправления").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("Дата_исправления").OptionsColumn.AllowEdit = False
                view.Columns("Записал").OptionsColumn.AllowEdit = False
                view.Columns("Исправил").OptionsColumn.AllowEdit = False
                view.Columns("Примечание").ColumnEdit = Me.riMemoEditПароль
                view.Columns("IDPassport").Visible = False
                view.Columns("IDUser").Visible = False
        End Select

        For Each column As GridColumn In view.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        view.BestFitColumns()
        view.OptionsView.ColumnAutoWidth = True
    End Sub
    ''' <summary>
    ''' Процедура: Инициализация полей таблиц контролера
    ''' </summary>
    ''' <param name="riLUEF">служебное поле</param>
    Private Sub InitRILookUpEdit(ByVal riLUEF As RepositoryItemLookUpEdit)
        Dim coll As LookUpColumnInfoCollection = riLUEF.Columns

        coll.Add(New LookUpColumnInfo("row", "Номер позиции", 0))

        Select Case riLUEF.Name
            Case "riLookUpEditФакультет"
                coll.Add(New LookUpColumnInfo("NAME", "Название факультета", 0))
            Case "riLookUpEditСтепень"
                coll.Add(New LookUpColumnInfo("NAME", "Научная степень", 0))
            Case "riLookUpEditДолжность"
                coll.Add(New LookUpColumnInfo("NAME", "Занимаемая должность", 0))
            Case "riLookUpEditКонтакт"
                coll.Add(New LookUpColumnInfo("NAME", "Тип контакта", 0))
            Case "riLookUpEditАдрес"
                coll.Add(New LookUpColumnInfo("NAME", "Тип адреса", 0))
            Case "riLookUpEditEmail"
                coll.Add(New LookUpColumnInfo("NAME", "Тип электронной почты", 0))
            Case "riLookUpEditПароль"
                coll.Add(New LookUpColumnInfo("NAME", "Уровень пользователя", 0))
            Case "riLookUpEditФото"
                coll.Add(New LookUpColumnInfo("NAME", "Тип пользовательской фотографии", 0))
        End Select

        riLUEF.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        riLUEF.BestFitMode = BestFitMode.BestFitResizePopup
        riLUEF.SearchMode = SearchMode.AutoComplete
        riLUEF.AutoSearchColumnIndex = 1
        riLUEF.Columns("row").Visible = False
        riLUEF.ValueMember = "row"
        riLUEF.DisplayMember = "NAME"
    End Sub
    ''' <summary>
    ''' Процедура: заполнение полей должность, степенб, факультет
    ''' </summary>
    ''' <param name="riLookUpEditD">Список: стандартные наименование должностей</param>
    ''' <param name="riLookUpEditS">Список: стандартные наименования ученых степеней</param>
    ''' <param name="riLookUpEditF">Список: наименования факультетов</param>
    Private Sub riLookUpEditData0(ByVal riLookUpEditD As RepositoryItemLookUpEdit, ByVal riLookUpEditS As RepositoryItemLookUpEdit, ByVal riLookUpEditF As RepositoryItemLookUpEdit)
        riLookUpEditD.DataSource = Nothing
        riLookUpEditS.DataSource = Nothing
        riLookUpEditF.DataSource = Nothing
        riLookUpEditD.DataSource = db.p_GetListOfДолжность.ToList()
        riLookUpEditS.DataSource = db.p_GetListOfСтепень.ToList()
        riLookUpEditF.DataSource = db.p_GetListOfФакультет.ToList()
    End Sub
    ''' <summary>
    ''' Процедура: заполенение данными служебных полей таблиц
    ''' </summary>
    ''' <param name="i">номер поля</param>
    ''' <param name="riLookUpEdit">имя поля</param>
    Private Sub riLookUpEditData1(ByVal i As Integer, ByVal riLookUpEdit As RepositoryItemLookUpEdit)
        riLookUpEdit.DataSource = Nothing
        riLookUpEdit.DataSource = db.GetParameters(i).ToList()
    End Sub
    ''' <summary>
    ''' Функция: подключение к БД
    ''' </summary>
    ''' <returns></returns>
    Private Function DBConnect() As Boolean
        db = New DataClassesDorogaDataContext()

        Me.LookUpEditФакультет.Properties.DataSource = Nothing
        Me.LookUpEditФакультет.Properties.DataSource = db.p_GetListOfFullФакультет().ToList()
        Me.LookUpEditСтепень.Properties.DataSource = Nothing
        Me.LookUpEditСтепень.Properties.DataSource = db.p_GetListOfFullСтепень().ToList()
        Me.LookUpEditДолжность.Properties.DataSource = Nothing
        Me.LookUpEditДолжность.Properties.DataSource = db.p_GetListOfFullДолжность().ToList()

        Dim Kafedra = From tKS In db.p_GetКафедраФакультет(CType(Me.LookUpEditФакультет.EditValue, Integer))

        Me.LookUpEditКафедра.Properties.DataSource = Nothing
        Me.LookUpEditКафедра.Properties.DataSource = Kafedra

        Dim iKafedra = From tKS In db.p_GetКафедра_Сотрудник(iСотрудник) Take 1 Select tKS.кодКафедра

        For Each iK As Integer In iKafedra
            Me.LookUpEditКафедра.EditValue = iK
        Next

        Dim Kontakt = From p In db.p_GetКонтактСотрудник(iСотрудник)
        Dim Email = From p In db.p_GetEmailСотрудник(iСотрудник)
        Dim Address = From p In db.p_GetКонтактАдрес(iСотрудник)
        Dim Passport = From p In db.p_GetКонтактПаспорт(iСотрудник)
        Dim Photo = From p In db.p_GetКонтактФото(iСотрудник)
        Dim Password = From p In db.p_GetКонтактПароль(iСотрудник)

        Me.GridControlКонтакт.DataSource = Kontakt
        Me.GridControlEmail.DataSource = Email
        Me.GridControlАдрес.DataSource = Address
        Me.GridControlПаспорт.DataSource = Passport
        Me.GridControlФото.DataSource = Photo
        Me.GridControlБезопасность.DataSource = Password

        Call GVSetings(Me.GridViewКонтакт)
        Call GVSetings(Me.GridViewEmail)
        Call GVSetings(Me.GridViewАдрес)
        Call GVSetings(Me.GridViewПаспорт)
        Call GVSetings(Me.GridViewФото)
        Call GVSetings(Me.GridViewБезопасность)
        Return True
    End Function
    ''' <summary>
    ''' Функция: удаление записи из таблицы БД
    ''' </summary>
    ''' <param name="viewName">имя GridView</param>
    ''' <param name="db">определение набора данных</param>
    ''' <param name="iRec">номер записи для удаления</param>
    ''' <returns>истина - успешно, ложь - запись не удалилась</returns>
    Private Function DeleteRec(ByVal viewName As String, ByVal db As DataClassesDorogaDataContext, ByVal iRec As Integer) As Boolean
        Select Case viewName
            Case "GridViewФото"
                Try
                    db.p_DeleteФото(iRec)
                    db.SubmitChanges()
                    Return True
                    Exit Function
                Catch ex As Exception
                    XtraMessageBox.Show(String.Format("Таблица: {0}{1}Попытка удаления записи из БД:{1}Ошибка: {2}{0}Повторить попытку - [ОК].", SourceName(viewName),
                                                      Global.Microsoft.VisualBasic.ChrW(10), ex.Message), "Система: запись данных в БД.",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End Try
        End Select

        Return False
    End Function
    ''' <summary>
    ''' Функция: установка признака основной фотографии сотрудника
    ''' </summary>
    ''' <param name="view">GridViewФото_InitNewRow</param>
    ''' <returns>Истина - основная фотография, False - фотографий много</returns>
    Private Function TotalPhoto(ByVal nUser As Integer) As Boolean
        If (New DataClassesDorogaDataContext()).CountФото_сотрудников(nUser) <> 0 Then
            Return False
            Exit Function
        End If

        Return True
    End Function
    ''' <summary>
    ''' Функция: Заполнение иллюстрациями ImageSlider
    ''' </summary>
    ''' <param name="view">GridViewФото</param>
    ''' <returns>заполненный ImageSlider</returns>
    Private Function SliderPhoto(ByVal db As DataClassesDorogaDataContext, ByVal nUser As Integer) As Boolean
        SplashScreenManager.ShowForm(GetType(WaitFormLoadRec))
        SplashScreenManager.Default.SetWaitFormCaption("Ожидайте...")
        SplashScreenManager.Default.SetWaitFormDescription("Идет обновление изображений.")

        If Me.ImageSliderPersona.Images.Count > 0 Then
            Me.ImageSliderPersona.Images.Clear()
        End If

        If TotalPhoto(nUser) Then
            Me.ImageSliderPersona.Images.Add(My.Resources.Нет_фото)
        Else
            For Each pPhoto In From dP In db.p_GetФото_Сотрудник(nUser)
                If pPhoto.Оригинал IsNot Nothing Then
                    Me.ImageSliderPersona.Images.Add(ByteArrayToImage(pPhoto.Оригинал.ToArray()))
                End If
            Next
        End If

        SplashScreenManager.CloseForm(False)
        Return True
    End Function
#End Region
End Class
