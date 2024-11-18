namespace ExpenseTracker.Domain;

public class Expense
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null;
    public bool IsCriticalAmount { get; set; } = false;

    public Expense(int id, int amount, string description)
    {
        Id = id;
        Amount = amount;
        Description = description;
    }
    public void UpdateTime()
    {
        UpdatedAt = DateTime.Now;
    }
    public void IsCritical()
    {
        IsCriticalAmount = true;
    }
    public void IsNotCritical()
    {
        IsCriticalAmount = false;
    }

}
