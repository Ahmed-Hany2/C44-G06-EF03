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
            }
        }
    }
}
