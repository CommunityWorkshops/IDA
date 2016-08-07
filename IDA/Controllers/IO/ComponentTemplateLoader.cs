using IDA.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Controllers.IO
{
    class ComponentTemplateLoader
    {

        public delegate void LogHandler(string message);
        public event LogHandler ComponentTemplateLoaderLog;

        public List<ComponentModel> LoadComponents()
        {

            var cmList = new List<Models.ComponentModel>();
            var platformPath = @"templates\platforms\" + CurrentProjectModel.Platform + @"\versions\" +
                               CurrentProjectModel.Version + @"\components\internal\";
            var componentDirectories = Directory.GetDirectories(platformPath);
            var files = new List<string>();
            var internalComponentBasePath = @"Templates\Platforms\" + CurrentProjectModel.Platform + @"\Versions\" + CurrentProjectModel.Version + @"\Components\internal\";

            foreach (var dir in componentDirectories)
            {
                foreach (var file in Directory.GetFiles(dir))
                {
                    if (file.ToLowerInvariant().EndsWith(".icl", StringComparison.OrdinalIgnoreCase))
                        files.Add(file);
                }
            }

            FileStream fs = null;
            StreamReader sr = null;

            // Load the .icl files (IDA Component List)
            foreach (var file in files)
            {
                try
                {
                    fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                    sr = new StreamReader(fs);


                    var line = sr.ReadLine();
                    if (line.StartsWith(@"//", StringComparison.CurrentCulture) || !line.Contains("=")) continue;
                    var cm = new Models.ComponentModel();
                    var lineParts = line.Split('=');

                    if (lineParts[0].ToLower() != "version") continue;

                    if (string.Equals(lineParts[1].ToLower(), CurrentProjectModel.Version.ToLower(),
                        StringComparison.OrdinalIgnoreCase))
                    {
                        while (!sr.EndOfStream)
                        {
                            var versionLine = sr.ReadLine();
                            var versionParts = versionLine?.Split('=');
                            if (versionParts != null && versionParts[0].ToLower() == "name")
                                cm.ComponentName = versionParts[1].ToString();
                            else if (versionParts != null && versionParts[0].ToLower() == "description")
                                cm.ComponentDescription = versionParts[1].ToString();
                            else if (versionParts != null && versionParts[0].ToLower() == "options")
                            {
                                var options = versionParts[1].Split(',');
                                foreach (var option in options)
                                {
                                    if (option.ToLower() == "analog")
                                        cm.ComponentOptions.Add(ComponentModel.Options.Analog);
                                    if (option.ToLower() == "digital")
                                        cm.ComponentOptions.Add(ComponentModel.Options.Digital);
                                }
                            }
                            else if (versionParts != null && versionParts[0].ToLower() == "icon")
                            {
                                var iconPath = GetIconPath(file);
                                cm.ComponentIcon = Image.FromFile(iconPath);
                            }
                            else if (versionParts != null && versionParts[0].ToLower() == "images")
                            {
                                var imagePath = string.Empty;
                                // templates\platforms\Arduino\versions\Uno\components\internal\SerialInput\SerialInput.icl
                                if (cm.ComponentOptions.Contains(ComponentModel.Options.Analog))
                                {
                                    imagePath = GetImagePath(file,"analog");
                                    cm.ComponentSchematic = Image.FromFile(Path.Combine(imagePath, "schematic.png"));
                                    cm.ComponentLayout = Image.FromFile(Path.Combine(imagePath, "layout.png"));
                                }
                                else if (cm.ComponentOptions.Contains(ComponentModel.Options.Digital))
                                {
                                    imagePath = GetImagePath(file, "digital");
                                    cm.ComponentSchematic = Image.FromFile(Path.Combine(imagePath, "schematic.png"));
                                    cm.ComponentLayout = Image.FromFile(Path.Combine(imagePath, "layout.png"));
                                }
                                else
                                {
                                    OnLog("Could not determine if this is a digital or analog internal component");
                                }
                            }
                            else if (versionParts != null && versionParts[0].ToLower() == "global")
                                cm.ComponentGlobal.Add(versionParts[1]);
                            else if (versionParts != null && versionParts[0].ToLower() == "analog global")
                                cm.ComponentAnalogGlobal.Add(versionParts[1]);
                            else if (versionParts != null && versionParts[0].ToLower() == "digital global")
                                cm.ComponentDigitalGlobal.Add(versionParts[1]);
                            else if (versionParts != null && versionParts[0].ToLower() == "setup")
                                cm.ComponentSetup.Add(versionParts[1]);
                            else if (versionParts != null && versionParts[0].ToLower() == "analog setup")
                                cm.ComponentAnalogSetup.Add(versionParts[1]);
                            else if (versionParts != null && versionParts[0].ToLower() == "digital setup")
                                cm.ComponentDigitalSetup.Add(versionParts[1]);
                            else if (versionParts != null && versionParts[0].ToLower() == "loop")
                                cm.ComponentLoop.Add(versionParts[1]);
                            else if (versionParts != null && versionParts[0].ToLower() == "analog loop")
                                cm.ComponentAnalogLoop.Add(versionParts[1]);
                            else if (versionParts != null && versionParts[0].ToLower() == "digital loop")
                                cm.ComponentDigitalLoop.Add(versionParts[1]);
                            else if (versionParts != null)
                                ComponentTemplateLoaderLog?.Invoke("Erroneous Template Entry: " +
                                                                   versionParts[0].ToLower() + "=" +
                                                                   versionParts[1]);
                        }
                        cmList.Add(cm);
                    }
                    sr?.Close();
                    fs?.Close();
                }
                catch (Exception ex)
                {
                    OnLog(ex.Message);
                    sr?.Close();
                    fs?.Close();
                }
                finally
                {
                    sr?.Close();
                    fs?.Close();
                }
            }
            return cmList;
        }

        private static string GetImagePath(string file, string option)
        {
            var result = string.Empty;

            switch (option.ToLowerInvariant())
            {
                case "analog":
                    result = file.Replace(file.Split('\\')[file.Split('\\').Length - 1], "analog");
                    break;
                case "digital":
                    result = file.Replace(file.Split('\\')[file.Split('\\').Length - 1], "digital");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(option), option, null);
            }


            return result;
        }

        private static string GetIconPath(string file)
        {
            return file.ToLowerInvariant().Replace(".icl", ".png");
        }

        private void OnLog(string message)
        {
            ComponentTemplateLoaderLog?.Invoke(message);
        }
    }
}
