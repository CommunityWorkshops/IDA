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
    static class SaveProject
    {

        // Tell this instance of the Editor to save it's contents 
        internal static void Save(Control control)
        {
            
        }


        // Project configuration file = project name + .ida
        internal static void SaveProjectConfiguration()
        {
            var pc = CurrentProjectModel.Name + ".ida";
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(Path.Combine(CurrentProjectModel.ProjectBasePath, pc), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                sw = new StreamWriter(fs);

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
                sw.WriteLine(CurrentProjectModel.ComPort);                

                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
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
