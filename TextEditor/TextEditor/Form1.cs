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
using TextEditor.Commands;
using TextEditor.observer;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public static WorkWithFile work = new WorkWithFile();
        public static OpenCommand openCommand = new OpenCommand(work);
        public static ICommand command = new SaveCommand(work);
        public static Invoker invoker = new Invoker();
        public static string directory = @"C:\Users\Max\Desktop\trpz";
        public FileStatusDelegate fileStatusDelegate = new FileStatusDelegate(directory, new Subscriber(String.Empty).ItIsSubscriber);

        public Form1()
        {
            InitializeComponent();
        }
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remove all text from text box
            fastColoredTextBox1.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Command
            openCommand.Execute();
            fastColoredTextBox1.Language = work.contextFile.Language;
            fastColoredTextBox1.Text = work.contextFile.Text;
            this.Text = work.fileName;
            directory = work.dir;
            fileStatusDelegate = new FileStatusDelegate(directory, new Subscriber(String.Empty).ItIsSubscriber);
            MessageBox.Show($"{directory}");
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
            catch { /*saveCommand.Execute();*/ invoker.StoreCommand(command);
                invoker.ExecuteCommand();
            }
           
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            work.contextFile.Text = fastColoredTextBox1.Text;
            work.fileName = this.Text;
            //Command
            //saveCommand.Execute();
            invoker.StoreCommand(command);
            invoker.ExecuteCommand();

            fastColoredTextBox1.Text = work.contextFile.Text;
            this.Text = work.fileName;
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
