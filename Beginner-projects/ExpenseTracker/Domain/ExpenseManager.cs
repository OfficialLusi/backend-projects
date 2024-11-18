using ExpenseTracker.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace ExpenseTracker.Domain;

public class ExpenseManager
{

    private readonly IExpenseRepository _repository;
    private readonly List<Expense> _expenses;

    public ExpenseManager(IExpenseRepository repo)
    {
        _repository = repo;
        _expenses = _repository.LoadExpenses();
    }

    public void AddExpense(string description, int amount)
    {
        int newId = _expenses.Count > 0 ? _expenses.Max(e => e.Id) + 1 : 1;
        Expense newExpense = new Expense(newId, amount, description);
        _expenses.Add(newExpense);
        if(_expenses.Count == 1) _repository.SaveExpenses(_expenses[0]);
        else _repository.SaveExpenses(_expenses.First());
        Console.WriteLine($"Expense added succesfully (ID: {newId}\n");
    }

    public void UpdateExpense(int id, string description, int amount)
    {
        Expense expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense != null)
        {
            expense.Amount = amount;
            expense.Description = description;
            expense.UpdateTime();
            _repository.SaveExpenses(expense);
            Console.WriteLine($"Expense updated succesfully (ID: {id}\n");
        }
        else Console.WriteLine($"Expense with ID: {id} not found\n");
    }

    public void DeleteExpense(int id)
    { 
        Expense expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense != null) 
        {
            _expenses.Remove(expense);
            _repository.SaveExpenses(_expenses);
            Console.WriteLine($"Expense deleted succesfully (ID: {id}\n");
        }
        else Console.WriteLine($"Expense with ID: {id} not found\n");
    }

    public void ListAllExpenses()
    {
        foreach (Expense expense in _expenses)
            Console.WriteLine($"Expense Id: {expense.Id}\n" +
                              $"Expense Description: {expense.Description}\n" +
                              $"Expense Amount: {expense.Amount}\n" +
                              $"Expense Created At: {expense.CreatedAt}\n" +
                              $"Expense Updated At: {expense.UpdatedAt}\n");
    }

    public void ViewAllMoneySpent()
    {
        int totalAmount = 0;
        foreach(Expense expense in _expenses) 
        totalAmount += expense.Amount;

        Console.WriteLine($"Total Amount Spent : {totalAmount}\n");
    }

    public void ListExpensesPerMonth(int month)
    {
        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        Console.WriteLine($"In {monthName} you had these expenses:");
        int monthTotalAmount = 0;
        foreach(Expense expense in _expenses)
        {
            if (expense.CreatedAt.Month == month)
            {
                Console.WriteLine($"On date: {expense.CreatedAt} the expense was: {expense.Description} for an amount of: {expense.Amount}");
                monthTotalAmount += expense.Amount;
            }
        }
        Console.WriteLine($"For a total amount of: {monthTotalAmount}");
    }
}
