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

        public delegate void ThisIsSelectedHandler();
        public event ThisIsSelectedHandler ThisIsSelected;


        public Image PlatformOrVersionImage { get; set; }

        private Color bgColour; 
        public NewProjectSelectionControl()
        {
            InitializeComponent();
            bgColour = lblName.BackColor;
            pbSelectionImage.Image = PlatformOrVersionImage;
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
        }

        private bool _IsSelected = false;
        public void Selected(bool isSelected)
        {
            if (!isSelected) lblName.BackColor = bgColour;
            OnThisIsSelected();
        }

        protected virtual void OnThisIsSelected()
        {
            ThisIsSelected?.Invoke();
        }
    }
}
