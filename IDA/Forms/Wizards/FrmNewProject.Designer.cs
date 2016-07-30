namespace IDA.Forms.Wizards
{
    partial class FrmNewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewProject));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.flpPlatform = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.flpVersion = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedProjectType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbProjectName = new System.Windows.Forms.TextBox();
            this.cbThisIsALibrary = new System.Windows.Forms.CheckBox();
            this.cbThisIsOpenSource = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 28);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Platform";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpPlatform
            // 
            this.flpPlatform.AutoScroll = true;
            this.flpPlatform.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpPlatform.Location = new System.Drawing.Point(0, 28);
            this.flpPlatform.Name = "flpPlatform";
            this.flpPlatform.Size = new System.Drawing.Size(825, 158);
            this.flpPlatform.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 28);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Version";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpVersion
            // 
            this.flpVersion.AutoScroll = true;
            this.flpVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpVersion.Location = new System.Drawing.Point(0, 214);
            this.flpVersion.Name = "flpVersion";
            this.flpVersion.Size = new System.Drawing.Size(825, 157);
            this.flpVersion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected Project Type:";
            // 
            // lblSelectedProjectType
            // 
            this.lblSelectedProjectType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedProjectType.AutoSize = true;
            this.lblSelectedProjectType.Location = new System.Drawing.Point(133, 385);
            this.lblSelectedProjectType.Name = "lblSelectedProjectType";
            this.lblSelectedProjectType.Size = new System.Drawing.Size(16, 13);
            this.lblSelectedProjectType.TabIndex = 4;
            this.lblSelectedProjectType.Text = "...";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Project Name";
            // 
            // tbProjectName
            // 
            this.tbProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProjectName.Enabled = false;
            this.tbProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProjectName.Location = new System.Drawing.Point(125, 413);
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.Size = new System.Drawing.Size(688, 26);
            this.tbProjectName.TabIndex = 2;
            this.tbProjectName.TextChanged += new System.EventHandler(this.tbProjectName_TextChanged);
            // 
            // cbThisIsALibrary
            // 
            this.cbThisIsALibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbThisIsALibrary.AutoSize = true;
            this.cbThisIsALibrary.Location = new System.Drawing.Point(19, 457);
            this.cbThisIsALibrary.Name = "cbThisIsALibrary";
            this.cbThisIsALibrary.Size = new System.Drawing.Size(99, 17);
            this.cbThisIsALibrary.TabIndex = 3;
            this.cbThisIsALibrary.Text = "This is a Library";
            this.cbThisIsALibrary.UseVisualStyleBackColor = true;
            // 
            // cbThisIsOpenSource
            // 
            this.cbThisIsOpenSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbThisIsOpenSource.AutoSize = true;
            this.cbThisIsOpenSource.Location = new System.Drawing.Point(19, 480);
            this.cbThisIsOpenSource.Name = "cbThisIsOpenSource";
            this.cbThisIsOpenSource.Size = new System.Drawing.Size(122, 17);
            this.cbThisIsOpenSource.TabIndex = 4;
            this.cbThisIsOpenSource.Text = "This is Open Source";
            this.cbThisIsOpenSource.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(738, 480);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(657, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 515);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cbThisIsOpenSource);
            this.Controls.Add(this.cbThisIsALibrary);
            this.Controls.Add(this.tbProjectName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSelectedProjectType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpVersion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flpPlatform);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpPlatform;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedProjectType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.CheckBox cbThisIsALibrary;
        private System.Windows.Forms.CheckBox cbThisIsOpenSource;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}