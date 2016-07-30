using System;
using System.IO;
using System.Windows.Forms;
using Dolinay;
using IDA.Controllers.Hardware;
using IDA.Controllers.IO;
using IDA.Forms.Dialog;
using IDA.Forms.Dockable;
using IDA.Forms.Wizards;
using IDA.Models;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;

namespace IDA
{
    public partial class FrmMain : Form
    {
        private readonly string _configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
        private bool _saveLayout = true;
        private readonly DeserializeDockContent _deserializeDockContent;

        private DriveDetector driveDetector = new DriveDetector();

        private readonly FrmSplash _frmSplash = new FrmSplash();
        private FrmLog _frmLog = new FrmLog();
        private FrmProjectExplorer _frmProjectExplorer = new FrmProjectExplorer();


        public FrmMain()
        {

            InitializeComponent();
            Log("Initialising");
            _frmSplash.Show();
            _frmSplash.SetAction("Running USB Connections Detector");
            driveDetector.DeviceArrived += DriveDetector_DeviceArrived;
            driveDetector.DeviceRemoved += DriveDetector_DeviceRemoved;
            driveDetector.QueryRemove += DriveDetector_QueryRemove;
            _frmSplash.SetAction("Looking for compatible Hardware");
            Log("Looking for Hardware Port");
            CurrentProjectModel.ComPort = Usb.GetUsbDevice();
            _frmSplash.SetAction("Opening Logging Window");
            _frmLog.LogWindowClosing += _frmLog_LogWindowClosing;
            _frmLog.LogWindowOpening += _frmLog_LogWindowOpening;
            _frmSplash.SetAction("Loading Docking Settings");
            _deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            _frmSplash.SetAction("Loading User Settings");
            Log("Loading User Settings");
            UserSettingsIo.LoadUser();
            toolStripMenuItemUserName.Text = UserModel.UserName;
            toolStripMenuItemComPort.Text = "Port " + CurrentProjectModel.ComPort;
        }

        private void DriveDetector_QueryRemove(object sender, DriveDetectorEventArgs e)
        {
            // If we recognise this device then we should query it?
            Log("Device Removed " + e.Drive);
        }

        private void DriveDetector_DeviceRemoved(object sender, DriveDetectorEventArgs e)
        {
            // If we recognise this device then we should remove it?
            Log("Device Removed " + e.Drive);
        }

        private void DriveDetector_DeviceArrived(object sender, DriveDetectorEventArgs e)
        {
            // If we recognise this device then we should add it?
            Log("Device Added " + e.Drive);
        }

