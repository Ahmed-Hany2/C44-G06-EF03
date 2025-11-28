using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int? Dep_Id { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public ICollection<Stud_Course> Stud_Courses { get; set; } = new List<Stud_Course>();
    }

}
