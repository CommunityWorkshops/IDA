using System;
using System.IO;
using IDA.Models;
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
                if (!Directory.Exists("Settings")) Directory.CreateDirectory("Settings");

                fs = new FileStream(Path.Combine("Settings", "User.dat"), FileMode.Create, FileAccess.Write, FileShare.None);
                sw = new StreamWriter(fs);

                sw.WriteLine(tbName.Text);
                sw.WriteLine(tbEmail.Text);

                UserModel.UserName = tbName.Text;
                UserModel.UserEmail = tbEmail.Text;

                sw?.Close();
                fs?.Close();
            }
            catch (Exception)
            {
                //TODO: Pass Error on to Log
                throw;
            }
            finally
            {
                sw?.Close();
                fs?.Close();
            }
           
            Close();

        }
    }
}
