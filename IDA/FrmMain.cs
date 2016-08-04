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
        #region Docking Properties
        private readonly string _configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
        private bool _saveLayout = true;
        private DeserializeDockContent _deserializeDockContent;
        #endregion

        #region USB Properties
        private DriveDetector driveDetector = new DriveDetector();
        #endregion

        #region Forms
        private readonly FrmSplash _frmSplash = new FrmSplash();
        private FrmLog _frmLog = new FrmLog();
        private FrmProjectExplorer _frmProjectExplorer = new FrmProjectExplorer();
        #endregion


        public FrmMain()
        {

            InitializeComponent();

            SplashOne();
            UsbEventSubscription();
            SplashTwo();
            LogWindowEventSubscriptions();
            DeserialiseContent();
            SplashFour();
            LoadUser();
            DisplaySelectedComPort();
        }

        #region SPLASH

        private void SplashOne()
        {
            Log("Initialising");
            _frmSplash.Show();
            _frmSplash.SetAction("Running USB Connections Detector");
        }

        private void SplashTwo()
        {
            _frmSplash.SetAction("Opening Logging Window");
        }

        private void SplashThree()
        {
            _frmSplash.SetAction("Loading Docking Settings");
        }

        private void SplashFour()
        {
            _frmSplash.SetAction("Loading User Settings");
        }
        #endregion

        #region USB

        private void UsbEventSubscription()
        {
            driveDetector.DeviceArrived += DriveDetector_DeviceArrived;
            driveDetector.DeviceRemoved += DriveDetector_DeviceRemoved;
            driveDetector.QueryRemove += DriveDetector_QueryRemove;

            _frmSplash.SetAction("Looking for compatible Hardware");
            Log("Looking for Hardware Port");
            CurrentProjectModel.ComPort = Usb.GetUsbDevice();
        }

        //TODO: Use this http://www.codeproject.com/Articles/60579/A-USB-Library-to-Detect-USB-Devices
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
        #endregion

        #region Docking

        private void DeserialiseContent()
        {
            _deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
        }


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

        private void CloseDocuments()
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                document.DockHandler.Close();
            }
        }
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

        #region Logging

        private void LogWindowEventSubscriptions()
        {
            _frmLog.LogWindowClosing += _frmLog_LogWindowClosing;
            _frmLog.LogWindowOpening += _frmLog_LogWindowOpening;
        }

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

        private void _frmProjectExplorer_ProjectExplorerLog(string message)
        {
            Log(message);
        }

        private void Sp_Log(string message)
        {
            Log(message);
        }

        private void Exec_Log(string message)
        {
            Log(message);
        }

        private void Op_Log(string message)
        {
            Log(message);
        }

        private void OProj_Log(string message)
        {
            Log(message);
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
            CurrentProjectModel.ProjectBasePath = PathsGenerator.CreateBasePath(name);

            // Open Code Window
            OpenCodeEditor(name);


            // Load Appropriate Toolbox
            // Load Project Explorer
            PopulateProjectExplorer();



            // Save Project Configuration File
            Log("Saving Configuration File");
            SaveProject sp = new SaveProject();
            sp.OnLog += Sp_Log;
            sp.SaveProjectConfiguration();
            sp.OnLog -= Sp_Log;
            sp = null; // Not really necessary
        }



        private void OpenCodeEditor(string name)
        {
            var _frmCodeEditor = new FrmCodeEditor(name);

            _frmCodeEditor.Show(dockPanel1, DockState.Document);
            _frmCodeEditor.EditorDirty += _frmCodeEditor_EditorDirty;
            _frmCodeEditor.EditorClean += _frmCodeEditor_EditorClean;
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
        }

        private void _frmCodeEditor_EditorClean(string name)
        {
            foreach (Control ctrl in dockPanel1.Documents)
            {
                try
                {
                    if (ctrl.Tag.ToString() == name)
                    {
                        ctrl.Text = name;
                        saveToolStripButton.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    Log("Error " + ex.Message);
                }

            }
        }

        private void _frmCodeEditor_EditorDirty(string name)
        {
            foreach (Control ctrl in dockPanel1.Documents)
            {
                try
                {
                    if (ctrl.Tag.ToString() == name)
                    {
                        ctrl.Text = name + " *";
                        saveToolStripButton.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    Log("Error: " + ex.Message);
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

        #region User Editor and Settings

        private void LoadUser()
        {
            Log("Loading User Settings");
            UserSettingsIo.LoadUser();
            toolStripMenuItemUserName.Text = UserModel.UserName;
        }

        private void userEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log("Loading User Editor");
            FrmUserEditor userEditor = new FrmUserEditor();
            userEditor.ShowDialog();
        }


        #endregion

        #region Com Port Selector and Settings

        private void DisplaySelectedComPort()
        {
            toolStripMenuItemComPort.Text = "Port " + CurrentProjectModel.ComPort;
        }

        // COM PORT SELECTOR DIALOG
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Log("Com port Selector Opening");
            FrmComPortSelector cps = new FrmComPortSelector();
            cps.ShowDialog();
            toolStripMenuItemComPort.Text = "Port " + CurrentProjectModel.ComPort;
        }
        #endregion

        #region Compile
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

            // Do the transformation of the files? - really should be done as we go?

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
            Controllers.CLI.Exec exec = new Controllers.CLI.Exec();
            exec.Log += Exec_Log;
            Log("Writing Embedded Code");
            exec.ExecuteSerialWriter();
        }
        #endregion

        #region Save Project

        /// <summary>
        /// Save the current active Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Log("Attempting Saving File");
            foreach (Control ctrl in dockPanel1.Documents)
            {
                if(dockPanel1.ActiveDocument == ctrl)
                {                 
                    FrmCodeEditor fce = (FrmCodeEditor)ctrl;
                    fce.Save();
                    ctrl.Text = CurrentProjectModel.Name;
                    saveToolStripButton.Enabled = false;
                    Log("File Saved");
                }
            }
        }
        #endregion

        #region Project Explorer

        /// <summary>
        /// Subscribe to all the Project Explorer Events
        /// </summary>
        /// <param name="pe">
        /// FrmProjectExplorer: The Project Explorer Form that the events belong to.
        /// </param>
        private void ProjectExplorerEvents(FrmProjectExplorer pe)
        {
            pe.ProjectExplorerOpenDocument += _frmProjectExplorer_ProjectExplorerOpenDocument;
            pe.ProjectExplorerLog += _frmProjectExplorer_ProjectExplorerLog;
        }

        /// <summary>
        /// Project Explorer raised event to open a new document
        /// </summary>
        /// <param name="path">
        /// string: Fully qualified Path to the document to open
        /// </param>
        private void _frmProjectExplorer_ProjectExplorerOpenDocument(string path)
        {
            Log("Opening file " + path);
            OpenCodeEditor(path);
        }

        /// <summary>
        /// Populate the Project Explorer with the current Project
        /// </summary>
        private void PopulateProjectExplorer()
        {
            _frmProjectExplorer.LoadProject(CurrentProjectModel.ProjectBasePath);          
        }
        
        /// <summary>
        /// Open Project Explorer Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void projectExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProjectExplorer pe = new Forms.Dockable.FrmProjectExplorer();
            ProjectExplorerEvents(pe);
            pe.Show(dockPanel1, DockState.DockRight);
        }


        #endregion

        #region Open Project
        // Open a previously created project.
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            // If a new project is opened... do we Save and Close this project? For now we will.
            FrmOpenProject op = new Forms.Wizards.FrmOpenProject();
            op.Log += Op_Log;
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(CurrentProjectModel.Name))
                {
                    SaveProject sp = new SaveProject();

                    // Ask before saving.
                    DialogResult dresult = MessageBox.Show("Save Project?", "Save Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dresult == DialogResult.Yes)
                    {
                        foreach (Control ctrl in dockPanel1.Documents)
                        {
                            try
                            {
                                if (ctrl.Tag.ToString() == CurrentProjectModel.Name)
                                {
                                    FrmCodeEditor fce = (FrmCodeEditor)ctrl;
                                    fce.Save();
                                    ctrl.Text = CurrentProjectModel.Name;
                                    saveToolStripButton.Enabled = false;
                                }
                            }
                            catch (Exception ex2)
                            {
                                Log("Error: " + ex2.Message);
                            }

                        }
                        sp.SaveProjectConfiguration();
                    }
                    CloseDocuments();
                    CurrentProjectModel.Reset();
                }

                // Now open the project
                if (!string.IsNullOrEmpty(op.ProjectBasePath))
                {
                    CurrentProjectModel.ProjectBasePath = op.ProjectBasePath;
                    CurrentProjectModel.Name = GetProjectName(CurrentProjectModel.ProjectBasePath);
                    OpenProject oProj = new OpenProject();
                    oProj.Log += OProj_Log;
                    oProj.LoadProjectConfiguration();
                    FrmCodeEditor codeEditor = new FrmCodeEditor();
                    codeEditor.Show(dockPanel1, DockState.Document);
                    codeEditor.EditorDirty += _frmCodeEditor_EditorDirty;
                    codeEditor.EditorClean += _frmCodeEditor_EditorClean;
                    codeEditor.Tag = CurrentProjectModel.Name;
                    codeEditor.Open(CurrentProjectModel.ProjectBasePath);
                    codeEditor.Parent.Text = CurrentProjectModel.Name;
                    // Load Project Explorer
                    _frmProjectExplorer.LoadProject(CurrentProjectModel.ProjectBasePath);                    
                }
            }
        }
        #endregion






        #region Utilities

        private string GetProjectName(string projectName)
        {
            return projectName.Split('\\')[projectName.Split('\\').Length - 1];
        }

        #endregion





    }
}
