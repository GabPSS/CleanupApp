using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp.Models
{
    public abstract class CleaningTask
    {
        public string Name { get; set; } = "Untitled Task";
        public Action? Action { get; set; }

        public void Run()
        {
            Console.WriteLine("Started task \"" + Name + "\"");
            Action?.Invoke();
            Console.WriteLine("Done");
        }
    }
}
