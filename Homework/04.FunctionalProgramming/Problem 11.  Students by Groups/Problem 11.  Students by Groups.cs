namespace Problem_11.Students_by_Groups
{
    using Problem_1.Class_Student.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroups
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Sara", "Dimitrova", 22, 100014, "08888888", "sdimitrova0@abv.bg", new List<int>(), "2",
                    "Ghouls"),
                new Student("Sarrah", "Pillsner", 12, 100015, "+3598888888", "spills@marketwatch.com", new List<int>(),
                    "2", "Ghouls"),
                new Student("Sanny", "Kills", 32, 100016, "028888888", "skills@abv.com", new List<int>(), "1", "Wizards"),
                new Student("Sorry", "Feels", 42, 100017, "+35928888888", "sfeels@abv.bg", new List<int>(), "3",
                    "Wizards")
            };

            var groupedStudents = from student in studentList
            group student by student.GroupName into newGroup
            orderby newGroup.Key
            select newGroup;

            foreach (var group in groupedStudents)
            {
                Console.WriteLine(group.Key + ": ");
                foreach(var student in group)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }
    }
}
