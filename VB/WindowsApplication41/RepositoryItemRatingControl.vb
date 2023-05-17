Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.Utils.Drawing

<UserRepositoryItem("RegisterMyRatingControl")>
Public Class RepositoryItemRatingControl
    Inherits RepositoryItem

    Private titles As String() = {"Vote Here!", "Very Bad", "Bad", "Normal", "Good", "Very Good", "Perfect", "Excellent", "Great", "8-th title", "Awesome"}

    Private _barColor As Color

    Private _starsRectangleBackgroundColor As Color

    Private _titlesRectangleBackgroundColor As Color

    Private _normalStarColor As Color

    Private _selectedStarColor As Color

    Private _hotTrackedStarColor As Color

    Private titleField As String

    Private _hotTrackIndex As Integer

    <Browsable(False)>
    Public Property HotTrackIndex As Integer
        Get
            Return _hotTrackIndex
        End Get

        Set(ByVal value As Integer)
            If _hotTrackIndex = value Then Return
            _hotTrackIndex = value
            OnPropertiesChanged()
        End Set
    End Property

    Public Property Title As String
        Get
            Return titleField
        End Get

        Set(ByVal value As String)
            If Not Equals(titleField, value) Then
                titleField = value
                OnPropertiesChanged()
            End If
        End Set
    End Property

'#Region "Colors"
    Public Property TitlesRectangleBackgroundColor As Color
        Get
            Return _titlesRectangleBackgroundColor
        End Get

        Set(ByVal value As Color)
            If _titlesRectangleBackgroundColor = value Then Return
            _titlesRectangleBackgroundColor = value
            OnPropertiesChanged()
        End Set
    End Property

    Public Property StarsRectangleBackgroundColor As Color
        Get
            Return _starsRectangleBackgroundColor
        End Get

        Set(ByVal value As Color)
            If _starsRectangleBackgroundColor = value Then Return
            _starsRectangleBackgroundColor = value
            OnPropertiesChanged()
        End Set
    End Property

    Public Property BarColor As Color
        Get
            Return _barColor
        End Get

        Set(ByVal value As Color)
            If _barColor = value Then Return
            _barColor = value
            OnPropertiesChanged()
        End Set
    End Property

    Public Property NormalStarColor As Color
        Get
            Return _normalStarColor
        End Get

        Set(ByVal value As Color)
            If _normalStarColor = value Then Return
            _normalStarColor = value
            OnPropertiesChanged()
        End Set
    End Property

    Public Property SelectedStarColor As Color
        Get
            Return _selectedStarColor
        End Get

        Set(ByVal value As Color)
            If _selectedStarColor = value Then Return
            _selectedStarColor = value
            OnPropertiesChanged()
        End Set
    End Property

    Public Property HotTrackedStarColor As Color
        Get
            Return _hotTrackedStarColor
        End Get

        Set(ByVal value As Color)
            If _hotTrackedStarColor = value Then Return
            _hotTrackedStarColor = value
            OnPropertiesChanged()
        End Set
    End Property

