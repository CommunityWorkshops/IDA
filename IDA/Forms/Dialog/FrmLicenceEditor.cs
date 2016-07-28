using System;
using WeifenLuo.WinFormsUI.Docking;

namespace IDA.Forms.Dialog
{
    public partial class FrmLicenceEditor : DockContent
    {
        public FrmLicenceEditor()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
