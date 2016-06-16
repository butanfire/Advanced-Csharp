namespace Problem_2.Students_by_Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Problem_1.Class_Student.Models;

    public class StudentsbyGroup
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();

            studentList.Add(new Student("Bunny", "Dimitrova", 22, 100014, "08888888", "bdimitrova0@abv.bg", new List<int>(), "4"));
            studentList.Add(new Student("Anny", "Prillsner", 12, 100015, "+3598888888", "aprills@marketwatch.com", new List<int>(), "4"));
            studentList.Add(new Student("Ferry", "Abbadel", 42, 100017, "+35928888888", "fabbadel@abv.bg", new List<int>(), "3"));
            studentList.Add(new Student("Abby", "Kills", 32, 100016, "028888888", "akills@abv.com", new List<int>(), "2"));
            studentList.Add(new Student("Betty", "Feels", 42, 100017, "+35928888888", "bfeels@abv.bg", new List<int>(), "2"));

            var query = studentList.Where(student => student.GroupNumber == "2").OrderBy(student => student.FirstName);

            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
