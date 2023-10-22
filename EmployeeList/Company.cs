namespace EmployeeList
{
    public class Company
    {
        public EmployeeList EmployeeList { 
            get => _employeeList; 
            set => _employeeList = value; }

        private EmployeeList _employeeList = new EmployeeList();


        //public Company()
        //{
        //    // = new EmployeeList();

        //    //var path = Path.Combine(Environment.CurrentDirectory, "employees.csv");
        //    //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees.csv");
            
        //    //StreamReader reader = new StreamReader(path);

        //    //while (!reader.EndOfStream)
        //    //{
        //        //values = nextLine();
        //        //var record = new List<thisEmployee>();
        //        //string tempName = 


        //        //string FirstName = values[FirstName];
        //        //Employee newEmployee = new(
        //        //    tempName : values[0],
                    
        //        //    values[Name]);

        //        //_lastName = lastName;
        //        //_firstName = firstName;
        //        //_gender = gender;
        //        //_department = department;
        //        //_salary = salary;
        //    //}
        }
    }
