namespace IDA.Controls
{
    partial class OpenProjectSelectionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbProjectIcon = new System.Windows.Forms.PictureBox();
            this.pbPlatformIcon = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjectIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatformIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProjectIcon
            // 
            this.pbProjectIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProjectIcon.Location = new System.Drawing.Point(4, 4);
            this.pbProjectIcon.Name = "pbProjectIcon";
            this.pbProjectIcon.Size = new System.Drawing.Size(142, 109);
            this.pbProjectIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProjectIcon.TabIndex = 0;
            this.pbProjectIcon.TabStop = false;
            this.pbProjectIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbProjectIcon_MouseUp);
            // 
            // pbPlatformIcon
            // 
            this.pbPlatformIcon.Location = new System.Drawing.Point(4, 4);
            this.pbPlatformIcon.Name = "pbPlatformIcon";
            this.pbPlatformIcon.Size = new System.Drawing.Size(47, 50);
            this.pbPlatformIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlatformIcon.TabIndex = 1;
            this.pbPlatformIcon.TabStop = false;
            this.pbPlatformIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPlatformIcon_MouseUp);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(4, 120);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(143, 23);
            this.lblName.TabIndex = 2;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblName_MouseUp);
            // 
            // OpenProjectSelectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbPlatformIcon);
            this.Controls.Add(this.pbProjectIcon);
            this.Name = "OpenProjectSelectionControl";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenProjectSelectionControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbProjectIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatformIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProjectIcon;
        private System.Windows.Forms.PictureBox pbPlatformIcon;
        private System.Windows.Forms.Label lblName;
    }
}
