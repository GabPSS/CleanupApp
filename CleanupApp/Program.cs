using CleanupApp.Models;
using CleanupApp.Tasks;

namespace CleanupApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<CleaningTask> cleaningTasks = new List<CleaningTask>() {
                new ClearDirsTask(),
                new WinClearRecentFilesTask(),
                new AppDirsTask(),
                new RemoveBrowsingDataTask(),
                new ResetWallpaperCacheTask(),
            };

            Console.WriteLine("CleanupApp 0.1.0");

            if (args.Contains("--help") || args.Contains("/?"))
            {
                ShowHelp(cleaningTasks);
                return;
            }

            List<int>? tasksToRun = GetWhichTasksToRun(args, cleaningTasks);

            for (int taskIndex = 0; taskIndex < cleaningTasks.Count; taskIndex++)
            {
                if (tasksToRun?.Contains(taskIndex) ?? true)
                {
                    cleaningTasks[taskIndex].Run();
                }
            }

            Console.WriteLine("=== Cleaning complete ===");
        }

        private static List<int>? GetWhichTasksToRun(string[] args, List<CleaningTask> availableTasks)
        {
            List<int> tasks = new();
            if (args.Length > 0)
            {
                if (args.Contains("--all"))
                {
                    return null;
                }

                for (int i = 0; i < availableTasks.Count; i++)
                {
                    CleaningTask task = availableTasks[i];
                    if (args.Contains("--" + task.Codename))
                    {
                        tasks.Add(i);
                    }
                }
            }
            else
            {
                int selection = ShowMenu(availableTasks);
                if (selection == -1) return null;
                tasks.Add(selection);
            }

            return tasks;
        }

        static int ShowMenu(List<CleaningTask> tasks)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Welcome to CleanupApp!\n\nOptions:\n" +
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
            }
        }

        static void ShowHelp(List<CleaningTask> tasks)
        {
            Console.WriteLine("Usage:");
            Console.Write("cleaningapp [--help][--all]");
            foreach (CleaningTask task in tasks)
            {
                Console.Write("[--" + task.Codename + "]");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--all".PadLeft(20) + "  Run all cleaning tasks");
            Console.WriteLine("--help".PadLeft(20) + "  Display help message");
            foreach (CleaningTask task in tasks)
            {
                Console.Write(("--" + task.Codename).PadLeft(20));
                Console.WriteLine("  " + task.Name);
            }
        }
    }
}