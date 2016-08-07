using IDA.Controllers.IO;
using IDA.Controls;
using IDA.Models;
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

        public delegate void LogHandler(string message);
        public event LogHandler FrmComponentToolboxLog;

        public FrmComponentToolbox()
        {
            InitializeComponent();            
        }

        public void LoadComponents(List<ComponentModel> cmList)
        {
            foreach(var cm in cmList)
            {
                var csc = new ComponentSelectionControl();
                csc.ComponentTemplateLoaderSelection += Csc_ComponentTemplateLoaderSelection;
                csc.SelectedComponent += Csc_SelectedComponent;
                csc.SetIcon(cm.ComponentIcon);
                csc.SetName(cm.ComponentName);
                csc.Tag = cm; // Connect the ComponentModel to the Control
                flpInternalComponents.Controls.Add(csc);
                lblNumberOfInternalComponents.Text = (Convert.ToInt16(lblNumberOfInternalComponents.Text) + 1).ToString();
                csc.ResetHighlightColor();
            }
        }

        private void Csc_SelectedComponent(ComponentSelectionControl csc)
        {
            foreach (ComponentSelectionControl cc in flpInternalComponents.Controls)
            {
                if(cc == csc)
                    cc.SelectHighlightColor();
                else
                    cc.ResetHighlightColor();

                cc.Refresh();
            }
        }

        private void Csc_ComponentTemplateLoaderSelection(string selectedComponent)
        {            
           Log(selectedComponent);
            lblDescription.Text = selectedComponent;
        }

        private void Ctl_ComponentTemplateLoaderLog(string message)
        {
            Log(message);
        }

        private void Log(string message)
        {
            FrmComponentToolboxLog?.Invoke(message);
        }

        private void flpInternalComponents_MouseDown(object sender, MouseEventArgs e)
        {
           // button1.DoDragDrop(button1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}
