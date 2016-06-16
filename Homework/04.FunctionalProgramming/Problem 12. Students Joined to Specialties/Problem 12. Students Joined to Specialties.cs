namespace Problem_12.Students_Joined_to_Specialties
{
    using Problem_1.Class_Student.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsJoinedToSpecialty
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Sara", "Dimitrova", 22, 100014, "08888888", "sdimitrova0@abv.bg", new List<int>(), "2"),
                new Student("Sarrah", "Pillsner", 12, 100015, "+3598888888", "spills@marketwatch.com", new List<int>(),
                    "2"),
                new Student("Sanny", "Kills", 32, 100016, "028888888", "skills@abv.com", new List<int>(), "1"),
                new Student("Sorry", "Feels", 42, 100017, "+35928888888", "sfeels@abv.bg", new List<int>(), "3")
            };
            
            List<StudentSpecialty> studentSpecialties = new List<StudentSpecialty>
            {
                new StudentSpecialty("C# Developer", 100014),
                new StudentSpecialty("WebDeveloper", 100014),
                new StudentSpecialty("PHP Developer", 100015),
                new StudentSpecialty("QA Engineer", 100016),
                new StudentSpecialty("WebDeveloper", 100017)
            };
            
            var joinedStudents = from specialty in studentSpecialties
                join student in studentList on specialty.FacultyNumber equals student.FacultyNumber
                select new
                {
                    Name = student.FirstName + " " + student.LastName,
                    FacNum = student.FacultyNumber,
                    Specialty = specialty.SpecialtyName
                };

            foreach(var student in joinedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
