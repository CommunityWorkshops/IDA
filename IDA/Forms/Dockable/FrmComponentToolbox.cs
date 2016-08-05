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

        public delegate void LogHandler(string name);
        public event LogHandler FrmComponentToolboxLog;

        public FrmComponentToolbox()
        {
            InitializeComponent();            
        }

        public void LoadComponents(List<ComponentModel> cmList)
        {
            foreach(ComponentModel cm in cmList)
            {
                ComponentSelectionControl csc = new ComponentSelectionControl();
                csc.ComponentTemplateLoaderSelection += Csc_ComponentTemplateLoaderSelection;
                csc.SetIcon(cm.componentIcon);
                csc.SetName(cm.componentName);
                flpInternalComponents.Controls.Add(csc);
                lblNumberOfInternalComponents.Text = (Convert.ToInt16(lblNumberOfInternalComponents.Text) + 1).ToString();
            }
        }

        private void Csc_ComponentTemplateLoaderSelection(string SelectedComponent)
        {
            FrmComponentToolboxLog?.Invoke(SelectedComponent);
        }

        private void Ctl_ComponentTemplateLoaderLog(string message)
        {
            Log(message);
        }

        private void Log(string message)
        {
            FrmComponentToolboxLog?.Invoke(message);
        }
                
    }
}
