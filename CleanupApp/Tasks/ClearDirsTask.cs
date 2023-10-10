using CleanupApp.TaskHelpers;

namespace CleanupApp.Tasks
{
    internal class ClearDirsTask : Models.CleaningTask
    {
        private static List<string> windirs = new()
        {
            @"Downloads",
            @"Pictures",
            @"Music",
            @"Videos"
        };

        private static List<string> appdirs = new()
        {
            @"OneDrive",
            @"source",
            @"AppData\Local\Roblox",
            @"AppData\Local\Temp"
        };

        public ClearDirsTask()
        {
            Name = "Clear common directories";
            Codename = "common-dirs";
            Action = ClearDirectories;
        }

        private void ClearDirectories()
        {
            windirs.ForEach((value) => DirHelpers.RemoveDir(DirPrefix.UserProfile, value, true));
            appdirs.ForEach((value) => DirHelpers.RemoveDir(DirPrefix.UserProfile, value));
        }
    }
}
