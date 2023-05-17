Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Utils.Drawing

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
