using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
    public class DataLoader
    {
        public static EmployeeList LoadData(string path)
        {
            StreamReader reader = new StreamReader(path);

            TextFieldParser textFieldParser = new(reader);
            textFieldParser.HasFieldsEnclosedInQuotes = true;
            textFieldParser.TrimWhiteSpace = true;
            textFieldParser.Delimiters = new string[] { "," };

            // Assuming the first line is actually the header here
            // Check for nulls
            string record = textFieldParser.ReadLine();
            record = record.ToLower();   // making header row case insensitive
            string[] header = record.Split(',');
            int headerColumns = header.Length;
            EmployeeList employeeList = new();
            //Employee employee;

            while (!textFieldParser.EndOfData)
            {
                string LastName = string.Empty;
                string FirstName = string.Empty;
                string Gender = string.Empty;
                string Department = string.Empty;
                decimal Salary = 0;

                string[] items = textFieldParser.ReadFields();

                for (int index = 0; index < header.Length; index++)
                {
                    string column = header[index];
                    switch (column)
                    {
                        case "name":
                            {
                                // Assumption:  Full Names containe only 2 strings: 0=first name and 1=last name
                                // Fix this - sub string to space = first, everything else = last?
                                // or start and end-to space = last and everything else = first?
                                string FullName = items[index];
                                string[] Names = FullName.Split(" ");
                                FirstName = Names[0];
                                LastName = Names[1];
                                continue;
                            }

                        case "gender":
                            {
                                Gender = items[index];
                                continue;
                            }

                        case "department":
                            {
                                Department = items[index];
                                continue;
                            }

                        case "salary":
                            {
                                string strSalary = items[index];
                                strSalary = strSalary.Replace("$", "");
                                if (decimal.TryParse(strSalary, out decimal value))
                                {
                                    Salary = value;
                                }
                                continue;
                            }
                    }
                }

                Employee newEmployee = new(LastName, FirstName);
                newEmployee.Salary = Salary;
                newEmployee.Gender = Gender;
                newEmployee.Department = Department;
                employeeList.Add(newEmployee, "last");
            }

           return employeeList;
        }
    }
}
