namespace NovaGrService;
using System.Text;

public class Commands
{
    Company comp = new Company();
    Animal ani = new Animal();
    Cashier cashy = new Cashier();
    Groomer Grom = new Groomer();
    AnimalOwner owner = new AnimalOwner();
    public void help()
    {
        Console.WriteLine("here are the following commands :  ");
        Console.WriteLine("to start day sequnce type 'start day sequence'");
    }
    public void variableReader(string s)
    {
        switch (s)
        {
            case "company-name":
                Console.WriteLine($"variable is -> {comp.companyName}");
                break;
            default:
                Console.WriteLine("those variables don't exist sorry;");
                break;
        }
    }
    public void registerCompany()
    {
        string path = "Company.txt";

        using FileStream fs = File.OpenRead(path);

        byte[] buf = new byte[1024];
        int c;
        int v = 0;
        string Inter = "";
        while ((c = fs.Read(buf, 0, buf.Length)) > 0)
        {
            Inter = (Encoding.UTF8.GetString(buf, 0, c));
        }
        for (int i = 0; i < Inter.Length; i++)
        {

            if (Inter[i] == '|')
            {
                comp.money = Convert.ToDouble(Inter.Substring(v, i - v - 1));
                v = i;
            }
            if (Inter[i] == '/')
            {
                comp.companyName = Inter.Substring(0, i - 1);
                v = i;
            }
            if (Inter[i] == '~')
            {
                comp.adress = Inter.Substring(v, i - v - 1);
                v = i;
            }
            if (Inter[i] == ';')
            {
                comp.telNumber = Inter.Substring(v, i - v - 1);
                v = i;
            }
            comp.ID = Inter.Substring(v,Inter.Length - v - 1);
        }
        Console.WriteLine("company's money is: " + comp.money);
        Console.WriteLine("company's name is: " + comp.companyName);
        Console.WriteLine("company's adress is: " + comp.adress);
        Console.WriteLine("company's tel number is: " + comp.telNumber);
        Console.WriteLine("company's ID is" + comp.ID);
    }
    public void registerCashier()
    {
        string path = "Cashier.txt";

        using FileStream fs = File.OpenRead(path);

        byte[] buf = new byte[1024];
        int c;
        string Inter = "";
        string InterMoney = "";
        while ((c = fs.Read(buf, 0, buf.Length)) > 0)
        {
            Inter = (Encoding.UTF8.GetString(buf, 0, c));
        }
        for (int i = 0; i < Inter.Length; i++)
        {
            if (Inter[i] == '|')
            {
                cashy.Name = Inter.Substring(0, i - 1);
                InterMoney = Inter.Substring(i+1,Inter.Length - i - 1);
                cashy.Money = Convert.ToDouble(InterMoney);
                break;
            }
        }
        Console.WriteLine("cashier name is: " + cashy.Name);
        Console.WriteLine("cashier's money is: " + cashy.Money);
    }
    public void registerClient()
    {
        Console.Write("client's name is: ");
        owner.Name = Console.ReadLine();
        Console.Write("is client vip? (yes or no) : ");
        string s = Console.ReadLine();
        if (s == "yes")
        {
            owner.IsVip = true;
        }
        if (owner.IsVip == true)
        {
            cashy.Fee = cashy.Fee * 1.3;
        }
    }
    public void registerClientAnimals()
    {
        Console.WriteLine("how many cats? : ");
        double Cati = Convert.ToDouble(Console.ReadLine);
        for (double i = 0; i < Cati; i++)
        {
            Cat cat = new Cat();

            Console.Write($"{i}-th Cat's name is: ");
            cat.Name = Console.ReadLine();
            cat.owner = owner;

            owner.cats.Add(cat);
        }
        //dog section
        Console.WriteLine("how many dogs? : ");
        double Dogi = Convert.ToDouble(Console.ReadLine());
        for (double i = 0; i < Dogi; i++)
        {
            Dog dog = new Dog();

            Console.Write($"{i}-th dogs name is: ");
            dog.Name = Console.ReadLine();
            owner.dogs.Add(dog);
        }
        //mice section
        Console.WriteLine("how many mice? : ");
        double Micei = Convert.ToDouble(Console.ReadLine());
        for (double i = 0; i < Micei; i++)
        {
            Mouse mouse = new Mouse();

            Console.Write($"{i}-th mice's name is: ");
            mouse.Name = Console.ReadLine();
            mouse.owner = owner;
            owner.mice.Add(mouse);
        }
    }
    public void registerGroomer()
    {
        Console.Write("groomer's name is : ");
        Grom.Name = Console.ReadLine();
        Grom.PersonalMoney = 0;
        Console.Write("sheering style is : ");
        Grom.SheeringStyle = Console.ReadLine();
    }
    public void GroomingJob()
    {
        Grom.IsFree = false;
        foreach (var dog in owner.dogs)
        {
            Console.WriteLine($"Groomer - done with {dog.Name}");

            Grom.PersonalMoney += cashy.Fee * 0.7;
            cashy.Money = cashy.Fee * 0.1;
            comp.money = cashy.Fee * 0.2;
            Console.WriteLine($"Groomer money = {Grom.PersonalMoney}");
            Console.WriteLine($"company money = {comp.money}");
            Console.WriteLine($"cashier money = {cashy.Money}");
        }
        Grom.IsFree = true;
    }

}