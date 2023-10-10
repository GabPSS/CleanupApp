namespace CleanupApp.TaskHelpers
{
    internal static class DirHelpers
    {
        public static void RemoveFile(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine("Removing file: " + path);
                try
                {
                    File.Delete(path);
                }
                catch (IOException)
                {
                    Console.WriteLine("ERROR: Got \"Access denied\" when trying to delete " + path);
                }
            }
        }

        public static void RemoveDir(string dir, bool keepDir = false)
        {
            if (!Directory.Exists(dir))
            {
                return;
            }

            Console.WriteLine("Removing directory: " + dir);

            try
            {
                SimpleRemoveDir(dir, keepDir);

            }
            catch
            {
                RemoveDirByIteration(dir);
            }
        }

        public static void RemoveDir(DirPrefix prefixType, string dir, bool keepDir = false)
        {
            string? prefix = "";
            switch (prefixType)
            {
                case DirPrefix.DriveRoot:
                    prefix = Environment.GetEnvironmentVariable("HOMEDRIVE");
                    break;
                case DirPrefix.UserProfile:
                    prefix = Environment.GetEnvironmentVariable("USERPROFILE");
                    break;
                case DirPrefix.LocalAppData:
                    prefix = Environment.GetEnvironmentVariable("LOCALAPPDATA");
                    break;
            }
            RemoveDir(prefix + "\\" + dir, keepDir);
        }

        private static void RemoveDirByIteration(string dir)
        {
            IEnumerable<string> dirs = Directory.EnumerateDirectories(dir);
            foreach (string subdir in dirs)
            {
                try
                {
                    Directory.Delete(subdir, true);
                }
                catch (AccessViolationException) { Console.WriteLine("ERROR: Got \"Access denied\" when trying to delete " + subdir); }
                catch (UnauthorizedAccessException) { Console.WriteLine("ERROR: Got \"Access denied\" when trying to delete " + subdir); }
                catch (System.IO.IOException) { Console.WriteLine("ERROR: Got \"Access denied\" when trying to delete " + subdir); }
            }

            IEnumerable<string> files = Directory.EnumerateFiles(dir);
            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);

                }
                catch (AccessViolationException) { Console.WriteLine("ERROR: Got \"Access denied\" when trying to delete " + file); }
                catch (UnauthorizedAccessException) { Console.WriteLine("ERROR: Got \"Access denied\" when trying to delete " + file); }
                catch (System.IO.IOException) { Console.WriteLine("ERROR: Got \"Access denied\" when trying to delete " + file); }
            }
        }

        private static void SimpleRemoveDir(string dir, bool keepDir)
        {
            Directory.Delete(dir, true);
            if (keepDir)
            {
                Directory.CreateDirectory(dir);
            }
        }


    }

    public enum DirPrefix { DriveRoot, UserProfile, LocalAppData }
}