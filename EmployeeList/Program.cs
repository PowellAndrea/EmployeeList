// Read csv

using EmployeeList;
using System.Runtime.CompilerServices;

Company myCompany = new Company();

Console.WriteLine("Do things to employees!\n");

Console.WriteLine("1: View Employee List.");
Console.WriteLine("2: Find Employee.");
Console.WriteLine("3: Add Employee.");
Console.WriteLine("4: Display Average Employee Salary.");
Console.WriteLine("5: Edit Employee.");
Console.WriteLine("6. Delete Employee.");
Console.WriteLine("7: End the Pain.\n");
Console.WriteLine("Choose your fate: ");

var choice = Console.ReadLine();
switch (choice)
{
    case "1":   // Print Employee List
        //EmployeeList.Print();
        break;
    case "2":   // Find Employee
        break;
    case "3":   // Add Employee
        break;
    case "4":   // Display average salary
        break;
    case "5":   // Edit Employee
        break;
    case "6":   // Delete Employee
        break;
    case "7":   // Quit
        Console.WriteLine("The End.");
        break;
};