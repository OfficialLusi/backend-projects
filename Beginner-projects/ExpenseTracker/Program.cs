using ExpenseTracker.Application;

namespace ExpenseTracker;

public class Program
{
    static void Main(string[] args)
    {
        ExpenseManagerCli cli = new ExpenseManagerCli();
        cli.ExpenseManagerCliMain();
    }
}