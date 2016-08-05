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

        public ComponentModel LoadComponents()
        {
            ComponentModel cm = new Models.ComponentModel();
            var platformPath = @"templates\platforms\" + CurrentProjectModel.Platform + @"\components\";
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                var componentBasePath = Path.Combine(platformPath, "InternalComponents.txt");
                fs = new FileStream(componentBasePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                sr = new StreamReader(fs);

                while(!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if(!line.StartsWith(@"//") && line.Contains("="))
                    {
                        string[] lineParts = line.Split('=');
                        switch (lineParts[0].ToLower())
                        {
                            case "version":
                                if(lineParts[1].ToLower() == CurrentProjectModel.Version.ToLower())
                                {
                                    var versionLine = sr.ReadLine();
                                    string[] versionParts = versionLine.Split(':');
                                    switch (versionParts[0].ToLower())
                                    {
                                        case "name":
                                            cm.componentName = versionParts[1].ToString();
                                            break;
                                        case "description":
                                            cm.componentDescription = versionParts[1].ToString();
                                            break;
                                        case "options":
                                            string[] options = versionParts[1].Split(',');
                                            foreach(string option in options)
                                            {
                                                if (option.ToLower() == "analog")
                                                    cm.componentOptions.Add(ComponentModel.Options.Analog);
                                                if (option.ToLower() == "digital")
                                                    cm.componentOptions.Add(ComponentModel.Options.Digital);
                                            }
                                            break;
                                        case "icon":
                                            // generate full path to the icon
                                            var iconPath = Path.Combine(componentBasePath, @"images\internal\icons\" + versionParts[1]);
                                            cm.componentIcon = Image.FromFile(iconPath);
                                            break;
                                        case "images":
                                            var imagePath = Path.Combine(componentBasePath, @"images\internal\" + versionParts[1]);
                                            cm.componentSchematic = Image.FromFile(Path.Combine(imagePath, "schematic.png"));
                                            cm.componentLayout = Image.FromFile(Path.Combine(imagePath, "layout.png"));
                                            break;
                                        case "global":
                                            cm.componentGlobal.Add(versionParts[1]);
                                            break;
                                        case "analog global":
                                            cm.componentAnalogGlobal.Add(versionParts[1]);
                                            break;
                                        case "digital global":
                                            cm.componentDigitalGlobal.Add(versionParts[1]);
                                            break;
                                        case "setup":
                                            cm.componentSetup.Add(versionParts[1]);
                                            break;
                                        case "analog setup":
                                            cm.componentAnalogSetup.Add(versionParts[1]);
                                            break;
                                        case "digital setup":
                                            cm.componentDigitalSetup.Add(versionParts[1]);
                                            break;
                                        case "loop":
                                            cm.componentLoop.Add(versionParts[1]);
                                            break;
                                        case "analog loop":
                                            cm.componentAnalogLoop.Add(versionParts[1]);
                                            break;
                                        case "digital loop":
                                            cm.componentDigitalLoop.Add(versionParts[1]);
                                            break;
                                        default:
                                            //Ignore everything else for now
                                            break;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
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


            return cm;
        }

        private void OnLog(string message)
        {
            ComponentTemplateLoaderLog?.Invoke(message);
        }
    }
}
