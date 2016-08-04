using System;
using System.Collections.Generic;
using System.IO;

namespace IDA.Controllers.IO
{
    internal class LoadSourceFile
    {
        private string projSourceName;

        public LoadSourceFile(string projSourceName)
        {
            this.projSourceName = projSourceName;
        }

        internal List<string> LoadSource()
        {
            List<string> lines = new List<string>();
            FileStream fs = new FileStream(projSourceName, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(fs);

            while(!sr.EndOfStream)
            {
               lines.Add(sr.ReadLine());
            }

            sr.Close();
            fs.Close();

            return lines;
        }
    }
}