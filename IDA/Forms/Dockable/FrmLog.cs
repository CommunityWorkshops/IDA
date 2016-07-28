using System;
using WeifenLuo.WinFormsUI.Docking;


namespace IDA.Forms.Dockable
{
    public partial class FrmLog : DockContent
    {


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
            fcTb.InsertText(message + Environment.NewLine,true);
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
