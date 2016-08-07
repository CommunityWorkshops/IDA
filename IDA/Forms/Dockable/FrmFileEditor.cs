using System;
using System.Collections.Generic;
using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using IDA.Controls;
using IDA.Models;

namespace IDA.Forms.Dockable
{
    public partial class FrmFileEditor : DockContent
    {
        public delegate void LogHandler(string message);
        public event LogHandler FrmFileEditorLog;

        public delegate void EditorDirtyHandler(string name);
        public event EditorDirtyHandler EditorDirty;

        public delegate void EditorCleanHandler(string name);
        public event EditorCleanHandler EditorClean;

        public FrmFileEditor()
        {
            InitializeComponent();
            Name = CurrentProjectModel.Name;
            Tag = Name;
            Initialise();
        }

        public FrmFileEditor(string name)
        {
            InitializeComponent();
            Name = name;
            Initialise();
        }

        private void Initialise()
        {
            editor.Tag = Name;
            editor.AllowInsertRemoveLines = true;
            editor.AllowDrop = true;
            editor.AutoCompleteBrackets = true;
            editor.AutoCompleteBracketsList = new[] {'{', '}', '[', ']', '(', ')'};
            editor.AcceptsReturn = true;
            editor.AcceptsTab = true;
            editor.AllowSeveralTextStyleDrawing = true;
            editor.AutoIndent = true;
            editor.AllowMacroRecording = true;
            editor.AutoIndentChars = true;
            editor.AutoIndentExistingLines = true;
            editor.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy1;
            editor.CaretBlinking = true;
            editor.CaretColor = Color.BlueViolet;
            editor.CaretVisible = true;
            // editor.FoldedBlockStyle = new FoldedBlockStyle();
            editor.ShowLineNumbers = true;
            editor.HighlightFoldingIndicator = true;
            editor.Language = Language.CSharp;
            editor.LeftPadding = 10;
            editor.WordWrap = true;
            editor.WordWrapAutoIndent = true;
            editor.WordWrapMode = WordWrapMode.WordWrapControlWidth;
            
        }

       

        public void Save()
        {
            var fPath = Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath, Tag.ToString() + ".c");

            if (File.Exists((fPath)))
            {
                editor.SaveToFile(fPath, Encoding.ASCII);
            }
        }

        

        public void AddLicenceHeader(List<string> licence)
        {
            if (licence == null) return;

            foreach (var line in licence)
            {
                editor.InsertText(line + Environment.NewLine);
            }
        }

        internal void AddPlatformCode(List<string> code)
        {
            if (code == null) return;

            editor.InsertText(Environment.NewLine);
            editor.InsertText(Environment.NewLine);

            foreach (var line in code)
            {
                editor.InsertText(line + Environment.NewLine);
            }          
        }


       

        internal void OpenProjectMain(string projectBasePath)
        {
            var projSourceName = projectBasePath.Split('\\')[projectBasePath.Split('\\').Length - 1];
            var sourceLocation = Path.Combine(projectBasePath, projSourceName + ".c");

            var lsf = new Controllers.IO.LoadSourceFile(sourceLocation);

            var lines = lsf.LoadSource();
            var firstBlank = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line) && firstBlank)
                {
                    // Ignore extra lines.
                    firstBlank = false;
                }
                else
                {
                    firstBlank = true;
                    editor.InsertText(line + Environment.NewLine);
                }
            }
        }

        internal void Open(string name)
        {

            var lsf = new Controllers.IO.LoadSourceFile(name);

            var lines = lsf.LoadSource();
            var firstBlank = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line) && firstBlank)
                {
                    // Ignore extra lines.
                    firstBlank = false;
                }
                else
                {
                    firstBlank = true;
                    editor.InsertText(line + Environment.NewLine);
                }
            }
        }

        private void editor_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ComponentSelectionControl)))
            {
                ComponentSelectionControl csc = (ComponentSelectionControl)e.Data.GetData("IDA.Controls.ComponentSelectionControl");
                ComponentModel cm = csc.Tag as ComponentModel;
                e.Effect = DragDropEffects.Copy;
                if (cm != null) Log("Description " + cm.ComponentDescription);
            }
            else
                Log("Component Model Data is NOT Present");
        }

        private void Log(string message)
        {
            FrmFileEditorLog?.Invoke(message);
        }

        

        private void editor_DragDrop(object sender, DragEventArgs e)
        {
            //ComponentModel p = sender as ComponentModel;
            //Log("Received " + p.ComponentDescription);

        }

        private void editor_Click(object sender, EventArgs e)
        {
            UpdateStats();
        }

        private void editor_KeyUp(object sender, KeyEventArgs e)
        {
           UpdateStats();
        }

        private void UpdateStats()
        {
            lblTotalLines.Text = editor.Lines.Count.ToString("N0");
            lblPosition.Text = "N/A";


        }
    }
}
