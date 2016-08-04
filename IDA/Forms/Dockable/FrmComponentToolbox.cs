using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace IDA.Forms.Dockable
{
    public partial class FrmComponentToolbox : DockContent
    {
        public FrmComponentToolbox()
        {
            InitializeComponent();
        }

        private void lvComponents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
