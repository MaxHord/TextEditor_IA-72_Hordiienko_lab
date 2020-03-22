using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public static class WorkWithFile
    {

        public static Type type = new Type();
        public static string fileName;
        public static FastColoredTextBox contextFile = new FastColoredTextBox();
        public static void OpenDlg()
        {
            //create new open file dialog
            OpenFileDialog of = new OpenFileDialog();
            //open file dialog files extension filter
            of.Filter = "Text File|*.txt|JS File|*.js|HTML File|*.html|Any File|*.*";
            //if after showing dialog, clicked ok
            if (of.ShowDialog() == DialogResult.OK)
            {
                //open file
                StreamReader sr = new StreamReader(of.FileName);
                //if (Path.GetExtension(of.FileName) == ".js")
                //{
                //    contextFile.Language = Language.JS;
                //}
                //else if (Path.GetExtension(of.FileName) == ".cs")
                //{
                //    contextFile.Language = Language.CSharp;
                //}
                //else
                //{
                //    contextFile.Language = Language.Custom;
                //}
                if (Path.GetExtension(of.FileName) == ".js")
                {
                    type.TypeSyn = new JsType();
                    contextFile.Language = type.LanguageType();
                }
                else if (Path.GetExtension(of.FileName) == ".cs")
                {
                    type.TypeSyn = new Csharp();
                    contextFile.Language = type.LanguageType();
                }
                else
                {
                    contextFile.Language = Language.Custom;
                }
                //place file text to text box
                contextFile.Text = sr.ReadToEnd();
                //close
                sr.Close();
                fileName = of.FileName;
            }
            
        }
    }
}
