using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TextEditor.observer
{
    //Поставщик событий
    public class FileStatusEventObservable : IObservable<string>, IDisposable
    {
        private readonly List<IObserver<string>> observers;
        private readonly System.Timers.Timer timer;
         
        private readonly Monitoring monitoring;

        public FileStatusEventObservable(string directory)
        {
            observers = new List<IObserver<string>>();
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
                foreach (var observer in observers)
                {
                    observer.OnNext(fileName);
                }
            }
        }

        public void Dispose()
        {
            timer.Dispose();
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscribe(observers, observer);
        }
    }
    public class Unsubscribe : IDisposable
    {
        private readonly List<IObserver<string>> _observers;
        private readonly IObserver<string> _observer;

        public Unsubscribe(List<IObserver<string>> observers, IObserver<string> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if(_observer!=null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
