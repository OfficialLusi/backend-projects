

namespace TestTracker;

public class Commands(string command)
{
    private const string Add = "add";
    private const string Update = "update";
    private const string Delete = "delete";
    private const string MarkInProgress = "mark-in-progress";
    private const string MarkDone = "mark-done";
    private const string ListAll = "list-all";
    private const string ListTodo = "list-todo";
    private const string ListInProgress = "list-in-progress";
    private const string ListDone = "list-done";

    private string Command { get; set; } = command;

    public void ExecuteCommand()
    {
        switch (Command)
        {
            case Add:
                AddTask();
                break;
            case Update:
                UpdateTask();
                break;
            case Delete:
                DeleteTask();
                break;
            case MarkInProgress:
                MarkTaskInProgress();
                break;
            case MarkDone:
                MarkTaskDone();
                break;
            case ListAll:
                ListAllTasks();
                break;
            case ListTodo:
                ListTodoTasks();
                break;
            case ListInProgress:
                ListInProgressTasks();
                break;
            case ListDone:
                ListDoneTasks();
                break;
        }
    }


    private void AddTask()
    {
        throw new NotImplementedException();
    }
    private void UpdateTask()
    {
        throw new NotImplementedException();
    }
    private void DeleteTask()
    {
        throw new NotImplementedException();
    }
    private void MarkTaskInProgress()
    {
        throw new NotImplementedException();
    }
    private void MarkTaskDone()
    {
        throw new NotImplementedException();
    }
    private void ListAllTasks()
    {
        throw new NotImplementedException();
    }
    private void ListTodoTasks()
    {
        throw new NotImplementedException();
    }
    private void ListInProgressTasks()
    {
        throw new NotImplementedException();
    }
    private void ListDoneTasks()
    {
        throw new NotImplementedException();
    }
}
