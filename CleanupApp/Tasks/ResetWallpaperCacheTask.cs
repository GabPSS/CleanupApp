using CleanupApp.TaskHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp.Tasks
{
    internal class ResetWallpaperCacheTask : Models.CleaningTask
    {
        public ResetWallpaperCacheTask()
        {
            Name = "Reset wallpaper cache";
            Codename = "wpp";
            Action = ResetWallpaper;
        }

        private void ResetWallpaper()
        {
            DirHelpers.RemoveDir(Environment.GetEnvironmentVariable("APPDATA") + @"\Microsoft\Windows\Themes\CachedFiles\", true);
        }
    }
}
