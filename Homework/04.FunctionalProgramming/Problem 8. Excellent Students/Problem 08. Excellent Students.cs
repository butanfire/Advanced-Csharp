namespace Problem_8.Excellent_Students
{
    using Problem_1.Class_Student.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExcellentStudents
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Bunny", "Dimitrova", 22, 100014, "08888888", "bdimitrova0@abv.bg", new List<int>(), "2"),
                new Student("Anny", "Prillsner", 12, 100015, "+3598888888", "aprills@marketwatch.com", new List<int>(),
                    "2"),
                new Student("Stephanie", "Kills", 32, 100016, "028888888", "skills@abv.com", new List<int>(), "1"),
                new Student("Lenny", "Feels", 42, 100017, "+35928888888", "lfeels@abv.bg", new List<int>(), "3"),
                new Student("Ferry", "Abbadel", 42, 100017, "+35928888888", "fabbadel@abv.bg", new List<int>(), "3")
            };

            studentList[0].Marks.Add(2);
            studentList[0].Marks.Add(2);

            studentList[1].Marks.Add(6);
            studentList[1].Marks.Add(2);
            studentList[1].Marks.Add(2);
            studentList[1].Marks.Add(2);

            studentList[2].Marks.Add(6);
            studentList[2].Marks.Add(6);
            studentList[2].Marks.Add(6);

            studentList[3].Marks.Add(3);
            studentList[3].Marks.Add(4);
            studentList[3].Marks.Add(5);
            studentList[3].Marks.Add(6);

            var excellentStudents = studentList
                .Where(s => s.Marks.Contains(6))
                .Select(s => new
                {
                    Name = s.FirstName + " " + s.LastName, s.Marks
                })
            .ToArray();

            StringBuilder output = new StringBuilder();
            foreach (var student in excellentStudents)
            {
                output.AppendLine("Name: " + student.Name);
                output.AppendLine("Marks: " + string.Join(" ", student.Marks));
            }

            Console.WriteLine(output.ToString());
        }
    }
}
