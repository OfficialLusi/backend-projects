using ExpenseTracker.Domain;
using System.Drawing;
using System.Globalization;

namespace ExpenseTracker.Application;

public class ExpenseService : IExpenseService
{
    private readonly ExpenseManager _manager;

    public ExpenseService(ExpenseManager manager)
    {
        _manager = manager;
    }

    /*
     * The input should be something like:
     * add --description "description" --amount "amount
     */
    public void Add(string[] commandArgs)
    {
        if (commandArgs.Length > 3)
        {
            string description = commandArgs[2];
            int amount = Convert.ToInt32(commandArgs[4]);
            _manager.AddExpense(description, amount);
        }
        else
            Console.WriteLine("You need a description and an amount to add an expense");
    }

    /*
     * The input should be something like:
     * update --id 3 --newdescription "description" --newamount "amount"
     */ 
    public void Update(string[] commandArgs)
    {
        if (commandArgs.Length > 5)
        {
            int updateId = Convert.ToInt32(commandArgs[2]);
            string newDescription = commandArgs[4];
            int newAmount = Convert.ToInt32(commandArgs[6]);
            _manager.UpdateExpense(updateId, newDescription, newAmount);
        }
        else
            Console.WriteLine("You need an Id, a new description and a new amount to update an expense");
    }

     /*
     * The input should be something like:
     * delete --id 3 
     */
    public void Delete(string[] commandArgs)
    {
        if (commandArgs.Length > 1)
        {
            int deleteId = Convert.ToInt32(commandArgs[2]);
            _manager.DeleteExpense(deleteId);
        }
        else
            Console.WriteLine("You need an Id to delete an expense");
    }

    /*
    * The input should be something like:
    * list-all-expenses 
    */
    public void ListAllExpenses()
    {
        _manager.ListAllExpenses();
    }

    /*
    * The input should be something like:
    * view-expenses-per-month --month "month-name" or "2"
    */
    public void ListExpensesPerMonth(string[] commandArgs)
    {
        DateTimeFormatInfo dtfi = CultureInfo.CurrentCulture.DateTimeFormat;
        int month = 0;
        try 
        {
            month = Convert.ToInt32(commandArgs[2]);
            _manager.ListExpensesPerMonth(month);

        }
        catch
        {
            month = Array.FindIndex(dtfi.MonthNames, m => m.Equals(commandArgs[2], StringComparison.CurrentCultureIgnoreCase)) + 1;

            _manager.ListExpensesPerMonth(month);
        }
    }

    /*
    * The input should be something like:
    * view-all-money-spent
    */
    public void ViewMoneySpent()
    {
        _manager.ViewAllMoneySpent();
    }
}
