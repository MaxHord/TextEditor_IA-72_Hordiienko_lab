using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TextEditor.observer
{
    public class FileStatusDelegate : IDisposable
    {
        private readonly Action<string> subscriber;
        private readonly System.Timers.Timer timer;
        private readonly Monitoring monitoring;

        public FileStatusDelegate(string directory, Action<string> subscriber)
        {
            this.subscriber = subscriber;
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
                subscriber(fileName);
            }
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
