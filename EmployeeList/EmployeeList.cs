using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

// Add inherited generic link list type
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

        public Employee Find(Employee findMe, string? key)
        {
            Employee current = _head;
            while (current != null)
            {
                if (key == Key.first.ToString())
                {
                    if (current.FirstName == findMe.FirstName && current.LastName == findMe.LastName)
                    {
                        return current;
                    }
                }
                else if (key == Key.department.ToString())
                {
                    if (current.Department == findMe.Department)
                    {
                        return current;
                    }
                }
                else if (current.LastName == findMe.LastName && current.FirstName == findMe.FirstName)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void Delete(Employee phoEmployee)
        {
            Employee found;
            found = Find(phoEmployee, null);
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


        public void Add(Employee newEmployee, string? sort = null)  //Default sort = Last Name, First Name
        {
            if (_head == null)
            {
                // empty list, add head and exit
                _head = newEmployee;
                _tail = _head;
                return;
            }
            else
            {   
                if (compare(_head, newEmployee, sort) >= 0)
                {
                    InsertAfterHead(newEmployee);
                    return;
                }
            }

            Employee current = _head;

            while (current != null)
            {
                // Case:  current > newEmployee, insert before
                if (compare(current, newEmployee, sort) > 0)
                {
                    InsertBeforeCurrent(current, newEmployee);
                    return;
                }

                // Case:  current < newEmployee, insert after
                else
                {   // Case:  current is the end of list
                    if (current.Next == null)
                    {
                        AddAsTail(current, newEmployee);
                        return;
                    }

                    // Case:  currentNode < newNode < current.next
                    if (compare(current, newEmployee) > 0)
                    {
                        InsertAfterCurrent(current, newEmployee);
                        return;
                    }
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
                    currentChoice = current.FirstName + current.LastName;
                    newChoice = newEmployee.FirstName + newEmployee.LastName;
                    break;
                case "department":
                    currentChoice = current.Department + current.LastName;
                    newChoice = newEmployee.Department + newEmployee.LastName;
                    break;
                default:
                    currentChoice = current.LastName + current.FirstName;
                    newChoice = newEmployee.LastName + newEmployee.FirstName;
                    break;
            }
            return (currentChoice.CompareTo(newChoice));
        }

        private void InsertAfterHead(Employee newEmployee)
        {
            Employee oldHead = _head;
            _head = newEmployee;
            newEmployee.Next = oldHead;
            oldHead.Previous = _head;
        }

        private void AddAsTail(Employee current, Employee newEmployee)
        {
            _tail = newEmployee;
            current.Next = newEmployee;
            newEmployee.Previous = current;
            return;
        }

        private void InsertAfterCurrent(Employee current, Employee newEmployee)
        {
            Employee oldNext = current.Next;
            current.Next = newEmployee;

            newEmployee.Previous = current;
            newEmployee.Next = oldNext;

            oldNext.Previous = newEmployee;
            return;
        }

        private void InsertBeforeCurrent(Employee current, Employee newEmployee)
        {
            Employee oldCurrent = current;
            newEmployee.Next = oldCurrent;
            newEmployee.Previous = oldCurrent.Previous;

            oldCurrent.Previous = newEmployee;

            return;
        }

        public EmployeeList Sort(string? sortKey)
        {
            EmployeeList sortList = new();

            Employee current = _head;
            Employee newEmployee;

            while (current != null)
            {
                current = current.Next;
            }
            return sortList;
        }

        public double GetAverageSalary()
        {
            int count = 0;
            double avgSalary = 0;
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
            return avgSalary / count;
        }

        public void Print(string? sortKey)
        {
            switch (sortKey){
            case "2":  // First Name, Last Name
                    {
                        Print();
                        break;
                    }
                case "3":  // Department
                    {
                        Print();
                        break;
                    }
                default:  // Last Name, First Name
                    {
                        Print();
                        break;
                    }
            }
            return;
        }

        public void Print()
        {
            if (_head != null)
            {
                Employee current = _head;
                while (current != null)
                {
                    Console.WriteLine(
                        current.LastName + ", "
                        + current.FirstName + ", \t"
                        + ", Department: " + current.Department + "\t"
                        + ", Salary: " + current.Salary);

                    current = current.Next;
                }
            }
            else
                Console.WriteLine("Empty List!");
        }
    }
}