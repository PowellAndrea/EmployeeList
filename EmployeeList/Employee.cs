namespace EmployeeList
{
    public class Employee
    {
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public string Department { get => _department; set => _department = value; }
        public decimal Salary { get => _salary; set => _salary = value; }

        public Employee Previous;
        public Employee Next;

        private String _lastName;
        private String _firstName;
        private String _gender;
        private String _department;
        private decimal _salary;

        public Employee()
        {
            _lastName = string.Empty; 
            _firstName = string.Empty;
            _gender = string.Empty;
            _department = string.Empty;
            _salary = 0;
        }
        
        public Employee(
            string lastName, 
            string firstName
            )
        {
            _lastName = lastName;
            _firstName = firstName;
            _gender = string.Empty;
            _department = string.Empty;
            _salary = 0;
        }
    
        public string Print(string sort)
        {
            if (sort == null) { sort = "last"; }
            switch (sort)
            {
                case "first":
                    return _firstName + " " + _lastName + ",\t " + _gender + ", " + "Department: " + _department + ", " + _salary.ToString("C");
                case "department":
                    return "Department: " + _department + ",\t " + _firstName + " " + _lastName + _salary.ToString("C") + ", Gender: " + _gender;
                default:
                    return _lastName + " " + _firstName + ",\t " + "Department: " + _department + ", " + _salary.ToString("C") + ", Gender: " +_gender;
            }
        }
    }
}