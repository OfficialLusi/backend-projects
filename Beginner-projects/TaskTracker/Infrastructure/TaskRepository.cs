using Newtonsoft.Json;
using TaskTracker.Domain;

namespace TaskTracker.Infrastructure;

public class TaskRepository
{
    private readonly string _filePath;

    public TaskRepository(string filePath)
    {
        _filePath = filePath;

        if (!File.Exists(_filePath))
            CreateEmptyJsonFile();
    }

    public List<TaskProp> LoadTasks()
    {
        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<TaskProp>>(json) ?? new List<TaskProp>();
    }

    public void SaveTasks(List<TaskProp> tasks)
    {
        var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }

    private void CreateEmptyJsonFile()
    {
        File.WriteAllText(_filePath, "[]");
    }
}
