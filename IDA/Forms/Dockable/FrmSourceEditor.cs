using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace IDA.Forms.Dockable
{
    public partial class FrmCodeEditor : DockContent
    {
        public FrmCodeEditor()
        {
            InitializeComponent();
            
           
        }

       

        public void AddLicenceHeader(List<string> licence)
        {
            if (licence == null) return;

            foreach (var line in licence)
            {
                editor.Text += line + Environment.NewLine;
            }
        }


        internal void AddPlatformCode(List<string> code)
        {
            if (code == null) return;

            editor.Text += Environment.NewLine;
            editor.Text += Environment.NewLine;

            foreach (var line in code)
            {
                editor.Text += line + Environment.NewLine;
            }

            
        }

       
        private void editor_TextChanged(object sender, EventArgs e)
        {
            UpdateLineNumbersColumn();
        }

        private void UpdateLineNumbersColumn()
        {
           
        }
    }
}
