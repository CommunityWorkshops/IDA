﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dolinay;
using IDA.Controllers.Hardware;
using IDA.Controllers.IO;
using IDA.Forms.Dialog;
using IDA.Forms.Dockable;
using IDA.Forms.Wizards;
using IDA.Models;
using WeifenLuo.WinFormsUI.Docking;

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
        private FrmCodeEditor _frmCodeEditor = new FrmCodeEditor();

        public FrmMain()
        {

            InitializeComponent();
            _frmSplash.Show();
            _frmSplash.SetAction("Running USB Connections Detector");
            driveDetector.DeviceArrived += DriveDetector_DeviceArrived;
            driveDetector.DeviceRemoved += DriveDetector_DeviceRemoved;
            driveDetector.QueryRemove += DriveDetector_QueryRemove;
            _frmSplash.SetAction("Looking for compatible Hardware");
            CurrentProjectModel.ComPort = Usb.GetUsbDevice();
            _frmSplash.SetAction("Opening Logging Window");
            _frmLog.LogWindowClosing += _frmLog_LogWindowClosing;
            _frmLog.LogWindowOpening += _frmLog_LogWindowOpening;
            _frmSplash.SetAction("Loading Docking Settings");
            _deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            _frmSplash.SetAction("Loading User Settings");
            UserSettingsIo.LoadUser();
            toolStripMenuItemUserName.Text = UserModel.UserName;
            toolStripMenuItemComPort.Text = "Port " + CurrentProjectModel.ComPort;
        }

        private void DriveDetector_QueryRemove(object sender, DriveDetectorEventArgs e)
        {
            // If we recognise this device then we should query it?
        }

        private void DriveDetector_DeviceRemoved(object sender, DriveDetectorEventArgs e)
        {
            // If we recognise this device then we should remove it?
        }

        private void DriveDetector_DeviceArrived(object sender, DriveDetectorEventArgs e)
        {
            // If we recognise this device then we should add it?
        }

        #region Docking
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FrmLog).ToString())
                return _frmLog;
            else if (persistString == typeof(FrmCodeEditor).ToString())
                return _frmCodeEditor;

            return null;
        }
        #endregion

        #region Code Editor
        private void codeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCodeEditor();
        }

        private void OpenCodeEditor()
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

        #endregion

        #region Views
        private void resetAllViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists(_configFile))
                File.Delete(_configFile);

            Application.Restart();
        }
        #endregion

        #region Main Form Events
        private void FrmMain_Load(object sender, EventArgs e)
        {

            if (File.Exists(_configFile))
                dockPanel1.LoadFromXml(_configFile, _deserializeDockContent);
            _frmSplash.Close();
            TopMost = false;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

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
            _frmLog.Log("Log Window Opening");
        }

        private void _frmLog_LogWindowClosing()
        {
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
                    _frmLog.Log("Error: " + ex.Message);
                }
            }
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
            FrmNewProject newProject = new FrmNewProject();
            newProject.CreateNewProject += NewProject_CreateNewProject;
            newProject.ShowDialog();
            newProject.CreateNewProject -= NewProject_CreateNewProject;
        }

        private void NewProject_CreateNewProject(string name)
        {
            // Open Code Window
            _frmCodeEditor = new FrmCodeEditor();
            _frmCodeEditor.Show(dockPanel1, DockState.Document);
            // Load Appropriate Keywords For Code Completion
            LoadCodeCompletion.Load();
            // Load Appropriate License Header
            // Populate with License Header
            _frmCodeEditor.AddLicenceHeader(LoadLicenceHeader.Load());
            // Populate with default code for the platform and version
           _frmCodeEditor.AddPlatformCode(LoadDefaultPlatformCode.Load());
            // Load Appropriate Toolbox
            // Load Project Explorer
        }
        #endregion

        #region Licence Editor
        private void licenseEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenceEditor newLicenceEditor = new FrmLicenceEditor();
            newLicenceEditor.ShowDialog();
        }
        #endregion

        #region User Editor
        private void userEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            FrmComPortSelector cps = new FrmComPortSelector();
            cps.ShowDialog();
            toolStripMenuItemComPort.Text = "Port " + CurrentProjectModel.ComPort;
        }
    }


}
