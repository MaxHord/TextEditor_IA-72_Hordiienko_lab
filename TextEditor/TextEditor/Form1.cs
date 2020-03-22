using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remove all text from text box
            fastColoredTextBox1.Text = "";
        }
        //private void OpenDlg()
        //{
        //    //create new open file dialog
        //    OpenFileDialog of = new OpenFileDialog();
        //    //open file dialog files extension filter
        //    of.Filter = "Text File|*.txt|JS File|*.js|HTML File|*.html|Any File|*.*";

        //    //if after showing dialog, clicked ok
        //    if (of.ShowDialog() == DialogResult.OK)
        //    {
        //        //open file
        //        StreamReader sr = new StreamReader(of.FileName);
        //        if (Path.GetExtension(of.FileName) == ".js")
        //        {
        //            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
        //        }
        //        else if (Path.GetExtension(of.FileName) == ".cs")
        //        {
        //            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        //        }
        //        else
        //        {
        //            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
        //        }
        //        //place file text to text box
        //        fastColoredTextBox1.Text = sr.ReadToEnd();
        //        //close
        //        sr.Close();
        //        //text of this window = path of cirrently opened file
        //        this.Text = of.FileName;
        //    }
        //}

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkWithFile.OpenDlg();
            fastColoredTextBox1.Language = WorkWithFile.contextFile.Language;
            fastColoredTextBox1.Text = WorkWithFile.contextFile.Text;
            this.Text = WorkWithFile.fileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //save file
                StreamWriter sw = new StreamWriter(this.Text);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
            catch { /*OpenDlg();*/ }
           
        }

        //save file method
        private void SaveDlg()
        {
            //new save file dialog
            SaveFileDialog sf = new SaveFileDialog();
            //filter
            sf.Filter = "Text File|*.txt|JS File|*.js|HTML File|*.html|Any File|*.*";
            //if after showing dialog, user clicked ok
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sf.FileName);
                sr.Write(fastColoredTextBox1.Text);
                sr.Close();
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDlg();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new color choosing dialog
            ColorDialog cd = new ColorDialog();
            //if after showing dialog, user clicked ok
            if (cd.ShowDialog() == DialogResult.OK)
            {
                //set background color to text box
                fastColoredTextBox1.BackColor = cd.Color;
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new color choosing dialog
            ColorDialog cd = new ColorDialog();
            //if after showing dialog, user clicked ok
            if (cd.ShowDialog() == DialogResult.OK)
            {
                //set text color to text box
                fastColoredTextBox1.ForeColor = cd.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new font choosing dialog
            FontDialog fd = new FontDialog();
            //if after showing dialog, user clicked ok
            if (fd.ShowDialog() == DialogResult.OK)
            {
                //set font to text box
                fastColoredTextBox1.Font = fd.Font;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.SelectAll();

        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowGoToDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }
    }
}
