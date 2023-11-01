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

        public void Add(Employee newEmployee, string? sort)  //Default sort = Last Name, First Name
        {
            if (_head == null)
            {
                // empty list, add head and exit
                _head = newEmployee;
                _tail = _head;
                return;
            }
            else if (compare(_head, newEmployee, sort) >= 0)
            {   
                Employee oldHead = _head;
                _head = newEmployee;
                newEmployee.Previous = null;
                newEmployee.Next = oldHead;
                oldHead.Previous = _head;
                return;
            }

            Employee current = _head;

            while (current != null)
            {
                // Case:  current > newEmployee, insert before
                if (compare(current, newEmployee, sort) > 0)
                {
                    Employee oldCurrent = current;
                    newEmployee.Next = oldCurrent.Next;
                    newEmployee.Previous = oldCurrent;
                    oldCurrent.Next = newEmployee;

                    return;
                }                
                else if (current.Next == null)  // Insert as Tail
                {   // Case:  current is the end of list
                    current.Next = newEmployee;
                    newEmployee.Previous = current;
                    _tail = newEmployee;
                    return;
                }

                // Case:  currentNode < newNode < current.next
                if (compare(current, newEmployee) > 0)
                {
                    Employee oldCurrent = current;

                    newEmployee.Next = oldCurrent.Next;
                    newEmployee.Previous = oldCurrent;
                    oldCurrent.Next = newEmployee;
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

        public void Print(string sortKey)
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