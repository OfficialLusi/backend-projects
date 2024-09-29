namespace TestTracker;

public class TaskProp(int id, string description, TaskProp.Status taskStatus, DateTime createdAt, DateTime updatedAt)
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;
    public Status TaskStatus { get; set; } = taskStatus;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime UpdatedAt { get; set; } = updatedAt;

    public enum Status
    {
        todo,
        inProgress,
        done
    }
}
