using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace IDA.Forms.Dockable
{
    public partial class FrmCodeEditor : DockContent
    {
        public FrmCodeEditor()
        {
            InitializeComponent();

            editor.BeforeInsert += Scintilla1_BeforeInsert;
            editor.BeforeDelete += Scintilla1_BeforeDelete;
            editor.CharAdded += Scintilla1_CharAdded;
            editor.Insert += Scintilla1_Insert;

            

            editor.StyleResetDefault();
            editor.Styles[Style.Default].Font = "Consolas";
            editor.Styles[Style.Default].Size = 10;
            editor.Styles[Style.Default].BackColor = Color.MidnightBlue;
            editor.StyleClearAll();
            
            editor.Lexer = Lexer.Cpp;
            
            // Configure the CPP (C#) lexer styles
            editor.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            editor.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            editor.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            editor.Styles[Style.Cpp.CommentLine].Italic = true; // Italic
            editor.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            editor.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            editor.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            editor.Styles[Style.Cpp.Word2].ForeColor = Color.BlueViolet;
            editor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            editor.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            editor.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;

            // Set the keywords
            editor.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
            editor.SetKeywords(1, "setup loop");
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
    }
}
