using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTracker;

public class TaskManager
{
    private List<Task> _tasks;
    private TaskRepository _repository;

    public TaskManager(TaskRepository repository)
    {
        _repository = repository;
        _tasks = _repository.LoadTasks();
    }

    public void AddTask(string description)
    {
        int newId = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
        Task newTask = new Task(newId, description);
        _tasks.Add(newTask);
        _repository.SaveTasks(_tasks);
        Console.WriteLine($"Task added succesfully (ID: {newId})");
    }

    public void UpdateTask(int id, string newDescription)
    {
        Task task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;
            _repository.SaveTasks(_tasks);
            Console.WriteLine($"Task {id} updated succesfully.");
        }
        else
        {
            Console.WriteLine($"Task with ID {id} not found.");
        }
    }

    public void DeleteTask(int id)
    {
        Task task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
            _repository.SaveTasks(_tasks);
            Console.WriteLine($"Task {id} deleted.");
        }
        else
        {
            Console.WriteLine($"Task with ID {id} not found.");
        }
    }

    public void MarkTask(int id, string status)
    {
        Task task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.UpdateStatus(status);
            _repository.SaveTasks(_tasks);
            Console.WriteLine($"Task {id} updated at '{status}'.");
        }
        else
        {
            Console.WriteLine($"Task with ID  {id}  not found.");
        }
    }

    public void ListTasks(string status = null)
    {
        IEnumerable<Task> tasksToDisplay = _tasks;

        if (!string.IsNullOrEmpty(status))
        {
            tasksToDisplay = tasksToDisplay.Where(t => t.Status == status);
        }

        foreach (var task in tasksToDisplay)
        {
            Console.WriteLine($"{task.Id}. {task.Description} - {task.Status} (Created: {task.CreatedAt}, Updated: {task.UpdatedAt})");
        }
    }
}
