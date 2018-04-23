Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication41
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.dataSet1 = New System.Data.DataSet()
			Me.dataTable1 = New System.Data.DataTable()
			Me.dataColumn1 = New System.Data.DataColumn()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.myRepositoryItemProgressBar1 = New RepositoryItemRatingControl()
			Me.ratingControl1 = New RatingControl()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myRepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ratingControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(738, 240)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(106, 23)
			Me.simpleButton1.TabIndex = 0
			Me.simpleButton1.Text = "ChangeEditValue"
'			Me.simpleButton1.Click += New System.EventHandler(Me.simpleButton1_Click);
			' 
			' gridControl1
			' 
			Me.gridControl1.DataMember = "Table1"
			Me.gridControl1.DataSource = Me.dataSet1
			Me.gridControl1.Location = New System.Drawing.Point(28, 21)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.myRepositoryItemProgressBar1})
			Me.gridControl1.Size = New System.Drawing.Size(242, 342)
			Me.gridControl1.TabIndex = 2
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' dataSet1
			' 
			Me.dataSet1.DataSetName = "NewDataSet"
			Me.dataSet1.Tables.AddRange(New System.Data.DataTable() { Me.dataTable1})
			' 
			' dataTable1
			' 
			Me.dataTable1.Columns.AddRange(New System.Data.DataColumn() { Me.dataColumn1})
			Me.dataTable1.TableName = "Table1"
			' 
			' dataColumn1
			' 
			Me.dataColumn1.ColumnName = "Column1"
			Me.dataColumn1.DataType = GetType(Integer)
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colColumn1})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' colColumn1
			' 
			Me.colColumn1.Caption = "Column1"
			Me.colColumn1.ColumnEdit = Me.myRepositoryItemProgressBar1
			Me.colColumn1.FieldName = "Column1"
			Me.colColumn1.Name = "colColumn1"
			Me.colColumn1.Visible = True
			Me.colColumn1.VisibleIndex = 0
			' 
			' myRepositoryItemProgressBar1
			' 
			Me.myRepositoryItemProgressBar1.AutoHeight = False
			Me.myRepositoryItemProgressBar1.BarColor = System.Drawing.Color.YellowGreen
			Me.myRepositoryItemProgressBar1.HotTrackedStarColor = System.Drawing.Color.Purple
			Me.myRepositoryItemProgressBar1.HotTrackIndex = 0
			Me.myRepositoryItemProgressBar1.Maximum = 5
			Me.myRepositoryItemProgressBar1.Name = "myRepositoryItemProgressBar1"
			Me.myRepositoryItemProgressBar1.NormalStarColor = System.Drawing.Color.Yellow
			Me.myRepositoryItemProgressBar1.SelectedStarColor = System.Drawing.Color.Red
			Me.myRepositoryItemProgressBar1.StarsRectangleBackgroundColor = System.Drawing.Color.Black
			Me.myRepositoryItemProgressBar1.Title = "Vote Here!"
			Me.myRepositoryItemProgressBar1.TitlesRectangleBackgroundColor = System.Drawing.Color.Green
			' 
			' ratingControl1
			' 
			Me.ratingControl1.Location = New System.Drawing.Point(333, 80)
			Me.ratingControl1.Name = "ratingControl1"
			Me.ratingControl1.Properties.AutoHeight = False
			Me.ratingControl1.Properties.BarColor = System.Drawing.Color.YellowGreen
			Me.ratingControl1.Properties.HotTrackedStarColor = System.Drawing.Color.Purple
			Me.ratingControl1.Properties.HotTrackIndex = 0
			Me.ratingControl1.Properties.Maximum = 9
			Me.ratingControl1.Properties.NormalStarColor = System.Drawing.Color.Yellow
			Me.ratingControl1.Properties.SelectedStarColor = System.Drawing.Color.Red
			Me.ratingControl1.Properties.StarsRectangleBackgroundColor = System.Drawing.Color.Black
			Me.ratingControl1.Properties.Title = "Vote Here!"
			Me.ratingControl1.Properties.TitlesRectangleBackgroundColor = System.Drawing.Color.Green
			Me.ratingControl1.Size = New System.Drawing.Size(520, 135)
			Me.ratingControl1.TabIndex = 3
			Me.ratingControl1.TabStop = False
			Me.ratingControl1.Title = "Vote Here!"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1073, 477)
			Me.Controls.Add(Me.ratingControl1)
			Me.Controls.Add(Me.gridControl1)
			Me.Controls.Add(Me.simpleButton1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myRepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ratingControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private dataSet1 As System.Data.DataSet
		Private dataTable1 As System.Data.DataTable
		Private dataColumn1 As System.Data.DataColumn
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private colColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private myRepositoryItemProgressBar1 As RepositoryItemRatingControl
		Private ratingControl1 As RatingControl
	End Class
End Namespace

