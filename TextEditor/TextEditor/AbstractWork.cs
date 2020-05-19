using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public abstract class AbstractWork
    {
        public abstract void SaveDlg();
        public abstract void OpenDlgName();

        public void Algoritm()
        {
            SaveDlg();
            OpenDlgName();
        }
    }
}
