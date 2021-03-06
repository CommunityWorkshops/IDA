﻿using System;
using System.IO;
using System.Windows.Forms;
using IDA.Controls;
using IDA.Models;

namespace IDA.Forms.Wizards
{
    public partial class FrmNewProject : Form
    {

        private string _platformType = string.Empty;
        private string _versionType = string.Empty;

        public delegate void CreateNewProjectHandler(string name);
        public event CreateNewProjectHandler CreateNewProject;

        public FrmNewProject()
        {
            InitializeComponent();
            LoadPlatforms();
            LoadFirstPlatformVersions();
        }

        private bool PlatformSelected = false;
        private bool PlatformVersionSelected = false;

        private bool _firstVersion = true;
        private void LoadFirstPlatformVersions()
        {
            // folder for the first Platform is platforms[0]
            var platforms = Directory.GetDirectories("Templates\\Platforms\\");
            var versions = Directory.GetDirectories(Path.Combine(platforms[0], "versions"));
            LoadVersions(versions);
        }

        private void Npsc_ThisIsSelected(string name)
        {
            _versionType = name;
            lblSelectedProjectType.Text = _platformType + @" " + _versionType;
            foreach (NewProjectSelectionControl ctrl in flpVersion.Controls)
            {
                ctrl.SetSelected(false);
                if (string.Equals(ctrl.Name, name, StringComparison.CurrentCultureIgnoreCase)) ctrl.SetSelected(true);
                PlatformVersionSelected = true;
            }

            EnableUI();
        }

        private void EnableUI()
        {
            if (PlatformSelected && PlatformVersionSelected)
            {
                if (!tbProjectName.Enabled) tbProjectName.Enabled = true;
                if (tbProjectName.Enabled && !string.IsNullOrEmpty(tbProjectName.Text))
                    btnCreate.Enabled = true;
                else
                    btnCreate.Enabled = false;
            }
        }

        private void Npsc_PlatformIsSelected(string name)
        {
            _platformType = name;
            _versionType = string.Empty;
            lblSelectedProjectType.Text = _platformType + @" " + _versionType;
            foreach (NewProjectSelectionControl ctrl in flpPlatform.Controls)
            {
                ctrl.SetSelected(false);
                if (string.Equals(ctrl.Name, name, StringComparison.CurrentCultureIgnoreCase)) ctrl.SetSelected(true);
                LoadVersionsFor(name);
                PlatformSelected = true;
            }
            EnableUI();
        }

        private void LoadVersionsFor(string name)
        {
            flpVersion.Controls.Clear();
            try
            {
                var versions = Directory.GetDirectories("Templates\\Platforms\\" + Path.Combine(name, "versions"));
                LoadVersions(versions);

            }
            catch (Exception)
            {
                //TODO: Show No version types are available
                //TODO: This should be sent to Main for the Log
                //TODO: Needs to be Translateable.
                flpVersion.Text = "No Versions Available";
            }

        }

        private void LoadVersions(string[] versions)
        {
            foreach (var folder in versions)
            {
                var npsc = new NewProjectSelectionControl();
                npsc.ThisIsSelected += Npsc_ThisIsSelected;
                npsc.Name = folder.Replace("\\", " ").Split(' ')[folder.Replace("\\", " ").Split(' ').Length - 1].Trim(); //TODO: FIX THIS Horrible :P

                if (_firstVersion) _versionType = npsc.Name;
                _firstVersion = false;

                try
                {
                    var imageNames = Directory.EnumerateFiles(Path.Combine(folder, "Images"));
                    foreach (var imageName in imageNames)
                    {
                        if (imageName.ToLower().Contains("version")) npsc.SetImage(imageName);
                    }

                    _versionType = npsc.Name;
                    npsc.SetTitle(npsc.Name);
                }
                catch (Exception)
                {
                    //TODO: This should be sent to Main for the Log
                    throw;
                }

                flpVersion.Controls.Add(npsc);

            }
        }

        private bool _firstPlatform = true;
        private void LoadPlatforms()
        {
            // Load images from the Templates Platform folders
            var platforms = Directory.GetDirectories("Templates\\Platforms\\");
            foreach (var folder in platforms)
            {
                var npsc = new NewProjectSelectionControl();
                npsc.ThisIsSelected += Npsc_PlatformIsSelected;
                npsc.Name = folder.Replace("\\", " ").Split(' ')[folder.Replace("\\", " ").Split(' ').Length - 1].Trim(); //TODO: FIX THIS Horrible :P

                if (_firstPlatform) _platformType = npsc.Name;

                _firstPlatform = false;

                // Now get the Image for the Platform
                try
                {
                    var imageNames = Directory.EnumerateFiles(Path.Combine(folder, "Images"));
                    foreach (var imageName in imageNames)
                    {
                        if (imageName.ToLower().Contains("platform")) npsc.SetImage(imageName);
                    }

                    _platformType = npsc.Name;
                    npsc.SetTitle(npsc.Name);
                }
                catch (Exception ex)
                {
                    //TODO: This should be sent to Main for the Log
                    throw;
                }


                flpPlatform.Controls.Add(npsc);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            CurrentProjectModel.Name = tbProjectName.Text;
            CurrentProjectModel.IsLibrary = cbThisIsALibrary.Checked;
            CurrentProjectModel.IsOpenSource = cbThisIsOpenSource.Checked;
            CurrentProjectModel.Platform = _platformType;
            CurrentProjectModel.Version = _versionType;

            if (string.IsNullOrEmpty(CurrentProjectModel.Name) || string.IsNullOrEmpty(CurrentProjectModel.Platform) || string.IsNullOrEmpty(CurrentProjectModel.Version))
            {
                if (string.IsNullOrEmpty(CurrentProjectModel.Name)) MessageBox.Show("You need to give your project a name");
                if (string.IsNullOrEmpty(CurrentProjectModel.Platform)) MessageBox.Show("You have not selected a Platform");
                if (string.IsNullOrEmpty(CurrentProjectModel.Version)) MessageBox.Show("You have not selected a Platform Version");
            }
            else
            {
                CurrentProjectModel.Name = tbProjectName.Text;
                CurrentProjectModel.IsLibrary = cbThisIsALibrary.Checked;
                CurrentProjectModel.IsOpenSource = cbThisIsOpenSource.Checked;
                CurrentProjectModel.Platform = _platformType;
                CurrentProjectModel.Version = _versionType;
                OnCreateNewProject(tbProjectName.Text);
                Close();
            }
        }

        protected virtual void OnCreateNewProject(string name)
        {
            CreateNewProject?.Invoke(name);
        }

        private void tbProjectName_TextChanged(object sender, EventArgs e)
        {
            EnableUI();
        }
    }
}
