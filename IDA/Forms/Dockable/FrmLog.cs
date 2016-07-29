using System;
using WeifenLuo.WinFormsUI.Docking;


namespace IDA.Forms.Dockable
{
    public partial class FrmLog : DockContent
    {

        private delegate void UpdateTextDelegate(string value);

        public delegate void LogWindowClosingHandler();
        public event LogWindowClosingHandler LogWindowClosing;
        public delegate void LogWindowOpeningHandler();
        public event LogWindowOpeningHandler LogWindowOpening;

        public FrmLog()
        {
            InitializeComponent();
        }


        public void Log(string message)
        {
            if (this.fcTb.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.fcTb.Invoke(new UpdateTextDelegate(this.Log), message);
            }
            else
            {
                // This is the UI thread so perform the task.
                fcTb.InsertText(message + Environment.NewLine, true);
            }            
        }

        protected virtual void OnLogWindowClosing()
        {
            LogWindowClosing?.Invoke();
        }

        protected virtual void OnLogWindowOpening()
        {
            LogWindowOpening?.Invoke();
        }
    }
}
