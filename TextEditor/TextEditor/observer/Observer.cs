using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.observer
{
    //наблюдатель подписчика за событиями
    public class Observer : IObserver<string>
    {
        private IDisposable unsub;
        public virtual void Subscribe(IObservable<string> provider)
        {
            if (provider != null)
            {
                unsub = provider.Subscribe(this);
            }
        }
        //Завершение подписки
        public void OnCompleted()
        {
            Unsubscribe();
        }

        public void OnError(Exception error)
        {
            MessageBox.Show("An error was occured: "+error.Message);
        }

        public void OnNext(string value)
        {
            MessageBox.Show($"{value} file was deleted");
        }

        public virtual void Unsubscribe()
        {
            unsub.Dispose();  
        }
    }
}
