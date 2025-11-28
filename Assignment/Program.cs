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

            // join
            var students = from student in context.Students
                                   join dept in context.Departments
                                   on student.Dep_Id equals dept.ID
                                   select new
                                   {
                                       StudentName = student.FName + " " + student.LName,
                                       DepartmentName = dept.Name,
                                       Age = student.Age
                                   };

            foreach (var item in students)
            {
                Console.WriteLine($"Student: {item.StudentName}, Department: {item.DepartmentName}, Age: {item.Age}");
            }

            var coursesWithTopics = context.Courses
                   .Join(context.Topics,
                         course => course.Top_ID,
                         topic => topic.ID,
                         (course, topic) => new
                         {
                             CourseName = course.Name,
                             TopicName = topic.Name,
                             Duration = course.Duration
                         });

            foreach (var item in coursesWithTopics)
            {
                Console.WriteLine($"Course: {item.CourseName}, Topic: {item.TopicName}, Duration: {item.Duration} hours");
            }

            var studentsPerDept = from student in context.Students
                                  join dept in context.Departments on student.Dep_Id equals dept.ID
                                  group student by dept.Name into deptGroup
                                  select new
                                  {
                                      DepartmentName = deptGroup.Key,
                                      StudentCount = deptGroup.Count()
                                  };

            foreach (var item in studentsPerDept)
            {
                Console.WriteLine($"Department: {item.DepartmentName}, Number of Students: {item.StudentCount}");
            }
        }
    }
}
