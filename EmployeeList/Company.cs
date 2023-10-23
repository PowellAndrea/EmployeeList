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
            string[] header = record.Split(',');
            int headerColumns = header.Length;

            // add check for lines with more fields than headers
            Dictionary<string, string> myDictionary = new();
            string ColumnName;

            while (!textFieldParser.EndOfData)
            {
                string LastName;
                string FirstName;
                string Gender;
                string Department;
                double Salary;

                string[] items = textFieldParser.ReadFields();
                for (int index = 0; index < items.Length; index++)
                {
                    if (index < headerColumns)
                    {
                        ColumnName = header[index];
                    }
                    else
                    {
                        ColumnName = "Item" + index;
                    }

                    myDictionary.Add(ColumnName, items[index]);

                    // make keys not case sensative?
                    if (myDictionary.ContainsKey("Name"))
                    {
                        LastName = myDictionary["Name"].ToString();
                        // split into first and last
                    }
                    FirstName = "need to split";
                    if (myDictionary.ContainsKey("gender"))
                    {
                        Gender = myDictionary["Gender"];
                    }

                    Employee newEmployee = new(LastName, FirstName);

                    //        //_department = department;
                    //        //_salary = salary;
                }

            }
        }
    }
}
