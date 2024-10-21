namespace TaskTracker.Domain;

public class TaskProp
{

    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public TaskProp(int id, string description)
    {
        Id = id;
        Description = description;
        Status = "todo";
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
        UpdatedAt = DateTime.Now;
    }

}
