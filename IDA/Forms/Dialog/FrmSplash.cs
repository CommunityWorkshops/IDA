using System.Windows.Forms;

namespace IDA.Forms.Dialog
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
            lblVersion.Text = GetVersion();

        }


        public void SetAction(string Action)
        {
            lblAction.Text = Action;
        }

        private string GetVersion()
        {
            return "Version: " + typeof (FrmMain).Assembly.GetName().Version.ToString();
        }       
    }
}
