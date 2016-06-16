namespace Problem_3.Students_by_First_and_Last_Name
{
    using Problem_1.Class_Student.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByFandLname
    {
        public static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();

            studentList.Add(new Student("Bunny", "Dimitrova", 22, 100014, "08888888", "bdimitrova0@abv.bg", new List<int>(), "2"));
            studentList.Add(new Student("Anny", "Prillsner", 12, 100015, "+3598888888", "aprills@marketwatch.com", new List<int>(), "2"));
            studentList.Add(new Student("Stephanie", "Kills", 32, 100016, "028888888", "skills@abv.com", new List<int>(), "1"));
            studentList.Add(new Student("Lenny", "Feels", 42, 100017, "+35928888888", "lfeels@abv.bg", new List<int>(), "3"));
            studentList.Add(new Student("Ferry", "Abbadel", 42, 100017, "+35928888888", "fabbadel@abv.bg", new List<int>(), "3"));

            var outputList = studentList.Where(student => string.Compare(student.FirstName, student.LastName, StringComparison.Ordinal) == -1);

            foreach (var item in outputList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
