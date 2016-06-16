namespace Problem_10.Students_Enrolled_in_2014
{
    using Problem_1.Class_Student.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsEnrolledInYear
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Bunny", "Dimitrova", 22, 123114, "08888888", "bdimitrova0@abv.bg", new List<int>(), "2"),
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

            var result = studentList
                .Where(s => s.FacultyNumber % 100 == 14)
                .ToList();

            //or via extracting 5th and 6th digit from the faculty number
            //var result = studentList.Where(s => s.FacultyNumber % 100 / 10 == 1 && s.FacultyNumber % 10 == 4).ToList();

            result.ForEach(s => Console.WriteLine(
                s.FirstName + " " + 
                s.LastName + " " + 
                string.Join(" ", s.Marks))
                );
        }
    }
}
