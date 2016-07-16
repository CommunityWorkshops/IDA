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

namespace IDA.Forms.Dialog
{
    public partial class FrmComPortSelector : Form
    {
        public FrmComPortSelector()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            

            if (ports.Length == 0)
            {
                MessageBox.Show("No ports are used. Is your device connected?");
                Close();
            }


            foreach (string port in ports)
            {
                lbComPorts.Items.Add(port);
            }
        }
    }
}
