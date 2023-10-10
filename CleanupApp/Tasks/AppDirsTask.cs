using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanupApp.TaskHelpers;

namespace CleanupApp.Tasks
{
    public class AppDirsTask : Models.CleaningTask
    {
        public AppDirsTask()
        {
            this.Name = "Clear program-specific directories";
            this.Codename = "app-dirs";
            this.Action = RemoveAppDirectories;
        }

        private void RemoveAppDirectories()
        {
            DirHelpers.RemoveDir(DirPrefix.UserProfile, @"VirtualBox VMs");
            DirHelpers.RemoveDir(DirPrefix.DriveRoot, @"Autodesk");
            DirHelpers.RemoveDir(DirPrefix.DriveRoot, @"Windows\winscp");
            DirHelpers.RemoveDir(DirPrefix.DriveRoot, @"ESD");
            DirHelpers.RemoveDir(DirPrefix.DriveRoot, @"WCH.CN");
            DirHelpers.RemoveDir(DirPrefix.DriveRoot, @"Users\Public\Downloads");
        }
    }
}
