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
Imports System.Collections.Generic
Imports System.Diagnostics

Public Class RatingControlPainter
	Inherits BaseEditPainter
	Private maximum As Integer = 0
	Private titles() As String = { "Vote Here!", "Very Bad", "Bad", "Normal", "Good", "Very Good", "Perfect", "Excellent", "Great", "Awesome" }
	Private images As New List(Of Image)()
	Protected Overrides Sub DrawContent(ByVal info As ControlGraphicsInfoArgs)
		Dim vi As RatingControlViewInfo = TryCast(info.ViewInfo, RatingControlViewInfo)
		info.Graphics.FillRectangle(New SolidBrush(info.ViewInfo.PaintAppearance.BackColor), info.Bounds)
		maximum = vi.Item.Maximum
		images = vi.Images
		DrawObject(info.Cache, vi.ProgressInfo)
	End Sub

	Public Sub DrawObject(ByVal cache As GraphicsCache, ByVal e As ObjectInfoArgs)
		If e Is Nothing Then
			Return
		End If
		Dim ee As RatingControlObjectInfoArgs = TryCast(e, RatingControlObjectInfoArgs)
		Dim prev As GraphicsCache = e.Cache
		e.Cache = cache
		Try
			e.Cache.Paint.FillRectangle(e.Graphics, New SolidBrush(ee.BackgroundColor), e.Bounds)
			DrawStarsRect(ee)
			DrawTitlesRect(ee)
			DrawStarsRects(ee)
			DrawBorder(ee)
		Finally
			e.Cache = prev
		End Try
	End Sub

	Protected Overridable Sub DrawStarsRect(ByVal e As RatingControlObjectInfoArgs)
		Dim brush As Brush = e.Cache.GetSolidBrush(e.StarsRectangleBackgroundColor)
		e.Cache.Paint.FillGradientRectangle(e.Graphics, brush, CalcStarsRect(e))
	End Sub

	Protected Overridable Sub DrawBorder(ByVal e As RatingControlObjectInfoArgs)
		Dim brush As Brush = e.Cache.GetSolidBrush(Color.Plum)
		e.Cache.Paint.DrawRectangle(e.Graphics, brush, CalcStarsRect(e))
	End Sub

	Protected Overridable Sub DrawTitlesRect(ByVal e As RatingControlObjectInfoArgs)
		Dim brush As Brush = e.Cache.GetSolidBrush(e.TitlesRectangleBackgroundColor)
		e.Cache.Paint.FillGradientRectangle(e.Graphics, brush, CalcTitlesRect(e))
		Dim rect As Rectangle = CalcTitlesRect(e)
		rect.Offset(rect.Width \ 2, 0)
		Dim title As String = If(e.HotTrackValue <> 0, titles(e.HotTrackValue), titles(e.Value))
		e.Cache.Paint.DrawString(e.Cache, title, New Font("Arial", 10), Brushes.Black, rect, New StringFormat())
	End Sub

	Protected Overridable Sub DrawStarsRects(ByVal e As RatingControlObjectInfoArgs)
		Dim normal As Brush = e.Cache.GetSolidBrush(e.NormalStarColor)
		Dim selected As Brush = e.Cache.GetSolidBrush(e.SelectedStarColor)
		Dim hotTrack As Brush = e.Cache.GetSolidBrush(e.HotTrackedStarColor)
		For Each item In CalcStarsRects(e)
			'e.Cache.Paint.FillGradientRectangle(e.Graphics, normal, item);
			e.Cache.Paint.DrawImage(e.Graphics, images(0), item)
		Next item
		Dim rect As List(Of Rectangle) = CalcStarsRects(e)
		For i As Integer = 0 To e.Value - 1
			'  e.Cache.Paint.FillGradientRectangle(e.Graphics, selected, rect[i]);
			e.Cache.Paint.DrawImage(e.Graphics, images(2), rect(i))
		Next i
		For i As Integer = 0 To e.HotTrackValue - 1
			e.Cache.Paint.DrawImage(e.Graphics, images(1), rect(i))
			'  e.Cache.Paint.FillGradientRectangle(e.Graphics, hotTrack, rect[i]);
		Next i
	End Sub

	Protected Overridable Function CalcStarsRects(ByVal e As RatingControlObjectInfoArgs) As List(Of Rectangle)
		Dim result As New List(Of Rectangle)()
		For i As Integer = 0 To maximum - 1
			Dim r As Rectangle = e.Bounds
			r.Width = r.Width \ maximum
			r.Offset(i * r.Width + 2, 2)
			r.Size = New Size(r.Width, ((r.Height * 70) / 100) - 4)
			r.Inflate(-1, -1)
			result.Add(r)
		Next i
		Return result
	End Function

	Protected Overridable Function CalcStarsRect(ByVal e As RatingControlObjectInfoArgs) As Rectangle
		Dim r As Rectangle = e.Bounds
		Dim size As Size = r.Size
		r.Height = (r.Height * 70) / 100
		r.Inflate(-1, -1)
		Return r
	End Function

	Protected Overridable Function CalcTitlesRect(ByVal e As RatingControlObjectInfoArgs) As Rectangle
		Dim r As Rectangle = e.Bounds
		Dim size As Size = r.Size
		r.Location = New Point(r.Location.X, r.Location.Y + (r.Height * 70) / 100)
		r.Height = (r.Height * 30) / 100
		r.Inflate(-1, -1)
		Return r
	End Function
End Class

