using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CleanupApp.Models;

namespace CleanupApp.Tasks
{
    public class WinClearRecentFilesTask : CleaningTask
    {
        public WinClearRecentFilesTask()
        {
            Name = "Clear recent files";
            Codename = "recent-files";
            Action = ClearRecentFiles;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern void SHAddToRecentDocs(uint flags, string? path);

        public static void ClearRecentFiles() => SHAddToRecentDocs(1, null);
    }
}
