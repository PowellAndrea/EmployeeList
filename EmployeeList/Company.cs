using System.Globalization;

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
            _employeeList = DataLoader.LoadData(path);
        }

        public string GetAverageSalary()
        {
            return _employeeList.GetAverageSalary().ToString("C");
        }

        public void PrintEmployeeList(string? sortKey)
        {
            _employeeList.Print(sortKey);
        }

        public void newEmployee(
            string firstName,
            string lastName,
            string department,
            string gender,
            string salary)
        {
            Employee newEmployee = new Employee(lastName, firstName);
            newEmployee.Department = department;
            newEmployee.Gender = gender;
            if(decimal.TryParse(salary, out decimal value))
            {
                newEmployee.Salary = value;
            };
        }

        public Employee FindEmployee(Employee phoEmployee, string searchKey) 
        {
            Employee found = _employeeList.Find(phoEmployee, searchKey);
            if (found != null)
            {
                Console.Write("found: " + found.Print("last"));
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            return found;
        }

        public bool DeleteEmployee(Employee phoEmployee)
        {
            return _employeeList.Delete(phoEmployee);
        }
    }
}
