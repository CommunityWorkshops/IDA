using IDA.Controls;
using IDA.Models;
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

namespace IDA.Forms.Wizards
{
    public partial class FrmOpenProject : Form
    {
        public string ProjectBasePath { get; internal set; }

        public delegate void LogHandler(string message);
        public event LogHandler Log;

        public FrmOpenProject()
        {
            InitializeComponent();
        }

        private void FrmOpenProject_Load(object sender, EventArgs e)
        {
            // Get all Directories.
            var path = Directory.GetDirectories(SystemModel.ProjectsPath);

            foreach (var project in path)
            {
                // If they contain an .ida file that is the same name as the directory then add to the list of projects
                var projName = project.Split('\\')[project.Split('\\').Count() - 1];
                var configName = projName + ".ida";
                var ConfigurationPath = Path.Combine(project, configName);
                if (File.Exists(ConfigurationPath))
                {
                    OpenProjectSelectionControl psc = new IDA.Controls.OpenProjectSelectionControl();
                    psc.SelectedProject += Psc_SelectedProject;
                    psc.DoLog += Psc_DoLog;
                    psc.ProjectSelection(GetPlatform(ConfigurationPath), project);
                    flpPreviousProjects.Controls.Add(psc);
                    psc.Tag = CurrentProjectModel.Name;
                }
            }
        }

        private void Psc_DoLog(string message)
        {
            DoLog(message);
        }

        private string GetPlatform(string project)
        {
            Controllers.IO.OpenProject op = new Controllers.IO.OpenProject();
            op.Log += Op_Log;
            return op.LoadProjectPlatform(project);
        }

        private void Op_Log(string message)
        {
            DoLog(message);
        }

        private void Psc_SelectedProject(string ProjectName)
        {
            DoLog("Selected Project " + ProjectName);
            ProjectBasePath = ProjectName; 
            
        }

        private void DoLog(string message)
        {
            Log?.Invoke(message);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            DoLog("Nothing Selected");
            Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
