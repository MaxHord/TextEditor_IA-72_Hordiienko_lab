using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.observer
{
    public class Monitoring
    {
        private List<string> files = new List<string>();
        private readonly string directory;

        public Monitoring(string directory)
        {
            this.directory = directory;
        }

        public bool StartMonitoring()
        {
            if (!Directory.Exists(directory))
            {
                return false;
            }
            var directoryInfo = new DirectoryInfo(directory);
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                this.files.Add(fileInfo.FullName);
            }

            return true;
        }

        public List<string> DeletedFiles()
        {
            var result = new List<string>();

            foreach(var file in files.ToArray())
            {
                if (!File.Exists(file))
                {
                    files.Remove(file);
                    result.Add(file);
                }
            }

            return result;
        }
    }
}
