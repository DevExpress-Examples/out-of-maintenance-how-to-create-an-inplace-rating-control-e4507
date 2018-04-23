Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils


<UserRepositoryItem("RegisterMyRatingControl")> _
Public Class RepositoryItemRatingControl
	Inherits RepositoryItem
	Private titles() As String = { "Vote Here!", "Very Bad", "Bad", "Normal", "Good", "Very Good", "Perfect", "Excellent", "Great", "8-th title", "Awesome" }
	Private _barColor As Color
	Private _starsRectangleBackgroundColor As Color
	Private _titlesRectangleBackgroundColor As Color
	Private _normalStarColor As Color
	Private _selectedStarColor As Color
	Private _hotTrackedStarColor As Color
	Private title_Renamed As String

	Private _hotTrackIndex As Integer
	<Browsable(False)> _
	Public Property HotTrackIndex() As Integer
		Get
			Return _hotTrackIndex
		End Get
		Set(ByVal value As Integer)
			If _hotTrackIndex = value Then
				Return
			End If
			_hotTrackIndex = value
			Me.OnPropertiesChanged()
		End Set
	End Property
	Public Property Title() As String
		Get
			Return title_Renamed
		End Get
		Set(ByVal value As String)
			If title_Renamed <> value Then
				title_Renamed = value
				OnPropertiesChanged()
			End If
		End Set
	End Property
	#Region "Colors"
	Public Property TitlesRectangleBackgroundColor() As Color
		Get
			Return _titlesRectangleBackgroundColor
		End Get
		Set(ByVal value As Color)
			If _titlesRectangleBackgroundColor = value Then
				Return
			End If
			_titlesRectangleBackgroundColor = value
			Me.OnPropertiesChanged()
		End Set
	End Property
	Public Property StarsRectangleBackgroundColor() As Color
		Get
			Return _starsRectangleBackgroundColor
		End Get
		Set(ByVal value As Color)
			If _starsRectangleBackgroundColor = value Then
				Return
			End If
			_starsRectangleBackgroundColor = value
			Me.OnPropertiesChanged()
		End Set
	End Property
	Public Property BarColor() As Color
		Get
			Return _barColor
		End Get
		Set(ByVal value As Color)
			If _barColor = value Then
				Return
			End If
			_barColor = value
			Me.OnPropertiesChanged()
		End Set
	End Property
	Public Property NormalStarColor() As Color
		Get
			Return _normalStarColor
		End Get
		Set(ByVal value As Color)
			If _normalStarColor = value Then
				Return
			End If
			_normalStarColor = value
			Me.OnPropertiesChanged()
		End Set
	End Property
	Public Property SelectedStarColor() As Color
		Get
			Return _selectedStarColor
		End Get
		Set(ByVal value As Color)
			If _selectedStarColor = value Then
				Return
			End If
			_selectedStarColor = value
			Me.OnPropertiesChanged()
		End Set
	End Property
	Public Property HotTrackedStarColor() As Color
		Get
			Return _hotTrackedStarColor
		End Get
		Set(ByVal value As Color)
			If _hotTrackedStarColor = value Then
				Return
			End If
			_hotTrackedStarColor = value
			Me.OnPropertiesChanged()
		End Set
	End Property

	#End Region

	Shared Sub New()
		RegisterMyRatingControl()
	End Sub

	Public Shared Sub RegisterMyRatingControl()
        EditorRegistrationInfo.Default.Editors.Add(
            New EditorClassInfo("RatingControl",
                                GetType(RatingControl),
                                GetType(RepositoryItemRatingControl),
                                GetType(RatingControlViewInfo),
                                New RatingControlPainter(),
                                True))
	End Sub

	Public Shadows ReadOnly Property Properties() As RepositoryItemRatingControl
		Get
			Return Me
		End Get
	End Property
    Public Shared posChanged As Object = New Object()
	<Browsable(False)> _
	Public Overrides ReadOnly Property EditorTypeName() As String
		Get
			Return "RatingControl"
		End Get
	End Property
	Private _minimum, _maximum As Integer
	Public Sub New()

		Me.fAutoHeight = False
		Me._barColor = Color.YellowGreen
		_starsRectangleBackgroundColor = Color.Black
		_titlesRectangleBackgroundColor = Color.Green
		_normalStarColor = Color.Yellow
		_selectedStarColor = Color.Red
		title_Renamed = titles(0)
		_hotTrackedStarColor = Color.Purple
		Me.HotTrackIndex = 0
		Me._minimum = 0
		Me._maximum = 5
	End Sub
	Public Overrides Sub Assign(ByVal item As RepositoryItem)
		Dim source As RepositoryItemRatingControl = TryCast(item, RepositoryItemRatingControl)
		BeginUpdate()
		Try
			MyBase.Assign(item)
			If source Is Nothing Then
				Return
			End If
			Me._maximum = source.Maximum
			Me._minimum = source.Minimum
			Me.BarColor = source.BarColor

			StarsRectangleBackgroundColor = source.StarsRectangleBackgroundColor
			TitlesRectangleBackgroundColor = source.TitlesRectangleBackgroundColor
			NormalStarColor = source.NormalStarColor
			SelectedStarColor = source.SelectedStarColor
			HotTrackedStarColor = source.HotTrackedStarColor
			Me.HotTrackIndex = source.HotTrackIndex
			Title = source.Title
		Finally
			EndUpdate()
		End Try
        Events.AddHandler(posChanged, source.Events(posChanged))
	End Sub
	Protected Shadows ReadOnly Property OwnerEdit() As RatingControl
		Get
			Return TryCast(MyBase.OwnerEdit, RatingControl)
		End Get
	End Property
	<Category(CategoryName.Behavior), Description("Gets or sets the control's minimum value."), RefreshProperties(RefreshProperties.All), DefaultValue(0)> _
	Public Property Minimum() As Integer
		Get
			Return _minimum
		End Get
		Set(ByVal value As Integer)
			If (Not IsLoading) Then
				If value > Maximum Then
					value = Maximum
				End If
			End If
			If Minimum = value Then
				Return
			End If
			_minimum = value
			OnMinMaxChanged()
			OnPropertiesChanged()
		End Set
	End Property
	<Category(CategoryName.Behavior), Description("Gets or sets the control's maximum value."), RefreshProperties(RefreshProperties.All), DefaultValue(100)> _
	Public Property Maximum() As Integer
		Get
			Return _maximum
		End Get
		Set(ByVal value As Integer)
			If (Not IsLoading) Then
				If value < Minimum Then
					value = Minimum
				End If
			End If
			If Maximum = value Then
				Return
			End If
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
		If IsLoading Then
			Return val
		End If
		val = Math.Max(val, Minimum)
		val = Math.Min(val, Maximum)
		Return val
	End Function
	Public Overrides Function GetBrick(ByVal info As PrintCellHelperInfo) As IVisualBrick
		Dim brick As IProgressBarBrick = CType(MyBase.GetBrick(info), IProgressBarBrick)
		brick.Position = ConvertValue(info.EditValue)
		Return brick
	End Function
	Protected Overridable Sub OnMinMaxChanged()
		If OwnerEdit IsNot Nothing Then
			OwnerEdit.OnMinMaxChanged()
		End If
	End Sub
	<Description("Occurs after the value of the ProgressBarControl.Position property has been changed."), Category(CategoryName.Events)> _
	Public Custom Event PositionChanged As EventHandler
		AddHandler(ByVal value As EventHandler)
            Me.Events.AddHandler(posChanged, value)
		End AddHandler
		RemoveHandler(ByVal value As EventHandler)
            Me.Events.RemoveHandler(posChanged, value)
		End RemoveHandler
		RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
		End RaiseEvent
	End Event
	Protected Overrides Sub RaiseEditValueChangedCore(ByVal e As EventArgs)
		MyBase.RaiseEditValueChangedCore(e)
		RaisePositionChanged(e)
	End Sub
	Protected Friend Overridable Sub RaisePositionChanged(ByVal e As EventArgs)
        Dim handler As EventHandler = CType(Me.Events(posChanged), EventHandler)
		If handler IsNot Nothing Then
			handler(GetEventSender(), e)
		End If
	End Sub
End Class
