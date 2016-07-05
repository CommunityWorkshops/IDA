using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Controllers.IO
{
    public class LoadLicenceHeader
    {

        public static string[] Load()
        {
            string[] Lines;

            // If default license is not available just use the licenceHeader template and make it the default
            // If no licence header is available download it from the Community-Workshop.com website

            if (!Directory.Exists("Settings")) Directory.CreateDirectory("Settings");
            if (File.Exists(Path.Combine("Settings", "DefaultHeader.tpl"))) return LoadDefaultHeaderLicence();
            else if (File.Exists(Path.Combine("Settings", "LicenceHeader.tpl"))) return LoadLicenceTemplate();
            else return DownloadLicenceTemplate();
            
        }

        private static string[] DownloadLicenceTemplate()
        {
            return new string[] {};
        }

        private static string[] LoadLicenceTemplate()
        {
            return new string[] {};
        }

        private static string[] LoadDefaultHeaderLicence()
        {
            return new string[] {};
        }
    }
}
