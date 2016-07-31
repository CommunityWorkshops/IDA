using System;
using System.Collections.Generic;
using System.Drawing;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace IDA.Forms.Dockable
{
    public partial class FrmCodeEditor : DockContent
    {

        public delegate void EditorDirtyHandler(string name);
        public event EditorDirtyHandler EditorDirty;

        public delegate void EditorCleanHandler(string name);
        public event EditorCleanHandler EditorClean;

        public FrmCodeEditor()
        {
            InitializeComponent();
            Initialise();
        }

        public FrmCodeEditor(string name)
        {
            InitializeComponent();
            Name = name;
            Initialise();
        }

        private void Initialise()
        {
            editor.Tag = Name;

            editor.BeforeInsert += Scintilla1_BeforeInsert;
            editor.BeforeDelete += Scintilla1_BeforeDelete;
            editor.CharAdded += Scintilla1_CharAdded;
            editor.Insert += Scintilla1_Insert;
            editor.SavePointLeft += Editor_SavePointLeft;
            editor.SavePointReached += Editor_SavePointReached;


            editor.StyleResetDefault();
            editor.Styles[Style.Default].Font = "Consolas";
            editor.Styles[Style.Default].Size = 10;
            editor.Styles[Style.Default].BackColor = Color.MidnightBlue;
            editor.Styles[Style.Cpp.Default].ForeColor = Color.Yellow;
            editor.StyleClearAll();

            editor.Lexer = Lexer.Cpp;

            // Configure the CPP (.C) lexer styles

            editor.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            editor.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            editor.Styles[Style.Cpp.CommentLine].Italic = true; // Italic
            editor.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            editor.Styles[Style.Cpp.Number].ForeColor = Color.Yellow;
            editor.Styles[Style.Cpp.Word].ForeColor = Color.LightBlue;
            editor.Styles[Style.Cpp.Word2].ForeColor = Color.AliceBlue;
            editor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            editor.Styles[Style.Cpp.Operator].ForeColor = Color.Azure;
            editor.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;

            // Set the keywords
            editor.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
            editor.SetKeywords(1, "setup loop");


        }



        public void Save()
        {
            FileStream fs = null;

            if (File.Exists(Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath, Tag.ToString() + ".c")))
                fs = new FileStream(Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath, Tag.ToString() + ".c"), FileMode.Truncate, FileAccess.Write, FileShare.None);
            else
                fs = new FileStream(Path.Combine(IDA.Models.CurrentProjectModel.ProjectBasePath, Tag.ToString() + ".c"), FileMode.Create, FileAccess.Write, FileShare.None);

            StreamWriter sw = new StreamWriter(fs);

            foreach (Line line in editor.Lines)
            {
                sw.WriteLine(line.Text);
            }

            sw.Close();
            fs.Close();

            editor.SetSavePoint();
        }

        private void Editor_SavePointLeft(object sender, EventArgs e)
        {
            EditorDirty?.Invoke(Tag.ToString());

        }

        private void Editor_SavePointReached(object sender, EventArgs e)
        {
            EditorClean?.Invoke(Tag.ToString());
        }

        public void GotoLine(int lineNumber)
        {
            
        }

        private void Scintilla1_Insert(object sender, ModificationEventArgs e)
        {

        }

        private void Scintilla1_CharAdded(object sender, CharAddedEventArgs e)
        {

        }

        private void Scintilla1_BeforeDelete(object sender, BeforeModificationEventArgs e)
        {

        }

        private void Scintilla1_BeforeInsert(object sender, BeforeModificationEventArgs e)
        {

        }

        public void AddLicenceHeader(List<string> licence)
        {
            if (licence == null) return;

            foreach (var line in licence)
            {
                editor.AddText(line + Environment.NewLine);
            }
        }


        internal void AddPlatformCode(List<string> code)
        {
            if (code == null) return;

            editor.AddText(Environment.NewLine);
            editor.AddText(Environment.NewLine);

            foreach (var line in code)
            {
                editor.AddText(line + Environment.NewLine);
            }


        }


        private void editor_TextChanged(object sender, EventArgs e)
        {
            UpdateLineNumbersColumn();
        }

        private int maxLineNumberCharLength;
        private void UpdateLineNumbersColumn()
        {
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = editor.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            editor.Margins[0].Width = editor.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;
        }
    }
}
