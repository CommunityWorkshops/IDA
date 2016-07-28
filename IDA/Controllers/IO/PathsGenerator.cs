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

        internal static string CreateBasePath(string name)
        {
            DirectoryInfo di = null;

            if (!Directory.Exists(Path.Combine(MyDocuments, "IDA")))
            {
                 di = Directory.CreateDirectory(Path.Combine(MyDocuments, "IDA"));
            }

            if (!Directory.Exists(Path.Combine(di.FullName,"Projects")))
            {
                di = Directory.CreateDirectory(Path.Combine(di.FullName, "Projects"));
            }

            // Now create the actual Project directory
            name = name.Replace(".", "_").Replace(" ", "_");
            if(!Directory.Exists(Path.Combine(di.FullName,name)))
            {
                di = Directory.CreateDirectory(Path.Combine(di.FullName, name));
            }

            // Now Create the Temporary Build Folder for the project
            if (!Directory.Exists(Path.Combine(di.FullName, "Build")))
            {
                Directory.CreateDirectory(Path.Combine(di.FullName, "Build"));
            }



            return di.FullName;
        }
    }
}
