using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace IDA.Forms.Dialog
{
    public partial class FrmUserEditor : DockContent
    {
        public FrmUserEditor()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text)) return;
            if (string.IsNullOrEmpty(tbEmail.Text)) return;

            FileStream fs = null;           
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(Path.Combine("Settings", "User.dat"), FileMode.Create, FileAccess.Write, FileShare.None);
                sw = new StreamWriter(fs);

                sw.WriteLine(tbName.Text);
                sw.WriteLine(tbEmail.Text);

                sw?.Close();
                fs?.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sw?.Close();
                fs?.Close();
            }
           


        }
    }
}
