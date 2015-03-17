namespace BSKChartMonitor
{
    partial class ucLogGrid
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.匯出EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcGrid
            // 
            this.gcGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGrid.Location = new System.Drawing.Point(0, 0);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoExEdit1});
            this.gcGrid.Size = new System.Drawing.Size(407, 370);
            this.gcGrid.TabIndex = 1;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGrid});
            // 
            // gvGrid
            // 
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.OptionsView.ColumnAutoWidth = false;
            this.gvGrid.OptionsView.ShowFooter = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.ShowIcon = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.匯出EXCELToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // 匯出EXCELToolStripMenuItem
            // 
            this.匯出EXCELToolStripMenuItem.Name = "匯出EXCELToolStripMenuItem";
            this.匯出EXCELToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.匯出EXCELToolStripMenuItem.Text = "匯出EXCEL";
            this.匯出EXCELToolStripMenuItem.Click += new System.EventHandler(this.匯出EXCELToolStripMenuItem_Click);
            // 
            // ucLogGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Name = "ucLogGrid";
            this.Size = new System.Drawing.Size(407, 370);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        public DevExpress.XtraGrid.GridControl gcGrid;
        public DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 匯出EXCELToolStripMenuItem;
    }
}
