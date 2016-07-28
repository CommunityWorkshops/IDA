using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Controllers.IO
{
    class PathsGenerator
    {
        internal static string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //TODO: Horrible and messy do it again
        internal static string CreateBasePath(string name)
        {
            DirectoryInfo di = null;

            if (!Directory.Exists(Path.Combine(MyDocuments, "IDA")))
            {
                 di = Directory.CreateDirectory(Path.Combine(MyDocuments, "IDA"));
            }

            if (!Directory.Exists(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects")))
            {
                di = Directory.CreateDirectory(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects"));
            }

            // Now create the actual Project directory
            name = name.Replace(".", "_").Replace(" ", "_");
            if(!Directory.Exists(Path.Combine(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects"), name)))
            {
                di = Directory.CreateDirectory(Path.Combine(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects"), name));
            }

            IDA.Models.CurrentProjectModel.ProjectBasePath = Path.Combine(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects"), name);

            // Now Create the Temporary Build Folder for the project
            if (!Directory.Exists(Path.Combine(Path.Combine(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects"), name), "Build")))
            {
                Directory.CreateDirectory(Path.Combine(Path.Combine(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects"), name), "Build"));
            }

            IDA.Models.CurrentProjectModel.ProjectBuildPath = Path.Combine(Path.Combine(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects"), name), "Build");

            return Path.Combine(Path.Combine(Path.Combine(MyDocuments, "IDA"), "Projects"), name);
        }
    }
}
