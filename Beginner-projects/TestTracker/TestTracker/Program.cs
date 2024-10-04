using System.Text.Json;

namespace TestTracker;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            CreateJsonFile();
            Console.WriteLine("File JSON creato con successo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore durante la creazione del file JSON: {ex.Message}");
        }
    }

    public static void CreateJsonFile()
    {
        string path = "E:/Users/lusaa1/OneDrive - Danieli/Documents/0-lusaa1/vs personal projects/backend-projects/Beginner-projects/TestTracker/TestTracker";

        TaskProp exampleTask = new TaskProp(1, "Example task", TaskProp.Status.todo, DateTime.Now, DateTime.Now);

        string jsonString = JsonSerializer.Serialize(exampleTask);

        try
        {
            File.WriteAllText(Path.Combine(path,"exampleTask.json"), jsonString);
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"Errore di I/O durante la scrittura del file: {ioEx.Message}");
            throw;
        }
    }
}