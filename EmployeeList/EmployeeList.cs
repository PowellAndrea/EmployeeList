namespace EmployeeList
{
    public class EmployeeList : LinkedList<Employee>
    {
        private Employee _head;
        private Employee _tail;

        public enum Key { first, last, department };

        public EmployeeList()
        {
            _head = null;
            _tail = null;
        }

        public Employee Find(Employee findMe, string? searchKey)
        {
            Employee current = _head;
            string searchString;

            while (current != null)
            {
                // Add Tie breaker
                switch (searchKey)
                {
                    case "first":
                        if (current.FirstName == findMe.FirstName) { return current; }
                        break;

                    case "department":
                        if (current.Department == findMe.Department) { return current; }
                        break;

                    default:
                        if (current.LastName == findMe.LastName) 
                        { return current; }
                        break;
                }
                current = current.Next;
            }
            return null;
        }

        public bool Delete(Employee phoEmployee)
        {
            Employee found = Find(phoEmployee, "last");
            if (found == null) 
            { 
                return false;
            } 
            else
            {
                if (found == _head)
                {
                    if (_head.Next != null)
                    {
                        _head = _head.Next;
                        _head.Previous = null;
                    }
                    else
                    {
                        _head = null;
                    }
                }
                else if (found == _tail)
                {
                    _tail = found.Previous;
                    _tail.Next = null;
                }
                else
                {
                    Employee oldEmployee = found;
                    found.Next.Previous = oldEmployee.Previous;
                    found.Previous.Next = oldEmployee.Next;
                }
                return true;
            }
        }


        public void Add(Employee newEmployee, string? sort)  //Default sort = Last Name, First Name
        {
            if(sort == null) { sort = "last"; }
            if (_head == null)
            {
                // empty list, add head and exit
                _head = newEmployee;
                _tail = _head;
                return;
            }
            else
            {
                if (compare(_head, newEmployee, sort) >= 0)  // Insert Before Head
                {
                    Employee oldHead = _head;
                    newEmployee.Next = oldHead;
                    _head = newEmployee;
                    oldHead.Previous = _head;
                    return;
                }
            }

            
            Employee current = _head;
            while (current != null)
            {
                // current is greater than new
                // Insert Before Current
                if (compare(current, newEmployee, sort) >= 0)
                {
                    Employee oldCurrent = current;
                    newEmployee.Next = oldCurrent.Next;
                    newEmployee.Previous = oldCurrent.Previous;

                    oldCurrent.Next = newEmployee;
                    return;
                }
                else  // current is greater than new
                      // Compare to current.next
                {
                    if (current.Next == null)  // Insert as Tail
                    {
                        current.Next = newEmployee;
                        newEmployee.Previous = current;
                        _tail = newEmployee;
                        return;
                    }
                }

                // Case:  currentNode < newNode < current.next
                if (compare(current.Next, newEmployee, sort) > 0)
                {
                    // Insert After Current

                    Employee oldCurrent = current;
                    newEmployee.Next = oldCurrent.Next;
                    newEmployee.Previous = oldCurrent;

                    oldCurrent.Next = newEmployee;
                    (newEmployee.Next).Previous = newEmployee;
                    return;
                }

                // currentNode < newNode > current.next
                current = current.Next;
            }
            return;
        }

        private int compare(Employee current, Employee newEmployee, string? sort=null)
        {
            string currentChoice;
            string newChoice;
            switch (sort)
            {
                case "first":
                    currentChoice = current.FirstName;
                    newChoice = newEmployee.FirstName;
                    break;
                case "department":
                    currentChoice = current.Department + current.LastName;
                    newChoice = newEmployee.Department + newEmployee.LastName;
                    break;
                default:
                    currentChoice = current.LastName;
                    newChoice = newEmployee.LastName;
                    break;
            }
            //var x = currentChoice.CompareTo(newChoice);
            return (currentChoice.CompareTo(newChoice));
        }

        public EmployeeList Sort(string? sortKey)
        {
            if (sortKey == "last")
            {
                return this;
            }

            EmployeeList sortList = new();
            Employee current = _head;

            while (current != null)
            {
                sortList.Add(current, sortKey);
                current = current.Next;
            }
            return sortList;
        }

        public double GetAverageSalary()
        {
            int count = 0;
            decimal avgSalary = 0;
            if (_head != null)
            {
                Employee current = _head;
                while (current != null)
                {
                    count++;
                    avgSalary = avgSalary + current.Salary;
                    current = current.Next;
                }
            }
            return (double)(avgSalary / count);
        }

        public void Print(string? sortKey)
        {
            if (_head != null)
            {
                Employee current = _head;
                while (current != null)
                {
                    Console.WriteLine(current.Print(sortKey));
                    current = current.Next;
                }
            }
            else
                Console.WriteLine("Empty List!");
        }
    }
}