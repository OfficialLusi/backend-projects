using TaskTracker.Domain;

namespace TaskTracker.Application;

class TaskService(TaskManager taskManager)
{
    private readonly TaskManager _taskManager = taskManager;

    public void Add(string[] commandArgs)
    {
        if (commandArgs.Length > 1)
        {
            string description = commandArgs[1];
            _taskManager.AddTask(description);
        }
        else
            Console.WriteLine("You need a description to add an activity");
    }

    public void Update(string[] commandArgs)
    {
        string[] updateArgs = commandArgs.Length > 1 ? commandArgs[1].Split(' ', 2) : null;
        if (updateArgs != null && updateArgs.Length == 2 && int.TryParse(updateArgs[0], out int updateId))
        {
            string newDescription = updateArgs[1];
            _taskManager.UpdateTask(updateId, newDescription);
        }
        else
            Console.WriteLine("Invalid format. Use: update <id> <nuova descrizione>");
    }

    public void Delete(string[] commandArgs)
    {
        if (commandArgs.Length > 1 && int.TryParse(commandArgs[1], out int deleteId))
            _taskManager.DeleteTask(deleteId);
        else
            Console.WriteLine("Invalid format. Use: delete <id>");
    }

    public void MarkInProgress(string[] commandArgs)
    {
        if (commandArgs.Length > 1 && int.TryParse(commandArgs[1], out int inProgressId))
            _taskManager.MarkTask(inProgressId, "in-progress");
        else
            Console.WriteLine("Invalid format. Use: mark-in-progress <id>");
    }

    public void MarkDone(string[] commandArgs)
    {
        if (commandArgs.Length > 1 && int.TryParse(commandArgs[1], out int doneId))
            _taskManager.MarkTask(doneId, "done");
        else
            Console.WriteLine("Invalid format. Use: mark-done <id>");
    }

    public void ListAll()
    {
        _taskManager.ListTasks();
    }

    public void ListToDo()
    {
        _taskManager.ListTasks("todo");
    }

    public void ListInProgress()
    {
        _taskManager.ListTasks("in-progress");
    }

    public void ListDone()
    {
        _taskManager.ListTasks("done");
    }

}