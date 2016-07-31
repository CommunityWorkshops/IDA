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
            lblName.Text = ProjectName;
            _ProjectName = ProjectName;
        }

        private Image GetPlatformImage(string platform)
        {
            Log("Getting Platform Image");
            switch (platform.ToLowerInvariant())
            {
                case "arduino":
                        return Image.FromFile(@"templates\Platforms\Arduino\Images\platform.jpg");
                default:
                    return Image.FromFile(@"templates\Platforms\Blank\Images\circuit.png");
                    
            }
        }

        private Image GetProjectIcon(string projectName)
        {
            Log("Getting Project Icon");
            var projectImageLocation = Path.Combine(Path.Combine(SystemModel.ProjectsPath, projectName), projectName, ".jpg");

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
            SelectedProject?.Invoke(_ProjectName);
        }

        private void Log(string message)
        {
            DoLog?.Invoke(message);
        }
    }
}
