namespace WindowsApplication41
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.myRepositoryItemProgressBar1 = new RepositoryItemRatingControl();
            this.ratingControl1 = new RatingControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myRepositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(738, 240);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "ChangeEditValue";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "Table1";
            this.gridControl1.DataSource = this.dataSet1;
            this.gridControl1.Location = new System.Drawing.Point(28, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.myRepositoryItemProgressBar1});
            this.gridControl1.Size = new System.Drawing.Size(242, 342);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Column1";
            this.dataColumn1.DataType = typeof(int);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colColumn1
            // 
            this.colColumn1.Caption = "Column1";
            this.colColumn1.ColumnEdit = this.myRepositoryItemProgressBar1;
            this.colColumn1.FieldName = "Column1";
            this.colColumn1.Name = "colColumn1";
            this.colColumn1.Visible = true;
            this.colColumn1.VisibleIndex = 0;
            // 
            // myRepositoryItemProgressBar1
            // 
            this.myRepositoryItemProgressBar1.AutoHeight = false;
            this.myRepositoryItemProgressBar1.BarColor = System.Drawing.Color.YellowGreen;
            this.myRepositoryItemProgressBar1.HotTrackedStarColor = System.Drawing.Color.Purple;
            this.myRepositoryItemProgressBar1.HotTrackIndex = 0;
            this.myRepositoryItemProgressBar1.Maximum = 5;
            this.myRepositoryItemProgressBar1.Name = "myRepositoryItemProgressBar1";
            this.myRepositoryItemProgressBar1.NormalStarColor = System.Drawing.Color.Yellow;
            this.myRepositoryItemProgressBar1.SelectedStarColor = System.Drawing.Color.Red;
            this.myRepositoryItemProgressBar1.StarsRectangleBackgroundColor = System.Drawing.Color.Black;
            this.myRepositoryItemProgressBar1.Title = "Vote Here!";
            this.myRepositoryItemProgressBar1.TitlesRectangleBackgroundColor = System.Drawing.Color.Green;
            // 
            // ratingControl1
            // 
            this.ratingControl1.Location = new System.Drawing.Point(333, 80);
            this.ratingControl1.Name = "ratingControl1";
            this.ratingControl1.Properties.AutoHeight = false;
            this.ratingControl1.Properties.BarColor = System.Drawing.Color.YellowGreen;
            this.ratingControl1.Properties.HotTrackedStarColor = System.Drawing.Color.Purple;
            this.ratingControl1.Properties.HotTrackIndex = 0;
            this.ratingControl1.Properties.Maximum = 9;
            this.ratingControl1.Properties.NormalStarColor = System.Drawing.Color.Yellow;
            this.ratingControl1.Properties.SelectedStarColor = System.Drawing.Color.Red;
            this.ratingControl1.Properties.StarsRectangleBackgroundColor = System.Drawing.Color.Black;
            this.ratingControl1.Properties.Title = "Vote Here!";
            this.ratingControl1.Properties.TitlesRectangleBackgroundColor = System.Drawing.Color.Green;
            this.ratingControl1.Size = new System.Drawing.Size(520, 135);
            this.ratingControl1.TabIndex = 3;
            this.ratingControl1.TabStop = false;
            this.ratingControl1.Title = "Vote Here!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 477);
            this.Controls.Add(this.ratingControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myRepositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colColumn1;
        private RepositoryItemRatingControl myRepositoryItemProgressBar1;
        private RatingControl ratingControl1;
    }
}