        #region Docking
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FrmLog).ToString())
                return _frmLog;
            else if (persistString == typeof(FrmProjectExplorer).ToString())        
                return _frmProjectExplorer;
            else if (persistString == typeof(FrmCodeEditor).ToString())
                return null;

            return null;
        }
        #endregion

        #region Code Editor
        private void codeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log("Opening Code Editor");
            //  OpenCodeEditor();
        }

        //private void OpenCodeEditor()
        //{
        //    if (codeEditorToolStripMenuItem.Checked)
        //    {
        //        _frmCodeEditor.Close();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            _frmCodeEditor.Show(dockPanel1, DockState.Document);
        //        }
        //        catch (Exception ex)
        //        {
        //            _frmCodeEditor = new FrmCodeEditor();
        //            _frmCodeEditor.Show(dockPanel1, DockState.Document);
        //            _frmLog.Log("Error: " + ex.Message);
        //        }
        //    }
        //}

        #endregion

        #region Views
        private void resetAllViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log("Reset All Views");
            if (File.Exists(_configFile))
                File.Delete(_configFile);

            Application.Restart();
        }
        #endregion

        #region Main Form Events
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Log("Loading");
            if (File.Exists(_configFile))
                dockPanel1.LoadFromXml(_configFile, _deserializeDockContent);
            _frmSplash.Close();
            TopMost = false;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("Closing");
            if (_saveLayout)
                dockPanel1.SaveAsXml(_configFile);
            else if (File.Exists(_configFile))
                File.Delete(_configFile);
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {

        }

        #endregion

        #region Log
        private void _frmLog_LogWindowOpening()
        {
            logToolStripMenuItem.Checked = true;
            Log("Log Window Opening");
        }

        private void _frmLog_LogWindowClosing()
        {
            Log("Closing Log Window");
            logToolStripMenuItem.Checked = false;
            dockPanel1.SaveAsXml(_configFile);
            _frmLog.LogWindowClosing -= _frmLog_LogWindowClosing;
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
                    Log("Error: " + ex.Message);
                }
            }
        }

        private void Log(string message)
        {
            _frmLog.Log(message);
        }

        #endregion

        #region New Project
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewProject();
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void NewProject()
        {
            Log("New Project");
            FrmNewProject newProject = new FrmNewProject();
            newProject.CreateNewProject += NewProject_CreateNewProject;
            newProject.ShowDialog();
            newProject.CreateNewProject -= NewProject_CreateNewProject;
        }

        private void NewProject_CreateNewProject(string name)
        {
            Log("Creating New Project");

            // Create Project Base Path
            IDA.Models.CurrentProjectModel.ProjectBasePath = PathsGenerator.CreateBasePath(name);

            // Open Code Window
            var _frmCodeEditor = new FrmCodeEditor(name);
            _frmCodeEditor.EditorDirty += _frmCodeEditor_EditorDirty;
            _frmCodeEditor.EditorClean += _frmCodeEditor_EditorClean;


            _frmCodeEditor.Show(dockPanel1, DockState.Document);
            _frmCodeEditor.Parent.Text = name;
            _frmCodeEditor.Tag = name;

            // Load Appropriate Keywords For Code Completion
            Log("Load Code Completion");
            LoadCodeCompletion.Load();
            // Load Appropriate License Header
            // Populate with License Header
            Log("Adding Licence Header");
            _frmCodeEditor.AddLicenceHeader(LoadLicenceHeader.Load());
            // Populate with default code for the platform and version
            Log("Adding Default Platform Code");
            _frmCodeEditor.AddPlatformCode(LoadDefaultPlatformCode.Load());

            // Load Appropriate Toolbox
            // Load Project Explorer
        }

        private void _frmCodeEditor_EditorClean(string name)
        {
            foreach (Control ctrl in dockPanel1.Documents)
            {
                if (ctrl.Tag.ToString() == name)
                {
                    ctrl.Text = name;
                    saveToolStripButton.Enabled = false;
                }
            }
        }

        private void _frmCodeEditor_EditorDirty(string name)
        {
            foreach (Control ctrl in dockPanel1.Documents)
            {
                if (ctrl.Tag.ToString() == name)
                {
                    ctrl.Text = name + " *";
                    saveToolStripButton.Enabled = true;
                }
            }
        }


        #endregion

        #region Licence Editor
        private void licenseEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log("Loading Licence Editor");
            FrmLicenceEditor newLicenceEditor = new FrmLicenceEditor();
            newLicenceEditor.ShowDialog();
        }
        #endregion

        #region User Editor
        private void userEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log("Loading User Editor");
            FrmUserEditor userEditor = new FrmUserEditor();
            userEditor.ShowDialog();
        }


        #endregion

        private void scintillaTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScintillaTest st = new FrmScintillaTest();
            st.Show(dockPanel1, DockState.Document);
        }

        // COM PORT SELECTOR DIALOG
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Log("Com port Selector Opening");
            FrmComPortSelector cps = new FrmComPortSelector();
            cps.ShowDialog();
            toolStripMenuItemComPort.Text = "Port " + CurrentProjectModel.ComPort;
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            // Save the Project.
            Log("Saving project");
            foreach (Control ctrl in dockPanel1.Documents)
            {
                if (ctrl.Tag.ToString() == CurrentProjectModel.Name)
                {
                    FrmCodeEditor fce = (FrmCodeEditor)ctrl;
                    fce.Save();
                    ctrl.Text = CurrentProjectModel.Name;
                    saveToolStripButton.Enabled = false;
                }
            }

            // Do the transformation of the files - really should be done as we go?
            
            // compile the transformed files
            Log("Starting Compilation");
            IDA.Controllers.CLI.Exec exec = new Controllers.CLI.Exec();
            exec.Log += Exec_Log;
            exec.CompilationCompleted += Exec_CompilationCompleted;
            Log("Starting Compiler");
            exec.ExecuteCompiler();
            
        }

        private void Exec_CompilationCompleted()
        {
            Log("Starting Serial Writer");
            IDA.Controllers.CLI.Exec exec = new Controllers.CLI.Exec();
            exec.Log += Exec_Log;
            Log("Writing Embedded Code");
            exec.ExecuteSerialWriter();
        }

        private void Exec_Log(string message)
        {
            Log(message);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Log("Saving project");
            foreach (Control ctrl in dockPanel1.Documents)
            {
                if (ctrl.Tag.ToString() == CurrentProjectModel.Name)
                {
                    FrmCodeEditor fce = (FrmCodeEditor)ctrl;
                    fce.Save();
                    ctrl.Text = CurrentProjectModel.Name;
                    saveToolStripButton.Enabled = false;
                }
            }
        }

        private void projectExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProjectExplorer pe = new Forms.Dockable.FrmProjectExplorer();
            pe.Show(dockPanel1, DockState.DockRight);
        }
    }


}