'#End Region
    Shared Sub New()
        RegisterMyRatingControl()
    End Sub

    Public Shared Sub RegisterMyRatingControl()
        Call EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo("RatingControl", GetType(RatingControl), GetType(RepositoryItemRatingControl), GetType(RatingControlViewInfo), New RatingControlPainter(), True, CType(Nothing, System.Drawing.Image), GetType(DevExpress.Accessibility.PopupEditAccessible)))
    End Sub

    Public Overloads ReadOnly Property Properties As RepositoryItemRatingControl
        Get
            Return Me
        End Get
    End Property

    Private Shared positionChangedField As Object = New Object()

    <Browsable(False)>
    Public Overrides ReadOnly Property EditorTypeName As String
        Get
            Return "RatingControl"
        End Get
    End Property

    Private _minimum, _maximum As Integer

    Public Sub New()
        fAutoHeight = False
        _barColor = Color.YellowGreen
        _starsRectangleBackgroundColor = Color.Black
        _titlesRectangleBackgroundColor = Color.Green
        _normalStarColor = Color.Yellow
        _selectedStarColor = Color.Red
        titleField = titles(0)
        _hotTrackedStarColor = Color.Purple
        HotTrackIndex = 0
        _minimum = 0
        _maximum = 5
    End Sub

    Public Overrides Sub Assign(ByVal item As RepositoryItem)
        Dim source As RepositoryItemRatingControl = TryCast(item, RepositoryItemRatingControl)
        BeginUpdate()
        Try
            MyBase.Assign(item)
            If source Is Nothing Then Return
            _maximum = source.Maximum
            _minimum = source.Minimum
            BarColor = source.BarColor
            StarsRectangleBackgroundColor = source.StarsRectangleBackgroundColor
            TitlesRectangleBackgroundColor = source.TitlesRectangleBackgroundColor
            NormalStarColor = source.NormalStarColor
            SelectedStarColor = source.SelectedStarColor
            HotTrackedStarColor = source.HotTrackedStarColor
            HotTrackIndex = source.HotTrackIndex
            Title = source.Title
        Finally
            EndUpdate()
        End Try

        Events.AddHandler(positionChangedField, source.Events(positionChangedField))
    End Sub

    Protected Overloads ReadOnly Property OwnerEdit As RatingControl
        Get
            Return TryCast(MyBase.OwnerEdit, RatingControl)
        End Get
    End Property

    <Category(CategoryName.Behavior), Description("Gets or sets the control's minimum value."), RefreshProperties(RefreshProperties.All), DefaultValue(0)>
    Public Property Minimum As Integer
        Get
            Return _minimum
        End Get

        Set(ByVal value As Integer)
            If Not IsLoading Then
                If value > Maximum Then value = Maximum
            End If

            If Minimum = value Then Return
            _minimum = value
            OnMinMaxChanged()
            OnPropertiesChanged()
        End Set
    End Property

    <Category(CategoryName.Behavior), Description("Gets or sets the control's maximum value."), RefreshProperties(RefreshProperties.All), DefaultValue(100)>
    Public Property Maximum As Integer
        Get
            Return _maximum
        End Get

        Set(ByVal value As Integer)
            If Not IsLoading Then
                If value < Minimum Then value = Minimum
            End If

            If Maximum = value Then Return
            _maximum = value
            OnMinMaxChanged()
            OnPropertiesChanged()
        End Set
    End Property

    Protected Friend Overridable Function ConvertValue(ByVal val As Object) As Integer
        Try
            Return CheckValue(Convert.ToInt32(val))
        Catch
        End Try

        Return Minimum
    End Function

    Protected Friend Overridable Function CheckValue(ByVal val As Integer) As Integer
        If IsLoading Then Return val
        val = Math.Max(val, Minimum)
        val = Math.Min(val, Maximum)
        Return val
    End Function

    Public Overrides Function GetBrick(ByVal info As PrintCellHelperInfo) As VisualBrick
        Dim brick As ProgressBarBrick = CType(MyBase.GetBrick(info), ProgressBarBrick)
        brick.Position = ConvertValue(info.EditValue)
        Return brick
    End Function

    Protected Overridable Sub OnMinMaxChanged()
        If OwnerEdit IsNot Nothing Then OwnerEdit.OnMinMaxChanged()
    End Sub

    <Description("Occurs after the value of the ProgressBarControl.Position property has been changed."), Category(CategoryName.Events)>
    Public Custom Event PositionChanged As EventHandler
        AddHandler(ByVal value As EventHandler)
            Events.AddHandler(positionChangedField, value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Events.RemoveHandler(positionChangedField, value)
        End RemoveHandler

        <Description("Occurs after the value of the ProgressBarControl.Position property has been changed."), Category(CategoryName.Events)>
        RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
        End RaiseEvent
    End Event

    Protected Overrides Sub RaiseEditValueChangedCore(ByVal e As EventArgs)
        MyBase.RaiseEditValueChangedCore(e)
        RaisePositionChanged(e)
    End Sub

    Protected Friend Overridable Sub RaisePositionChanged(ByVal e As EventArgs)
        Dim handler As EventHandler = CType(Events(positionChangedField), EventHandler)
        If handler IsNot Nothing Then handler(GetEventSender(), e)
    End Sub
End Class
