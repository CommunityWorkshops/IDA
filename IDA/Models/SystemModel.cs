using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Models
{
    static class SystemModel
    {

        public static string IDAVersion = GetVersion();
        internal static string ProjectsPath = @"C:\Users\Dave Gordon\Documents\IDA\Projects";

        private static string GetVersion()
        {
            return typeof(FrmMain).Assembly.GetName().Version.ToString();
        }
    }
}
