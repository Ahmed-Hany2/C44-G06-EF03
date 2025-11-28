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
            }
        }
    }
}
