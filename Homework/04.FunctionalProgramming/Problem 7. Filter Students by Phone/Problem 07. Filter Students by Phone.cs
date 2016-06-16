namespace Problem_7.Filter_Students_by_Phone
{
    using Problem_1.Class_Student.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByPhone
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Bunny", "Dimitrova", 22, 100014, "08888888", "bdimitrova0@abv.bg", new List<int>(), "2"),
                new Student("Anny", "Prillsner", 12, 100015, "+359 8888888", "aprills@marketwatch.com", new List<int>(),
                    "2"),
                new Student("Stephanie", "Kills", 32, 100016, "028888888", "skills@abv.com", new List<int>(), "1"),
                new Student("Lenny", "Feels", 42, 100017, "+35928888888", "lfeels@abv.bg", new List<int>(), "3"),
                new Student("Ferry", "Abbadel", 42, 100017, "+359 28888888", "fabbadel@abv.bg", new List<int>(), "3")
            };

            var resultStudents = studentList
                .Where(s => s.Phone.StartsWith("02") || 
                s.Phone.StartsWith("+3592") || 
                s.Phone.StartsWith("+359 2")
                )
                .ToList();

            resultStudents.ForEach(Console.WriteLine);
        }
    }
}
