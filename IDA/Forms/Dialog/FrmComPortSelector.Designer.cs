namespace IDA.Forms.Dialog
{
    partial class FrmComPortSelector
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComPortSelector));
            this.btnUse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvComPorts = new System.Windows.Forms.DataGridView();
            this.ComPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComPorts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUse
            // 
            this.btnUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUse.Location = new System.Drawing.Point(197, 236);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(75, 23);
            this.btnUse.TabIndex = 1;
            this.btnUse.Text = "Use";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(106, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvComPorts
            // 
            this.dgvComPorts.AllowUserToDeleteRows = false;
            this.dgvComPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComPorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComPort,
            this.DeviceName});
            this.dgvComPorts.Location = new System.Drawing.Point(12, 12);
            this.dgvComPorts.MultiSelect = false;
            this.dgvComPorts.Name = "dgvComPorts";
            this.dgvComPorts.ReadOnly = true;
            this.dgvComPorts.RowHeadersVisible = false;
            this.dgvComPorts.RowTemplate.ReadOnly = true;
            this.dgvComPorts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComPorts.ShowCellErrors = false;
            this.dgvComPorts.ShowCellToolTips = false;
            this.dgvComPorts.ShowEditingIcon = false;
            this.dgvComPorts.ShowRowErrors = false;
            this.dgvComPorts.Size = new System.Drawing.Size(260, 208);
            this.dgvComPorts.TabIndex = 3;
            // 
            // ComPort
            // 
            this.ComPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ComPort.Frozen = true;
            this.ComPort.HeaderText = "Com Port";
            this.ComPort.Name = "ComPort";
            this.ComPort.ReadOnly = true;
            this.ComPort.Width = 75;
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceName.HeaderText = "Device Name";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            // 
            // FrmComPortSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.dgvComPorts);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmComPortSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Com Port Selector";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvComPorts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvComPorts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
    }
}