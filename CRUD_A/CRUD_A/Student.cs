using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_A
{
    internal class Student
    {
        private int id;
        private string name;
        private string department;

        public Student(int id, string name, string department)
        {
            this.id = id;
            this.name = name;
            this.department = department;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Department { get => department; set => department = value; }
    }
}
