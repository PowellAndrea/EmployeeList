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
            Console.Write("Search by: 1) Last Name, 2)First Name, 3) Department:  ");
            string sortKey = Console.ReadLine();
            Console.Write("\nEnter employee's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("\nEnter employee's last name: ");
            string lastName = Console.ReadLine();
            Employee findMe = new Employee(lastName, firstName);

            if (sortKey == "department")
            {
               Console.WriteLine("\n Enter Department : ");
               findMe.Department = Console.ReadLine();
            }
            myCompany.FindEmployee(findMe, sortKey);
            break;

        case "3":   // Add Employee
            {
                Console.Clear();
                Console.WriteLine("ADD EMPLOYEE");
                Console.WriteLine("Enter Employee Details");
                Console.WriteLine("\tFirst Name: ");
                string First = Console.ReadLine();
                Console.WriteLine("\n\tEnter employee's Last Name: ");
                string Last = Console.ReadLine();
                Console.WriteLine("\n\tDepartment: " );
                string Department = Console.ReadLine();
                Console.WriteLine("\n\tGender: ");
                string Gender = Console.ReadLine();
                Console.WriteLine("\n\tSalary: ");
                string Salary = Console.ReadLine();

                myCompany.newEmployee(Last, First, Gender, Department, Salary);
            }
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