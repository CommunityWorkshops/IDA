using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDA.Controls;

namespace IDA.Forms.Wizards
{
    public partial class FrmNewProject : Form
    {

        private string _platformType = string.Empty;
        private string _versionType = string.Empty;
        
        public FrmNewProject()
        {
            InitializeComponent();
            LoadPlatforms();
            LoadFirstPlatformVersions();
        }

        private bool _firstVersion = true;
        private void LoadFirstPlatformVersions()
        {
            // folder for the first Platform is platforms[0]
            string[] platforms = Directory.GetDirectories("Templates\\Platforms\\");
            string[] versions = Directory.GetDirectories(Path.Combine(platforms[0],"versions"));

            foreach (var folder in versions)
            {
                NewProjectSelectionControl npsc = new NewProjectSelectionControl();
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

        private void Npsc_ThisIsSelected(string name)
        {
            _versionType = name;
            lblSelectedProjectType.Text = _platformType + @" " + _versionType;
            foreach (NewProjectSelectionControl ctrl in flpVersion.Controls)
            {
                ctrl.SetSelected(false);
                if(string.Equals(ctrl.Name, name, StringComparison.CurrentCultureIgnoreCase)) ctrl.SetSelected(true);
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
            }
        }

        private void LoadVersionsFor(string name)
        {
            flpVersion.Controls.Clear();
            try
            {
                string[] versions = Directory.GetDirectories("Templates\\Platforms\\" + Path.Combine(name, "versions"));

                foreach (var folder in versions)
                {
                    NewProjectSelectionControl npsc = new NewProjectSelectionControl();
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
            catch (Exception)
            {
                //TODO: Show No version types are available
                //TODO: This should be sent to Main for the Log
                //TODO: Needs to be Translateable.
                flpVersion.Text = "No Versions Available";
            }
           
        }

        private bool _firstPlatform = true;
        private void LoadPlatforms()
        {
            // Load images from the Templates Platform folders
            string[] platforms = Directory.GetDirectories("Templates\\Platforms\\");
            foreach (var folder in platforms)
            {
                NewProjectSelectionControl npsc = new NewProjectSelectionControl();
                npsc.ThisIsSelected += Npsc_PlatformIsSelected;
                npsc.Name = folder.Replace("\\", " ").Split(' ')[folder.Replace("\\", " ").Split(' ').Length-1].Trim(); //TODO: FIX THIS Horrible :P

                if (_firstPlatform) _platformType = npsc.Name;

                _firstPlatform = false;

                // Now get the Image for the Platform
                try
                {
                    var imageNames = Directory.EnumerateFiles(Path.Combine(folder, "Images"));
                    foreach (var imageName in imageNames)
                    {
                        if(imageName.ToLower().Contains("platform")) npsc.SetImage(imageName);
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
    }
}
