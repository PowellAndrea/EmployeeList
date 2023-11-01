// Read csv

using EmployeeList;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

Company myCompany = new Company();

bool cont = true;
while (cont) 
{
    Console.WriteLine("Do things to employees!\n");

    Console.WriteLine("1: View Employee List.");
    Console.WriteLine("2: Find Employee.");
    Console.WriteLine("3: Add Employee.");
    Console.WriteLine("4: Display Average Employee Salary.");
    Console.WriteLine("5: Edit Employee.");
    Console.WriteLine("6. Delete Employee.");
    Console.WriteLine("7: End the Pain.\n");
    Console.WriteLine("Choose your fate: ");

    //var choice = Console.ReadLine();
    switch (Console.ReadLine())
    {
        case "1":   // Print Employee List
            Console.Clear();
            Console.WriteLine("Print Employee List\n");
            Console.WriteLine("Order by:  1) Last Name, 2) First Name, 3) Department: ");
            string choice = Console.ReadLine();
            myCompany.PrintEmployeeList(choice);
            break;

        case "2":   // Find Employee
            Console.Clear();
            Console.WriteLine("FIND EMPLOYEE\n");
            Console.WriteLine("Search by: 1) Last Name, 2)First Name, 3) Department:  ");
            string searchKey = Console.ReadLine();
            Console.WriteLine("Enter employee's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter employee's last name: ");
            string lastName = Console.ReadLine();
            Employee findMe = new Employee(lastName, firstName);

            switch (searchKey)
            {
                case "3":
                    {
                        Console.WriteLine("\n Enter Department : ");
                        findMe.Department = Console.ReadLine();
                        break;
                    }
            }
            myCompany.FindEmployee(findMe, searchKey);

            break;
        case "3":   // Add Employee
            break;
        case "4":   // Display average salary
            Console.WriteLine(myCompany.GetAverageSalary());
            break;
        case "5":   // Edit Employee
            break;
        case "6":   // Delete Employee
            break;
        case "7":   // Quit
            Console.WriteLine("The End.");
            cont = false;
            break;
    };
}