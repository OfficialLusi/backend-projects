using Newtonsoft.Json;

namespace TestTracker;

public class TaskRepository
{
    private readonly string _filePath;

    public TaskRepository(string filePath)
    {
        _filePath = filePath;

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }

    public List<Task> LoadTasks()
    {
        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<Task>>(json) ?? new List<Task>();
    }

    public void SaveTasks(List<Task> tasks)
    {
        var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
}
