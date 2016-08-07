namespace IDA.Forms.Dockable
{
    partial class FrmProjectExplorer
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
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProjectExplorer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.btnForward = new System.Windows.Forms.ToolStripButton();
            this.btnHome = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnCollapse = new System.Windows.Forms.ToolStripButton();
            this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
            this.panelTreeViewContainer = new System.Windows.Forms.Panel();
            this.projectView = new System.Windows.Forms.TreeView();
            this.ilTreeview = new System.Windows.Forms.ImageList(this.components);
            this.ProjectWatcher = new System.IO.FileSystemWatcher();
            this.toolStrip1.SuspendLayout();
            this.panelTreeViewContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack,
            this.btnForward,
            this.btnHome,
            this.toolStripSeparator1,
            this.btnRefresh,
            this.btnCollapse,
            this.btnExpandAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(362, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Enabled = false;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 22);
            this.btnBack.Text = "Back";
            // 
            // btnForward
            // 
            this.btnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForward.Enabled = false;
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(23, 22);
            this.btnForward.Text = "Forward";
            // 
            // btnHome
            // 
            this.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHome.Enabled = false;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(23, 22);
            this.btnHome.Text = "Home";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            // 
            // btnCollapse
            // 
            this.btnCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCollapse.Enabled = false;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(23, 22);
            this.btnCollapse.Text = "Collapse";
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExpandAll.Enabled = false;
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(23, 22);
            this.btnExpandAll.Text = "Expand";
            // 
            // panelTreeViewContainer
            // 
            this.panelTreeViewContainer.Controls.Add(this.projectView);
            this.panelTreeViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTreeViewContainer.Location = new System.Drawing.Point(0, 25);
            this.panelTreeViewContainer.Name = "panelTreeViewContainer";
            this.panelTreeViewContainer.Size = new System.Drawing.Size(362, 638);
            this.panelTreeViewContainer.TabIndex = 1;
            // 
            // projectView
            // 
            this.projectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectView.ImageIndex = 0;
            this.projectView.ImageList = this.ilTreeview;
            this.projectView.LabelEdit = true;
            this.projectView.Location = new System.Drawing.Point(0, 0);
            this.projectView.Name = "projectView";
            this.projectView.SelectedImageIndex = 3;
            this.projectView.Size = new System.Drawing.Size(362, 638);
            this.projectView.TabIndex = 0;
            // 
            // ilTreeview
            // 
            this.ilTreeview.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeview.ImageStream")));
            this.ilTreeview.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTreeview.Images.SetKeyName(0, "ProjectImage");
            this.ilTreeview.Images.SetKeyName(1, "FolderImage");
            this.ilTreeview.Images.SetKeyName(2, "TxtImage");
            this.ilTreeview.Images.SetKeyName(3, "GreenArrowImage.png");
            this.ilTreeview.Images.SetKeyName(4, "IdaImage");
            // 
            // ProjectWatcher
            // 
            this.ProjectWatcher.EnableRaisingEvents = true;
            this.ProjectWatcher.IncludeSubdirectories = true;
            this.ProjectWatcher.SynchronizingObject = this;
            // 
            // FrmProjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 663);
            this.Controls.Add(this.panelTreeViewContainer);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProjectExplorer";
            this.Text = "Project Explorer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelTreeViewContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProjectWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHome;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripButton btnForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnCollapse;
        private System.Windows.Forms.ToolStripButton btnExpandAll;
        private System.Windows.Forms.Panel panelTreeViewContainer;
        private System.Windows.Forms.TreeView projectView;
        private System.IO.FileSystemWatcher ProjectWatcher;
        private System.Windows.Forms.ImageList ilTreeview;
    }
}