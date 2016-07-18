using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Models
{
    internal static class CurrentProjectModel
    {

        public static string Platform { get; set; }
        public static string Version { get; set; }
        public static string Name { get; set; }
        public static bool IsLibrary { get; set; }
        public static bool IsOpenSource { get; set; }
        public static int MajorVersion { get; set; }
        public static int MinorVersion { get; set; }
        public static int MajorBuild { get; set; }
        public static int MinorBuild { get; set; }
        public static string ComPort { get; internal set; }
    }
}
