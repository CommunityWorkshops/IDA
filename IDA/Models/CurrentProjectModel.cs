using System;

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

        public static string ProjectBasePath { get; set; }
        public static string ProjectBuildPath { get; set; }
        public static string ProjectConfigurationPath { get; internal set; }


        /// <summary>
        /// Reset all settings for the current project prior to opening a new project.
        /// Leave ComPort set as that will probably not be changing.
        /// </summary>
        internal static void Reset()
        {
            Platform = string.Empty;
            Version = string.Empty;
            Name = string.Empty;
            IsLibrary = false;
            IsOpenSource = false;
            MajorVersion = 0;
            MajorBuild = 0;
            MinorVersion = 0;
            MinorBuild = 0;
            ProjectBasePath = string.Empty;
            ProjectBuildPath = string.Empty;
        }
    }
}
