using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDA.Controls
{
    public partial class ComponentSelectionControl : UserControl
    {
        public delegate void SelectionHandler(string SelectedComponent);
        public event SelectionHandler ComponentTemplateLoaderSelection;

        public ComponentSelectionControl()
        {
            InitializeComponent();
        }

        public void SetIcon(Image icon)
        {
            pbIcon.Image = icon;
        }

        public void SetName(string name)
        {
            lblName.Text = name;
        }

        private void pbIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ComponentTemplateLoaderSelection?.Invoke(lblName.Text + " has been selected in the Toolbox");
        }
    }
}
