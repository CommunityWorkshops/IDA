using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using IDA.Models;

namespace IDA.Controllers.IO
{
    public class LoadLicenceHeader
    {

        public static List<string> Load()
        {

            // If default license is not available just use the licenceHeader template and make it the default
            // If no licence header is available download it from the Community-Workshop.com website

            if (!Directory.Exists("Settings")) Directory.CreateDirectory("Settings");
            if (File.Exists(Path.Combine("Settings", "DefaultHeader.tpl"))) return LoadDefaultHeaderLicence();
            else if (File.Exists(Path.Combine("Settings", "LicenceHeader.tpl"))) return LoadLicenceTemplate();
            else return DownloadLicenceTemplate();

        }

        private static List<string> DownloadLicenceTemplate()
        {
            //TODO: Implement This
            return null;
        }

        private static List<string> LoadLicenceTemplate()
        {
            List<string> LicenceTemplate = new List<string>();

            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(Path.Combine("settings\\LicenceHeader.tpl"), FileMode.Open, FileAccess.Read, FileShare.Read);
                sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line != null && line.StartsWith("//"))
                    {
                        LicenceTemplate.Add(ConvertTemplateLine(line));
                    }
                }


                sr.Close();
                fs.Close();
                return LicenceTemplate;
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

        private static string ConvertTemplateLine(string line)
        {
            if (line.ToLower().Contains("<project name>"))
                return line.Replace("<Project Name>", CurrentProjectModel.Name);
            if (line.ToLower().Contains("<project version>"))
                return line.Replace("<Project Version>", CurrentProjectModel.MajorVersion.ToString("X4")) + ":" + CurrentProjectModel.MinorVersion.ToString("X4") + ":" + CurrentProjectModel.MajorBuild.ToString("X4") + ":" + CurrentProjectModel.MinorBuild.ToString("X4");
            if (line.ToLower().Contains("<project type>"))
                if (CurrentProjectModel.IsLibrary)
                    return line.Replace("<Project Type>", "Library");
                else
                    return line.Replace("<Project Type>", "Application");
            if (line.ToLower().Contains("<project author>"))
                return line.Replace("<Project Author>", UserModel.UserName);
            if (line.ToLower().Contains("<author's email>"))
                return line.Replace("<Author's Email>", UserModel.UserEmail);

            if (line.ToLower().Contains("<created on>"))
                return line.Replace("<Created On>", DateTime.Now.ToString(CultureInfo.CurrentCulture));

            if (line.ToLower().Contains("<license type>"))
                if (CurrentProjectModel.IsOpenSource)
                    return line.Replace("<License Type>", "Open Source");
                else
                    return line.Replace("<License Type>", "Proprietory");

            return line;
        }

        private static List<string> LoadDefaultHeaderLicence()
        {
            return null;
        }
    }
}
