using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure;

namespace ExpenseTracker.Application;

public class ExpenseManagerCli
{

    private readonly IExpenseService _expenseService;
    private readonly ExpenseManager _expenseManager;
    private readonly IExpenseRepository _expenseRepository;

    private const string _filePath = "expenses.json";

    public ExpenseManagerCli()
    {
        _expenseRepository = new ExpenseRepository(_filePath);
        _expenseManager = new ExpenseManager(_expenseRepository);
        _expenseService = new ExpenseService(_expenseManager);
    }
    
    public void ExpenseManagerCliMain()
    {
        Console.WriteLine("Welcome to Expense Manager CLI!   ");
        Help();

        while (true)
        {
            Console.Write("\n> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Insert a valid number.");
                continue;
            }

            // Split input in base agli spazi
            string[] commandArgs = input.Split(' ', 2);
            string command = commandArgs[0].ToLower();

            switch (command)
            {
                case "add":
                    _expenseService.Add(commandArgs);
                    break;

                case "update":
                    _expenseService.Update(commandArgs);
                    break;

                case "delete":
                    _expenseService.Delete(commandArgs);
                    break;

                case "list-all-expenses":
                    _expenseService.ListAllExpenses();
                    break;

                case "view-expenses-per-month":
                    _expenseService.ListExpensesPerMonth(commandArgs);
                    break;

                case "view-all-money-spent":
                    _expenseManager.ViewAllMoneySpent();
                    break;

                case "exit":
                    Console.WriteLine("Exit program.");
                    return;

                case "help":
                    Help();
                    break;

                default:
                    Console.WriteLine("Unknow command.");
                    break;
            }
        }

    }
    private static void Help()
    {
        Console.WriteLine("you can use commands like:   \n" +
                          "   - add --description \"description\" --amount \"amount\"                           ,\n" +
                          "   - update --id \"id\" --newdesc \"newdesc\" --newamount \"newamount\"              ,\n" +
                          "   - delete --id \"id\"                                                              ,\n" +
                          "   - view-expenses-per-month --month \"month\" (wrote as a month name or number)     ,\n" +
                          "   - list-all-expenses,                                                              ,\n" +
                          "   - view-all-money-spent,                                                           ,\n" +
                          "   - exit                                                                            ,\n" +
                          "   - help                                                                            ");
    }
}
