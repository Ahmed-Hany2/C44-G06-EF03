using Assignment.Models;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ITIContext();
            var courses = context.Courses.FirstOrDefault(x => x.ID == 3);
            if (courses != null)
            {
                
                Console.WriteLine("Name: " + courses.Name +
                    "\nDescription: " + courses.Description +
                    "\nDuration: " + courses.Duration);

                var department = context.Departments.FirstOrDefault(d => d.ID == courses.ID);
                Console.WriteLine("Department: " + department.Name);
                context.SaveChanges();

                // ________________________________________________________________________

                if (courses.Topic != null)
                {
                    context.Entry(courses).Reference(c => c.Topic).Load();
                    var department1 = context.Departments.FirstOrDefault(d => d.ID == courses.ID);
                    context.Entry(department1).Reference(d => d).Load();
                    Console.WriteLine("Topic: " + courses.Topic.Name );

                }
                else
                {
                    Console.WriteLine("No Topic assigned to this course.");
                }
                // Lazy Loading
                var student = context.Students.FirstOrDefault(s => s.ID == 1);

                if (student != null)
                {
                    Console.WriteLine($"Student: {student.FName} {student.LName}");
                    Console.WriteLine($"Department {student.Department?.Name}");
                }

                var course = context.Courses.FirstOrDefault(c => c.ID == 1);

                if (course != null)
                {
                    Console.WriteLine($"Course: {course.Name}");

               
                    Console.WriteLine($"Topic : {course.Topic?.Name}");
                }
                var department3 = context.Departments.FirstOrDefault(d => d.ID == 1);

                if (department != null)
                {
                    Console.WriteLine($"Department: {department.Name}");

                    Console.WriteLine($"Number of Students : {department3.Students.Count}");

                    foreach (var s in department3.Students)
                    {
                        Console.WriteLine($"  - {s.FName} {s.LName}");
                    }
                }
            }
        }
    }
}
