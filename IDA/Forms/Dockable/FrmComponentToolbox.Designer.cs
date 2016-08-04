namespace IDA.Forms.Dockable
{
    partial class FrmComponentToolbox
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Internal Components", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("External Components", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComponentToolbox));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lvComponents = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(339, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbSearch
            // 
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Search";
            // 
            // lvComponents
            // 
            this.lvComponents.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvComponents.GridLines = true;
            listViewGroup1.Header = "Internal Components";
            listViewGroup1.Name = "InternalComponents";
            listViewGroup2.Header = "External Components";
            listViewGroup2.Name = "ExternalComponents";
            this.lvComponents.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvComponents.Location = new System.Drawing.Point(0, 25);
            this.lvComponents.Name = "lvComponents";
            this.lvComponents.Size = new System.Drawing.Size(339, 461);
            this.lvComponents.TabIndex = 1;
            this.lvComponents.UseCompatibleStateImageBehavior = false;
            // 
            // FrmComponentToolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 753);
            this.Controls.Add(this.lvComponents);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmComponentToolbox";
            this.Text = "Component Toolbox";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbSearch;
        private System.Windows.Forms.ListView lvComponents;
    }
}