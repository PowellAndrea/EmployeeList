using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// Add inherited link list type
namespace EmployeeList
{
    public class EmployeeList
    {
        private Employee _head;
        private Employee _tail;

        enum Key { first, last, department };

        public EmployeeList()
        {
            _head = null;
            _tail = null;
        }

        public Employee Find(string firstname, string lastname, string key, string? department)
        {
            Employee current = _head;
            while (current != null)
            {
                if (key == "first")
                {
                    if (current.FirstName == firstname && current.LastName == lastname)
                    {
                        return current;
                    }
                }
                else if (key == "department")
                {
                    if (current.Department == department)
                    {
                        return current;
                    }
                }
                else if (current.LastName == lastname && current.FirstName == firstname)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void Delete(string firstname, string lastname)
        {
            Employee found;
            while (true)
            {
                found = Find(firstname, lastname, nameof(Key.last), null);
                if (found == null)
                {
                    return;
                }
                else if (found == _head)
                {
                    if (_head.Next == null)
                    {
                        _head = null;
                        _tail = null;
                    }
                    else
                    {
                        _head = _head.Next;
                        _head.Previous = null;
                    }
                }
                else
                {
                    found.Previous.Next = found.Next;
                }
            }
        }

        public void Add(Employee newEmployee)
        {
            #region Head case
            if (_head == null)
            {
                // empty list, add head and exit
                _head = newEmployee;
                _tail = _head;
                return;
            }
            else
            {   // Compare on Last - this will need fixed
                if (_head.LastName.CompareTo(newEmployee.LastName) >= 0)
                {
                    Employee oldHead = _head;
                    _head = newEmployee;
                    oldHead.Previous = _head;
                    return;
                }
            }
            #endregion

            Employee current = _head;

            #region Base Case
            while (current != null)
            {
                // Case:  currentNode is greater than newNode, insert before
                if (current.LastName.CompareTo(newEmployee.LastName) > 0)
                {
                    Employee oldCurrent = current;
                    newEmployee.Next = oldCurrent.Next;
                    newEmployee.Previous = oldCurrent.Previous;

                    oldCurrent.Next = newEmployee;
                    return;
                }
                // Case:  currentLastName is less than newLastName
                else
                {   // Case:  current is the end of list
                    if (current.Next == null)
                    {   // Append and return
                        current.Next = newEmployee;
                        newEmployee.Previous = current;
                        _tail = newEmployee;
                        return;
                    }
                }

                // Case:  currentNode < newNode < current.next
                if (current.Next.LastName.CompareTo(newEmployee.LastName) > 0)
                {

                    Employee oldCurrent = current;
                    oldCurrent.Next = newEmployee;

                    newEmployee.Previous = oldCurrent;
                    newEmployee.Next = oldCurrent.Next;

                    oldCurrent.Previous = newEmployee;

                    return;
                }
                    }
                //       currentNode < newNode > current.next
                    current = current.Next;
                }
            }
            #endregion Base Case
            return;
        }

        public void Print()
        {
            if (_head != null)
            {
                Employee current = _head;
                while (current != null)
                {
                    Console.WriteLine(current.LastName + ", "
                        + current.FirstName + ", "
                        + current.Department + " department"
                        + ", Salary: " + current.Salary);

                    current = current.Next;
                }
            }
            else
                Console.WriteLine("Empty List!");
        }
    }
}
