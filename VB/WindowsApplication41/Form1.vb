Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms

Namespace WindowsApplication41

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            For i As Integer = 0 To 6 - 1
                dataTable1.Rows.Add(New Object() {i})
            Next
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ratingControl1.Position += 1
        End Sub
    End Class
End Namespace
