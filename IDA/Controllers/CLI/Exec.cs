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

        public delegate void LogHandler(string name);
        public event LogHandler Log;

        internal void ExecuteCompiler()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            Process proc = new Process();

            psi.WorkingDirectory = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location.ToLower().Replace("ida.exe",""), @"Binn\Compilers\Arduino");
            Log("Current Working Directory: " + psi.WorkingDirectory);
            psi.CreateNoWindow = true;
            psi.ErrorDialog = true;           
            psi.FileName = @"Binn\Compilers\Arduino\arduino-builder.exe"; // This may need changed for other hardware types
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;            
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

            /*
             * C:\Users\Dave Gordon\Source\Repos\IDA\IDA\bin\Debug\Binn\Compilers\Arduino>arduino-builder.exe -logger=machine -hardware hardware -tools tools-builder -tools hardware\tools\avr -built-in-libraries libraries -libraries "C:\\Users\\Dave Gordon\\Documents\\Arduino\\libraries" -fqbn=arduino:avr:uno -ide-version=1 -build-path "C:\Users\Dave Gordon\Documents\IDA\Projects\a\Build"  -warnings=all -prefs=build.warn_data_percentage=75 -verbose "C:\Users\Dave Gordon\Documents\IDA\Projects\a\a.c"
             */

            //" -logger=machine -hardware hardware -tools tools-builder -tools hardware\\tools\\avr -built-in-libraries libraries -libraries \"C:\\Users\\Dave Gordon\\Documents\\Arduino\\libraries\" -fqbn=arduino:avr:uno -ide-version=1.0.6054.40280 -build-path C:\\Users\\Dave Gordon\\Documents\\IDA\\Projects\\q8\\Build -warnings=all -prefs=build.warn_data_percentage=75 -verbose C:\\Users\\Dave Gordon\\Documents\\IDA\\Projects\\q8\\q8.c -logger=machine -hardware hardware -tools tools-builder -tools hardware\\tools\\avr -built-in-libraries libraries -libraries \"C:\\Users\\Dave Gordon\\Documents\\Arduino\\libraries\" -fqbn=arduino:avr:uno -ide-version=1.0.6054.40280 -build-path C:\\Users\\Dave Gordon\\Documents\\IDA\\Projects\\q8\\Build -warnings=all -prefs=build.warn_data_percentage=75 -verbose C:\\Users\\Dave Gordon\\Documents\\IDA\\Projects\\q8\\q8.c"

            var target = Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath, IDA.Models.CurrentProjectModel.Name + ".c");
            var tmpArgs = @" -logger=machine -hardware hardware -tools tools-builder -tools hardware\tools\avr -built-in-libraries libraries -libraries ""C:\Users\Dave Gordon\Documents\Arduino\libraries"" -fqbn=arduino:avr:uno -ide-version=" + IDA.Models.SystemModel.IDAVersion + " -build-path \"" + IDA.Models.CurrentProjectModel.ProjectBuildPath + "\" -warnings=all -prefs=build.warn_data_percentage=75 -verbose \"" + target + "\"";

            psi.Arguments = tmpArgs;

            proc.StartInfo = psi;
            proc.OutputDataReceived += Proc_OutputDataReceived;

            Log("Full Command = " + psi.FileName + " " + tmpArgs);
            try
            {
                proc.Start();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
                
                psi = null;
                proc.Dispose();
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
            }
            finally
            {
                psi = null;
                proc?.Dispose();
            }

            Log("Compilation Completed");
        }

        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                Log(e.Data);
        }
    }
}
