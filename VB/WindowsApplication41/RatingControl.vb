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

<ToolboxItem(True)> _
Public Class RatingControl
	Inherits BaseEdit

	Shared Sub New()
		RepositoryItemRatingControl.RegisterMyRatingControl()
	End Sub
	Public Sub New()
		Me.TabStop = False
		Me.fEditValue = 0
		Me.fOldEditValue = Me.fEditValue
	End Sub
	<Browsable(False)> _
	Public Overrides ReadOnly Property EditorTypeName() As String
		Get
			Return "RatingControl"
		End Get
	End Property
	<Description("Gets an object containing properties, methods and events specific to rating controls."), Category(CategoryName.Properties), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
	Public Shadows ReadOnly Property Properties() As RepositoryItemRatingControl
		Get
			Return TryCast(MyBase.Properties, RepositoryItemRatingControl)
		End Get
	End Property
	<Browsable(False), DefaultValue(0)> _
	Public Overrides Property EditValue() As Object
		Get
			Return MyBase.EditValue
		End Get
		Set(ByVal value As Object)
			MyBase.EditValue = ConvertCheckValue(value)
		End Set
	End Property
	<Category(CategoryName.Appearance), Description("Gets or sets position."), RefreshProperties(RefreshProperties.All), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(0), Bindable(ControlConstants.NonObjectBindable)> _
	Public Overridable Property Position() As Integer
		Get
			Return Properties.ConvertValue(EditValue)
		End Get
		Set(ByVal value As Integer)
			EditValue = Properties.CheckValue(value)
		End Set
	End Property
	Public Overridable Property Title() As String
		Get
			Return Properties.Title
		End Get
		Set(ByVal value As String)
			EditValue = value
		End Set
	End Property
	Protected Overridable Function ConvertCheckValue(ByVal val As Object) As Object
		If val Is Nothing OrElse TypeOf val Is DBNull Then
			Return val
		End If
		Dim converted As Integer = Properties.ConvertValue(val)
		Try
			If converted = Convert.ToInt32(val) Then
				Return val
			End If
		Catch
		End Try
		Return converted
	End Function
	Protected Friend Overridable Sub OnMinMaxChanged()
		If IsLoading Then
			Return
		End If
		Position = Properties.CheckValue(Position)
	End Sub
	Protected Friend Overridable Sub UpdatePercent()
		Dim vi As RatingControlViewInfo = TryCast(ViewInfo, RatingControlViewInfo)
		If vi Is Nothing Then
			Return
		End If
		vi.UpdateProgressInfo(vi.ProgressInfo)
	End Sub
	Public Custom Event PositionChanged As EventHandler
		AddHandler(ByVal value As EventHandler)
			AddHandler Properties.PositionChanged, value
		End AddHandler
		RemoveHandler(ByVal value As EventHandler)
			RemoveHandler Properties.PositionChanged, value
		End RemoveHandler
		RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
		End RaiseEvent
	End Event
	Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
		Properties.HotTrackIndex = GetValueByPoint(e.Location)
		UpdateValue()
		MyBase.OnMouseMove(e)
	End Sub
	Private Function GetValueByPoint(ByVal location As Point) As Integer
		Dim steps As Double = CDbl(Properties.Maximum) / CDbl(Width)
		Dim value As Double = location.X * steps
		Return CInt(Fix(Math.Ceiling(value)))
	End Function
	Protected Overrides Sub OnMouseClick(ByVal e As MouseEventArgs)
		Position = GetValueByPoint(e.Location)
		UpdateValue()
		MyBase.OnMouseClick(e)
	End Sub
	Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
		'TODO:
		Properties.HotTrackIndex = 0
		MyBase.OnMouseLeave(e)
	End Sub
	Protected Friend Overridable Sub UpdateValue()
		Dim vi As RatingControlViewInfo = TryCast(ViewInfo, RatingControlViewInfo)
		If vi Is Nothing Then
			Return
		End If
		vi.UpdateProgressInfo(vi.ProgressInfo)
	End Sub
End Class
