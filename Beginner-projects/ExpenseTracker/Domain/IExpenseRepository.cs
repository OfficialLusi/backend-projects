namespace ExpenseTracker.Domain;

public interface IExpenseRepository
{
    public List<Expense> LoadExpenses();
    public void SaveExpenses(List<Expense> expenses);
    public void SaveExpenses(Expense expense);
}
