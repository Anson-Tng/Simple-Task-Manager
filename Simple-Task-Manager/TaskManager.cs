using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TaskManager
{
    internal class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask()
        {
            Console.WriteLine("\nEnter Task: ");
            string TaskName = Console.ReadLine();
            Task task = new Task(tasks.Count + 1, TaskName);
            tasks.Add(task);
            Console.WriteLine("\nTask added.\n");
        }

        public void ViewList()
        {
            const int idWidth = 10; // Adjust width as needed
            const int descriptionWidth = 25; // Adjust width as needed
            const int statusWidth = 15;
            const int dateWidth = 15;
            
            
            Console.WriteLine($"\n{"TaskId",-idWidth} {"Description",-descriptionWidth} {"Status",-statusWidth} {"Date added",-dateWidth}\n");
            foreach (var task in tasks)
            {
                string statusString;
                if (task.IsCompleted)
                {
                    statusString = "Completed";
                }
                else
                {
                    statusString = "Not completed";
                }

                if (task.Description.Length > descriptionWidth)
                {
                    
                    var firstPart = task.Description.Substring(0, descriptionWidth);
                    var remainingPart = task.Description.Substring(descriptionWidth);
                    Console.WriteLine($"{task.TaskId,-idWidth} {firstPart,-descriptionWidth} {statusString,-statusWidth} {task.TaskDate.ToString("yyyy-MM-dd"),-dateWidth}");
                    Console.WriteLine($"{"",-idWidth} {remainingPart,-descriptionWidth}");
                }
                else
                {
                    Console.WriteLine($"{task.TaskId,-idWidth} {task.Description,-descriptionWidth} {statusString,-statusWidth}{task.TaskDate.ToString("yyyy-MM-dd"),-dateWidth}");
                }
            }
            Console.WriteLine("\n");
        }

        public void EditTask()
        {
            bool found = false;
            ViewList();

            Console.WriteLine("\nPlease enter the Task ID: ");

            if (int.TryParse(Console.ReadLine(), out int Id))
            {

                foreach (Task task in tasks)
                {
                    if (task.TaskId == Id)
                    {
                        found = true;
                        Console.WriteLine("\n" + task.Description);
                        Console.WriteLine("\nPlease enter new task:");
                        string newTask = Console.ReadLine();
                        task.Description = newTask;
                    }
                }
                if (found)
                {
                    Console.WriteLine("\nEdited\n");
                }
                else
                {
                    Console.WriteLine("\nError occurred\n");
                }
            }

        }

        public void RemoveTask()
        {
            ViewList();
            Console.WriteLine("Please enter the Task ID: ");

            if (int.TryParse(Console.ReadLine(), out int Id))
            {
                Task taskToRemove = null;

                foreach (Task task in tasks)
                {
                    if (task.TaskId == Id)
                    {
                        taskToRemove = task;
                        break; // exit loop once task is found
                    }
                }

                if (taskToRemove != null)
                {
                    Console.WriteLine(taskToRemove);
                    Console.WriteLine("\nAre you sure to remove it? (Type Y to confirm)");
                    string check = Console.ReadLine();
                    if (check == "Y" || check == "y")
                    {
                        if (tasks.Remove(taskToRemove))
                        {
                            Console.WriteLine("\nRemoved\n");
                        }
                        else
                        {
                            Console.WriteLine("\nError occurred\n");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("\nTask not found.\n");
                }
            }
        }

        public void MarkTask()
        {
            bool found = false;
            ViewList();
            Console.WriteLine("\nPlease enter the task ID to mark it as Completed or Not Completed:");
            if (int.TryParse(Console.ReadLine(), out int Id))
            {

                foreach (Task task in tasks)
                {
                    if (task.TaskId == Id)
                    {
                        found = true;

                        if (task.IsCompleted)
                        {
                            task.IsCompleted = false;
                        }
                        else
                        {
                            task.IsCompleted = true;
                        }
                    }
                }

                if (found)
                {
                    Console.WriteLine("\nEdited\n");
                }
                else
                {
                    Console.WriteLine("\nError occured\n");
                }
            }
        }

        public void SaveToFile(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Task>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, tasks);
                Console.WriteLine("\nFile Saved\n");
            }
        }

        public void LoadFromFile(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Task>));
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    tasks = (List<Task>)xmlSerializer.Deserialize(fileStream);
                    Console.WriteLine("\nFile loaded\n");
                }
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }

    }
}
