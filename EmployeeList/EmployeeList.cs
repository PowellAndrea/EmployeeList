using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
    public class EmployeeList
    {
        private Employee _head = null;
        private Employee _tail = null;

        enum Key { first, last, department };


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
                else if(found == _head)
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

        public void Add()
        {

        }

        public void PrintList()
        {

        }
    }
}
