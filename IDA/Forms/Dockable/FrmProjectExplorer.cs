using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Furty.Windows.Forms;
using IDA.Models;
using System.IO;

namespace IDA.Forms.Dockable
{
    public partial class FrmProjectExplorer : DockContent
    {

        public delegate void LogHandler(string message);
        public event LogHandler ProjectExplorerLog;
        public delegate void OpenDocumentHandler(string path);
        public event OpenDocumentHandler ProjectExplorerOpenDocument;

        public void Log(string message)
        {
            ProjectExplorerLog?.Invoke(message);
        }

        public FrmProjectExplorer()
        {
            InitializeComponent();
        }

        internal void LoadProject(string projectBasePath)
        {
            Log("Loading Explorer");
            ProjectWatcher.IncludeSubdirectories = true;
            ProjectWatcher.EnableRaisingEvents = true;

            ProjectWatcher.Path = projectBasePath;
            ProjectWatcher.Changed += ProjectWatcher_Changed;
            ProjectWatcher.Created += ProjectWatcher_Created;
            ProjectWatcher.Deleted += ProjectWatcher_Deleted;
            ProjectWatcher.Error += ProjectWatcher_Error;

            ProjectWatcher.Filter = "*";

            projectView.Nodes.Clear();
            PopulateTree();

        }

        private void ProjectWatcher_Error(object sender, ErrorEventArgs e)
        {
            Log("Error: " + e.GetException().Message.ToString());
        }

        private void ProjectWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Log("Deleted " + e.FullPath);
        }

        private void ProjectWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Log("Created " + e.FullPath);
        }

        private void ProjectWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Log("Changed " + e.FullPath);
        }

        private void PopulateTree()
        {
            projectView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(CurrentProjectModel.ProjectBasePath);
            projectView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
            projectView.AfterLabelEdit += ProjectView_AfterLabelEdit;
            projectView.AfterSelect += ProjectView_AfterSelect;
            projectView.Click += ProjectView_Click;
            projectView.DoubleClick += ProjectView_DoubleClick;
            projectView.LineColor = Color.Blue;
            projectView.NodeMouseClick += ProjectView_NodeMouseClick;
            projectView.NodeMouseDoubleClick += ProjectView_NodeMouseDoubleClick;
            projectView.NodeMouseHover += ProjectView_NodeMouseHover;

            projectView.ExpandAll();
        }

        private void ProjectView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            Log("Hover " + e.Node.Tag);
        }

        private void ProjectView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Log("Opening File " + e.Node.Tag);
            ProjectExplorerOpenDocument?.Invoke(e.Node.Tag.ToString());
        }

        private void ProjectView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Log("Click " + e.Node.Tag); ;
        }

        private void ProjectView_DoubleClick(object sender, EventArgs e)
        {
            Log("Project View Double Click");
        }

        private void ProjectView_Click(object sender, EventArgs e)
        {
            Log("Project View Click");
        }

        private void ProjectView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Log("After Select " + e.Node.Tag);
        }

        /// <summary>
        /// Allows the user to change the files name from the explorer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            Log("After Label Edit " + e.Node.Tag);
            // Warn about changing extension
            // Cancel change if required

            var newname = e.Label;
            // Tell Main to 
            // Change file name on File system
            // If Document Change Project configuration
            // Change appropriate tags


        }


        private static bool firstRun = true; // Must be Project Folder
        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {


            var tNode = new TreeNode(directoryInfo.Name);
            tNode.Tag = directoryInfo.FullName;
            if (firstRun)
            {
                firstRun = false;
                tNode.ImageKey = "ProjectImage";
            }
            else
                tNode.ImageKey = "FolderImage";

            var directoryNode = tNode;
            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }
            foreach (var file in directoryInfo.GetFiles())
            {
                var nNode = new TreeNode(file.Name);
                nNode.Tag = file.FullName;

                if (file.FullName.ToLowerInvariant().EndsWith(".ida"))
                    nNode.ImageKey = "IdaImage";

                else
                    nNode.ImageKey = "TxtImage";
                directoryNode.Nodes.Add(nNode);
            }
            return directoryNode;
        }
    }
}
