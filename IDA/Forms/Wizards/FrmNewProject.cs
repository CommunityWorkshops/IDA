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

        private void LoadFirstPlatformVersions()
        {
        }

        private bool _first = true;
        private void LoadPlatforms()
        {
            // Load images from the Templates Platform folders
            string[] platforms = Directory.GetDirectories("Templates\\Platforms\\");
            foreach (var folder in platforms)
            {
                NewProjectSelectionControl npsc = new NewProjectSelectionControl();
                npsc.Name = folder.Replace("\\", " ").Split(' ')[folder.Replace("\\", " ").Split(' ').Length-1].Trim(); //TODO: FIX THIS Horrible :P

                if (_first) _platformType = npsc.Name;

                _first = false;

                // Now get the Image for the Platform
                try
                {
                    var imageNames = Directory.EnumerateFiles(Path.Combine(folder, "Images"));
                    foreach (var imageName in imageNames)
                    {
                        if(imageName.ToLower().Contains("platform")) npsc.SetImage(imageName);
                    }

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
