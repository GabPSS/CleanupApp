using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanupApp.Models;
using CleanupApp.TaskHelpers;

namespace CleanupApp.Tasks
{
    public class RemoveBrowsingDataTask : CleaningTask
    {
        public RemoveBrowsingDataTask()
        {
            Name = "Remove browsing data";
            Codename = "browser-data";
            Action = RemoveBrowserData;
        }

        public static void RemoveBrowserData()
        {
            DirHelpers.RemoveDir(Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Google\Chrome\User Data", true);
            DirHelpers.RemoveDir(Environment.GetEnvironmentVariable("LOCALAPPDATA") + @"\Microsoft\Edge\User Data", true);
        }
    }
}
