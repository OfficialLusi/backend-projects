using ExpenseTracker.Domain;
using Newtonsoft.Json;

namespace ExpenseTracker.Infrastructure;

public class ExpenseRepository : IExpenseRepository
{

    private readonly string _filePath;

    public ExpenseRepository(string filePath)
    {
        _filePath = filePath;

        if (!File.Exists(filePath))
            CreateEmptyJsonFile();
    }

    public List<Expense> LoadExpenses()
    {
        string json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<Expense>>(json) ?? new List<Expense>();
    }

    public void SaveExpenses(Expense expense)
    {
        string json = JsonConvert.SerializeObject(expense, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
    public void SaveExpenses(List<Expense> expenses)
    {
        string json = JsonConvert.SerializeObject(expenses, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }

    #region private methods
    private void CreateEmptyJsonFile() 
    {
        File.WriteAllText(_filePath, "[]");
    }
    #endregion
}
