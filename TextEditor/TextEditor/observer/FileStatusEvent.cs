using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TextEditor.observer
{
    public class FileStatusEvent : IDisposable
    {
        public  EventHandler<string> RemoveFiles;
        private readonly System.Timers.Timer timer;
        private readonly Monitoring monitoring;

        public FileStatusEvent(string directory)
        {
            monitoring = new Monitoring(directory);

            if (monitoring.StartMonitoring())
            {
                timer = new System.Timers.Timer(1000);
                timer.Elapsed += CheckRemoval;
                timer.Start();
            }
            else
            {
                MessageBox.Show("нет");
                Dispose();
            }
        }

        private void CheckRemoval(Object source, EventArgs e)
        {
            foreach (var fileName in monitoring.DeletedFiles())
            {
                var handler = RemoveFiles;
                handler?.Invoke(this, fileName);
            }
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
