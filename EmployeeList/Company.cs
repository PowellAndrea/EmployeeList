using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace EmployeeList
{
    public class Company
    {
        public EmployeeList EmployeeList
        {
            get => _employeeList;
            set => _employeeList = value;
        }

        private EmployeeList _employeeList = new EmployeeList();

        public Company()
        {
            _employeeList = new();
            GetData();
        }

        public void GetData()
        {
            // string path = Path.Combine(Environment.CurrentDirectory, "employees.csv");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees.csv");
            StreamReader reader = new StreamReader(path);

            TextFieldParser textFieldParser = new(reader);
            textFieldParser.HasFieldsEnclosedInQuotes = true;
            textFieldParser.TrimWhiteSpace = true;
            textFieldParser.Delimiters = new string[] { "," };

            // Assuming the first line is actually the header here
            string record = textFieldParser.ReadLine();
            record = record.ToLower();   // making header row case insensitive
            string[] header = record.Split(',');
            int headerColumns = header.Length;

            // add check for lines with more fields than headers
            Dictionary<string, string> myDictionary = new();
            string ColumnName;

            while (!textFieldParser.EndOfData)
            {
                string LastName = string.Empty;
                string FirstName = string.Empty;
                string Gender = string.Empty;
                string Department = string.Empty;
                double Salary = 0.00;

                string[] items = textFieldParser.ReadFields();

                for (int index = 0; index < header.Length; index++)
                {
                    string column = header[index];
                    switch (column)
                    {
                        case "name":
                            {
                                // Fix this - sub string to space = first, everything else = last?
                                string FullName;
                                FullName = items[index];
                                string[] Names = FullName.Split(" ");
                                LastName = Names[0];
                                FirstName = Names[1];
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
                                double dblSalary = Convert.ToDouble(strSalary);
                                Salary = dblSalary;
                                continue;
                            }
                    }
                }
                
                Employee newEmployee = new(LastName, FirstName);
                newEmployee.Salary = Salary;
                newEmployee.Gender = Gender;
                newEmployee.Department = Department;
            }
        }
    }
}
