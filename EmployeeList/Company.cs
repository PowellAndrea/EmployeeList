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
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees.csv");
            EmployeeList = DataLoader.LoadData(path);
        }

        public void PrintEmployeeList()
        {
            EmployeeList.Print();
        }
    }
}
