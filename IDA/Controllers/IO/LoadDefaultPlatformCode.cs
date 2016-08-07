using System;
using System.Collections.Generic;
using System.IO;

namespace IDA.Controllers.IO
{
    class LoadDefaultPlatformCode
    {
        public static List<string> Load()
        {

            // If default license is not available just use the licenceHeader template and make it the default
            // If no licence header is available download it from the Community-Workshop.com website

            if (!Directory.Exists("Settings")) Directory.CreateDirectory("Settings");
            if (File.Exists(Path.Combine("Settings", "DefaultHeader.tpl"))) return LoadDefaultCodeTemplate();
            else if (File.Exists(Path.Combine("Settings", "LicenceHeader.tpl"))) return LoadCodeTemplate();
            else return DownloadCodeTemplate();

        }

        private static List<string> LoadDefaultCodeTemplate()
        {
            throw new NotImplementedException();
        }

        private static List<string> DownloadCodeTemplate()
        {
            //TODO: Implement This
            return null;
        }

        private static List<string> LoadCodeTemplate()
        {
            var codeTemplate = new List<string>();

            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(Path.Combine("settings\\ArduinoDefaultCode.tpl"), FileMode.Open, FileAccess.Read, FileShare.Read);
                sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    codeTemplate.Add(line);
                }


                sr.Close();
                fs.Close();
                return codeTemplate;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sr?.Close();
                fs?.Close();
            }
        }
    }
}
