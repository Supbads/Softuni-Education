using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Write the name of your company:");
        string companyName = Console.ReadLine();
        Console.WriteLine("Write the adress of your company:");
        string companyAdress = Console.ReadLine();
        Console.WriteLine("Write the phone number of your company:");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Write the fax number of your company:");
        string fax = Console.ReadLine();
        Console.WriteLine("Write the website of your company:");
        string webSite = Console.ReadLine();
        Console.WriteLine("Write the manager of the company's first name:");
        string managerName = Console.ReadLine();
        Console.WriteLine("Write the manager of the company's last name");
        string managerLastName = Console.ReadLine();
        Console.WriteLine("Write the manager's age:");
        string managerAge = Console.ReadLine();
        Console.WriteLine("Write the namanger's phone number:");
        string managerPhoneNumber = Console.ReadLine();
        Console.WriteLine("\n{0}\n" + "Company adress: {1}\n" + "Tel. : {2}\n" + "Fax: {3}\n" + "Web site: {4}\n" + "Manager: {5} {6} (Age: {7}, tel. :{8})",
            companyName, companyAdress, phoneNumber, fax, webSite, managerName, managerLastName, managerAge ,managerPhoneNumber);
    }
}