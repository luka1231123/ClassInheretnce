using System.Text;
namespace NovaGrService;

class Program
{
    static void Main()
    {
        //main logic ~ console
        Console.WriteLine("welcome to the Grooming Command line, in here you can manage the company");
        Console.WriteLine("ask for help by typing h;");
        bool loop = true;
        Commands com = new Commands();
        while (loop)
        {

            Console.Write("command-> ");
            string? newCommand = Console.ReadLine();
            string? newNewCommand = "";
            switch (newCommand)
            {
                case "h":
                    com.help();
                    break;
                case "acs variable":
                    Console.Write("write variable to read -> ");
                    newNewCommand = Console.ReadLine();
                    com.variableReader(newNewCommand);
                    break;
                case "start day sequence":
                    Console.Write("first time? (yes or no)");
                    newNewCommand = Console.ReadLine();
                    if (newNewCommand == "yes")
                    {
                        Console.WriteLine("~~company registered~~");
                        com.registerCompany();
                        Console.WriteLine("~~cashier registered~~");
                        com.registerCashier();
                        Console.WriteLine("~~client~~");
                        com.registerClient();
                        Console.WriteLine("~~animals registered~~");
                        com.registerClientAnimals();
                        Console.WriteLine("~~groomer registered~~");
                        com.registerGroomer();
                    }
                    else
                    {
                        Console.WriteLine("~~new client~~");
                        com.registerClient();
                        Console.WriteLine("~~animals~~");
                        com.registerClientAnimals();
                    }
                    break;
                case "register cashier":
                    Console.WriteLine("~~cashier registered");
                    com.registerCashier();
                    break;
                case "exit":
                    loop = false;
                    break;
                default:
                    Console.WriteLine("those commands don't exist sorry;");
                    break;
            }
        }
    }
}