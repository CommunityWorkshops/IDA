using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IDA.Models;

namespace IDA.Controls
{
    public partial class OpenProjectSelectionControl : UserControl
    {

        public delegate void SelectionHandler(string ProjectName);
        public event SelectionHandler SelectedProject;
        public delegate void LogHandler(string message);
        public event LogHandler DoLog;

        private string _ProjectName { get; set; }
 

        public OpenProjectSelectionControl()
        {
            InitializeComponent();
        }

        internal void ProjectSelection(string Platform, string ProjectName)
        {
            Log("Adding previous Project " + ProjectName);
            pbPlatformIcon.Image = GetPlatformImage(Platform);
            pbProjectIcon.Image = GetProjectIcon(ProjectName);
            lblName.Text = GetProjectName(ProjectName);
            _ProjectName = ProjectName; 
        }

        private Image GetPlatformImage(string platform)
        {
            Log("Getting Platform Image " + platform);
            switch (platform.ToLowerInvariant())
            {
                case "arduino":
                        return Image.FromFile(@"templates\Platforms\Arduino\Images\platform.jpg");
                default:
                    return Image.FromFile(@"templates\Platforms\Blank\Images\circuit.png");
                    
            }
        }

        private string GetProjectName(string projectName)
        {
            return projectName.Split('\\')[projectName.Split('\\').Count() - 1];
        }


        private Image GetProjectIcon(string projectName)
        {
            Log("Getting Project Icon " + projectName);
            var pImage = projectName.Split('\\')[projectName.Split('\\').Count() -1] + ".jpg";
            var projectImageLocation = Path.Combine(projectName,  pImage); 

            if (File.Exists(projectImageLocation))
            {
                return Image.FromFile(projectImageLocation);
            }
            else
            {
                return Image.FromFile(@"templates\Platforms\Blank\Images\circuit.png");
            }

        }

        private void OpenProjectSelectionControl_MouseUp(object sender, MouseEventArgs e)
        {
            IsSelected();
        }

        private void lblName_MouseUp(object sender, MouseEventArgs e)
        {
            IsSelected();
        }

        private void pbProjectIcon_MouseUp(object sender, MouseEventArgs e)
        {
            IsSelected();
        }

        private void pbPlatformIcon_MouseUp(object sender, MouseEventArgs e)
        {
            IsSelected();
        }

        private void IsSelected()
        {
            BackColor = Color.Chartreuse;
            SelectedProject?.Invoke(_ProjectName);
        }

        private void Log(string message)
        {
            DoLog?.Invoke(message);
        }
    }
}
