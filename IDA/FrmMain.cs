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
using IDA.Forms.Dialog;
using IDA.Forms.Dockable;
using WeifenLuo.WinFormsUI.Docking;

namespace IDA
{
    public partial class FrmMain : Form
    {
        private readonly string _configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
        private bool _saveLayout = true;
        private DeserializeDockContent _deserializeDockContent;

        private readonly FrmSplash _frmSplash = new FrmSplash();
        private FrmLog _frmLog = new FrmLog();
        private FrmCodeEditor _frmCodeEditor = new FrmCodeEditor();
        

        public FrmMain()
        {
            InitializeComponent();
            _frmSplash.ShowDialog();
            _frmLog.LogWindowClosing += _frmLog_LogWindowClosing;
            _frmLog.LogWindowOpening += _frmLog_LogWindowOpening;
            _deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
        }

        private void _frmLog_LogWindowOpening()
        {
            logToolStripMenuItem.Checked = true;
            _frmLog.Log("Log Window Opening");
        }

        private void _frmLog_LogWindowClosing()
        {
            logToolStripMenuItem.Checked = false;
            dockPanel1.SaveAsXml(_configFile);
            _frmLog.LogWindowClosing -= _frmLog_LogWindowClosing;
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FrmLog).ToString())
                return _frmLog;
            else if (persistString == typeof (FrmCodeEditor).ToString())
                return _frmCodeEditor;

            return null;
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logToolStripMenuItem.Checked)
            {
                _frmLog.Close();
            }
            else
            {
                try
                {
                    _frmLog.Show(dockPanel1, DockState.DockBottom);
                }
                catch (Exception ex)
                {
                    _frmLog = new FrmLog();
                    _frmLog.Show(dockPanel1, DockState.DockBottom);
                    _frmLog.Log("Error: " + ex.Message);
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {            
            if (File.Exists(_configFile))
                dockPanel1.LoadFromXml(_configFile, _deserializeDockContent);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (_saveLayout)
                dockPanel1.SaveAsXml(_configFile);
            else if (File.Exists(_configFile))
                File.Delete(_configFile);
        }

        private void resetAllViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists(_configFile))
                File.Delete(_configFile);

            Application.Restart();
        }

        private void codeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codeEditorToolStripMenuItem.Checked)
            {
                _frmCodeEditor.Close();
            }
            else
            {
                try
                {
                    _frmCodeEditor.Show(dockPanel1, DockState.Document);
                }
                catch (Exception ex)
                {
                    _frmCodeEditor = new FrmCodeEditor();
                    _frmCodeEditor.Show(dockPanel1, DockState.Document);
                    _frmLog.Log("Error: " + ex.Message);
                }
            }
        }
    }
}
