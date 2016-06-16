using Problem_1.Class_Student.Models;

namespace Problem_4.Students_by_Age
{
    using Problem_1.Class_Student;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsbyAge
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();

            studentList.Add(new Student("Bunny", "Dimitrova", 22, 100014, "08888888", "bdimitrova0@abv.bg", new List<int>(), "4"));
            studentList.Add(new Student("Anny", "Prillsner", 17, 100015, "+3598888888", "aprills@marketwatch.com", new List<int>(), "4"));
            studentList.Add(new Student("Ferry", "Abbadel", 24, 100017, "+35928888888", "fabbadel@abv.bg", new List<int>(), "3"));
            studentList.Add(new Student("Abby", "Kills", 60, 100016, "028888888", "akills@abv.com", new List<int>(), "2"));
            studentList.Add(new Student("Betty", "Feels", 13, 100017, "+35928888888", "bfeels@abv.bg", new List<int>(), "2"));

            var studentsFilteredByAge = studentList.Where(student => student.Age >= 18 && student.Age <= 24);

            var resultList = studentsFilteredByAge.Select(s => new
            {
                FName = s.FirstName,
                Lname = s.LastName,
                Age = s.Age
            }).ToList();

            foreach (var item in resultList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
