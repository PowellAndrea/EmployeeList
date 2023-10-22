namespace EmployeeList
{
    public class Employee
    {
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public string Department { get => _department; set => _department = value; }
        public double Salary { get => _salary; set => _salary = value; }

        public Employee Previous;
        public Employee Next;

        private String _lastName;
        private String _firstName;
        private String _gender;
        private String _department;
        private double _salary;

        public Employee(
            string lastName, 
            string firstName
            //string gender,
            //string department,
            //double salary,
            //string tempName
            )
        {
            _lastName = lastName;
            _firstName = firstName;
            //_gender = gender;
            //_department = department;
            //_salary = salary;
        }
    }
}