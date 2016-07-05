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
    public partial class NewProjectSelectionControl : UserControl
    {

        public delegate void ThisIsSelectedHandler(string name);
        public event ThisIsSelectedHandler ThisIsSelected;
        
        private readonly Color _bgColour; 
        public NewProjectSelectionControl()
        {
            InitializeComponent();
            _bgColour = lblName.BackColor;
        }

        public void SetImage(string path)
        {
            pbSelectionImage.Image = Image.FromFile(path);
        }


        private void NewProjectSelectionControl_MouseEnter(object sender, EventArgs e)
        {
            mEnter();
        }
        
        private void NewProjectSelectionControl_MouseLeave(object sender, EventArgs e)
        {
            mLeave();
        }
        
        private void NewProjectSelectionControl_MouseClick(object sender, MouseEventArgs e)
        {
            mClick();
        }
        
        private void pbSelectionImage_MouseClick(object sender, MouseEventArgs e)
        {
            mClick();
        }

        private void pbSelectionImage_MouseEnter(object sender, EventArgs e)
        {
            mEnter();
        }

        private void pbSelectionImage_MouseLeave(object sender, EventArgs e)
        {
            mLeave();
        }

        private void lblName_MouseClick(object sender, MouseEventArgs e)
        {
            mClick();
        }

        private void lblName_MouseEnter(object sender, EventArgs e)
        {
            mEnter();
        }

        private void lblName_MouseLeave(object sender, EventArgs e)
        {
            mLeave();
        }

        private void mEnter()
        {
           BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void mLeave()
        {
            BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

       private void mClick()
        {
            lblName.BackColor = Color.BurlyWood;
            Selected();
        }

        public void Selected()
        {            
            OnThisIsSelected(Name);
        }

        public void SetSelected(bool isSelected)
        {
            lblName.BackColor = !isSelected ? _bgColour : Color.BurlyWood;
        }

        public void SetTitle(string name)
        {
            lblName.Text = name.Normalize();
        }

        protected virtual void OnThisIsSelected(string name)
        {
            ThisIsSelected?.Invoke(name);
        }
    }
}
