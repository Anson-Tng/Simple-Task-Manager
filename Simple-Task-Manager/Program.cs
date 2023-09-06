using System;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {

            TaskManager taskManager = new TaskManager();
            // new functions later - Load & Save List
            while (true)
            {
                PrintMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add task
                        taskManager.AddTask();
                        break;

                    case "2":
                        // View List
                        taskManager.ViewList();
                        break;

                    case "3":
                        // Edit task
                        taskManager.EditTask();
                        break;

                    case "4":
                        // Remove task
                        taskManager.RemoveTask();
                        break;

                    case "5":
                        // Mark task
                        taskManager.MarkTask();
                        break;

                    case "6":
                        taskManager.SaveToFile("SaveFile");
                        break;

                    case "7":
                        taskManager.LoadFromFile("SaveFile");
                        break;

                    case "8":
                        // Exit
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nPlease enter 1-8 only\n");
                        break;

                }
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine("===To-Do List===");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. View list");
            Console.WriteLine("3. Edit task");
            Console.WriteLine("4. Remove task");
            Console.WriteLine("5. Mark task as completed");
            Console.WriteLine("6. Save file");
            Console.WriteLine("7. Load file");
            Console.WriteLine("8. Exit");
            Console.WriteLine("\nPlease enter a number:");
        }



    }
}

