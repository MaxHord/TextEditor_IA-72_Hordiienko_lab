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
    public class WorkWithFile : AbstractWork
    {
        public Type type = new Type();
        public string fileName;
        public string dir;
        public FastColoredTextBox contextFile = new FastColoredTextBox();
        public void OpenDlg()
        {
            //create new open file dialog
            OpenFileDialog of = new OpenFileDialog();
            //open file dialog files extension filter
            of.Filter = "Text File|*.txt|JS File|*.js|HTML File|*.html|Csharp File|*.cs*|SQL File|*.sql*|Any File|*.*";
            //if after showing dialog, clicked ok
            if (of.ShowDialog() == DialogResult.OK)
            {
                //open file
                StreamReader sr = new StreamReader(of.FileName);

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
                else if(Path.GetExtension(of.FileName) == ".html")
                {
                    type.TypeSyn = new HTMLType();
                    contextFile.Language = type.LanguageType();
                }
                else if (Path.GetExtension(of.FileName) == ".php")
                {
                    type.TypeSyn = new PHPType();
                    contextFile.Language = type.LanguageType();
                }
                else if (Path.GetExtension(of.FileName) == ".sql")
                {
                    type.TypeSyn = new SQLType();
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
                dir = of.FileName.Remove(of.FileName.IndexOf(of.SafeFileName));
            }
            
        }
        public override void SaveDlg(/*FastColoredTextBox _contextFile*/)
        {
            //this.contextFile = _contextFile;
            //new save file dialog
            SaveFileDialog sf = new SaveFileDialog();
            //filter
            sf.Filter = "Text File|*.txt|JS File|*.js|HTML File|*.html|Csharp File|*.cs*|SQL File|*.sql*|Any File|*.*";
            //if after showing dialog, user clicked ok
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sf.FileName);
                sr.Write(contextFile.Text);
                fileName = sf.FileName;
                sr.Close();
                OpenDlgName();
            }
        }

        public override void OpenDlgName()
        {

                //open file
                StreamReader sr = new StreamReader(fileName);

                if (Path.GetExtension(fileName) == ".js")
                {
                    type.TypeSyn = new JsType();
                    contextFile.Language = type.LanguageType();
                }
                else if (Path.GetExtension(fileName) == ".cs")
                {
                    type.TypeSyn = new Csharp();
                    contextFile.Language = type.LanguageType();
                }
                else if (Path.GetExtension(fileName) == ".html")
                {
                    type.TypeSyn = new HTMLType();
                    contextFile.Language = type.LanguageType();
                }
                else if (Path.GetExtension(fileName) == ".php")
                {
                    type.TypeSyn = new PHPType();
                    contextFile.Language = type.LanguageType();
                }
                else if (Path.GetExtension(fileName) == ".sql")
                {
                    type.TypeSyn = new SQLType();
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
        }
    }
}
