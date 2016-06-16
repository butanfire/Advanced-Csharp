namespace Problem_5.Sort_Students
{
    using Problem_1.Class_Student.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Bunny", "Dimitrova", 22, 100014, "08888888", "bdimitrova0@abv.bg", new List<int>(), "4"),
                new Student("Anny", "Prillsner", 12, 100015, "+3598888888", "aprills@marketwatch.com", new List<int>(),
                    "4"),
                new Student("Ferry", "Abbadel", 42, 100017, "+35928888888", "fabbadel@abv.bg", new List<int>(), "3"),
                new Student("Abby", "Kills", 32, 100016, "028888888", "akills@abv.com", new List<int>(), "2"),
                new Student("Betty", "Feels", 42, 100017, "+35928888888", "bfeels@abv.bg", new List<int>(), "2")
            };

            Console.WriteLine("Lambda :");

            var orderedStudentsLambda = studentList.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName).ToList();
            orderedStudentsLambda.ForEach(Console.WriteLine);
            
            Console.WriteLine("\nLINQ Query : \n");

            var orderedStudentsQuery = from student in studentList
                        orderby student.FirstName descending
                        orderby student.LastName descending
                        select student;

            foreach (var item in orderedStudentsQuery)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
