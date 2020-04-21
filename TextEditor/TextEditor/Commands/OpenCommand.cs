using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Commands
{
    public class OpenCommand : ICommand
    {
        WorkWithFile workFile = null;

        public OpenCommand(WorkWithFile work)
        {
            this.workFile = work;
        }

        public void Execute()
        {
            workFile.OpenDlg();
        }
    }
}
