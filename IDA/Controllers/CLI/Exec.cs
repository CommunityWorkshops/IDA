using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDA.Controllers.CLI
{
    class Exec
    {

        public delegate void LogHandler(string name);
        public event LogHandler Log;

        public delegate void CompilationCompletedHandler();
        public event CompilationCompletedHandler CompilationCompleted;

        internal void ExecuteCompiler()
        {
            var psi = new ProcessStartInfo();
            var proc = new Process();

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

            Log("Generating Arguments");
            var target = Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath, IDA.Models.CurrentProjectModel.Name + ".c");
            var tmpArgs = @" -logger=machine -hardware hardware -tools tools-builder -tools hardware\tools\avr -built-in-libraries libraries -libraries ""C:\Users\Dave Gordon\Documents\Arduino\libraries"" -fqbn=arduino:avr:uno -ide-version=" + IDA.Models.SystemModel.IDAVersion + " -build-path \"" + IDA.Models.CurrentProjectModel.ProjectBuildPath + "\" -warnings=all -prefs=build.warn_data_percentage=75 -verbose \"" + target + "\"";

            psi.Arguments = tmpArgs;

            proc.StartInfo = psi;
            proc.OutputDataReceived += Proc_OutputDataReceived;
            proc.ErrorDataReceived += Proc_ErrorDataReceived;

            Log("Full Command = " + psi.FileName + " " + tmpArgs);
            try
            {
                Log("Starting Compiler");
                proc.Start();
                proc.BeginOutputReadLine();
                Log("Waiting for Compilation End");
               // proc.WaitForExit(30000); //TODO: Make user settings: Timeout after 30 seconds

                for(;;)
                {
                    if (proc.HasExited) break;
                    Application.DoEvents();
                }

                Log("Cleaning up Resources");
                psi = null;
                proc.Dispose();
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
            }
            finally
            {
                Log("Finalising Compilation");
                psi = null;
                proc?.Dispose();
            }

            Log("Compilation Completed");
            CompilationCompleted();
        }

        private void Proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                Log("ERROR: " + e.Data);
        }

        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                Log(e.Data);
        }

        internal void ExecuteSerialWriter()
        {
            // C:\Program Files (x86)\Arduino\hardware\tools\avr/bin/avrdude -CC:\Program Files (x86)\Arduino\hardware\tools\avr/etc/avrdude.conf -v -patmega328p -carduino -PCOM3 -b115200 -D -Uflash:w:C:\Users\Dave\AppData\Local\Temp\build9c9ef3bdfe2fccb480bc6e4bac749e41.tmp/Blink.ino.hex:i 

            var psi = new ProcessStartInfo();
            var serialWriterProc = new Process();

            psi.WorkingDirectory = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location.ToLower().Replace("ida.exe", ""), @"Binn\Compilers\Arduino\hardware\tools\avr\bin");
            var configDirectory = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location.ToLower().Replace("ida.exe", ""), @"Binn\Compilers\Arduino\hardware\tools\avr\etc"); ;
            Log("Current Working Directory: " + psi.WorkingDirectory);
            psi.CreateNoWindow = true;
            psi.ErrorDialog = true;
            psi.FileName = @"Binn\Compilers\Arduino\hardware\tools\avr\bin\avrdude.exe"; // This may need changed for other hardware types         
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;

            //  var tmpArgs = @" -logger=machine -hardware hardware -tools tools-builder -tools hardware\tools\avr -built-in-libraries libraries -libraries ""C:\Users\Dave Gordon\Documents\Arduino\libraries"" -fqbn=arduino:avr:uno -ide-version=" + IDA.Models.SystemModel.IDAVersion + " -build-path \"" + IDA.Models.CurrentProjectModel.ProjectBuildPath + "\" -warnings=all -prefs=build.warn_data_percentage=75 -verbose \"" + target + "\"";     
            Log("Generating Arguments");
            var target = Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath, "build\\" + IDA.Models.CurrentProjectModel.Name + ".c.hex");
            Log("Targetting " + target);
            var config = Path.Combine(configDirectory, "avrdude.conf");
            Log("Loading Configuration " + config);
            var tmpArgs = " -C \"" + config + "\" -v -patmega328p -carduino -P" + Models.CurrentProjectModel.ComPort + " -b115200 -D -Uflash:w:\"" + target + ":i\"" ;

            psi.Arguments = tmpArgs;

            serialWriterProc.StartInfo = psi;
            serialWriterProc.OutputDataReceived += SerialWriterProc_OutputDataReceived;
            serialWriterProc.ErrorDataReceived += SerialWriterProc_ErrorDataReceived;

            Log("Full Command = " + psi.FileName); // + " " + tmpArgs);
            try
            {
                Log("Starting Serial Writer");
                serialWriterProc.Start();
                serialWriterProc.BeginOutputReadLine();
                serialWriterProc.BeginErrorReadLine();
                Log("Waiting for Serial Writer to Finish");
                for (;;)
                {
                    if (serialWriterProc.HasExited) break;
                    Application.DoEvents();
                }


                Log("Cleaning up Resources");
                psi = null;
                serialWriterProc.Dispose();
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
            }
            finally
            {
                Log("Finalising Serial Write");
                psi = null;
                serialWriterProc?.Dispose();
            }

            Log("Serial Write Completed");
        }

        private void SerialWriterProc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                Log(e.Data);
        }

        private void SerialWriterProc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                Log(e.Data);
        }
    }
}
