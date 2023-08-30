using System.Runtime.InteropServices;
using CleanupApp.TaskHelpers;
using CleanupApp.Tasks;
using CleanupApp.Models;

namespace CleanupApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<CleaningTask> CleaningTasks = new List<CleaningTask>() { 
                new ClearDirsTask(),
                new WinClearRecentFilesTask(),
                new ChromiumTask(),
                new ResetWallpaperCacheTask(),
            };

            int result = args.Length != 1 ? ShowMenu(CleaningTasks) : int.Parse(args[0]);

            if (result == -1)
            {
                foreach (var task in CleaningTasks)
                {
                    task.Run();
                }
            }
            else
            {
                CleaningTasks[result].Run();
            }

            Console.WriteLine("=== Cleaning complete ===");
        }

        static int ShowMenu(List<CleaningTask> tasks)
        {
            while (true)
            {
                Console.WriteLine("Options:\n" +
                "[0] - Run all");


                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] - " + tasks[i].Name);
                }

                Console.WriteLine();
                Console.Write("Enter an option: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result) && result >= 0 && result <= tasks.Count)
                {
                    return result - 1;
                }

                Console.Clear();
            }
        }
    }
}