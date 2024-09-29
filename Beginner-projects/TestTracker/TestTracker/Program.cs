using System.Text.Json;
using TestTracker;

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
        var exampleTask = new TaskProp(1, "Example task", TaskProp.Status.todo, DateTime.Now, DateTime.Now);

        string jsonString = JsonSerializer.Serialize(exampleTask);
        File.WriteAllText("exampleTask.json", jsonString);
    }

}