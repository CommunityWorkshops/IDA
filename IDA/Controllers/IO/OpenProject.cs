using IDA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Controllers.IO
{
    class OpenProject
    {

        public delegate void LogHandler(string message);
        public event LogHandler Log;

        internal void LoadProjectConfiguration()
        {
            var pc = CurrentProjectModel.Name + ".ida";
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(Path.Combine(CurrentProjectModel.ProjectBasePath, pc), FileMode.Open, FileAccess.Read, FileShare.None);
                sr = new StreamReader(fs);

                sr.ReadLine(); // sw.WriteLine("#ProjectConfigurationVersion=1");
                CurrentProjectModel.Name = sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.Name);
                CurrentProjectModel.Platform = sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.Platform);
                CurrentProjectModel.Version = sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.Version);
                CurrentProjectModel.ProjectBasePath = sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.ProjectBasePath);
                CurrentProjectModel.ProjectBuildPath = sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.ProjectBuildPath);
                CurrentProjectModel.MajorVersion = int.Parse(sr.ReadLine()); // sw.WriteLine(CurrentProjectModel.MajorVersion);
                CurrentProjectModel.MajorBuild = int.Parse(sr.ReadLine()); // sw.WriteLine(CurrentProjectModel.MajorBuild);
                CurrentProjectModel.MinorVersion = int.Parse(sr.ReadLine()); // sw.WriteLine(CurrentProjectModel.MinorVersion);
                CurrentProjectModel.MinorBuild = int.Parse(sr.ReadLine()); // sw.WriteLine(CurrentProjectModel.MinorBuild);
                CurrentProjectModel.IsLibrary = Convert.ToBoolean(sr.ReadLine()); // sw.WriteLine(CurrentProjectModel.IsLibrary);
                CurrentProjectModel.IsOpenSource = Convert.ToBoolean(sr.ReadLine()); // sw.WriteLine(CurrentProjectModel.IsOpenSource);
                CurrentProjectModel.ComPort = sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.ComPort);              // Remember this can change on each load so should always be updated on loading  

                sr.Close();
                fs.Close();

                Log?.Invoke("Project Configuration File Loaded");
            }
            catch (Exception ex)
            {
                Log?.Invoke("Error: " + ex.Message);
                sr?.Close();
                fs?.Close();
            }
            finally
            {
                sr?.Close();
                fs?.Close();
            }
        }

        internal string LoadProjectPlatform(string projectName)
        {
            
            var result = string.Empty;

            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(projectName, FileMode.Open, FileAccess.Read, FileShare.None);
                sr = new StreamReader(fs);

                sr.ReadLine(); // sw.WriteLine("#ProjectConfigurationVersion=1");
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.Name);
                result = sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.Platform);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.Version);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.ProjectBasePath);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.ProjectBuildPath);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.MajorVersion);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.MajorBuild);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.MinorVersion);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.MinorBuild);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.IsLibrary);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.IsOpenSource);
                sr.ReadLine(); // sw.WriteLine(CurrentProjectModel.ComPort);              // Remember this can change on each load so should always be updated on loading  

                sr.Close();
                fs.Close();

                Log?.Invoke("Discovered Project Platform type");
            }
            catch (Exception ex)
            {
                Log?.Invoke("Error: " + ex.Message);
                sr?.Close();
                fs?.Close();
            }
            finally
            {
                sr?.Close();
                fs?.Close();
            }

            return result;
        }

    }
}
