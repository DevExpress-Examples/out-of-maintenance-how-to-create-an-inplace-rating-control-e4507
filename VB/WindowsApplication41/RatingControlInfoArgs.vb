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

Public Class RatingControlObjectInfoArgs
	Inherits ObjectInfoArgs
	Public Sub New()
	End Sub
	Public StarsRectangleBackgroundColor As Color
	Public TitlesRectangleBackgroundColor As Color
	Public NormalStarColor As Color
	Public SelectedStarColor As Color
	Public HotTrackedStarColor As Color
	Public Title As String
	Public BackgroundColor As Color
	Public BarColor As Color
	Public Percent As Single = 0
	Public Value As Integer
	Public HotTrackValue As Integer = 0

End Class