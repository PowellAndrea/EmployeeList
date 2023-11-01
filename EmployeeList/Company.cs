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

        public void PrintEmployeeList(string key)
        {
            // validation
            //if(Enum.IsDefined(EmployeeList.Key., object sortKey){ }
            // Fix: Setup Search Strings and pass
            // Fix this - easy to break
            //EmployeeList.Key key = sortKey;
            // Print.SortList
            _employeeList.Print(key);
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

        public Employee FindEmployee(Employee phoEmployee, string key) 
        {
            EmployeeList sortedList;
            switch (key)
            {
                case "first":
                    {
                        sortedList = _employeeList.Sort("first");
                        break;
                    }
                case "department":
                    {
                        sortedList = _employeeList.Sort("department");
                        break;
                    }
                default:
                    sortedList = _employeeList;
                    break;
            }

            return sortedList.Find(phoEmployee, key);
        }
    }
}
