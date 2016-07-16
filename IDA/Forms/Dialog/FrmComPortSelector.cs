using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDA.Controllers.Hardware;

namespace IDA.Forms.Dialog
{
    public partial class FrmComPortSelector : Form
    {
        public FrmComPortSelector()
        {
            InitializeComponent();
            List<Usb.UsbDeviceInfo> ports = Usb.GetUsbDevices().ToList();


            if (ports.Count == 0)
            {
                MessageBox.Show("No ports are used. Is your device connected?");
                Close();
            }


            foreach (Usb.UsbDeviceInfo port in ports)
            {

                DataGridViewRow row = (DataGridViewRow)dgvComPorts.Rows[0].Clone();
                row.Cells[0].Value = port.DeviceId;
                row.Cells[1].Value = port.Description;
                dgvComPorts.Rows.Add(row);                   
            }
        }

        private void btnUse_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
