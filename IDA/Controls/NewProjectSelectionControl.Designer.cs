namespace IDA.Controls
{
    partial class NewProjectSelectionControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbSelectionImage = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectionImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 33);
            this.panel1.TabIndex = 0;
            // 
            // pbSelectionImage
            // 
            this.pbSelectionImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSelectionImage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbSelectionImage.Location = new System.Drawing.Point(12, 4);
            this.pbSelectionImage.Name = "pbSelectionImage";
            this.pbSelectionImage.Size = new System.Drawing.Size(126, 108);
            this.pbSelectionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelectionImage.TabIndex = 1;
            this.pbSelectionImage.TabStop = false;
            this.pbSelectionImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbSelectionImage_MouseClick);
            this.pbSelectionImage.MouseEnter += new System.EventHandler(this.pbSelectionImage_MouseEnter);
            this.pbSelectionImage.MouseLeave += new System.EventHandler(this.pbSelectionImage_MouseLeave);
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(150, 33);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Unknown";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblName_MouseClick);
            this.lblName.MouseEnter += new System.EventHandler(this.lblName_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.lblName_MouseLeave);
            // 
            // NewProjectSelectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbSelectionImage);
            this.Controls.Add(this.panel1);
            this.Name = "NewProjectSelectionControl";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewProjectSelectionControl_MouseClick);
            this.MouseEnter += new System.EventHandler(this.NewProjectSelectionControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.NewProjectSelectionControl_MouseLeave);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectionImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbSelectionImage;
    }
}
