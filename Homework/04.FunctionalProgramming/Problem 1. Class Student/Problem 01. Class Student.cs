using System.Collections.Generic;
using Problem_1.Class_Student.Models;

namespace Problem_1.Class_Student
{
    public class ClassStudent
    {
       public static void Main()
        {
            List<Student> studentList = new List<Student>();

            studentList.Add(new Student("Sara", "Dimitrova", 22, 100014, "08888888", "sdimitrova0@abv.bg", new List<int>(), "2"));
            studentList.Add(new Student("Sarrah", "Pillsner", 12, 100015, "+3598888888", "spills@marketwatch.com", new List<int>(), "2"));
            studentList.Add(new Student("Sanny", "Kills", 32, 100016, "028888888", "skills@abv.com", new List<int>(), "1"));
            studentList.Add(new Student("Sorry", "Feels", 42, 100017, "+35928888888", "sfeels@abv.bg", new List<int>(), "3"));

            studentList[0].Marks.Add(2);
            studentList[0].Marks.Add(2);

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
        }
    }
}

