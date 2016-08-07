using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IDA.Controllers.Hardware;
using IDA.Models;

namespace IDA.Forms.Dialog
{
    public partial class FrmComPortSelector : Form
    {

        private string DeviceId = null;

        public FrmComPortSelector()
        {
            InitializeComponent();

            dgvComPorts.SelectionChanged += DgvComPorts_SelectionChanged;

            var ports = Usb.GetUsbDevices().ToList();


            if (ports.Count == 0)
            {
                MessageBox.Show("No ports are used. Is your device connected?");
                Close();
            }


            foreach (var port in ports)
            {
                var row = (DataGridViewRow)dgvComPorts.Rows[0].Clone();
                row.Cells[0].Value = port.DeviceId;
                if (DeviceId == null) DeviceId = port.DeviceId;
                row.Cells[1].Value = port.Description;
                dgvComPorts.Rows.Add(row);
            }
        }

        private void DgvComPorts_SelectionChanged(object sender, EventArgs e)
        {
            DeviceId = dgvComPorts.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            CurrentProjectModel.ComPort = DeviceId;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CurrentProjectModel.ComPort = null;
            Close();
        }
    }
}
