namespace ExpenseTracker.Application;

public interface IExpenseService
{
    public void Add(string[] commandArgs);
    public void Update(string[] commandArgs);
    public void Delete(string[] commandArgs);
    public void ListAllExpenses();
    public void ViewMoneySpent();
    public void ListExpensesPerMonth(string[] commandArgs);
}
