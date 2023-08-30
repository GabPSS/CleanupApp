using CleanupApp.TaskHelpers;

namespace CleanupApp.Tasks
{
    internal class ClearDirsTask : Models.CleaningTask
    {
        private static List<string> windirs = new()
        {
            Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads",
            Environment.GetEnvironmentVariable("USERPROFILE") + @"\Pictures",
            Environment.GetEnvironmentVariable("USERPROFILE") + @"\Music",
            Environment.GetEnvironmentVariable("USERPROFILE") + @"\Videos"
        };

        private static List<string> appdirs = new()
        {
            Environment.GetEnvironmentVariable("USERPROFILE") + @"\OneDrive",
            Environment.GetEnvironmentVariable("USERPROFILE") + @"\source",
            Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Roblox",
            Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Temp"
        };

        public ClearDirsTask()
        {
            Name = "Clear common directories";
            Action = ClearDirectories;
        }

        private void ClearDirectories()
        {
            windirs.ForEach((value) => DirHelpers.RemoveDir(value, true));
            appdirs.ForEach((value) => DirHelpers.RemoveDir(value));
        }
    }
}
