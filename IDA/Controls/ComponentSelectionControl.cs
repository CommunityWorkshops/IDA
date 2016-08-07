using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDA.Models;

namespace IDA.Controls
{
    public partial class ComponentSelectionControl : UserControl
    {
        public delegate void SelectionHandler(string selectedComponent);
        public event SelectionHandler ComponentTemplateLoaderSelection;
        public delegate void SelectedComponentHandler(ComponentSelectionControl csc);
        public event SelectedComponentHandler SelectedComponent;

        private Color bcolorDefaultColor = Control.DefaultBackColor;

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
            
            var cm = Tag as ComponentModel;
            if (cm != null) ComponentTemplateLoaderSelection?.Invoke(cm.ComponentDescription);
            SelectedComponent?.Invoke(this);
        }

        private void ComponentSelectionControl_MouseDown(object sender, MouseEventArgs e)
        {
           
            var cm = Tag as ComponentModel;
            if (cm != null) DoDragDrop(this, DragDropEffects.Copy | DragDropEffects.Move);
        }

        public void ResetHighlightColor()
        {
            lblName.BackColor = bcolorDefaultColor;
        }

        public void SelectHighlightColor()
        {
            lblName.BackColor = Color.Aqua;
        }
    }
}
