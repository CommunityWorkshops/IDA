using IDA.Forms.Dockable;
using IDA.Models;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace IDA.Controllers.IO
{
    class SaveProject
    {
        public delegate void LogHandler(string message);
        public event LogHandler OnLog;
        
        // Project configuration file = project name + .ida
        internal void SaveProjectConfiguration()
        {
            var pc = CurrentProjectModel.Name + ".ida";
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(Path.Combine(CurrentProjectModel.ProjectBasePath, pc), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                sw = new StreamWriter(fs);

                sw.WriteLine("#ProjectConfigurationVersion=1");
                sw.WriteLine(CurrentProjectModel.Name);
                sw.WriteLine(CurrentProjectModel.Platform);
                sw.WriteLine(CurrentProjectModel.Version);
                sw.WriteLine(CurrentProjectModel.ProjectBasePath);
                sw.WriteLine(CurrentProjectModel.ProjectBuildPath);
                sw.WriteLine(CurrentProjectModel.MajorVersion);
                sw.WriteLine(CurrentProjectModel.MajorBuild);
                sw.WriteLine(CurrentProjectModel.MinorVersion);
                sw.WriteLine(CurrentProjectModel.MinorBuild);
                sw.WriteLine(CurrentProjectModel.IsLibrary);
                sw.WriteLine(CurrentProjectModel.IsOpenSource);
                sw.WriteLine(CurrentProjectModel.ComPort);              // Remember this can change on each load so should always be updated on loading  

                sw.Close();
                fs.Close();

                OnLog?.Invoke("Project Configuration File Saved");
            }
            catch (Exception ex)
            {
                OnLog?.Invoke("Error: " + ex.Message);
                sw?.Close();
                fs?.Close();
            }
            finally
            {
                sw?.Close();
                fs?.Close();
            }

        }

               
    }
}
