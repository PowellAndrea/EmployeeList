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
            EmployeeList sortList;

            switch (sortKey)
            {
                case "2":
                    {
                        sortList = _employeeList.Sort("first");
                        sortList.Print("first");
                        break;
                    }
                case "3": 
                    {
                        sortList = _employeeList.Sort("department");
                        sortList.Print("department");
                        break; }
                default: 
                    { _employeeList.Print("last"); break; }
            }
        }

        public void newEmployee(
            string lastName,
            string firstName,
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
            _employeeList.Add(newEmployee,"last");
        }

        public Employee FindEmployee(Employee phoEmployee, string searchKey) 
        {
            // Breaking Encapsulation
            Employee found = _employeeList.Find(phoEmployee, searchKey);
            if (found != null)
            {
                Console.WriteLine("found: " + found.Print("last"));
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            return found;
        }

        public void EditEmployee(Employee phoEmployee)
        {
            // Breaking Encapsulation
            Employee findMe = _employeeList.Find(phoEmployee, "last");
            if (findMe != null)
            {
                Employee editEmployee = new();
                Console.WriteLine("EDIT EMPLOYEE");
                Console.WriteLine("Current Employee Information");
                Console.Write("First Name: " + findMe.FirstName + "\t Enter new first name: ");
                editEmployee.FirstName = Console.ReadLine();
                Console.Write("\nLast Name: " + findMe.LastName + "\t Enter new last name: ");
                editEmployee.LastName = Console.ReadLine();
                Console.Write("\nDepartment: " + findMe.Department + "\t Enter new department: ");
                editEmployee.Department = Console.ReadLine();
                Console.Write("\nGender: " + findMe.Gender + "\t Enter new gender:  ");
                editEmployee.Gender = Console.ReadLine();
                Console.Write("\nSalary: " + findMe.Salary.ToString("C") + "\t Enter new salary: ");
                string salary = Console.ReadLine();

                if (decimal.TryParse(salary, out decimal value))
                {
                    editEmployee.Salary = value;
                }

                _employeeList.Delete(findMe);
                _employeeList.Add(editEmployee, "last");

            }
        }

        public bool DeleteEmployee(Employee phoEmployee)
        {
            return _employeeList.Delete(phoEmployee);
        }
    }
}
