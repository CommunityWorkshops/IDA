using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDA.Forms.Dialog
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
            lblVersion.Text = GetVersion();

        }

        private string GetVersion()
        {
            return "Version: " + typeof (FrmMain).Assembly.GetName().Version.ToString();
        }       
    }
}
