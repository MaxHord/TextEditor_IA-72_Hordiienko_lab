using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.observer
{
    public class Subscriber
    {
        private readonly string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void ItIsSubscriber(string fileName)
        {
            MessageBox.Show($"{name} {fileName} был удален");
        }
    }
 }
