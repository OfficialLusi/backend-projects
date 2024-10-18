using System;
using TestTracker;

class Program
{
    static void Main(string[] args)
    {
        TaskRepository repository = new TaskRepository("tasks.json");
        TaskManager taskManager = new TaskManager(repository);

        Console.WriteLine("Welcome to Task Manager CLI!");
        Console.WriteLine("you can use commands like: " +
            "   - add <activity>," +
            "   - update <id> <activity>," +
            "   - delete <id>," +
            "   - mark-in-progress <id>," +
            "   - mark-done <id>," +
            "   - list," +
            "   - exit");

        while (true)
        {
            Console.Write("\n> "); 
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Insert a valid number.");
                continue;
            }

            // Split input in base agli spazi
            string[] commandArgs = input.Split(' ', 2); 
            string command = commandArgs[0].ToLower();

            switch (command)
            {
                case "add":
                    if (commandArgs.Length > 1)
                    {
                        string description = commandArgs[1];
                        taskManager.AddTask(description);
                    }
                    else
                    {
                        Console.WriteLine("You need a description to add an activity");
                    }
                    break;

                case "update":
                    string[] updateArgs = commandArgs.Length > 1 ? commandArgs[1].Split(' ', 2) : null;
                    if (updateArgs != null && updateArgs.Length == 2 && int.TryParse(updateArgs[0], out int updateId))
                    {
                        string newDescription = updateArgs[1];
                        taskManager.UpdateTask(updateId, newDescription);
                    }
                    else
                    {
                        Console.WriteLine("Formato non valido. Usa: update <id> <nuova descrizione>");
                    }
                    break;

                case "delete":
                    if (commandArgs.Length > 1 && int.TryParse(commandArgs[1], out int deleteId))
                    {
                        taskManager.DeleteTask(deleteId);
                    }
                    else
                    {
                        Console.WriteLine("Formato non valido. Usa: delete <id>");
                    }
                    break;

                case "mark-in-progress":
                    if (commandArgs.Length > 1 && int.TryParse(commandArgs[1], out int inProgressId))
                    {
                        taskManager.MarkTask(inProgressId, "in-progress");
                    }
                    else
                    {
                        Console.WriteLine("Formato non valido. Usa: mark-in-progress <id>");
                    }
                    break;

                case "mark-done":
                    if (commandArgs.Length > 1 && int.TryParse(commandArgs[1], out int doneId))
                    {
                        taskManager.MarkTask(doneId, "done");
                    }
                    else
                    {
                        Console.WriteLine("Formato non valido. Usa: mark-done <id>");
                    }
                    break;

                case "list":
                    if (commandArgs.Length > 1)
                    {
                        taskManager.ListTasks(commandArgs[1]);
                    }
                    else
                    {
                        taskManager.ListTasks();
                    }
                    break;

                case "exit":
                    Console.WriteLine("Uscita dal programma.");
                    return;

                default:
                    Console.WriteLine("Comando non riconosciuto.");
                    break;
            }
        }
    }
}
