using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Commands
{
    public class SaveCommand : ICommand
    {
        WorkWithFile workFile = null;

        public SaveCommand(WorkWithFile work)
        {
            this.workFile = work;
        }

        public void Execute()
        {
            workFile.SaveDlg();
        }
    }
}
