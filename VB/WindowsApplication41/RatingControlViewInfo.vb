Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Utils.Drawing
Imports System.Diagnostics
Imports System.Collections.Generic

<ToolboxBitmap(GetType(RatingControl), "")>
Public Class RatingControlViewInfo
    Inherits BaseEditViewInfo

    Private positionField As Integer

    Private percentsField As Single

    Private hotTrackValue As Integer

    Private _images As List(Of Image)

    Private progressInfoField As RatingControlObjectInfoArgs

    Public Sub New(ByVal item As RepositoryItem)
        MyBase.New(item)
        _images = New List(Of Image)()
        _images.Add(New Bitmap("..\..\Normal.png"))
        _images.Add(New Bitmap("..\..\Highlighted.png"))
        _images.Add(New Bitmap("..\..\Selected.png"))
    End Sub

    Protected Overrides Sub Assign(ByVal info As BaseControlViewInfo)
        MyBase.Assign(info)
        Dim be As RatingControlViewInfo = TryCast(info, RatingControlViewInfo)
        If be Is Nothing Then Return
        percentsField = be.percentsField
        _images = be._images
        positionField = be.positionField
        hotTrackValue = be.hotTrackValue
    End Sub

    Protected Overrides Sub OnEditValueChanged()
        positionField = Item.ConvertValue(EditValue)
        percentsField = 1
        If Item.Maximum <> Item.Minimum Then
            percentsField = Math.Abs(CSng(Position - Item.Minimum) / CSng(Item.Maximum - Item.Minimum))
        End If
    End Sub

    Public Overridable ReadOnly Property Images As List(Of Image)
        Get
            Return _images
        End Get
    End Property

    Public Overridable ReadOnly Property Position As Integer
        Get
            Return positionField
        End Get
    End Property

    Public Overridable ReadOnly Property Percents As Single
        Get
            Return percentsField
        End Get
    End Property

    Protected Overrides Sub ReCalcViewInfoCore(ByVal g As Graphics, ByVal buttons As MouseButtons, ByVal mousePosition As Point, ByVal bounds As Rectangle)
        MyBase.ReCalcViewInfoCore(g, buttons, mousePosition, bounds)
        UpdateProgressInfo(ProgressInfo)
    End Sub

    Public Overrides Sub Reset()
        MyBase.Reset()
        progressInfoField = CreateInfoArgs()
        positionField = 0
        percentsField = 0
        hotTrackValue = 0
    End Sub

    Public Overridable ReadOnly Property ProgressInfo As RatingControlObjectInfoArgs
        Get
            Return progressInfoField
        End Get
    End Property

    Public Overloads ReadOnly Property Item As RepositoryItemRatingControl
        Get
            Return TryCast(MyBase.Item, RepositoryItemRatingControl)
        End Get
    End Property

    Protected Friend Overridable Sub UpdateProgressInfo(ByVal info As RatingControlObjectInfoArgs)
        info.Bounds = ContentRect
        info.BarColor = Item.BarColor
        info.NormalStarColor = Item.NormalStarColor
        info.StarsRectangleBackgroundColor = Item.StarsRectangleBackgroundColor
        info.TitlesRectangleBackgroundColor = Item.TitlesRectangleBackgroundColor
        info.NormalStarColor = Item.NormalStarColor
        info.SelectedStarColor = Item.SelectedStarColor
        info.HotTrackedStarColor = Item.HotTrackedStarColor
        info.BackgroundColor = Item.Appearance.BackColor
        info.Percent = Percents
        info.Value = Position
        info.HotTrackValue = hotTrackValue
    End Sub

    Protected Overrides Function GetBorderArgs(ByVal bounds As Rectangle) As ObjectInfoArgs
        Dim pi As RatingControlObjectInfoArgs = New RatingControlObjectInfoArgs()
        pi.Bounds = bounds
        Return pi
    End Function

    Protected Overrides Function GetBorderPainterCore() As BorderPainter
        Dim bp As BorderPainter = MyBase.GetBorderPainterCore()
        If TypeOf bp Is WindowsXPTextBorderPainter Then bp = New WindowsXPProgressBarBorderPainter()
        Return bp
    End Function

'#Region "Updating Object State"
    Protected Overrides Function UpdateObjectState() As Boolean
        Return True
    End Function

    Public Overrides ReadOnly Property IsRequiredUpdateOnMouseMove As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Function UpdateObjectState(ByVal mouseButtons As MouseButtons, ByVal mousePosition As Point) As Boolean
        If ProgressInfo.Bounds.Contains(mousePosition) Then
            hotTrackValue = GetValueByPoint(mousePosition)
        Else
            hotTrackValue = 0
        End If

        UpdateProgressInfo(progressInfoField)
        Return MyBase.UpdateObjectState(mouseButtons, mousePosition)
    End Function

'#End Region
    Private Function GetValueByPoint(ByVal location As Point) As Integer
        Dim steps As Double = CDbl(Item.Maximum) / CDbl(ProgressInfo.Bounds.Width)
        Dim value As Double = location.X * steps
        Return CInt(Math.Ceiling(value))
    End Function

    Public Overrides Sub Offset(ByVal x As Integer, ByVal y As Integer)
        MyBase.Offset(x, y)
        ProgressInfo.OffsetContent(x, y)
    End Sub

    Protected Overrides Sub CalcContentRect(ByVal bounds As Rectangle)
        MyBase.CalcContentRect(bounds)
        UpdateProgressInfo(ProgressInfo)
    End Sub

    Protected Overrides Function CalcClientSize(ByVal g As Graphics) As Size
        Dim s As Size = MyBase.CalcClientSize(g)
        s.Height = Images(0).Size.Height
        Return s
    End Function

    Protected Overridable Function CreateInfoArgs() As RatingControlObjectInfoArgs
        Return New RatingControlObjectInfoArgs()
    End Function

    Public Overrides Property EditValue As Object
        Get
            Return MyBase.EditValue
        End Get

        Set(ByVal value As Object)
            fEditValue = value
            OnEditValueChanged()
        End Set
    End Property

    Protected Overrides Function CalcMinHeightCore(ByVal g As Graphics) As Integer
        Dim height As Integer = MyBase.CalcMinHeightCore(g)
        height += _images(0).Size.Height
        Return height
    End Function
End Class
