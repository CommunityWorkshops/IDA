using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Controllers.CLI
{
    class Exec
    {

        internal void ExecuteCompiler()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            Process proc = new Process();

            psi.CreateNoWindow = true;
            psi.ErrorDialog = true;
            psi.FileName = "Binn\\Compilers\\Arduino\\arduino-builder.exe"; // This may need changed for other hardware types
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.StandardErrorEncoding = Encoding.Unicode;
            psi.StandardOutputEncoding = Encoding.Unicode;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;

            // "C:\Program Files (x86)\Arduino\arduino-builder"                                                     <-- Builder Path
            // -logger=human                                                                                        <-- Logger Type
            // -hardware "C:\Program Files (x86)\Arduino\hardware"                                                  <-- Path to Hardware folder
            // -tools "C:\Program Files (x86)\Arduino\tools-builder"                                                <-- Path to Tools-Builder
            // -tools "C:\Program Files (x86)\Arduino\hardware\tools\avr"                                           <-- Path to avr folder
            // -built-in-libraries "C:\Program Files (x86)\Arduino\libraries"                                       <-- Path to Libraries
            // -libraries "C:\Users\Dave Gordon\Documents\Arduino\libraries"                                        <-- Path to user Libraries?
            // -fqbn=arduino:avr:uno                                                                                <-- Fully Qualified Hardware Name
            // -ide-version=10609                                                                                   <-- IDA's Version
            // -build-path "C:\Users\Dave Gordon\AppData\Local\Temp\build9c9ef3bdfe2fccb480bc6e4bac749e41.tmp"      <-- Temporary Output Directory
            // -warnings=all                                                                                        <-- Warning Level
            // -prefs=build.warn_data_percentage=75                                                                 <-- Warning about size of output?
            // -verbose                                                                                             <-- Logging output level
            // "C:\Program Files (x86)\Arduino\examples\01.Basics\Blink\Blink.ino"                                  <-- File being compiled
            
            psi.Arguments = " -logger=machine -hardware hardware -tools hardware\\tools-builder -tools hardware\tools\avr -built-in-libraries libraries -libraries \"C:\\Users\\Dave Gordon\\Documents\\Arduino\\libraries\" -fqbn=arduino:avr:uno -ide-version=" + IDA.Models.SystemModel.IDAVersion + " -build-path " + Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath,"Build")  + " -warnings=all -prefs=build.warn_data_percentage=75 -verbose " + Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath,IDA.Models.CurrentProjectModel.Name);

            proc.StartInfo = psi;
            proc.ErrorDataReceived += Proc_ErrorDataReceived;
            proc.Exited += Proc_Exited;
            proc.OutputDataReceived += Proc_OutputDataReceived;
            

            try
            {
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {

                throw;
            }
            
           

            while(!proc.HasExited) { }

            psi = null;
            proc.Dispose();
        }

        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
